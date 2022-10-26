using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Visualization_Tool.Models
{
    public class WindowProperties
    {
        public int width { get; set; }
        public int height { get; set; }

        public WindowProperties(int _width, int _height)
        {
            width = _width;
            height = _height;
        }
    }
}
