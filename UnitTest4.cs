using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Курсовая;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void AuthTestFailure()
        {
            bool result1 = true;
            bool result2 = true;
            bool result3 = true;
            bool result4 = true;
            bool result5 = true;
            bool result6 = true;
            bool result7 = true;

            var thread = new Thread(() =>
            {
                var page = new MainWindow();

                result1 = page.Auth("nonexistent_user", "wrongpass"); // Несуществующий пользователь
                result2 = page.Auth("Messi", "wrongpass"); // Верный логин, но неверный пароль
                result3 = page.Auth("ivan_petrov", ""); // Верный логин, но пустой пароль
                result4 = page.Auth("", "pass123"); // Пустой логин, но верный пароль
                result5 = page.Auth("", ""); // Полностью пустые данные
                result6 = page.Auth("Messi", "   "); // Пароль из пробелов
                result7 = page.Auth("   ", "123"); // Логин из пробелов
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Авторизация не должна пройти в этих случаях
            Assert.IsFalse(result1, "Авторизация прошла для несуществующего пользователя");
            Assert.IsFalse(result2, "Авторизация прошла для неверного пароля");
            Assert.IsFalse(result3, "Авторизация прошла при пустом пароле");
            Assert.IsFalse(result4, "Авторизация прошла при пустом логине");
            Assert.IsFalse(result5, "Авторизация прошла при пустом логине и пароле");
            Assert.IsFalse(result6, "Авторизация прошла при пароле из пробелов");
            Assert.IsFalse(result7, "Авторизация прошла при логине из пробелов");
        }
    }
}
