using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая;
using Курсовая.Models;
using MSTestExtensions;


namespace TestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            bool result1 = false;
            bool result2 = false;
            bool result3 = false;
            bool result4 = false;

            var thread = new Thread(() =>
            {
                var page = new MainWindow();
                result1 = page.Auth("Messi", "123");
                result2 = page.Auth("user123", "123456");
                result3 = page.Auth("", "");
                result4 = page.Auth(" ", " ");
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }


    }
}
