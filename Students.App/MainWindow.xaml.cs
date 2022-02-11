using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Students.Model;

namespace Students.App
{
    public partial class MainWindow : Window
    {
        public Account Account { get; set; }
        public MainWindow(Account account)
        {
            InitializeComponent();

            var role = account.TabAccountRoles.First().Role;
            switch (role.Name)
            {
                case "student":
                    SetTabItemSelected(TabItem_Student, TabItem_Admin, TabItem_Teacher);
                    break;
                case "teacher":
                    SetTabItemSelected(TabItem_Teacher, TabItem_Admin, TabItem_Student);
                    break;
                case "admin":
                    SetTabItemSelected(TabItem_Admin, TabItem_Teacher, TabItem_Student);
                    break;
            }

        }

        private void SetTabItemSelected(TabItem active, params TabItem[] notActives)
        {
            TabControl_User.SelectedItem = active;
            foreach (var item in notActives)
            {
                item.IsEnabled = false;
            }
        }
    }
}