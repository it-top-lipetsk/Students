using System;
using System.Windows;

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
            throw new System.NotImplementedException();
        }
    }
}