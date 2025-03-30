using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Курсовая;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            bool result1 = false;
            bool result2 = false;
            bool result3 = false;
            bool result4 = false;
            bool result5 = false;
            bool result6 = false;
            bool result7 = false;

            var thread = new Thread(() =>
            {
                var page = new MainWindow();
                result1 = page.Auth("vanek", "1324");
                result2 = page.Auth("Messi", "123");
                result3 = page.Auth("ivan_petrov", "pass123");
                result4 = page.Auth("alexey_smirnov", "pass123");
                result5 = page.Auth("sergey_ivanov", "pass123");
                result6 = page.Auth("dmitry_kuznetsov", "pass123");
                result7 = page.Auth("nikolay_sidorov", "pass123");
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
            Assert.IsTrue(result5);
            Assert.IsTrue(result6);
            Assert.IsTrue(result7);
        }
    }
}
