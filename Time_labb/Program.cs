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

            public static Time operator +(Time time, int seconds)
            {
                int totalSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds + seconds;
                int newHours = totalSeconds / 3600 % 24;
                int newMinutes = (totalSeconds % 3600) / 60;
                int newSeconds = totalSeconds % 60;

                return new Time(newHours, newMinutes, newSeconds);
            }

            public static Time operator -(Time time, int seconds)
            {
                int totalSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds - seconds;
                if (totalSeconds < 0)
                {
                    totalSeconds += 24 * 3600;
                }
                int newHours = totalSeconds / 3600 % 24;
                int newMinutes = (totalSeconds % 3600) / 60;
                int newSeconds = totalSeconds % 60;

                return new Time(newHours, newMinutes, newSeconds);
            }

            public static bool operator ==(Time time1, Time time2)
            {
                if (ReferenceEquals(time1, time2))
                {
                    return true;
                }
                if (time1 is null || time2 is null)
                {
                    return false;
                }
                return time1.Hours == time2.Hours && time1.Minutes == time2.Minutes && time1.Seconds == time2.Seconds;
            }
            public static bool operator !=(Time time1, Time time2)
            {
                return !(time1 == time2);
            }
            public static bool operator <(Time time1, Time time2)
            {
                return time1.Hours < time2.Hours || (time1.Hours == time2.Hours && time1.Minutes < time2.Minutes) || (time1.Hours == time2.Hours && time1.Minutes == time2.Minutes && time1.Seconds < time2.Seconds);
            }

            public static bool operator >(Time time1, Time time2)
            {
                return time1.Hours > time2.Hours || (time1.Hours == time2.Hours && time1.Minutes > time2.Minutes) || (time1.Hours == time2.Hours && time1.Minutes == time2.Minutes && time1.Seconds > time2.Seconds);

            }
            public static bool operator <=(Time time1, Time time2)
            {
                return time1 == time2 || time1 < time2;
            }
            public static bool operator >=(Time time1, Time time2)
            {
                return time1 == time2 || time1 > time2;
            }
        }
    }
}
