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

        public abstract void InterruptThreads();
        
        public abstract void StartThreads();

        public abstract void CheckBoundariesCollision(LogicCircle cirle);

        public abstract void CheckCollisionsWithCircles(LogicCircle cirle);

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
                height = DataLayer.GetPoolHeight();
                width = DataLayer.GetPoolWidth();
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

            private static bool CirclesCollision(LogicCircle circle)
            {
                foreach (LogicCircle c in circlesCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.GetX() - circle.GetX()), 2) + Math.Pow((c.GetY() - circle.GetY()), 2)));
                    if (c != circle && distance <= (c.GetRadius() + circle.GetRadius()) && checkCircleBoundary(circle))
                    {
                        circle.ChangeXDirection();
                        circle.ChangeYDirection();
                        return true;
                    }
                }
                return false;
            }

            public static void UpdateCircleSpeed(LogicCircle circle)
            {
                if (circle.GetY() - circle.GetRadius() <= 0 || circle.GetY() + circle.GetRadius() >= height)
                {
                    circle.ChangeYDirection();
                }
                if (circle.GetX() + circle.GetRadius() >= width || circle.GetX() - circle.GetRadius() <= 0)
                {
                    circle.ChangeXDirection();
                }
            }

            private static bool checkCircleBoundary(LogicCircle circle)
            {
                return circle.GetY() - circle.GetRadius() <= 0 || circle.GetX() + circle.GetRadius() >= width || circle.GetY() + circle.GetRadius() >= height || circle.GetX() - circle.GetRadius() <= 0 ? false : true;
            }

            public override void CheckBoundariesCollision(Logic.LogicCircle cirle)
            {
                UpdateCircleSpeed(cirle);
            }

            public override void CheckCollisionsWithCircles(Logic.LogicCircle cirle)
            {
                CirclesCollision(cirle);
            }

            public override void InterruptThreads()
            {
                DataLayer.InterruptThreads();
            }
            
            public override void StartThreads()
            {
                DataLayer.StartThreads();
            }

            private readonly DataAbstractAPI DataLayer;
            private static Collection<LogicCircle> circlesCollection = new();
            private static double height;
            private static double width;
        }
    }
}
