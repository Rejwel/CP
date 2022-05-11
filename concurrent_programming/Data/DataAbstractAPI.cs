using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract void Connect();

        public abstract void CreatePoolWithBalls(int amount, double widthOfCanvas, double heightOfCanvas);

        public abstract List<Circle> GetCircles();

        public abstract void InterruptThreads();

        public abstract double GetPoolWidth();

        public abstract double GetPoolHeight();

        public static DataAbstractAPI CreateAPI()
        {
            return new API();
        }

        private class API : DataAbstractAPI
        {
            private Pool pool;

            public override void Connect()
            {
                throw new NotImplementedException();
            }

            public override void CreatePoolWithBalls(int amount, double widthOfCanvas, double heightOfCanvas)
            {
                this.pool = new Pool(amount, widthOfCanvas, heightOfCanvas);
            }

            public override List<Circle> GetCircles()
            {
                return pool.GetCircles();
            }

            public override void InterruptThreads()
            {
                pool.InterruptThreads();
            }

            public override double GetPoolHeight()
            {
                return pool.GetPoolHeight();
            }

            public override double GetPoolWidth()
            {
                return pool.GetPoolWidth();
            }

        }
    }
}
