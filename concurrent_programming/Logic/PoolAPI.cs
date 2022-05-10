using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Logic
{
    public abstract class PoolAbstractAPI
    {
        public static PoolAbstractAPI CreateLayer(DataAbstractAPI? data = default)
        {
            return new PoolAPI(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract ObservableCollection<Circle> CreateCircles(double poolWidth, double poolHeight, int circleCount);
        public abstract void UpdateCirlcePosition(double poolWidth, double poolHeight, Circle circles);

        public abstract void InterruptThreads();

        private class PoolAPI : PoolAbstractAPI
        {
            public PoolAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<Circle> CreateCircles(double poolWidth, double poolHeight, int circleCount)
            {
                ObservableCollection<Circle> circles = new();
                Random rnd = new();
                for (int i = 0; i < circleCount; i++)
                {
                    Circle circle = new(rnd.Next(20, 25), rnd.Next(40, (int)poolWidth - 40), rnd.Next(40, (int)poolHeight - 40));
                    circles.Add(circle);
                    circlesCollection.Add(circle);
                    Thread t = new Thread(() =>
                    {
                        while (true)
                        {
                            try
                            {
                                Thread.Sleep(10);
                                lock (circlesCollection)
                                {
                                    CirclesCollision(circle);
                                }
                                UpdateCirlcePosition(poolWidth, poolHeight, circle);
                            } catch ( Exception e)
                            {
                                break;
                            }
                        }

                    });
                    Threads.Add(t);
                }
                StartThreads();
                return circles;
            }

            public void StartThreads()
            {
                foreach(Thread t in Threads)
                {
                    t.Start();
                }
            }

            public override void InterruptThreads()
            {
                foreach (Thread t in Threads)
                {
                    t.Interrupt();
                }
                Threads = new();
            }

            private bool CirclesCollision(Circle circle)
            {
                foreach(Circle c in circlesCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.XPos - circle.XPos),2) + Math.Pow((c.YPos - circle.YPos),2)));
                    if(c != circle && distance <= (c.Radius + circle.Radius))
                    {
                        circle.XSpeed *= -1;
                        circle.YSpeed *= -1;
                        return true;
                    }
                }
                return false;
            }

            public override void UpdateCirlcePosition(double poolWidth, double poolHeight, Circle circle)
            {
                    if (circle.XPos + circle.Radius + 1 > poolWidth || circle.XPos - circle.Radius - 1 < 0) circle.XSpeed *= -1;
                    if (circle.YPos + circle.Radius + 1 > poolHeight || circle.YPos - circle.Radius - 1 < 0) circle.YSpeed *= -1;
                    circle.XPos += circle.XSpeed;
                    circle.YPos += circle.YSpeed;
            
            }

            private readonly DataAbstractAPI DataLayer;
            private Collection<Thread> Threads = new();
            private Collection<Circle> circlesCollection = new();
        }
    }
}
