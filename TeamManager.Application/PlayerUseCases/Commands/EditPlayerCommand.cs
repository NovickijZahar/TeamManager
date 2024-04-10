using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.PlayerUseCases.Commands
{
    public sealed record EditPlayerCommand(string Country, int Points, 
        int? TeamId, Player Player) : IRequest<Player>
    {
    }
}
