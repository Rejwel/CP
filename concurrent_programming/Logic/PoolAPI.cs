using Data;
using System;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class PoolAbstractAPI
    {
        public static PoolAbstractAPI CreateLayer(DataAbstractAPI? data = default)
        {
            return new PoolAPI(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract ObservableCollection<Circle> CreateCircles(double poolWidth, double poolHeight, int circleCount);
        public abstract ObservableCollection<Circle> UpdateCirlcePosition(double poolWidth, double poolHeight, ObservableCollection<Circle> circles);

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
                    Circle circle = new(rnd.Next(5, 10), rnd.Next(20, (int)poolWidth - 20), rnd.Next(20, (int)poolHeight - 20));
                    circles.Add(circle);
                }
                return circles;
            }

            public override ObservableCollection<Circle> UpdateCirlcePosition(double poolWidth, double poolHeight, ObservableCollection<Circle> circles)
            {
                ObservableCollection<Circle> newCircles = new();
                foreach (Circle circle in circles)
                {
                    if (circle.XPos + circle.Radius + 1 > poolWidth || circle.XPos - circle.Radius - 1 < 0) circle.XSpeed *= -1;
                    if (circle.YPos + circle.Radius + 1 > poolHeight || circle.YPos - circle.Radius - 1 < 0) circle.YSpeed *= -1;
                    circle.XPos += circle.XSpeed;
                    circle.YPos += circle.YSpeed;
                    newCircles.Add(circle);
                }
                return newCircles;
            }

            private readonly DataAbstractAPI DataLayer;
        }
    }
}
