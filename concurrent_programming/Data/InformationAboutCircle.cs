using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Data
{
    internal class InformationAboutCircle
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }
        public string Date { get; set; }
        public InformationAboutCircle(double XPos,double YPos,int XSpeed, int YSpeed)
        {
            this.XPos = XPos;
            this.YPos = YPos;   
            this.XSpeed = XSpeed;
            this.YSpeed = YSpeed;
            string millisecondFormat = $"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff";
            string fullPattern = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern;
            fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", $"$1{millisecondFormat}");
            Date = DateTime.Now.ToString(fullPattern);
        }
    }
}
