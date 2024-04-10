using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Team> TeamRepository { get; }
        IRepository<Player> PlayerRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
