using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_labb
{
    internal class Program
    {
        public class Time
        {
            public int Hours { get; }
            public int Minutes { get; }
            public int Seconds { get; }

            public Time(int hours, int minutes, int seconds)
            {
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
            }
             
            public bool IsValid()
            {
                return Hours >= 0 && Hours <= 23 && Minutes >= 0 && Minutes <= 59 && Seconds >= 0 && Seconds <= 59;
            }
        }
    }
}
