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
        public void IsAm_AfterNoon_ReturnsFalse()
        {
            Program.Time time = new Program.Time(13, 30, 12);
            bool result = time.IsAm();

            Assert.IsFalse(result);
        }
    }
}