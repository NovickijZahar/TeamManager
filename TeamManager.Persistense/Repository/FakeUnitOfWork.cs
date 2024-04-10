using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Persistence.Data;

namespace TeamManager.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Team>> _fakeTeamRepository;
        private readonly Lazy<IRepository<Player>> _fakePlayerRepository;

        public FakeUnitOfWork(/*AppDbContext context*/)
        {
            //_context = context;
            _fakeTeamRepository = new Lazy<IRepository<Team>>(() =>
                new FakeTeamRepository());
            _fakePlayerRepository = new Lazy<IRepository<Player>>(() =>
                new FakePlayerRepository());
        }

        public IRepository<Team> TeamRepository => _fakeTeamRepository.Value;
        public IRepository<Player> PlayerRepository => _fakePlayerRepository.Value;
        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
