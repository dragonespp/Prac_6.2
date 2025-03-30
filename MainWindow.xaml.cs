using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Курсовая.Data;
using Курсовая.Windows;
using Курсовая.Models;

namespace Курсовая
{
    public partial class MainWindow : Window
    {
        private string _playerName;
        private int _matchID;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Новый метод для авторизации (доступен для тестов)
        public bool Auth(string username, string password)
        {
            using (var db = new FootballClubContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    // Сохраняем данные для последующего использования
                    _playerName = user.Username;
                    _matchID = GetPlayerMatchID(user.Username);

                    MessageBox.Show($"Добро пожаловать, {user.Username}! Роль: {user.Role}");
                    OpenRoleBasedWindow(user.Role, user.Username);
                    return true;
                }
                return false;
            }
        }

        // Упрощенный обработчик кнопки входа
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth(UsernameTextBox.Text, PasswordBox.Password))
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private int GetPlayerMatchID(string playerName)
        {
            using (var db = new FootballClubContext())
            {
                return db.Squads
                    .Where(s => s.Player.FirstName + " " + s.Player.LastName == playerName)
                    .Select(s => s.MatchID)
                    .FirstOrDefault();
            }
        }

        private void OpenRoleBasedWindow(string role, string username)
        {
            int matchID = GetPlayerMatchID(username);

            Window roleWindow = role switch
            {
                "Игрок" => new PlayerWindow(username, matchID),
                "Тренер" => new CoachWindow(),
                "Медицинский персонал" => new MedicalWindow(),
                "Финансовый директор" => new FinanceWindow(),
                "Президент клуба" => new PresidentWindow(),
                "Администратор" => new AdminWindow(),
                _ => null
            };

            roleWindow?.Show();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}