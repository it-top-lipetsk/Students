using System.Linq;
using System.Windows.Controls;
using Students.DB_Lib;
using Students.Model;

namespace Students.App.Components
{
    public partial class StudentUI : UserControl
    {
        public StudentUI(Student student)
        {
            InitializeComponent();
            
            DataContext = this;
            
            InitStudent(student);
        }

        private void InitStudent(Student student)
        {
            Input_LastName.Text = student.Person.LastName;
            Input_FirstName.Text = student.Person.FirstName;
            Input_DateOfBirth.Text = student.Person.DateOfBirth.ToString("d");

            switch (student.Person.Sex)
            {
                case "М":
                    Input_SexMale.IsChecked = true;
                    break;
                case "Ж":
                    Input_SexFemale.IsChecked = true;
                    break;
            }

            var db = new DbStudents();
            Select_GroupName.ItemsSource = db.TabGroups.ToList();
            Select_GroupName.SelectedItem = student.Group;
        }
    }
}