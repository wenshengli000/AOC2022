using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestXTestRunner
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [TestCategory("Simple Tests")]
        public void MyTest()
        {
            Assert.IsTrue(true);
        }
    }
}