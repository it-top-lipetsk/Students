using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Students.App.Components;
using Students.Model;

namespace Students.App
{
    public partial class MainWindow : Window
    {
        public Student Student { get; set; }
        public MainWindow(Account account)
        {
            Student = account.Person.TabStudents.First(s => s.Person == account.Person);
            
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
            active.Content = new StudentUI(Student);
            
            TabControl_User.SelectedItem = active;
            foreach (var item in notActives)
            {
                item.IsEnabled = false;
            }
        }
    }
}