using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.PlayerUseCases.Commands
{
    public sealed record AddPlayerCommand(string Name, DateTime DateOfBirth, 
        string Country, int Points, int?TeamId) : IRequest<Player>
    {
    }
}
