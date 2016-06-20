using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace AutoCADDataExtractor
{
    public partial class Downloading : Form
    {
        public Downloading(string url)
        {
            InitializeComponent();
            GetData(url);
        }

        private void GetData(string url)
        {
            GetContourData(url);
        }

        private void GetImgData(string url)
        {
            GlobalVariables.acAerial = JsonConvert.DeserializeObject<ACData_Aerial>(htmlRequest.acJson(url));
            string imgPath = htmlRequest.GetImage(GlobalVariables.acAerial.href);
            double width = Convert.ToDouble(GlobalVariables.acAerial.extent.xmax) - Convert.ToDouble(GlobalVariables.acAerial.extent.xmin);
            double height = Convert.ToDouble(GlobalVariables.acAerial.extent.ymax) - Convert.ToDouble(GlobalVariables.acAerial.extent.ymin);
            DrawEntity.DrawImg(new Autodesk.AutoCAD.Geometry.Point3d(Convert.ToDouble(GlobalVariables.acAerial.extent.xmin), Convert.ToDouble(GlobalVariables.acAerial.extent.ymin), 0), imgPath, "Img", height, width);
        }

        private void GetContourData(string url)
        {
            GlobalVariables.acContour = JsonConvert.DeserializeObject<ACData_Contour>(htmlRequest.acJson(url));
            foreach(ACData_Contour_Features feature in GlobalVariables.acContour.features)
            {
                foreach(ACData_Contour_Geometry geometry in feature.geometry)
                {
                    
                    DrawEntity.DrawPlineFrom3PtList("CONTOUR", 20, geometry.paths[0].path.ToList<string>() );
                }
            }
        }

        /*
                private void GetData(string url)
        {
            ACData ac = new ACData();
            ac = htmlRequest.acJson(
                        "https://maps.aucklandcouncil.govt.nz/ArcGIS/rest/services/Aerials/MapServer/export?bbox=1755677.060%2C5931079.026%2C1755732.218%2C5930979.248%09&bboxSR=&layers=3&layerdefs=&size=1200%2C1200&imageSR=2193&format=jpg&transparent=false&dpi=600&f=pjson");
            MessageBox.Show(ac.href);
        }
        */


    }
}
