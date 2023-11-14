using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDomain.Entities
{
    public class Menu
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Expiration { get; set; }

        public int TypeId { get; set; }
        public Type? Type { get; set; }

        public int ProviderId { get; set; }
    }
}