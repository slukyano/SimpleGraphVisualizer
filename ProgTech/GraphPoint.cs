using System;
using System.Collections.Generic;
using System.Text;

namespace ProgTech
{
    class GraphPoint
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public GraphPoint(double x, double y)
        {
            X = x;
            Y = y;
        }    
    }
}
