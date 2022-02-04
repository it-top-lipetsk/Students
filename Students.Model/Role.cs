using System.Collections.Generic;

#nullable disable

namespace Students.Model
{
    public partial class Role
    {
        public Role()
        {
            TabAccountRoles = new HashSet<AccountRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccountRole> TabAccountRoles { get; set; }
    }
}
