using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP
{
    [TestClass()]
    public class SetPosition
    {
        [TestMethod()]
        public void SetPositionTest()
        {
            int expectedX = 10;
            int expectedY = 10;

            Form1 f = new Form1();
            f.SetPosition(10, 10);
            int exactX = f.getX();
            int exactY = f.getY();
            Assert.AreEqual(expectedX, exactX);
            Assert.AreEqual(expectedY, exactY);
        }

        [TestMethod()]
        public void compileErrorTest()
        {
            int errorline = 1;
            string line = "Command not recognised on line " + errorline;
            Assert.AreEqual(line, "Command not recognised on line 1");
        }


        [TestMethod()]
        public void moveToTest()
        {
            Form1 f = new Form1();
            int expectedX = 10;
            int expectedY = 10;
            f.moveTo(10, 10);

            int actualX = f.getX();
            int actualY = f.getY();
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);


        }
    }
}