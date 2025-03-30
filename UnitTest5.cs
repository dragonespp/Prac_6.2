using Microsoft.VisualStudio.TestTools.UnitTesting;
using Курсовая;
using Курсовая.Data;
using Курсовая.Models;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void RegisterTestSuccess()
        {
            // Arrange
            string newUsername = "test_user_" + Guid.NewGuid().ToString()[..8]; // Уникальное имя
            string newPassword = "TestPass123";
            string confirmPassword = "TestPass123";
            string role = "Игрок";

            // Act & Assert
            bool registrationResult = ExecuteInSTAThread(() =>
            {
                using (var db = new FootballClubContext())
                {
                    // Удаляем пользователя, если он существует
                    var existingUser = db.Users.FirstOrDefault(u => u.Username == newUsername);
                    if (existingUser != null)
                    {
                        db.Users.Remove(existingUser);
                        db.SaveChanges();
                    }

                    var regWindow = new RegistrationWindow();
                    return regWindow.Register(newUsername, newPassword, confirmPassword, role);
                }
            });

            // Assert
            Assert.IsTrue(registrationResult, "Регистрация должна быть успешной");

            using (var db = new FootballClubContext())
            {
                var addedUser = db.Users.FirstOrDefault(u => u.Username == newUsername);
                Assert.IsNotNull(addedUser, "Пользователь должен быть добавлен в базу данных");
                Assert.AreEqual(newPassword, addedUser.Password, "Пароль должен совпадать");
                Assert.AreEqual(role, addedUser.Role, "Роль должна быть правильной");
            }
        }

        [TestMethod]
        public void RegisterTestFailure_UserExists()
        {
            // Arrange
            string existingUsername = "existing_user_" + Guid.NewGuid().ToString()[..8];
            string password = "Pass123";
            string confirmPassword = "Pass123";
            string role = "Тренер";

            // Создаем пользователя заранее
            using (var db = new FootballClubContext())
            {
                if (!db.Users.Any(u => u.Username == existingUsername))
                {
                    db.Users.Add(new User { Username = existingUsername, Password = password, Role = role });
                    db.SaveChanges();
                }
            }

            // Act & Assert
            bool registrationResult = ExecuteInSTAThread(() =>
            {
                var regWindow = new RegistrationWindow();
                return regWindow.Register(existingUsername, password, confirmPassword, role);
            });

            // Assert
            Assert.IsFalse(registrationResult, "Регистрация должна провалиться, если пользователь уже существует");
        }

        private static T ExecuteInSTAThread<T>(Func<T> action)
        {
            T result = default;
            var thread = new Thread(() =>
            {
                result = action();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return result;
        }
    }
}