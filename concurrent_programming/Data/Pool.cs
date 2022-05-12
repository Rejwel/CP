using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Data
{
    internal class Pool
    {
        private readonly Object locked = new();
        private List<Circle> circles = new();
        private Collection<Thread> threads = new();
        private double poolHeight;
        private double poolWidth;

        public Pool(int amount, double widthOfCanvas, double heightOfCanvas)
        {
            this.poolHeight = heightOfCanvas;
            this.poolWidth = widthOfCanvas;
            CreateBalls(amount);
            CreateThreads();
            StartThreads();
        }

        public void CreateBalls(int amount)
        {
            
            Random rnd = new();
            for (int i = 0; i < amount; i++)
            {
                int xposition = rnd.Next(30, (int)poolWidth - 30);
                int yposition = rnd.Next(30, (int)poolHeight - 30);
                while (!CanCreate(xposition, yposition))
                {
                    xposition = rnd.Next(30, (int)poolWidth - 30);
                    yposition = rnd.Next(30, (int)poolHeight - 30);
                }
                circles.Add(new Circle(xposition, yposition));
            }
        }

        private bool CanCreate(int x, int y)
        {
            if (circles.Count == 0) return true;
            foreach (Circle c in circles)
            {
                double distance = Math.Sqrt(Math.Pow((c.XPos - x), 2) + Math.Pow((c.YPos - y), 2));
                if (distance <= (2 * c.Radius + 20))
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateThreads()
        {
            foreach(Circle c in circles)
            {
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Thread.Sleep(15);
                            lock (locked)
                            {
                                c.Move();
                            
                            }
                        }
                        catch (Exception e)
                        {
                            break;
                        }

                    }
                });
                threads.Add(t);
            }
        }

        public void StartThreads()
        {
            foreach(Thread t in threads)
            {
                t.Start();
            }
        }

        public void InterruptThreads()
        {
            foreach(Thread t in threads)
            {
                t.Interrupt();
            }
        }

        public List<Circle> GetCircles()
        {
            return circles;
        }

        public double GetPoolHeight()
        {
            return poolHeight;
        }

        public double GetPoolWidth()
        {
            return poolWidth;
        }

    }
}
