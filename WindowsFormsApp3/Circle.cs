using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    /// <summary>
    /// This is a Circle class which creates shape of a circle
    /// </summary>
    class Circle : Shapes
    {
        int radius;

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(colour);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.radius;
        }
    }
}
