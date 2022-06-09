using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal abstract class AbstractCricle
    {
        public int Radius { get; internal set;  }
        public Vector2 Position { get; internal set; }
        public Vector2 Speed { get; internal set;  }

        public abstract void Move();
        public abstract void ChangeDirectionX();
        public abstract void ChangeDirectionY();

        public static AbstractCricle CreateCircle(Vector2 position)
        {
            return new Circle(position);
        }
    }
}
