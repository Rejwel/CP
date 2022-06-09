using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ModelCircle : ViewModelBase
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; }

        public String Color { get; set; }
    

        public ModelCircle(double x, double y, double radius)
        {
            Random rnd = new();
            this.X = x; 
            this.Y = y;
            this.Radius = radius;
            this.Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Logic.LogicCircle circle = (Logic.LogicCircle)s;
            X = circle.X;
            Y = circle.Y;
        }
    }
}
