using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.TeamUseCases.Commands
{
    public sealed record AddTeamCommand(string Name, string Country,
        DateTime CreatedDate) : IRequest<Team>
    {
    }
}
