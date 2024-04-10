using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.TeamUseCases.Queries
{
    public sealed record GetAllTeamsRequest : IRequest<IEnumerable<Team>>
    {
    }
}
