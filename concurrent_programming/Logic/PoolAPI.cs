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

        public abstract ObservableCollection<AbstractLogicCircle> CreateCircles(double poolWidth, double poolHeight, int circleCount);

        public abstract void InterruptThreads();
        
        public abstract void StartThreads();

        public abstract void CheckBoundariesCollision(AbstractLogicCircle cirle);

        public abstract void CheckCollisionsWithCircles(AbstractLogicCircle cirle);

        private class PoolAPI : PoolAbstractAPI
        {
            public PoolAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<AbstractLogicCircle> CreateCircles(double poolWidth, double poolHeight, int circleCount)
            {
                List<AbstractCricle> circles = new();
                ObservableCollection<AbstractLogicCircle> logicCircles = new();
                DataLayer.CreatePoolWithBalls(circleCount, poolWidth, poolHeight);
                height = DataLayer.GetPoolHeight();
                width = DataLayer.GetPoolWidth();
                circles = DataLayer.GetCircles();
                foreach (AbstractCricle c in circles)
                {
                    AbstractLogicCircle logicCircle = AbstractLogicCircle.CreateCircle(c);
                    c.PropertyChanged += logicCircle.Update!;
                    circlesCollection.Add(logicCircle);
                    logicCircles.Add(logicCircle);                
                }
                return logicCircles;
            }

            private static bool CirclesCollision(AbstractLogicCircle circle)
            {
                foreach (AbstractLogicCircle c in circlesCollection)
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

            public static void UpdateCircleSpeed(AbstractLogicCircle circle)
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

            private static bool checkCircleBoundary(AbstractLogicCircle circle)
            {
                return circle.GetY() - circle.GetRadius() <= 0 || circle.GetX() + circle.GetRadius() >= width || circle.GetY() + circle.GetRadius() >= height || circle.GetX() - circle.GetRadius() <= 0 ? false : true;
            }

            public override void CheckBoundariesCollision(Logic.AbstractLogicCircle cirle)
            {
                UpdateCircleSpeed(cirle);
            }

            public override void CheckCollisionsWithCircles(Logic.AbstractLogicCircle cirle)
            {
                CirclesCollision(cirle);
            }

            public override void InterruptThreads()
            {
                DataLayer.InterruptThreads();
                circlesCollection.Clear();
            }
            
            public override void StartThreads()
            {
                DataLayer.StartThreads();
            }

            private readonly DataAbstractAPI DataLayer;
            private static Collection<AbstractLogicCircle> circlesCollection = new();
            private static double height;
            private static double width;
        }
    }
}
