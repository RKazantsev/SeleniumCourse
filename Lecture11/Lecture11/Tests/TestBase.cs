using NUnit.Framework;

namespace Lecture11
{
    public class TestBase
    {       
        protected PageManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new PageManager();
            manager.Navigator
                .GoToHomePage()
                .WaitMainPageLoaded();           
        }

        [TearDown]
        public void Stop()
        {
            manager.Stop();
        }
    }
}