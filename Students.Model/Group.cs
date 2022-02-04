using System.Collections.Generic;

#nullable disable

namespace Students.Model
{
    public partial class Group
    {
        public Group()
        {
            TabStudents = new HashSet<Student>();
            TabTeachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> TabStudents { get; set; }
        public virtual ICollection<Teacher> TabTeachers { get; set; }
    }
}
