using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Persistence.Data;

namespace TeamManager.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Team>> _teamRepository;
        private readonly Lazy<IRepository<Player>> _playerRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _teamRepository = new Lazy<IRepository<Team>>(() =>
                new EfRepository<Team>(context));
            _playerRepository = new Lazy<IRepository<Player>>(() => 
                new EfRepository<Player>(context));
        }

        public IRepository<Team> TeamRepository => _teamRepository.Value;
        public IRepository<Player> PlayerRepository => _playerRepository.Value;
        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
