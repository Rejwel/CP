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
                    int randomCircleRadius = rnd.Next(20, 25);
                    Circle circle = new(randomCircleRadius, rnd.Next(randomCircleRadius + 1, (int)poolWidth - randomCircleRadius - 1), rnd.Next(randomCircleRadius + 1, (int)poolHeight - randomCircleRadius - 1));
                    while (!CheckStartingPosition(poolWidth, poolHeight, circle))
                    {
                        circle = new(randomCircleRadius, rnd.Next(randomCircleRadius + 1, (int)poolWidth - randomCircleRadius - 1), rnd.Next(randomCircleRadius + 1, (int)poolHeight - randomCircleRadius - 1));
                    }
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
                                    CirclesCollision(poolWidth, poolHeight, circle);
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

            private bool CirclesCollision(double poolWidth, double poolHeight, Circle circle)
            {
                foreach(Circle c in circlesCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.XPos - circle.XPos),2) + Math.Pow((c.YPos - circle.YPos),2)));
                    if(c != circle && distance <= (c.Radius + circle.Radius) && checkCircleBoundary(poolWidth, poolHeight, circle))
                    {
                        circle.XSpeed *= -1;
                        circle.YSpeed *= -1;
                        return true;
                    }
                }
                return false;
            }

            private bool CheckStartingPosition(double poolWidth, double poolHeight, Circle circle)
            {
                if (circlesCollection.Count == 0) return true;
                foreach (Circle c in circlesCollection)
                {
                    double distance = Math.Sqrt(Math.Pow((c.XPos - circle.XPos), 2) + Math.Pow((c.YPos - circle.YPos), 2));
                    if (distance <= (c.Radius + circle.Radius + 5))
                    {
                        return false;
                    }
                }
                return true;
            }

            public override void UpdateCirlcePosition(double poolWidth, double poolHeight, Circle circle)
            {
                    UpdateCircleSpeed(poolWidth, poolHeight, circle);
                    circle.XPos += circle.XSpeed;
                    circle.YPos += circle.YSpeed;
            }

            private void UpdateCircleSpeed(double poolWidth, double poolHeight, Circle circle)
            {
                if (circle.YPos - circle.Radius <= 0 || circle.YPos + circle.Radius >= poolHeight) 
                {
                    circle.YSpeed *= -1;
                }
                if (circle.XPos + circle.Radius >= poolWidth || circle.XPos - circle.Radius <= 0)
                {
                    circle.XSpeed *= -1;
                }
            }

            private bool checkCircleBoundary(double poolWidth, double poolHeight, Circle circle)
            {
                return circle.YPos - circle.Radius <= 0 || circle.XPos + circle.Radius >= poolWidth || circle.YPos + circle.Radius >= poolHeight || circle.XPos - circle.Radius <= 0 ? false : true;
            }

            private readonly DataAbstractAPI DataLayer;
            private Collection<Thread> Threads = new();
            private Collection<Circle> circlesCollection = new();
        }
    }
}
