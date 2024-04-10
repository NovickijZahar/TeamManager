using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App.PlayerUseCases.Queries
{
    internal class GetPlayersByGroupRequestHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetPlayersByGroupRequest, IEnumerable<Player>>
    {
        public async Task<IEnumerable<Player>> Handle(GetPlayersByGroupRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PlayerRepository.ListAsync(t => t.TeamId.Equals(request.Id), cancellationToken);
        }
    }
}
