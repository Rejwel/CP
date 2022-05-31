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
        public int Hash { get; set; }
        public string Date { get; set; }
        public InformationAboutCircle(double XPos,double YPos,int XSpeed, int YSpeed,int Hash)
        {
            this.XPos = XPos;
            this.YPos = YPos;   
            this.XSpeed = XSpeed;
            this.YSpeed = YSpeed;
            this.Hash = Hash;
            string millisecondFormat = $"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff";
            string fullPattern = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern;
            fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", $"$1{millisecondFormat}");
            Date = DateTime.Now.ToString(fullPattern);
        }

        public string ToString() {
            string toWrite = "circle:" + "\n";
            toWrite += "  - Hash: " + Hash + "\n";
            toWrite += "  - XPos: " + XPos + "\n";
            toWrite += "  - Ypos: " + YPos + "\n";
            toWrite += "  - XSpeed: " + XSpeed + "\n";
            toWrite += "  - YSpeed: " + YSpeed + "\n";
            return toWrite;
        }
    }
}
