using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ProgTech
{
    class GraphCanvas : GroupBox
    {
        private int GraphMargin = 50;
        private double XSize = 32.0;
        private double YSize = 42.0;
        private double XBase = 0.0;
        private double YBase = 20.0;
        private double XDelta = 5;
        private double YDelta = 10;

        private readonly List<GraphLine> Lines = new List<GraphLine>();

        private GraphLine _lineToShowName;
        
        public GraphCanvas()
        {
            this.Paint += GraphCanvas_Paint;
            this.MouseDown += GraphCanvas_MouseDown;
            this.MouseUp += GraphCanvas_MouseUp;
        }

        public void AddLine(List<GraphPoint> points, int numberOfPoints, Pen pen, string name)
        {
            Lines.Add(new GraphLine(points, numberOfPoints, pen, name));
        }

        public void RemoveAllLines()
        {
            Lines.Clear();
        }

        private Point TransformPoint(GraphPoint point)
        {
            return new Point(Convert.ToInt32((point.X - XBase) * (Width - GraphMargin*2) / XSize),
                Convert.ToInt32((point.Y - YBase) * (Height - GraphMargin*2) / YSize));
        }

        private GraphPoint TransformPointBack(Point point)
        {
            return new GraphPoint(point.X * XSize / (Width - GraphMargin * 2) + XBase,
                point.Y * YSize / (Height - GraphMargin * 2) + YBase);
        }

        private void GraphCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (Lines.Count == 0)
                return;

            Pen blackPen = new Pen(Color.Black);
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            e.Graphics.TranslateTransform(GraphMargin, Height - GraphMargin);

            for (double x = XBase; x <= XBase + XSize; x += XDelta)
            {
                Point axisPoint = TransformPoint(new GraphPoint(x, 0));

                e.Graphics.DrawString(x.ToString("0.##"),
                    new System.Drawing.Font("Arial", 12),
                    blackBrush,
                    new Point(axisPoint.X - 5, 5));
    
                if (x != XBase)
                    e.Graphics.DrawLine(blackPen, new Point(axisPoint.X, -3), new Point(axisPoint.X, 3));
            }
            
            for (double y = YBase; y <= YBase + YSize; y += YDelta)
            {
                Point axisPoint = TransformPoint(new GraphPoint(0, y));

                e.Graphics.DrawString(y.ToString("0.##"),
                    new System.Drawing.Font("Arial", 12),
                    blackBrush,
                    new Point(-30, -(axisPoint.Y + 10)));

                if (y != YBase)
                    e.Graphics.DrawLine(blackPen, new Point(-3, -axisPoint.Y), new Point(3, -axisPoint.Y));
            }

            e.Graphics.ScaleTransform(1.0F, -1.0F);

            e.Graphics.DrawLine(blackPen, 0, 0, Width - GraphMargin*2, 0);
            e.Graphics.DrawLine(blackPen, 0, 0, 0, Height - GraphMargin*2);

            foreach (GraphLine line in Lines)
            {
                if (line.Points.Count == 0)
                    continue;

                Point currentPoint = TransformPoint(line.Points[0]);
                Point nextPoint;

                for (int i = 0; i < line.Length - 1; i++)
                {
                    nextPoint = TransformPoint(line.Points[i + 1]);
                    e.Graphics.DrawLine(line.Pen, currentPoint, nextPoint);
                    currentPoint = nextPoint;
                }
            }

            if (_lineToShowName != null)
            {
                e.Graphics.ResetTransform();
                e.Graphics.DrawString(_lineToShowName.Name, 
                    new System.Drawing.Font("Arial", 20), 
                    new SolidBrush(_lineToShowName.Pen.Color), 
                    new PointF(Location.X + Width - 100, Location.Y + 5));
            }
        }

        private void GraphCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;

            Point translatedPoint = new Point(e.Location.X - GraphMargin, Height - e.Location.Y - GraphMargin);
            GraphPoint transformedPoint = TransformPointBack(translatedPoint);
            foreach (GraphLine line in Lines)
                if (line.ContainsPoint(transformedPoint))
                {
                    _lineToShowName = line;
                    Invalidate(new Rectangle(new Point(Location.X + Width - 100, Location.Y + 5), new Size(100, 30)));
                    return;
                }
        }

        void GraphCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;

            _lineToShowName = null;
            Invalidate(new Rectangle(new Point(Location.X + Width - 100, Location.Y + 5), new Size(100, 30)));
        }     
    }
}
