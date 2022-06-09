using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class AbstractLogicCircle
    {
        //private readonly Data.AbstractCricle circle;

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public abstract void Update(Object s, PropertyChangedEventArgs e);

        public abstract void ChangeXDirection();

        public abstract void ChangeYDirection();

        public abstract double GetX();

        public abstract double GetY();

        public abstract double GetRadius();


        public static AbstractLogicCircle CreateCircle(Data.AbstractCricle c)
        {
            return new LogicCircle(c);
        }
    }
}
