using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCADDataExtractor
{
    public class ACData
    {
        public string href { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public ACExtent extent { get; set; }
        public string scale { get; set; }
    }
    public class ACExtent
    {
        public string xmin { get; set; }
        public string ymin { get; set; }
        public string xmax { get; set; }
        public string ymax { get; set; }
        public Dictionary<string, string> spatialReference { get; set; }
    }
}
