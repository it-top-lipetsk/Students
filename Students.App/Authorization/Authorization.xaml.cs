using System;
using System.Linq;
using System.Windows;
using Students.DB_Lib;
using Students.Model;

namespace Students.App.Authorization
{
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            Closing += ClosedWindow;
        }

        private void ClosedWindow(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Хотите выйти?", "Closed", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                //TODO Закрытие всего приложения
            }
        }

        private void ButtonAuth_OnClick(object sender, RoutedEventArgs e)
        {
            var login = InputLogin.Text;
            var password = InputPassword.Password;

            var db = new DbStudents();
            var account = db.TabAccounts.FirstOrDefault(a => a.Login == login && a.Password == password);

            MessageBox.Show(account is null ? "Неправильно ввели логин и пароль!" : "Добро пожаловать!");
        }
    }
}