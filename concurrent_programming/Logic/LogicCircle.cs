using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicCircle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.Circle cirlce = (Data.Circle)s; 
            X = circle.XPos;
            Y = circle.YPos;
        }


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
            return X;
        }

        public double GetY()
        {
            return Y;
        }

        public double GetRadius()
        {
            return circle.Radius;
        }

        public String GetColor()
        {
            return circle.Color;
        }
    }
}
