using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoCADDataExtractor
{
    class Geocoding
    {
        public static Tuple<double,double> GeocodeAddress(string address)
        {
            Tuple<double, double> latlong = new Tuple<double, double>(0,0);
            WebRequest request;
            WebResponse response;
            XDocument xdoc;
            string requestParameter = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));
            try
            {
                request = WebRequest.Create(requestParameter);
                response = request.GetResponse();
                xdoc = XDocument.Load(response.GetResponseStream());
                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement coordinates = result.Element("geometry").Element("location");
                XElement lat = coordinates.Element("lat");
                XElement lng = coordinates.Element("lng");
                latlong = new Tuple<double, double>(Convert.ToDouble(lat.Value), Convert.ToDouble(lng.Value)) ;
            }
            catch (Exception e)
            {
                
            }

            return latlong;
        }
    }
}
