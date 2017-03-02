using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGraph
{
    public class City
    {
        public string Name { get; set; }
        public PointF Pos { get; set; }
        public SizeF Size { get; set; }

        public City(string name)
        {
            Name = name;
        }
    }
}
