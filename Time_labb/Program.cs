using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            public string ToString(bool is12HourFormat)
            {
                if (is12HourFormat)
                {
                    int hours = Hours % 12 == 0 ? 12 : Hours % 12;
                    string timePeriod = Hours <= 12 ? "am" : "pm";
                    return $"{hours:D2}:{Minutes:D2}:{Seconds:D2} {timePeriod}";
                }
                else
                {
                    return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
                }
            }

            public bool IsAm()
            {
                if (Hours <= 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
