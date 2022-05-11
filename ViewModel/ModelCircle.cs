using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ModelCircle : ViewModelBase
    {
        public double X { get; set; }
        public double Y { get; set;}
        public double Radius { get; set; }

        public Logic.LogicCircle circle;

        public ModelCircle(double x, double y, double radius, Logic.LogicCircle c)
        {
            this.X = x; 
            this.Y = y;
            this.Radius = radius;
            this.circle = c; 
        }
    }
}
