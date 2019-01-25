using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    /// <summary>
    /// This is a abstract class of name Shapes
    /// </summary>
    abstract class Shapes
    {
        protected int x, y;
        protected Color colour;

        /// <summary>
        /// This is a constructor of class Shapes
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Shapes(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// This is a abstract method
        /// </summary>
        /// <param name="g"></param>
        public abstract void draw(Graphics g);

        /// <summary>
        /// This is a ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " " + this.x + " " + this.y + " : ";
        }
    }
}
