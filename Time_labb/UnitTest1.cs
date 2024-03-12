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
    }
}