using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace AutoCADDataExtractor
{
    class htmlRequest
    {
        public static string acJson(string url)
        {
            string json = string.Empty;
            using (WebClient webclient = new WebClient())
            {            
                try
                {
                    json = webclient.DownloadString(url);
                }
                catch
                {

                }
            }
            return json;
        }

        public static string ExportUrlConstructor(string serviceUrl, Tuple<double, double> latlong, double bboxSize, string layerName, Tuple<int, int> imageSize)
        {
            serviceUrl = "https://maps.aucklandcouncil.govt.nz/ArcGIS/rest/services/Aerials/MapServer";
            double minX = latlong.Item1 - (bboxSize / 2);
            double minY = latlong.Item2 - (bboxSize / 2);
            double maxX = latlong.Item1 + (bboxSize / 2);
            double maxY = latlong.Item2 + (bboxSize / 2);
            string url = string.Format(
                "{0}/export?bbox={1},{2},{3},{4}&layers={5}&size{6},{7}&imageSR=2193&format=jpg&transparent=false&dpi=600&f=pjson",
                serviceUrl, minX, minY, maxX, maxY, layerName, imageSize.Item1, imageSize.Item2
                );
            return url;
        }

        public static string QuerryUrlConstructor(string serviceUrl, Tuple<double, double> latlong, double bboxSize)
        {
            serviceUrl = "https://maps.aucklandcouncil.govt.nz/ArcGIS/rest/services/DataExport/MapServer/5";
            double minX = latlong.Item1 - (bboxSize / 2);
            double minY = latlong.Item2 - (bboxSize / 2);
            double maxX = latlong.Item1 + (bboxSize / 2);
            double maxY = latlong.Item2 + (bboxSize / 2);
            string url = string.Format(
                "{0}/query?text=&geometry={1}%2C{2}%2C{3}%2C{4}&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelContains&where=&returnGeometry=true&outSR=&outFields=ELEVATION&f=json",
                serviceUrl, minX, minY, maxX, maxY
                );
            System.Windows.MessageBox.Show(url);
            return url;
        }

        public static string GetImage(string url)
        {
            string savePath = Path.GetTempPath();
            string fileName = Path.GetTempFileName();
            fileName = fileName.Replace(".tmp", ".jpg"); //Temporary file names have a ".tmp" extension. Change to a jpg(doesn't matter if it's gif or etc as long as AutoCAD can insert it
            using (WebClient webclient = new WebClient())
            {
                webclient.DownloadFile(url, fileName);
            }
            return fileName;
        }
    }
}
