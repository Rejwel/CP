using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Circle
    {
        public int Radius { get; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public string Color { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        public Circle(int Radius, double XPos, double YPos)
        {
            Random rnd = new();
            this.Radius = Radius;
            this.XPos = XPos;
            this.YPos = YPos;
            this.Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
            while (XSpeed == 0)
            {
                XSpeed = rnd.Next(-5, 6);
            }
            while (YSpeed == 0)
            {
                YSpeed = rnd.Next(-5, 6);
            }
        }
    }
}

