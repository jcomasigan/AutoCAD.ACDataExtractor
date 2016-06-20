using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCADDataExtractor
{
    public partial class AcDataForm : Form
    {
        Tuple<double, double> latlongNztm;
        Tuple<int, int> imageSize = new Tuple<int, int>(1200, 1200);
        public AcDataForm()
        {
            InitializeComponent();
        }

        private void addressTxtBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Tuple<double,double> latlong = Geocoding.GeocodeAddress(addressTxtBox.Text);
                double northingNztm = new double();
                double eastingNztm = new double();
                NZGD2000_NZTM.geod_nztm(AngleConvertion.Deg2Rad(latlong.Item1), AngleConvertion.Deg2Rad(latlong.Item2), ref northingNztm, ref eastingNztm);
                coordEastingTxtBox.Text = northingNztm.ToString();
                coordNorthingTxtBox.Text = eastingNztm.ToString();
                latlongNztm = new Tuple<double, double>(eastingNztm, northingNztm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Can't get coordinates of the address.");
            }
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {          
            imageSize = new Tuple<int, int>(Convert.ToInt32(imageXinput.Value), Convert.ToInt32(imageYinput.Value));
            string url = htmlRequest.ExportUrlConstructor("", latlongNztm, Convert.ToInt32(bboxNumInput.Value), "3", imageSize);
            string url1 = htmlRequest.QuerryUrlConstructor("", latlongNztm, Convert.ToInt32(bboxNumInput.Value));
            Downloading dw = new Downloading(url1);
            dw.ShowDialog();
        }
    }
}
