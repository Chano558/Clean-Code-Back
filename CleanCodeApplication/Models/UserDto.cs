using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApplication.Models
{
    public class UserDto
    {
        public string? UserId { get; set; }

        // aca entra a la clase Role y luego toma el Nombre
        public string? RoleName { get; set; }

        public bool? RoleIsDefault { get; set; }

        public string? Name { get; set; }
    }
}