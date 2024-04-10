using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.App.PlayerUseCases.Commands;

namespace TeamManager.App.PlayerUseCases.Commands
{
    internal class EditPlayerCommandHandler : IRequestHandler<EditPlayerCommand, Player>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditPlayerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Player> Handle(EditPlayerCommand request, CancellationToken cancellationToken)
        {
            Player newPlayer = await _unitOfWork.PlayerRepository.GetByIdAsync(request.Player.Id);
            if (request.TeamId.HasValue)
            {
                newPlayer.AddToTeam(request.TeamId.Value);
            }
            newPlayer.Points = request.Points;
            newPlayer.Country = request.Country;

            await _unitOfWork.PlayerRepository.UpdateAsync(newPlayer, cancellationToken);
            return newPlayer;
        }
    }
}
