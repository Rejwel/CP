using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Logger
    {

        private Logger() { }

        private static Logger _instance;

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        public void SaveDataAsYaml(InformationAboutCircle o)
        {
            using StreamWriter file = new($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/ballData.yaml", append: true);
            file.Write(o.ToString());
            file.Close();
        }

    }
}
