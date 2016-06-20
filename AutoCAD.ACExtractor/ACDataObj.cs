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

    public class ACData_Contour
    {
        public string displayFieldName { get; set; }
        public ACData_Contour_FieldAliases fieldAliases { get; set; }
        public string geometryType { get; set; }
        public Dictionary<string, string> spatialReference { get; set; }
        public ACData_Contour_Features[] features { get; set; }

    }

    public class ACData_Contour_FieldAliases
    {
        public string Source { get; set; }
        public string ELAVATION { get; set; }
        public string Shape_Length { get; set; }
    }

    public class ACData_Contour_Features
    {
        public ACData_Contour_Attributes attributes { get; set; }
        public List<ACData_Contour_Geometry> geometry { get; set; }


    }

    public class ACData_Contour_Attributes
    {
        public string Source { get; set; }
        public string ELAVATION { get; set; }
        public string Shape_Length { get; set; }
    }

    public class ACData_Contour_Geometry
    {
        public ACData_Contour_Path[] paths { get; set; }
    }

    public class ACData_Contour_Path
    {
        public string[] path { get; set; }
    }
}
