using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.App.PlayerUseCases.Queries;

namespace TeamManager.App.TeamUseCases.Queries
{
    internal class GetAllTeamsRequestHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllTeamsRequest, IEnumerable<Team>>
    {
        public async Task<IEnumerable<Team>> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.TeamRepository.ListAllAsync();
        }
    }
}
