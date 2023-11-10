namespace TestProj1
{
    [TestFixture] //group of methods
    public class Tests
    {
        [SetUp]
        //Non executable.every method which should be called during the starting for eg: refresh every time
        public void Init()
        {
            Console.WriteLine("Setup method");
        }

        [Test] // one method
        [Order(1)]
        public void SecondTest()
        {
            Console.WriteLine("Test1 method");
           Assert.AreEqual(1, 1);  //assert for checking certain conditions are equal
           // donot write more than one assert in a single test method.
        }

        [Ignore("Incomplete code")]
        [Test]
        [Order(2)]
        public void FirstTest()
        {
            Console.WriteLine("Test2 method");
            Assert.That(1.Equals(1));   
        }

        [Test]
        [Order(3)]
        public void ThirdTest()
        {
            Console.WriteLine("Test2 method");
            Assert.That(1.Equals(1));
        }

        //[TearDown]
        ////Non executable.
        //public void Close()
        //{
        //    Console.WriteLine("Close method");

        //}

        [OneTimeTearDown]
        //Non executable.
        public void Close1()
        {
            Console.WriteLine("Close method");

        }

    }
}