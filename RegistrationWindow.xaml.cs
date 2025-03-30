using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Курсовая.Data;
using Курсовая.Models;

namespace Курсовая
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        public bool Register(string username, string password, string confirmPassword, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(role))
            {
                return false; // Поля не заполнены
            }

            if (password != confirmPassword)
            {
                return false; // Пароли не совпадают
            }

            using (var db = new FootballClubContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    return false; // Пользователь уже существует
                }

                var newUser = new User { Username = username, Password = password, Role = role };
                db.Users.Add(newUser);
                db.SaveChanges();
                return true; // Регистрация успешна
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();



            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            try
            {
                using (var db = new FootballClubContext())
                {
                    if (db.Users.Any(u => u.Username == username))
                    {
                        MessageBox.Show("Пользователь с таким именем уже существует!");
                        return;
                    }

                    var newUser = new User
                    {
                        Username = username,
                        Password = password,
                        Role = role
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();
                    MessageBox.Show("Регистрация успешна!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.InnerException?.Message ?? ex.Message}");
            }

        }
    }
}
