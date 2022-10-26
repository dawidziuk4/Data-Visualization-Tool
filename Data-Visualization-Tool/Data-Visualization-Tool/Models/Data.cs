using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Visualization_Tool;

namespace Data_Visualization_Tool.Models
{
    public class Data
    {
        public float time;
        public int scanner;
        public float value;
        public Color color;
        public Data(float _time, int _scanner, float _value, Color _color)
        {
            time = _time;
            scanner = _scanner;
            value = _value;
            color = _color;
        }
    }
}
