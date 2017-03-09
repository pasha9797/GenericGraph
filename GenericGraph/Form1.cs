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
            gScreen = drawBox.CreateGraphics();
            bitmap = new Bitmap(drawBox.Width, drawBox.Height);
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
            gScreen.DrawImage(bitmap, drawBox.ClientRectangle);
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

        private void drawBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (cityRB.Checked == true)
            {
                if (tB.Text == "")
                {
                    MessageBox.Show("Введите название города!");
                }
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
                {
                    cMap.Selected = null;
                }
                else if (cMap.Selected == null)
                {
                    cMap.Selected = city;
                }
                drawer.CurMousePos = new Point(e.X, e.Y);
                InvalidateResult();
            }
            else if (deleteRB.Checked == true)
            {
                City city = cMap.FindByPos(e.X, e.Y);
                if (city != null)
                {
                    cMap.RemoveCity(city);
                    InvalidateResult();
                }
            }
        }

        private void drawBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (roadRB.Checked == true)
            {
                City city = cMap.FindByPos(e.X, e.Y);
                if (city != null && cMap.Selected != null && city != cMap.Selected)
                {
                    int length = 0;
                    try
                    {
                        length = Convert.ToInt32(tB.Text);
                        if (length < 0)
                        {
                            MessageBox.Show("Пожалуйста, введите неотрицательное число!");
                        }
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
                    catch (FormatException)
                    {
                        MessageBox.Show("Пожалуйста, введите целое число!");
                    }
                }
                cMap.Selected = null;
                InvalidateResult();
            }
        }

        private void drawBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (roadRB.Checked == true && cMap.Selected != null)
            {
                drawer.CurMousePos = new Point(e.X, e.Y);
                InvalidateResult();
            }
        }

        private void deepB_Click(object sender, EventArgs e)
        {
            if (cMap.MainGraph.Count() == 0)
            {
                MessageBox.Show("Создайте граф!");
            }
            else
            {
                try
                {
                    int start = Convert.ToInt32(startWalkTB.Text);

                    if (start < 0 || start >= cMap.MainGraph.Count())
                    {
                        MessageBox.Show("Номер вершины выходит за допустимые границы!");
                    }
                    else
                    {
                        cMap.MainGraph.WalkDeep(start, InvalidateResult);
                        InvalidateResult();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Вы должны корректно ввести номер вершины!");
                }
            }
        }

        private void wideB_Click(object sender, EventArgs e)
        {
            if (cMap.MainGraph.Count() == 0)
            {
                MessageBox.Show("Создайте граф!");
            }
            else
            {
                try
                {
                    int start = Convert.ToInt32(startWalkTB.Text);

                    if (start < 0 || start >= cMap.MainGraph.Count())
                    {
                        MessageBox.Show("Номер вершины выходит за допустимые границы!");
                    }
                    else
                    {
                        cMap.MainGraph.WalkWide(start, InvalidateResult);
                        InvalidateResult();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Вы должны корректно ввести номер вершины!");
                }
            }
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            cMap.MainGraph.ResetVisit();
            cMap.MainGraph.ResetInTree();
        }

        private void dijkstrB_Click(object sender, EventArgs e)
        {
            if (cMap.MainGraph.Count() == 0)
            {
                MessageBox.Show("Создайте граф!");
            }
            else
            {
                try
                {
                    int beg = Convert.ToInt32(begTB.Text);
                    int end = Convert.ToInt32(endTB.Text);

                    if (beg < 0 || beg >= cMap.MainGraph.Count() || end < 0 || end >= cMap.MainGraph.Count())
                    {
                        MessageBox.Show("Номера вершин должны быть >= 0 и <=" + (cMap.MainGraph.Count() - 1));
                    }
                    else
                    {
                        List<int> path = new List<int>();
                        int distance = cMap.MainGraph.Dijkstr(beg, end, a => a.Length, ref path);
                        if (distance != -1)
                        {
                            string s = "Длина пути: " + distance + "\nПуть:\n";
                            foreach (int n in path)
                            {
                                s += n + ": " + cMap.MainGraph[n].Name + '\n';
                            }
                            MessageBox.Show(s);
                        }
                        else
                        {
                            MessageBox.Show("Невозможно найти путь между двумя заданными вершинами");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите начальный и конечный номера вершин!");
                }
            }
        }

        private void cruskalB_Click(object sender, EventArgs e)
        {
            if (cMap.MainGraph.Count() == 0)
            {
                MessageBox.Show("Создайте граф!");
            }
            else
            {
                cMap.MainGraph.Kruscall(a => a.Length);
                InvalidateResult();
            }
        }

        private void drawBox_Resize(object sender, EventArgs e)
        {
            gScreen = drawBox.CreateGraphics();
            bitmap = new Bitmap(drawBox.Width, drawBox.Height);
            g = Graphics.FromImage(bitmap);
            InvalidateResult();
        }
    }
}
