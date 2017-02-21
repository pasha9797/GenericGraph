using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CitiesMap cMap = new CitiesMap();
        Drawer drawer = new Drawer();
        Graphics g;
        Bitmap bitmap;
        Graphics gScreen;

        private void Form1_Load(object sender, EventArgs e)
        {
            gScreen = this.CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            labelTip.Visible = false;
            tB.Visible = false;
            InvalidateResult();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            InvalidateResult();
        }

        private void InvalidateResult()
        {
            drawer.Draw(g, cMap);
            gScreen.DrawImage(bitmap, ClientRectangle);
        }

        private void cursorRB_Click(object sender, EventArgs e)
        {
            cMap.Selected = null;
            labelTip.Visible = false;
            tB.Visible = false;
        }

        private void cityRB_Click(object sender, EventArgs e)
        {
            cMap.Selected = null;
            labelTip.Visible = true;
            tB.Visible = true;
            labelTip.Text = "Название города";
        }

        private void roadRB_Click(object sender, EventArgs e)
        {
            cMap.Selected = null;
            labelTip.Visible = true;
            tB.Visible = true;
            labelTip.Text = "Длина дороги";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cityRB.Checked == true)
            {
                if (tB.Text == "")
                    MessageBox.Show("Введите название города!");
                else
                {
                    cMap.AddCity(tB.Text, e.X, e.Y);
                    InvalidateResult();
                }
            }
            else if (roadRB.Checked == true)
            {
                City city = cMap.FindByPos(e.X, e.Y);
                if (city == null)
                    cMap.Selected = null;
                else if (cMap.Selected == null)
                    cMap.Selected = city;
                drawer.CurMousePos = new Point(e.X, e.Y);
                InvalidateResult();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (roadRB.Checked == true)
            {
                City city = cMap.FindByPos(e.X, e.Y);
                if (city != null && cMap.Selected != null)
                {
                    int length = 0;
                    try
                    {
                        length = Convert.ToInt32(tB.Text);
                        if (length < 0)
                            MessageBox.Show("Пожалуйста, введите неотрицательное число!");
                        else
                        {
                            try
                            {
                                cMap.AddRoad(length, cMap.Selected, city);
                            }
                            catch
                            {
                                MessageBox.Show("Похоже, дорога между городами уже есть!");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Пожалуйста, введите целое число!");
                    }
                }
                cMap.Selected = null;
                InvalidateResult();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (roadRB.Checked == true && cMap.Selected != null)
            {
                drawer.CurMousePos = new Point(e.X, e.Y);
                InvalidateResult();
            }
        }
    }
}
