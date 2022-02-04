#nullable disable

namespace Students.Model
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Person Person { get; set; }
    }
}
