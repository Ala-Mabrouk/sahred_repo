using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity_DAL.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public String RoleName { get; set; }

        public ICollection<SupportUser> Students { get; set; }
    }
}
