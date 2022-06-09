using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class AbstractLogicCircle
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public abstract Vector2 Postion { get; internal set; }

        public abstract void Update(Object s, PropertyChangedEventArgs e);

        public abstract void ChangeXDirection();

        public abstract void ChangeYDirection();

        public abstract double GetRadius();


        public static AbstractLogicCircle CreateCircle(Data.AbstractCricle c)
        {
            return new LogicCircle(c);
        }
    }
}
