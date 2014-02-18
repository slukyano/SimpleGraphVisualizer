using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ProgTech
{
    class GraphLine
    {
        private const double Precision = 0.01;

        public List<GraphPoint> Points { get; private set; }
        public int Length { get; private set; }
        public Pen Pen { get; private set; }
        public string Name { get; private set; }

        public GraphLine(List<GraphPoint> points, int length, Pen pen, string name)
        {
            Points = points;
            Length = length;
            Pen = pen;
            Name = name;
        }

        public bool ContainsPoint(GraphPoint point)
        {
            for (int i = 0; i < Points.Count - 1; i++)
                if (Points[i].X <= point.X && Points[i + 1].X >= point.X)
                {
                    double x1 = Points[i].X;
                    double x2 = Points[i + 1].X;
                    double x = point.X;
                    double y1 = Points[i].Y;
                    double y2 = Points[i + 1].Y;
                    double y = point.Y;

                    double k = (y2 - y1) / (x2 - x1);
                    double b = y1 - k * x1;

                    if (Math.Abs((y - k * x) - b) < Precision * Math.Max(y1, y2))
                        return true;
                }

            return false;
        }
    }
}
