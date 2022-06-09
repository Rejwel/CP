using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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

        private Vector2 _position;
        public override Vector2 Postion 
        { 
            get => _position;
            internal set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.AbstractCricle cir = (Data.AbstractCricle)s;
            Postion = cir.Position;
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

        public override double GetRadius()
        {
            return circle.Radius;
        }
    }
}
