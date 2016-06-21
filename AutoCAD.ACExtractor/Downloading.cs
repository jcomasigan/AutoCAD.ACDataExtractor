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
            for(int i = 0; i < GlobalVariables.acContour.features.Count; i++ )
            {
                List<Tuple<double, double, double>> contourPts = new List<Tuple<double, double, double>>();
                Tuple<double, double, double> ContourPtLatLng;

                //for(int j = 0; i < GlobalVariables.acContour.features[i].geometry.paths[0].Count; j++)
                for (int j = 0; j < GlobalVariables.acContour.features[i].geometry.paths[0].Count; j++)
                {
                    double lat;
                    double lng;
                    double elav = GlobalVariables.acContour.features[i].attributes.ELEVATION;
                    lat = GlobalVariables.acContour.features[i].geometry.paths[0][j][0];
                    lng = GlobalVariables.acContour.features[i].geometry.paths[0][j][1];
                    ContourPtLatLng = new Tuple<double, double, double>(lat, lng, elav);
                    contourPts.Add(ContourPtLatLng);
                }
                DrawEntity.DrawPlineFrom3PtList("ACEXTRACTOR.CONTOURS", 10, contourPts);
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
