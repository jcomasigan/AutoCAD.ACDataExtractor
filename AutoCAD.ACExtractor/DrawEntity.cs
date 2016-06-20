using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Colors;

namespace AutoCADDataExtractor
{
    class DrawEntity
    {
        /// <summary>
        /// Z E Command
        /// </summary>
        public static void ZoomExtents()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("._z e ", true, false, false);
        }
        /// <summary>
        /// Create a new layer. Checks if the layer exist first.
        /// </summary>
        /// <param name="layerName">Name of the new layer</param>
        /// <param name="colour">Colour of the new layer</param>
        private static void CreateLayer(string layerName, short colour)
        {

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                LayerTable layerTable = (LayerTable)tr.GetObject(currentDB.LayerTableId, OpenMode.ForWrite);
                if (!layerTable.Has(layerName))
                {
                    LayerTableRecord layer = new LayerTableRecord();
                    layer.Name = layerName;
                    layer.Color = Color.FromColorIndex(ColorMethod.ByLayer, colour);
                    ObjectId layerID = layerTable.Add(layer);
                    tr.AddNewlyCreatedDBObject(layer, true);
                    tr.Commit();
                }
            }
        }

        public static ObjectIdCollection SelectByLayer(string layerName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            ObjectIdCollection selectedObjects = new ObjectIdCollection() ;
            TypedValue[] typedVals = new TypedValue[]
            {
              new TypedValue((int)DxfCode.LayerName,layerName)
            };
            SelectionFilter selectFilter = new SelectionFilter(typedVals);
            PromptSelectionResult selection = ed.SelectAll(selectFilter);
            if(selection.Status == PromptStatus.OK)
            {
                selectedObjects =  new ObjectIdCollection(selection.Value.GetObjectIds());
            }

            return selectedObjects;
        }
        /// <summary>
        /// Draw 4 point polygon
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="pt3"></param>
        /// <param name="pt4"></param>
        /// <param name="layerName"> Sets the layer of the polygon. Will create a new layer if layerName is not in the dwg</param>
        /// <param name="colour">Layer Colour</param>
        /// <param name="isClosed">Whether the polyline is closed or not</param>
        /// <returns></returns>
        public static Entity DrawBox(Point3d topCorner, Point3d bottomCorner, string layerName, short colour = 255, bool isClosed = true)
        {
            Point2d pt1 = new Point2d(topCorner.X, topCorner.Y);
            Point2d pt2 = new Point2d(bottomCorner.X, topCorner.Y);
            Point2d pt3 = new Point2d(bottomCorner.X, bottomCorner.Y);
            Point2d pt4 = new Point2d(topCorner.X, bottomCorner.Y);
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, colour);
            Entity entCreated;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                Polyline polyLine = new Polyline();
                polyLine.AddVertexAt(0, pt1, 0, 0, 0);
                polyLine.AddVertexAt(1, pt2, 0, 0, 0);
                polyLine.AddVertexAt(2, pt3, 0, 0, 0);
                polyLine.AddVertexAt(3, pt4, 0, 0, 0);
                
                polyLine.Closed = isClosed;
                polyLine.Layer = layerName;
                blockTableRec.AppendEntity(polyLine);
                tr.AddNewlyCreatedDBObject(polyLine, true);
                tr.Commit();
                entCreated = polyLine;
            }
            return entCreated;
        }
        /// <summary>
        /// Draw aligned dimension
        /// </summary>
        /// <param name="start">Start of dim</param>
        /// <param name="end">End of dim</param>
        /// <param name="text">Text overide of dim</param>
        /// <param name="layerName"></param>
        /// <param name="mtextheight"></param>
        /// <param name="colour"></param>
        /// <param name="isClosed"></param>
        /// <returns></returns>
        public static Entity DrawDim(Point3d start, Point3d end, string text, string layerName, double mtextheight, double yLocationMultiplier, short colour = 255)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, colour);
            Entity entCreated;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                AlignedDimension alignedDim = new AlignedDimension();
                alignedDim.XLine1Point = start;
                alignedDim.XLine2Point = end;
                alignedDim.DimensionText = text;
                alignedDim.Dimscale = mtextheight;
                alignedDim.DimLinePoint = new Point3d(((end.X - start.X) / 2), start.Y * yLocationMultiplier, 0);
                alignedDim.HorizontalRotation = 0;
                alignedDim.Layer = layerName;
                blockTableRec.AppendEntity(alignedDim);
                tr.AddNewlyCreatedDBObject(alignedDim, true);
                tr.Commit();
                entCreated = alignedDim;
            }
            return entCreated;
        }

    
    /// <summary>
    /// Draws 3 point list. ie list from XML data of contours. X,Y & elevation
    /// </summary>
    /// <param name="layerName">Layer Name of the polyline</param>
    /// <param name="colour">Colour code of polyline</param>
    /// <param name="polyList">List of points</param>
    /// <param name="elav">elevation point, seperated from the list</param>
    /// <param name="closePoly">Bool to close polyline.</param>
    public static void DrawPlineFrom3PtList(string layerName, short colour, List<string> polyList, double elav = 0, bool closePoly = true)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database currentDB = doc.Database;
        CreateLayer(layerName, colour);
        using (Transaction tr = currentDB.TransactionManager.StartTransaction())
        {
            BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            Polyline polyLine = new Polyline();
            int j = 0; //counter for using pairs of coordinates in a single list.
            for (int i = 0; i < ((polyList.Count / 3) - 1); i++)
            {
                polyLine.AddVertexAt(i, new Point2d(Convert.ToDouble(polyList[j + 1]), Convert.ToDouble(polyList[j])), 0, 0, 0); //stupid chch contours is the other way around!
                j += 3;
            }
            polyLine.Elevation = elav;
            polyLine.Closed = closePoly;   //Closes the polyline 
            polyLine.Layer = layerName;
            blockTableRec.AppendEntity(polyLine);
            tr.AddNewlyCreatedDBObject(polyLine, true);
            tr.Commit();
        }
    }

    public static void DrawImg(Point3d location, string fileName, string layerName, double height, double width, short colour = 255, bool isClosed = true)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, colour);
            string imageName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                RasterImageDef rasterImgDef;
                ObjectId imgDefId;
                ObjectId imageDictId = RasterImageDef.GetImageDictionary(currentDB);
                if(imageDictId.IsNull)
                {
                    imageDictId = RasterImageDef.CreateImageDictionary(currentDB);
                }
                DBDictionary imageDictionary = tr.GetObject(imageDictId, OpenMode.ForRead) as DBDictionary;
                if(imageDictionary.Contains(imageName))
                {
                    imgDefId = imageDictionary.GetAt(imageName);
                    rasterImgDef = tr.GetObject(imageDictId, OpenMode.ForWrite) as RasterImageDef;
                }
                else
                {
                    RasterImageDef newRasterDef = new RasterImageDef();
                    newRasterDef.SourceFileName = fileName;
                    newRasterDef.Load();
                    imageDictionary.UpgradeOpen();
                    imageDictId = imageDictionary.SetAt(imageName, newRasterDef);
                    tr.AddNewlyCreatedDBObject(newRasterDef, true);
                    rasterImgDef = newRasterDef;
                }
                BlockTable blockTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRecord = tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                using (RasterImage rasterImg = new RasterImage())
                {
                    rasterImg.ImageDefId = imageDictId;
                    Vector3d widthV = new Vector3d(width, 0, 0); 
                    Vector3d heightV = new Vector3d(0, height, 0);
                    CoordinateSystem3d coordinate = new CoordinateSystem3d(location, widthV, heightV);
                    rasterImg.Orientation = coordinate;
                    rasterImg.Rotation = 0;
                    rasterImg.Layer = layerName;
                    blockTableRecord.AppendEntity(rasterImg);
                    tr.AddNewlyCreatedDBObject(rasterImg, true);
                    RasterImage.EnableReactors(true);
                    rasterImg.AssociateRasterDef(rasterImgDef);
                }
                tr.Commit();
            }
        }
        /// <summary>
        /// Creates an MText
        /// </summary>
        /// <param name="pt1">Point of origin</param>
        /// <param name="textVal">Contents of the Mtxt</param>
        /// <param name="layerName"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public static Tuple<double, double> DrawText(Point2d pt1, double textHeight, double textWidth, string textVal, string layerName, short colour = 255)
        {
            Tuple<double, double> actualHnW;
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, colour);
            Entity entCreated;
            double actualHeight = 0;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                MText text = new MText();                
                text.Contents = textVal;
                text.Width = textWidth;
                text.TextHeight = textHeight;
                text.Location = new Point3d(pt1.X, pt1.Y, 0);
                text.Layer = layerName;
                
                blockTableRec.AppendEntity(text);
                tr.AddNewlyCreatedDBObject(text, true);
                actualHeight = text.ActualHeight;
                tr.Commit();
                actualHnW = new Tuple<double, double>(text.ActualWidth, text.ActualHeight);
                entCreated = text;
            }          
            return actualHnW;
        }
        /// <summary>
        /// Draw a circle
        /// </summary>
        /// <param name="ballRadius"></param>
        /// <param name="ballCentre"></param>
        /// <param name="layerName"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public static Entity DrawCircle(double ballRadius, Point3d ballCentre, string layerName, short colour = 255)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, colour);
            Entity entCreated;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                Circle ball = new Circle();
                ball.Radius = ballRadius;
                ball.Center = ballCentre;
                ball.Layer = layerName;
                blockTableRec.AppendEntity(ball);
                tr.AddNewlyCreatedDBObject(ball, true);
                tr.Commit();
                entCreated = ball;
            }
            return entCreated;
        }
    }
}
