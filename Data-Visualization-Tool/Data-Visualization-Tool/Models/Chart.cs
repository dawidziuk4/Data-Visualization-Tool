using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Visualization_Tool.Models
{
    public class Chart
    {
        public float resolution;
        public float minValue;
        public float maxValue;
        public float minTime;
        public float maxTime;
        public int scannersCount;
        public List<Data> data;

        private float length;
        private float height;
        private float depth;

        public Chart(List<Data> _data)
        {
            data = _data;
            length = (maxTime - minTime) * resolution;
            height = (maxValue - minValue) * resolution;
            depth = scannersCount * resolution;
        }
    }
}
