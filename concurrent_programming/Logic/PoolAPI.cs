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

        public abstract ObservableCollection<LogicCircle> CreateCircles(double poolWidth, double poolHeight, int circleCount);
        public abstract void UpdateCircleSpeed(LogicCircle logicCircle);

        public abstract void InterruptThreads();

        private class PoolAPI : PoolAbstractAPI
        {
            public PoolAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<LogicCircle> CreateCircles(double poolWidth, double poolHeight, int circleCount)
            {
                List<Circle> circles = new();
                ObservableCollection<LogicCircle> logicCircles = new();
                DataLayer.CreatePoolWithBalls(circleCount, poolWidth, poolHeight);
                circles = DataLayer.GetCircles();
                foreach (Circle c in circles)
                {
                    LogicCircle logicCircle = new LogicCircle(c);
                    c.PropertyChanged += logicCircle.Update!;
                    circlesCollection.Add(logicCircle);
                    logicCircles.Add(logicCircle);                
                }
                return logicCircles;
            }

            private bool CirclesCollision(double poolWidth, double poolHeight, LogicCircle circle)
            {
                foreach (LogicCircle c in circlesCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.GetX() - circle.GetX()), 2) + Math.Pow((c.GetY() - circle.GetY()), 2)));
                    if (c != circle && distance <= (c.GetRadius() + circle.GetRadius()) && checkCircleBoundary(poolWidth, poolHeight, circle))
                    {
                        circle.ChangeXDirection();
                        circle.ChangeYDirection();
                        return true;
                    }
                }
                return false;
            }

            public override void UpdateCircleSpeed(LogicCircle circle)
            {
                if (circle.GetY() - circle.GetRadius() <= 0 || circle.GetY() + circle.GetRadius() >= DataLayer.GetPoolHeight())
                {
                    circle.ChangeYDirection();
                }
                if (circle.GetX() + circle.GetRadius() >= DataLayer.GetPoolWidth() || circle.GetX() - circle.GetRadius() <= 0)
                {
                    circle.ChangeXDirection();
                }
            }

            private bool checkCircleBoundary(double poolWidth, double poolHeight, LogicCircle circle)
            {
                return circle.GetY() - circle.GetRadius() <= 0 || circle.GetX() + circle.GetRadius() >= poolWidth || circle.GetY() + circle.GetRadius() >= poolHeight || circle.GetX() - circle.GetRadius() <= 0 ? false : true;
            }

            public override void InterruptThreads()
            {
                DataLayer.InterruptThreads();
            }

            private readonly DataAbstractAPI DataLayer;
            private Collection<LogicCircle> circlesCollection = new();
        }
    }
}
