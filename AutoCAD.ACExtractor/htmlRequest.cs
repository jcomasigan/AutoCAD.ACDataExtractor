using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutoCADDataExtractor
{
    class htmlRequest
    {
        public static ACData acJson(string url)
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
            return JsonConvert.DeserializeObject<ACData>(json);
        }

        public static string UrlConstructor(string serviceUrl, Tuple<double, double> latlong, double bboxSize, string layerName, Tuple<int, int> imageSize)
        {
            serviceUrl = "https://maps.aucklandcouncil.govt.nz/ArcGIS/rest/services/Aerials/MapServer";
            double minX = latlong.Item1 - bboxSize;
            double minY = latlong.Item2 - bboxSize;
            double maxX = latlong.Item1 + bboxSize;
            double maxY = latlong.Item2 + bboxSize;
            string url = string.Format(
                "{0}/export?bbox={1},{2},{3},{4}&layers={5}&size{6},{7}&imageSR=2193&format=jpg&transparent=false&dpi=600&f=pjson",
                serviceUrl, minX, minY, maxX, maxY, layerName, imageSize.Item1, imageSize.Item2
                );
            return url;
        }
    }
}
