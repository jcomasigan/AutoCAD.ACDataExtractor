using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

// This line is not mandatory, but improves loading performances
[assembly: CommandClass(typeof(AutoCADDataExtractor.MyCommands))]

namespace AutoCADDataExtractor
{
    public class MyCommands
    {
        [CommandMethod("ACDATA",CommandFlags.Modal)]
        public void MyCommand() // This method can have any name
        {

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed;
            if (doc != null)
            {
                ed = doc.Editor;
                ed.WriteMessage("Hello, this is your first command.");
                AcDataForm acData = new AcDataForm();
                acData.ShowDialog();
            }
        }
    }

}
