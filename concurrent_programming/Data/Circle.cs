using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Data
{
    class Circle : AbstractCricle, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Circle(Vector2 position)
        {
            Random rnd = new();
            Radius = 15;
            Position = position;
            Speed = new();
            while (Speed.X == 0 || Speed.Y == 0)
            {
                Speed = new(rnd.Next(-3, 4));
            }
        }

        internal override void Move(Stopwatch timer)
        {
            int multiplier = (int)(timer.ElapsedMilliseconds / 1000);
            Position += new Vector2(Speed.X + multiplier, Speed.Y + multiplier);
            OnPropertyChanged("Move");
        }

        public override void ChangeDirectionX()
        {
            Speed = new Vector2(Speed.X * -1, Speed.Y);
        }

        public override void ChangeDirectionY()
        {
            Speed = new Vector2(Speed.X, Speed.Y * -1);
        }

        public override void Update(Object s,PropertyChangedEventArgs e)
        {
            Logger.GetInstance().SaveDataAsYaml(new InformationAboutCircle(Position.X, Position.Y, Speed.X, Speed.Y, this.GetHashCode()));
        }
    }
}

