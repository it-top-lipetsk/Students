using System;
using System.Collections.Generic;

#nullable disable

namespace Students.Model
{
    public partial class Person
    {
        public Person()
        {
            TabStudents = new HashSet<Student>();
            TabTeachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }

        public virtual Account IdNavigation { get; set; }
        public virtual ICollection<Student> TabStudents { get; set; }
        public virtual ICollection<Teacher> TabTeachers { get; set; }
    }
}
