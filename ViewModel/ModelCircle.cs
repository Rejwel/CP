using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ModelCircle : ViewModelBase
    {
        public float X { get => Postition.X; }
        public float Y { get => Postition.Y; }

        public Vector2 Postition { get; internal set; }

        public double Radius { get; internal set; }

        public String Color { get; internal set; }
    

        public ModelCircle(double x, double y, double radius)
        {
            Random rnd = new();
            this.Postition = new Vector2((float)x, (float)y);
            this.Radius = radius;
            this.Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Logic.AbstractLogicCircle circle = (Logic.AbstractLogicCircle) s;
            this.Postition = circle.Postion;
        }
    }
}
