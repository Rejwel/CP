using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Data
{
    public class Circle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Radius { get; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public string Color { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        public double Mass { get; set; }

        public Circle( double XPos, double YPos)
        {
            Random rnd = new();
            this.Radius = 15;
            this.XPos = XPos;
            this.YPos = YPos;
            this.Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
            this.Mass = 5.0;
            while (XSpeed == 0)
            {
                XSpeed = rnd.Next(-3, 4);
            }
            while (YSpeed == 0)
            {
                YSpeed = rnd.Next(-3, 4);
            }
        }

        public void Move()
        {
            this.XPos += this.XSpeed;
            this.YPos += this.YSpeed;
            OnPropertyChanged("Move");
        }

        public void ChangeDirectionX()
        {
            this.XSpeed *= -1;
        }

        public void ChangeDirectionY()
        {
            this.YSpeed *= -1;
        }

        public void Update(Object s,PropertyChangedEventArgs e)
        {
            Json.PrettyWrite(new InformationAboutCircle(XPos,YPos,XSpeed,YSpeed), "C:\\Users\\Filip\\Desktop\\Infa4\\wspolbiezne\\test.txt");
        }
    }
}

