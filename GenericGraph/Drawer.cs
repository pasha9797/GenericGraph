using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGraph
{
    public class Drawer
    {
        private Brush myBrush;
        private Pen myPen=new Pen(Color.Black, 1);
        public const float CityWidth=100, CityHeight=30;
        public PointF CurMousePos { get; set; }

        public void Draw(Graphics g, CitiesMap cMap)
        {
            g.Clear(Color.White);

            myBrush = Brushes.Black;
            foreach (City city in cMap.myGraph)
            {              
                foreach (Road road in cMap.myGraph.GetEdgesOf(city))
                {
                    g.DrawLine(myPen, road.Connections[0].Pos, road.Connections[1].Pos);
                    PointF mid = new PointF((road.Connections[0].Pos.X + road.Connections[1].Pos.X) / 2, (road.Connections[0].Pos.Y + road.Connections[1].Pos.Y) / 2);
                    g.DrawString(road.Length.ToString(), new Font("Tahoma", 10), myBrush, mid);
                }
            }

            if (cMap.Selected != null)
                g.DrawLine(Pens.Gray, cMap.Selected.Pos, CurMousePos);

            foreach (City city in cMap.myGraph)
            {
                myBrush = Brushes.LightCyan;
                float x = city.Pos.X - CityWidth/2;
                float y = city.Pos.Y - CityHeight/2;
                g.FillRectangle(myBrush, x, y, CityWidth, CityHeight);
                g.DrawRectangle(myPen, x, y, CityWidth, CityHeight);
                myBrush = Brushes.Black;
                g.DrawString(city.Name, new Font("Tahoma", 10), myBrush, x+1, y+1);
            }
        }
    }
}
