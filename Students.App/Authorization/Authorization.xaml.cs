using System.Linq;
using System.Windows;
using Students.DB_Lib;

namespace Students.App.Authorization
{
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void ButtonAuth_OnClick(object sender, RoutedEventArgs e)
        {
            var login = InputLogin.Text;
            var password = InputPassword.Password;

            var db = new DbStudents();
            var account = db.TabAccounts.FirstOrDefault(a => a.Login == login && a.Password == password);

            if (account is null)
            {
                MessageBox.Show("Неправильно ввели логин и пароль!", "!!! ERROR !!!");
            }
            else
            {
                MessageBox.Show("Добро пожаловать!");
                var main = new MainWindow(account);
                main.Show();
                Close();
            }
            
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            InputLogin.Clear();
            InputPassword.Clear();
        }
    }
}