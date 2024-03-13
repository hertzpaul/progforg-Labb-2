namespace Time_labb
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Isvalid_ValidTime_ReturnsStrue()
        {
            Program.Time time = new Program.Time(12, 30, 23);
            Assert.IsTrue(time.IsValid());
        }

        [Test]
        public void Isvalid_InValidHour_ReturnsFalse()
        {
            Program.Time time = new Program.Time(25, 30, 30);
            Assert.IsFalse(time.IsValid());
        }

        [Test]
        public void Isvalid_InValidMinutes_ReturnsFalse()
        {
            Program.Time time = new Program.Time(12, 63, 30);
            Assert.IsFalse(time.IsValid());
        }

        [Test]
        public void Isvalid_InValidSeconds_ReturnsFalse()
        {
            Program.Time time = new Program.Time(12, 30, 70);
            Assert.IsFalse(time.IsValid());
        }

        [Test]
        public void ToString_24HoursFormat_ReturnsCorrectFormat()
        {
            Program.Time time = new Program.Time(15, 23, 12);
            Assert.That(time.ToString(is12HourFormat: false), Is.EqualTo("15:23:12"));
        }
        [Test]
        public void ToString_12HourFormat_Am_ReturnsCorrectFormat()
        {
            Program.Time time = new Program.Time(02, 32, 01);
            Assert.That(time.ToString(is12HourFormat: true), Is.EqualTo("02:32:01 am"));
        }

        [Test]
        public void ToString_12HourFormat_Pm_ReturnsCorrectFormat()
        {
            Program.Time time = new Program.Time(14, 45, 45);
            Assert.That(time.ToString(is12HourFormat: true), Is.EqualTo("02:45:45 pm"));
        }

        [Test]
        public void IsAm_BeforeNoon_ReturnsTrue()
        {
            Program.Time time = new Program.Time(10, 30, 12);
            bool result = time.IsAm();

            Assert.IsTrue(result);
        }
        [Test]
        public void IsAm_AfterNoon_ReturnsFalse()
        {
            Program.Time time = new Program.Time(13, 30, 12);
            bool result = time.IsAm();

            Assert.IsFalse(result);
        }
        [Test]
        public void AddSeconds_PositiveValue_GeneratesFutureTime()
        {
            Program.Time currentTime = new Program.Time(10, 30, 15);

            Program.Time futureTime = currentTime + 5;

            Assert.That(futureTime.ToString(is12HourFormat:false), Is.EqualTo("10:30:20"));
        }
        [Test]
        public void SubtractSeconds_PositiveValue_GeneratesPastTime()
        {
            Program.Time currentTime = new Program.Time(10, 30, 15);
            Program.Time pastTime = currentTime - 5;

            Assert.That(pastTime.ToString(is12HourFormat: false), Is.EqualTo("10:30:10"));
        }
        [Test]
        public void SubtractSeconds_OverFlor_GeneratesPreviousDayTime()
        {
            Program.Time currentTime = new Program.Time(00, 00, 10);
            Program.Time previousDayTime = currentTime - 30;

            Assert.That(previousDayTime.ToString(is12HourFormat: false), Is.EqualTo("23:59:40"));
        }

        [Test]
        public void EqualOperator_SameTime_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(10, 30, 15);
            Program.Time time2 = new Program.Time(10, 30, 15);

            bool result = time1 == time2;

            Assert.IsTrue(result);
        }
        [Test]
        public void EqualOperator_DifferentTime_ReturnsFalse()
        {
            Program.Time time1 = new Program.Time(10, 30, 15);
            Program.Time time2 = new Program.Time(09, 30, 15);

            bool result = time1 == time2;

            Assert.IsFalse(result);
        }

        [Test]
        public void InEqualityOperator_SameTimes_ReturnsFalse()
        {
            Program.Time time1 = new Program.Time(10, 30, 15);
            Program.Time time2 = new Program.Time(10, 30, 15);

            bool result = time1 != time2;
            Assert.IsFalse(result);
        }

        [Test]
        public void InEqualityOperator_DifferentTimes_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(10, 30, 15);
            Program.Time time2 = new Program.Time(10, 20, 15);

            bool result = time1 != time2;
            Assert.IsTrue(result);
        }

        [Test]
        public void LessThanOperator_EarlierTime_ReturnsTrue()
        {
            Program.Time earlierTime = new Program.Time(10, 30, 15);
            Program.Time laterTime = new Program.Time(12, 15, 30);

            bool result = earlierTime < laterTime;
            Assert.IsTrue(result);
        }
        [Test]
        public void LessThanOperator_LaterTime_ReturnsFalse()
        {
            Program.Time earlierTime = new Program.Time(12, 15, 30);
            Program.Time laterTime = new Program.Time(10, 30, 15);

            bool result = earlierTime < laterTime;
            Assert.IsFalse(result);
        }
        [Test]
        public void GreaterThanOperatorTime1Later_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(12, 30, 20);
            Program.Time time2 = new Program.Time(12, 30, 15);

            bool result = time1 > time2;
            Assert.IsTrue(result);
        }

        [Test]
        public void GreaterThanOperatorTime2Later_ReturnsFalse()
        {
            Program.Time time1 = new Program.Time(12, 30, 20);
            Program.Time time2 = new Program.Time(13, 30, 15);

            bool result = time1 > time2;
            Assert.IsFalse(result);
        }
        [Test]
        public void LessThanOrEqualOperator_Time1Earlier_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(10, 30, 15);
            Program.Time time2 = new Program.Time(12, 30, 15);

            bool result = time1 <= time2;
            Assert.IsTrue(result);
        }
        [Test]
        public void LessThanOrEqualOperator_Time1Equal_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(12, 30, 20);
            Program.Time time2 = new Program.Time(12, 30, 20);

            bool result = time1 <= time2;
            Assert.IsTrue(result);
        }
        [Test]
        public void GreaterThanOrEqualOperator_Time1Later_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(12, 30, 20);
            Program.Time time2 = new Program.Time(12, 30, 15);

            bool result = time1 >= time2;
            Assert.IsTrue(result);
        }

        [Test]
        public void GreaterThanOrEqualOperator_TimeEqual_ReturnsTrue()
        {
            Program.Time time1 = new Program.Time(12, 30, 20);
            Program.Time time2 = new Program.Time(12, 30, 20);

            bool result = time1 >= time2;
            Assert.IsTrue(result);
        }
    }
}