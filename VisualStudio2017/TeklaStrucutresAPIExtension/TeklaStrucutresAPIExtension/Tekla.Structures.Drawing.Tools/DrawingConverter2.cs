using System;
using Tekla.Structures.Geometry3d;
using TSD = Tekla.Structures.Drawing;
using TSM = Tekla.Structures.Model;
using TP = System.Threading.Tasks.Parallel;

namespace TeklaStrucutresAPIExtension.Tekla.Structures.Drawing.Tools
{
    class DrawingConverter2
    {
        private static readonly TSM.Model _model = new TSM.Model();

        /// <summary>
        /// Converts point from model coordinate system to the view coordinate system
        /// </summary>
        /// <param name="modelPoint"></param>
        /// <param name="viewInDrawing"></param>
        /// <returns></returns>mm
        public static Point FromModelToView(Point modelPoint, TSD.View viewInDrawing)
        {
            var matrixToGlobal = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane().TransformationMatrixToGlobal;
            var matrixToLocal = new TSM.TransformationPlane(viewInDrawing.ViewCoordinateSystem).TransformationMatrixToLocal;

            return matrixToLocal.Transform(matrixToGlobal.Transform(modelPoint));
        }

        /// <summary>
        /// Converts vector in model coordinate system to the ciew coordinate system
        /// </summary>
        /// <param name="vectorInModel"></param>
        /// <param name="viewInDrawing"></param>
        /// <returns></returns>
        public static Vector FromModelToView(Vector vectorInModel, TSD.View viewInDrawing)
        {
            var matrixToGlobal = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane().TransformationMatrixToGlobal;
            var correctedCoordinateSystem = viewInDrawing.ViewCoordinateSystem;
            correctedCoordinateSystem.Origin = new Point();
            var matrixToLocal = new TSM.TransformationPlane(correctedCoordinateSystem).TransformationMatrixToLocal;

            return new Vector(matrixToLocal.Transform(matrixToGlobal.Transform(vectorInModel as Point)));
        }

        /// <summary>
        /// Converts coordinate system from model coordinate system to the view coordinate system
        /// </summary>
        /// <param name="coordinateSystemInModel"></param>
        /// <param name="viewInDrawing"></param>
        /// <returns></returns>
        public static CoordinateSystem FromModelToView(CoordinateSystem coordinateSystemInModel, TSD.View viewInDrawing)
        {
            return new CoordinateSystem()
            {
                Origin = FromModelToView(coordinateSystemInModel.Origin, viewInDrawing),
                AxisX = FromModelToView(coordinateSystemInModel.AxisX, viewInDrawing),
                AxisY = FromModelToView(coordinateSystemInModel.AxisY, viewInDrawing)
            };
        }

        /// <summary>
        /// Converts line in model coordinate view to the view coordinate system
        /// </summary>
        /// <param name="lineInModel"></param>
        /// <param name="viewInDrawing"></param>
        /// <returns></returns>
        public static Line FromModelToView(Line lineInModel, TSD.View viewInDrawing)
        {
            //TODO method
            throw new NotImplementedException();
        }

        /// <summary>
        /// converts line segment in model coordinate system to the view coordinate system
        /// </summary>
        /// <param name="lineSegmentInModel"></param>
        /// <param name="viewInDrawing"></param>
        /// <returns></returns>
        public static LineSegment FromModelToView(LineSegment lineSegmentInModel, TSD.View viewInDrawing)
        {
            return new LineSegment(FromModelToView(lineSegmentInModel.Point1, viewInDrawing), FromModelToView(lineSegmentInModel.Point2, viewInDrawing));
        }


        public static LineSegment[] FromModelToView(LineSegment[] inputLineSegments, TSD.View viewInDrawing)
        {
            var outputLineSegments = new LineSegment[inputLineSegments.Length];

            TP.For(0, inputLineSegments.Length, (i) =>
            {
                outputLineSegments[i] = FromModelToView(inputLineSegments[i], viewInDrawing);
            });

            return outputLineSegments;
        }

        /// <summary>
        /// Converts point from one view coordinate system to another
        /// </summary>
        /// <param name="pointInView1"></param>
        /// <param name="view1"></param>
        /// <param name="toView"></param>
        /// <returns></returns>
        public static Point FromViewToView(Point pointInView1, TSD.View view1, TSD.View toView)
        {
            //TODO method

            throw new NotImplementedException();
        }

    }
}
