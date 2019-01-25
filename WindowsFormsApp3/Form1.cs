using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    /// <summary>
    /// This is a Graphical Programming program which run the give code and execute its expected result
    /// </summary>
    public partial class Form1 : Form
    {
        ArrayList shape = new ArrayList();

        /// <summary>
        /// This will return x
        /// </summary>
        /// <returns></returns>
        public int getX()
        {
            return x;
        }
        /// <summary>
        /// This will return y
        /// </summary>
        /// <returns></returns>
        public int getY()
        {
            return y;
        }

        //ArrayList shapes = new ArrayList();
        Pen myPen = new Pen(System.Drawing.Color.Black);
        int x = 0, y = 0, radius = 0, width = 0, height = 0, counter = 0;
        int loop = 0, kStart = 0, ifcounter = 0;

        /// <summary>
        /// Creating object of a Point
        /// </summary>
        public Point current = new Point();

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < shape.Count; i++)
            {
                Shapes s;
                s = (Shapes)shape[i];
                s.draw(g);
                Console.WriteLine(s.ToString());

            }
        }

        private void runToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string command = textBox1.Text;
            read(command);
            panel1.Refresh();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
            if (radioButton1.Checked)
            {
                p.Width = 1;
            }
            else if (radioButton2.Checked)
            {
                p.Width = 5;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                current = e.Location;
                g.DrawLine(p, old, current);
                old = current;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                p.Color = cd.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to close?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (dialog == DialogResult.No)
            {
                //exx.Cancel = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "Text FIles(*.txt)|*.txt"

            };
            saveFileDialog1.Title = "Save the Source Code";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile()))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Filter = "Text FIles(*.txt)|*.txt"
            };


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);

                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sajag Shumsher Pandey");
        }

        /// <summary>
        /// This is a SetPosition which set the position of x-axis and y-axis
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (radioButton3.Checked)
            {
                    shape.Add(new Circle(Color.Black, x, y, 40));
            }
            else if (radioButton4.Checked)
            {
                    shape.Add(new Rectangle(Color.AliceBlue, x, y, 40, 80));
            }
            else if (radioButton5.Checked)
            {
                shape.Add(new Triangle(Color.AliceBlue, x, y, 40, 80));
            }
            SetPosition(x, y);
            panel1.Refresh();
        }
        /// <summary>
        /// Creating object of Point
        /// </summary>
        public Point old = new Point();
        /// <summary>
        /// Creating object of Graphics
        /// </summary>
        public Graphics g;
        /// <summary>
        /// Creating object of Pen
        /// </summary>
        public Pen p = new Pen(Color.Black, 5);

        /// <summary>
        /// This is a form
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            g = panel1.CreateGraphics();
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

        }

        /// <summary>
        /// This is a read method which compile the code
        /// </summary>
        /// <param name="command"></param>
        public void read(string command)
        {
            command = command.ToLower();
            String[] commandline = command.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 0; k < commandline.Length; k++)
            {
                Console.WriteLine(commandline.Length);

                string[] commands = commandline[k].Split(' ');

                if (commands[0].Equals("MoveTo", StringComparison.InvariantCultureIgnoreCase))
                {
                    string[] coordinates = commands[1].Split(',');
                    int x = 0, y = 0;
                    Int32.TryParse(coordinates[0], out x);
                    Int32.TryParse(coordinates[1], out y);

               
                        moveTo(x, y);
                        Console.WriteLine(x + "," + y);
                    
                }
                else
                if (commands[0].Equals("Rectangle", StringComparison.InvariantCultureIgnoreCase))
                {
                    string[] dimensions = commands[1].Split(',');
                    if (!dimensions[0].Equals("width"))
                    {
                        Int32.TryParse(dimensions[0], out width);
                    }
                    if (!dimensions[1].Equals("height", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Int32.TryParse(dimensions[1], out height);
                    }
                    Console.WriteLine(x + "," + y);
                    
                        shape.Add(new Rectangle(Color.AliceBlue, x, y, width, height));
                        panel1.Refresh();


                }
                else
                if (commands[0].Equals("Circle", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!commands[1].Equals("radius"))
                    {
                        Int32.TryParse(commands[1], out radius);
                    }
                    
                        shape.Add(new Circle(Color.Black, x, y, radius));
                        panel1.Refresh();


                }
                else
                if (commands[0].Equals("Triangle", StringComparison.InvariantCultureIgnoreCase))
                {
                    string[] dimensions = commands[1].Split(',');
                    if (!dimensions[0].Equals("width"))
                    {
                        Int32.TryParse(dimensions[0], out width);
                    }
                    if (!dimensions[1].Equals("height", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Int32.TryParse(dimensions[1], out height);
                    }
                    Console.WriteLine(x + "," + y);
                    
                        shape.Add(new Triangle(Color.AliceBlue, x, y, width, height));
                        panel1.Refresh();


                }

                else
                    if (commands[0].Equals("radius", StringComparison.InvariantCultureIgnoreCase))
                {//defining the radius variable and assigning value to it.
                    if (commands[1].Equals("="))
                    {
                        Int32.TryParse(commands[2], out radius);

                        Console.WriteLine(radius);
                    }
                    else
                    if (commands[1].Equals("+"))
                    {//to add the values to radius
                        int r;
                        Int32.TryParse(commands[2], out r);

                        radius = radius + r;
                        Console.WriteLine(radius);
                    }
                    else
                    if (commands[1].Equals("-"))
                    {//to deduct the values of radius.
                        int r;
                        Int32.TryParse(commands[2], out r);

                        radius = radius - r;
                    }

                }
                else
                    if (commands[0].Equals("width", StringComparison.InvariantCultureIgnoreCase))
                {//defining width and its assignments.
                    if (commands[1].Equals("="))
                    {
                        Int32.TryParse(commands[2], out width);

                        Console.WriteLine(width);
                    }
                    else
                    if (commands[1].Equals("+"))
                    {
                        int w;
                        Int32.TryParse(commands[2], out w);

                        width = width + w;
                    }
                    else
                    if (commands[1].Equals("-"))
                    {
                        int w;
                        Int32.TryParse(commands[2], out w);
                        width = width - w;
                    }
                }
                else
                    if (commands[0].Equals("height", StringComparison.InvariantCultureIgnoreCase))
                {
                    //defining height and its assignment that includes, addition substraction to height.
                    if (commands[1].Equals("="))
                    {
                        Int32.TryParse(commands[2], out height);

                        Console.WriteLine(height);
                    }
                    else
                    if (commands[1].Equals("+"))
                    {
                        int h;
                        Int32.TryParse(commands[2], out h);
                        height = height + h;
                    }
                    else
                    if (commands[1].Equals("-"))
                    {
                        int h;
                        Int32.TryParse(commands[2], out h);
                        height = height - h;
                    }
                }

                else
                    if (commands[0].Equals("Loop", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (loop == 0)
                    {
                        Int32.TryParse(commands[1], out counter);
                        kStart = k;
                    }

                }
                else
                    if (commands[0].Equals("if", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (commands[1].Equals("counter") && commands[2].Equals("=") && commands[4].Equals("then"))
                    {
                        Int32.TryParse(commands[3], out ifcounter);
                        if (ifcounter == (loop + 1))
                        {
                            if (commands[5].Equals("radius", StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (commands[6].Equals("="))
                                {
                                    Int32.TryParse(commands[7], out radius);
                                    Console.WriteLine(radius);
                                }
                                else
                                if (commands[6].Equals("+"))
                                {
                                    int r;
                                    Int32.TryParse(commands[7], out r);
                                    radius = radius + r;
                                    Console.WriteLine(radius);
                                }
                                else
                                if (commands[6].Equals("-"))
                                {
                                    int r;
                                    Int32.TryParse(commands[7], out r);
                                    radius = radius - r;
                                }

                            }
                            else
                    if (commands[5].Equals("Width", StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (commands[6].Equals("="))
                                {
                                    Int32.TryParse(commands[7], out width);
                                    Console.WriteLine(width);
                                }
                                else
                                if (commands[6].Equals("+"))
                                {
                                    int w;
                                    Int32.TryParse(commands[7], out w);
                                    width = width + w;
                                }
                                else
                                if (commands[6].Equals("-"))
                                {
                                    int w;
                                    Int32.TryParse(commands[7], out w);
                                    width = width - w;
                                }
                            }
                            else
                    if (commands[5].Equals("Height", StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (commands[6].Equals("="))
                                {
                                    Int32.TryParse(commands[7], out height);
                                    Console.WriteLine(height);
                                }
                                else
                                if (commands[6].Equals("+"))
                                {
                                    int h;
                                    Int32.TryParse(commands[7], out h);
                                    height = height + h;
                                }
                                else
                                if (commands[6].Equals("-"))
                                {
                                    int h;
                                    Int32.TryParse(commands[7], out h);
                                    height = height - h;
                                }
                            }
                        }
                    }

                }
                else
                if (commands[0].Equals("endif", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (commands[1].Equals("radius", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (commands[2].Equals("="))
                        {
                            int endifvar;
                            Int32.TryParse(commands[3], out endifvar);
                            if (radius == endifvar)
                            {
                                break;
                            }
                        }

                    }
                    else
                    if (commands[1].Equals("Width", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (commands[2].Equals("="))
                        {
                            int endifvar;
                            Int32.TryParse(commands[3], out endifvar);
                            if (width == endifvar)
                            {
                                break;
                            }
                        }

                    }
                    else
                    if (commands[1].Equals("Height", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (commands[2].Equals("="))
                        {
                            int endifvar;
                            Int32.TryParse(commands[3], out endifvar);
                            if (height == endifvar)
                            {
                                break;
                            }
                        }

                    }

                }
                else
                if (commands[0].Equals("End", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (counter > 0)
                    {
                        loop++;
                    }
                    if (counter == loop)
                    {
                        counter = 0;
                        loop = 0;

                    }
                    else
                    {
                        k = kStart;
                    }

                }
                else
                    if (!commands[0].Equals(null))
                {
                    int errorLine = k + 1;
                    CompileError(errorLine);
                }

            }
        }

        /// <summary>
        /// This is a CompileError method which executes an error if the user input is undefine
        /// </summary>
        /// <param name="errorLine"></param>
        public void CompileError(int errorLine)
        {
            MessageBox.Show("Command not recognised on line " + errorLine, "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox2.Text = "Compile Error! There is error on line no. " + errorLine;
        }

        /// <summary>
        /// This is moveTo method which move the object 
        /// </summary>
        /// <param name="tox"></param>
        /// <param name="toy"></param>
        public void moveTo(int tox, int toy)
        {
            x = tox;
            y = toy;

        }
    }
}
