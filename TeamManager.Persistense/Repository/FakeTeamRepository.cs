using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Persistence.Repository
{
    public class FakeTeamRepository : IRepository<Team>
    {
        List<Team> _teams;

        public FakeTeamRepository()
        {
            _teams = new List<Team>();

            var team = new Team("Team Liquid", "Netherlands", new DateTime(2012, 12, 6));
            team.Id = 1;
            _teams.Add(team);
            team = new Team("Team Spirit", "Russia", new DateTime(2015, 12, 6));
            team.Id = 2;
            _teams.Add(team);
        }

        public Task AddAsync(Team entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Team entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Team> FirstOrDefaultAsync(Expression<Func<Team, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Team, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Team>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _teams);
        }

        public Task<IReadOnlyList<Team>> ListAsync(Expression<Func<Team, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Team, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Team entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
