using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLib;

namespace GenericGraph
{
    public class Drawer //отрисовщик
    {
        private Brush myBrush;
        private Pen myPen;
        private Font myFont = new Font("Tahoma", 10);

        public PointF CurMousePos { get; set; }
        public const int NameMargin = 2; //отступ названия города от краев прямоугольника

        public void Draw(Graphics g, CitiesMap cMap) //нарисовать cMap на g
        {
            g.Clear(Color.White);

            /*отрисовка дорог*/
            myBrush = Brushes.Black;
            foreach (City city in cMap.MainGraph)
            {
                foreach (Road road in cMap.MainGraph.GetEdgesOf(city))
                {
                    if (cMap.MainGraph.IsEdgeInTree(road))
                        myPen = Pens.DarkRed;
                    else
                        myPen = Pens.Gray;
                    g.DrawLine(myPen, road.Connections[0].Pos, road.Connections[1].Pos);
                    PointF mid = new PointF((road.Connections[0].Pos.X + road.Connections[1].Pos.X) / 2, (road.Connections[0].Pos.Y + road.Connections[1].Pos.Y) / 2);
                    g.DrawString(road.Length.ToString(), new Font("Tahoma", 10), myBrush, mid);
                }
            }

            if (cMap.Selected != null) //отрисовка анимации проложения дороги
                g.DrawLine(Pens.Gray, cMap.Selected.Pos, CurMousePos);
            
            /*отрисовка городов*/
            myPen = Pens.Black;
            int i = 0;
            foreach (City city in cMap.MainGraph)
            {
                if (cMap.MainGraph.IsVertexVisit(city) || cMap.MainGraph.IsVertexInTree(city))
                    myBrush = Brushes.DarkKhaki;
                else
                    myBrush = Brushes.LightCyan;
                string s = i + ": " + city.Name;
                SizeF strSize = g.MeasureString(s, myFont);
                float width = strSize.Width + 2 * NameMargin;
                float height = strSize.Height + 2 * NameMargin;
                city.Size = new SizeF(width, height);
                float x = city.Pos.X - width / 2;
                float y = city.Pos.Y - height / 2;
                g.FillRectangle(myBrush, x, y, width, height);
                g.DrawRectangle(myPen, x, y, width, height);
                myBrush = Brushes.Black;
                g.DrawString(s, myFont, myBrush, x + NameMargin, y + NameMargin);
                i++;
            }
        }
    }
}
