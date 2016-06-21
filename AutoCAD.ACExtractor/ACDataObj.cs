using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCADDataExtractor
{
    #region Aerial Service Json
    public class ACData_Aerial
    {
        public string href { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public ACData_Aerial_Extent extent { get; set; }
        public string scale { get; set; }
    }
    public class ACData_Aerial_Extent
    {
        public string xmin { get; set; }
        public string ymin { get; set; }
        public string xmax { get; set; }
        public string ymax { get; set; }
        public Dictionary<string, string> spatialReference { get; set; }
    }
    #endregion

    public class FieldAliases
    {
        public string Source { get; set; }
        public string Shape_Length { get; set; }
    }

    public class SpatialReference
    {
        public int wkid { get; set; }
    }

    public class Attributes
    {
        public string Source { get; set; }
        public double Shape_Length { get; set; }
    }

    public class Geometry
    {
        public List<List<List<double>>> paths { get; set; }
    }

    public class Feature
    {
        public Attributes attributes { get; set; }
        public Geometry geometry { get; set; }
    }

    public class ACData_Contour
    {
        public string displayFieldName { get; set; }
        public FieldAliases fieldAliases { get; set; }
        public string geometryType { get; set; }
        public SpatialReference spatialReference { get; set; }
        public List<Feature> features { get; set; }
    }
}
