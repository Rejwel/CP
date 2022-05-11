using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicCircle
    {
        private readonly Data.Circle circle;
        
        public LogicCircle(Data.Circle c)
        {
            circle = c;
        }

        public void ChangeXDirection()
        {
            circle.ChangeDirectionX();
        }

        public void ChangeYDirection()
        {
            circle.ChangeDirectionY();
        }

        public double GetX()
        {
            return circle.XPos;
        }

        public double GetY()
        {
            return circle.YPos;
        }

        public double GetRadius()
        {
            return circle.Radius;
        }
    }
}
