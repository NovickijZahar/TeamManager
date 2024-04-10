using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Persistence.Repository
{
    public class FakePlayerRepository : IRepository<Player>
    {
        List<Player> _players = new List<Player>();

        public FakePlayerRepository()
        {
            int k = 1;  
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j <= 10; j++)
                {
                    var player = new Player(new Person($"Player {k++}",
                        DateTime.Now.AddYears(-Random.Shared.Next(30))), $"Country {k++}",
                        Random.Shared.Next(100));
                    player.AddToTeam(i);
                    _players.Add(player);
                }
        }

        public Task AddAsync(Player entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Player entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Player> FirstOrDefaultAsync(Expression<Func<Player, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Player, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Player>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Player>> ListAsync(Expression<Func<Player, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Player, object>>[]? includesProperties)
        {
            var data = _players.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task UpdateAsync(Player entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
