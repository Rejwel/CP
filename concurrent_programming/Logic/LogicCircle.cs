using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicCircle : AbstractLogicCircle, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _x;
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }
        private double _y;
        public double Y 
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.AbstractCricle cirlce = (Data.AbstractCricle)s; 
            X = circle.Position.X;
            Y = circle.Position.Y;
            PoolAbstractAPI.CreateLayer().CheckBoundariesCollision(this);
            PoolAbstractAPI.CreateLayer().CheckCollisionsWithCircles(this);
        }


        private readonly Data.AbstractCricle circle;
        
        public LogicCircle(Data.AbstractCricle c)
        {
            circle = c;
        }

        public override void ChangeXDirection()
        {
            circle.ChangeDirectionX();
        }

        public override  void ChangeYDirection()
        {
            circle.ChangeDirectionY();
        }

        public override double GetX()
        {
            return X;
        }

        public override double GetY()
        {
            return Y;
        }

        public override double GetRadius()
        {
            return circle.Radius;
        }
    }
}
