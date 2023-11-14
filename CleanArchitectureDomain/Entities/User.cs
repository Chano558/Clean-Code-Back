using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDomain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string? Name { get; set; }
        public Role? Role { get; set; }
    }
}