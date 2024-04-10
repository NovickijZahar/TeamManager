using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.PlayerUseCases.Commands
{
    internal class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, Player>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPlayerCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Player> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            Player newPlayer = new Player(new Person(request.Name, request.DateOfBirth), 
                request.Country, request.Points);
            if (request.TeamId.HasValue)
            {
                newPlayer.AddToTeam(request.TeamId.Value);
            }
            newPlayer.Id = _unitOfWork.PlayerRepository.ListAllAsync().Result.Count + 1;
            await _unitOfWork.PlayerRepository.AddAsync(newPlayer, cancellationToken);
            return newPlayer;
        }
    }
}
