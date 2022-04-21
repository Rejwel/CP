using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract void Connect();

        public static DataAbstractAPI CreateAPI()
        {
            return new API();
        }

        private class API : DataAbstractAPI
        {
            public override void Connect()
            {
                throw new NotImplementedException();
            }
        }
    }
}
