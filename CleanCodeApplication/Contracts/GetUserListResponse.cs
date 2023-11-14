using CleanArchitectureApplication.Models;
using CleanArchitectureDomain.Entities;

namespace CleanArchitectureApplication.Contracts
{
    // OUTPUT del handler
    public class GetUserListResponse
    {
        public List<UserDto> UserList { get; set; } = new List<UserDto>();
    }
}