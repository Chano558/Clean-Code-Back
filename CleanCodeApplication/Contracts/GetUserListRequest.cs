using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApplication.Contracts
{
    // INPUT del handler
    public class GetUserListRequest : IRequest<GetUserListResponse>
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}