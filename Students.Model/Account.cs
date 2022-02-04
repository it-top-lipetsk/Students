using System.Collections.Generic;

#nullable disable

namespace Students.Model
{
    public partial class Account
    {
        public Account()
        {
            TabAccountRoles = new HashSet<AccountRole>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<AccountRole> TabAccountRoles { get; set; }
    }
}
