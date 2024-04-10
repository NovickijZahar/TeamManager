using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.PlayerUseCases.Queries
{
    public sealed record GetPlayersByGroupRequest(int Id) : IRequest<IEnumerable<Player>>
    {
        
    }
}
