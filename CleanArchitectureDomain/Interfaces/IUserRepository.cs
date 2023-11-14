using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureDomain.Entities;

namespace CleanArchitectureDomain.Interfaces
{
    public interface IUserRepository
    {
        User? GetUser(int id);

        List<User> GetList(DateTime? From = null, DateTime? To = null);
    }
}