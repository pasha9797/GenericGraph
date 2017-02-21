using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLib;
using System.Drawing;

namespace GenericGraph
{
    public class CitiesMap
    {
        public Graph<City, Road> myGraph = new Graph<City, Road>();
        public City Selected = null;

        public void AddCity(string name, float x, float y)
        {
            City city = new GenericGraph.City(name);
            city.Pos = new PointF(x, y);
            myGraph.AddVertex(city, name);
        }
        public void AddRoad(int length, City c1, City c2)
        {
            Road road = new GenericGraph.Road(length);
            road.Connections[0] = c1;
            road.Connections[1] = c2;
            myGraph.AddEdge(road, length, c1, c2);
        }
        public City FindByPos(float x, float y)
        {
            foreach (City city in myGraph)
            {
                if (x >= city.Pos.X - Drawer.CityWidth / 2 && x <= city.Pos.X + Drawer.CityWidth / 2 &&
                    y >= city.Pos.Y - Drawer.CityHeight / 2 && y <= city.Pos.Y + Drawer.CityHeight / 2)
                    return city;
            }
            return null;
        }
    }
}
