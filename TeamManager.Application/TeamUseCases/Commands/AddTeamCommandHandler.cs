using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.TeamUseCases.Commands
{
    internal class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, Team>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTeamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Team> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            Team newTeam = new Team(request.Name, request.Country, request.CreatedDate);
            newTeam.Id = _unitOfWork.TeamRepository.ListAllAsync().Result.Count + 1;
            await _unitOfWork.TeamRepository.AddAsync(newTeam);
            return newTeam;
        }
    }
}
