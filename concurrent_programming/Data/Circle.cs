﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Data
{
    public class Circle
    {
        public int Radius { get; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public string Color { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        public double Mass { get; set; }

        public Thread Thread { get; set; }

        public Circle( double XPos, double YPos)
        {
            Random rnd = new();
            this.Radius = 5;
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
        }

        public void ChangeDirectionX()
        {
            this.XSpeed *= -1;
        }

        public void ChangeDirectionY()
        {
            this.YSpeed *= -1;
        }
    }
}
