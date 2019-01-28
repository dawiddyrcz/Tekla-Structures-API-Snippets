using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Geometry3d;

namespace Tekla.Structures.Drawing
{
    /// <summary>
    /// Allow user to sort points from the view eg. from upper half, lower half, right half, left half. Points must be in view coordinate sysstem
    /// </summary>
    class SortPointsFromView2
    {
        private View _view;

        /// <summary>
        /// Creates new instance of class.
        /// </summary>
        /// <param name="view">The view in the drawing</param>
        public SortPointsFromView2(View view)
        {
            this._view = view;
        }

        /// <summary>Gets the pointlist and check all points if they are on the UPPER half of the view then return them</summary>
        public PointList GetPointsFromThe_Upper_HalfOfView(PointList pointList, double y = 0.0)
        {
            //if (pointList.Count < 2) Debug.Fail("PointList have less than two points");
            if (pointList.Count <= 2) return pointList;

            var returnPointList = new PointList();
            var centerY = _view.RestrictionBox.GetCenterPoint().Y;
            if (y != 0.0) centerY = y;

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.Y > centerY) returnPointList.Add(currentPoint);
            }

            //if (returnPointList.Count < 2) Debug.Fail("Return pointList have less than two points");
            return returnPointList;
        }

        /// <summary>Gets the pointlist and check all points if they are on the LOWER half of the view then return them</summary>
        public PointList GetPointsFromThe_Lower_HalfOfView(PointList pointList, double y = 0.0)
        {
            //if (pointList.Count < 2) Debug.Fail("PointList have less than two points");
            if (pointList.Count <= 2) return pointList;

            var returnPointList = new PointList();
            var centerY = _view.RestrictionBox.GetCenterPoint().Y;
            if (y != 0.0) centerY = y;

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.Y < centerY) returnPointList.Add(currentPoint);
            }

            //if (returnPointList.Count < 2) Debug.Fail("Return pointList have less than two points");
            return returnPointList;
        }

        /// <summary>Gets the pointlist and check all points if they are on the LEFT half of the view then return them</summary>
        public PointList GetPointsFromThe_Left_HalfOfView(PointList pointList, double x = 0.0)
        {
            // if (pointList.Count < 2) Debug.Fail("PointList have less than two points");
            if (pointList.Count <= 2) return pointList;

            var returnPointList = new PointList();
            var centerX = _view.RestrictionBox.GetCenterPoint().X;
            if (x != 0.0) centerX = x;

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.X < centerX) returnPointList.Add(currentPoint);
            }

            // if (returnPointList.Count < 2) Debug.Fail("Return pointList have less than two points");
            return returnPointList;
        }

        /// <summary>Gets the pointlist and check all points if they are on the RIGHT half of the view then return them</summary>
        public PointList GetPointsFromThe_Right_HalfOfView(PointList pointList, double x = 0.0)
        {
            //if (pointList.Count < 2) Debug.Fail("PointList have less than two points");
            if (pointList.Count <= 2) return pointList;

            var returnPointList = new PointList();
            var centerX = _view.RestrictionBox.GetCenterPoint().X;
            if (x != 0.0) centerX = x;

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.X > centerX) returnPointList.Add(currentPoint);
            }

            //if (returnPointList.Count < 2) Debug.Fail("Return pointList have less than two points");
            return returnPointList;
        }

        /// <summary>Gets the upper left point from the list. With minimum X and maximum Y</summary>
        public Point GetUpperLeftPoint(PointList pointList)
        {
            var returnPoint = new Point(double.MaxValue, double.MinValue);

            foreach (Point currentPoint in pointList)
            {
                //if (currentPoint.X <= returnPoint.X & currentPoint.Y >= returnPoint.Y) returnPoint = currentPoint;
                if (currentPoint.X < returnPoint.X)
                {
                    returnPoint = currentPoint;
                }
                else if (currentPoint.X == returnPoint.X & currentPoint.Y > returnPoint.Y) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the upper right point from the list. With maximum X and maximum Y</summary>
        public Point GetUpperRightPoint(PointList pointList)
        {
            var returnPoint = new Point(double.MinValue, double.MinValue);

            foreach (Point currentPoint in pointList)
            {
                //if (currentPoint.X >= returnPoint.X & currentPoint.Y >= returnPoint.Y) returnPoint = currentPoint;
                if (currentPoint.X > returnPoint.X)
                {
                    returnPoint = currentPoint;
                }
                else if (currentPoint.X == returnPoint.X & currentPoint.Y > returnPoint.Y) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the lower left point from the list. With minimum X and minimum Y</summary>
        public Point GetLowerLeftPoint(PointList pointList)
        {
            var returnPoint = new Point(double.MaxValue, double.MaxValue);

            foreach (Point currentPoint in pointList)
            {
                //if (currentPoint.X <= returnPoint.X & currentPoint.Y <= returnPoint.Y) returnPoint = currentPoint;
                if (currentPoint.X < returnPoint.X)
                {
                    returnPoint = currentPoint;
                }
                else if (currentPoint.X == returnPoint.X & currentPoint.Y < returnPoint.Y) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the lower right point from the list. With maximum X and minimum Y</summary>
        public Point GetLowerRightPoint(PointList pointList)
        {

            var returnPoint = new Point(double.MinValue, double.MaxValue);

            foreach (Point currentPoint in pointList)
            {
                //if (currentPoint.X >= returnPoint.X & currentPoint.Y <= returnPoint.Y) returnPoint = currentPoint;
                if (currentPoint.X > returnPoint.X)
                {
                    returnPoint = currentPoint;
                }
                else if (currentPoint.X == returnPoint.X & currentPoint.Y < returnPoint.Y) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the most left point from the list. With minimum X</summary>
        public Point GetMostLeftPoint(PointList pointList)
        {
            if (pointList.Count == 0) return null;
            var returnPoint = new Point(double.MaxValue, 0);

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.X <= returnPoint.X) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the most right point from the list. With maximum X</summary>
        public Point GetMostRightPoint(PointList pointList)
        {
            if (pointList.Count == 0) return null;
            var returnPoint = new Point(double.MinValue, 0);

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.X >= returnPoint.X) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the most upper point from the list. With minimum X</summary>
        public Point GetMostUpperPoint(PointList pointList)
        {
            if (pointList.Count == 0) return null;
            var returnPoint = new Point(0, double.MinValue);

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.Y >= returnPoint.Y) returnPoint = currentPoint;
            }
            return returnPoint;
        }

        /// <summary>Gets the most lower point from the list. With maximum X</summary>
        public Point GetMostLowerPoint(PointList pointList)
        {
            if (pointList.Count == 0) return null;
            var returnPoint = new Point(0, double.MaxValue);

            foreach (Point currentPoint in pointList)
            {
                if (currentPoint.Y <= returnPoint.Y) returnPoint = currentPoint;
            }
            return returnPoint;
        }
    }
}
