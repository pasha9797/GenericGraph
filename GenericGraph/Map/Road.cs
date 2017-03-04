using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGraph
{
    public class Road
    {
        public int Length { get; set; }
        public City[] Connections { get; set; }

        public Road(int length)
        {
            Length = length;
            Connections = new City[2];
        }
    }
}
