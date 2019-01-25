using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    /// <summary>
    /// This is a Triangle class which creates shape of a triangle
    /// </summary>
    class Triangle : Shapes
    {
        int width, height;
        public Triangle(Color color, int x, int y, int height, int width) : base(color, x, y)
        {
            this.height = height;
            this.width = width;

        }
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(colour);

            PointF[] P = new PointF[3];
            P[0].X = x;
            P[0].Y = y;

            P[1].X = x + width;
            P[1].Y = y;

            P[2].X = x + (width / 2);
            P[2].Y = y + height;

            g.DrawPolygon(p, P);

        }
    }
}
