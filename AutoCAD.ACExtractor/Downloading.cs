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
            ACData ac = new ACData();
            ac = htmlRequest.acJson(url);
            MessageBox.Show(ac.href);
            System.Diagnostics.Process.Start(ac.href);
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
