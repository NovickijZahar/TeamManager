using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.App
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            await unitOfWork.TeamRepository.
                AddAsync(new Team("Team Liquid", "Netherlands", new DateTime(2012, 12, 6)) { Id = 1 });
            await unitOfWork.TeamRepository.
                AddAsync(new Team("Team Spirit", "Russia", new DateTime(2015, 12, 6)) { Id = 2 });
            await unitOfWork.TeamRepository.
                AddAsync(new Team("Wings", "China", new DateTime(2017, 4, 19)) { Id = 3 });
            await unitOfWork.TeamRepository.
                AddAsync(new Team("B8", "Ukraine", new DateTime(2020, 1, 27)) { Id = 4 });
            await unitOfWork.TeamRepository.
                AddAsync(new Team("Outsiders", "Belarus", new DateTime(2023, 6, 26)) { Id = 5});

            await unitOfWork.SaveAllAsync();


            var player = new Player(new Person("Matumbaman", new DateTime(1997, 6, 20)),
                "Finland", Random.Shared.Next(100)) { Id = 1 };
            player.AddToTeam(1);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Miracle", new DateTime(1995, 3, 3)),
                "Jordan", Random.Shared.Next(100)) { Id = 2 };
            player.AddToTeam(1);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Mind Control", new DateTime(1995, 1, 20)),
                "Bulgaria", Random.Shared.Next(100)) {Id = 3};
            player.AddToTeam(1);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("GH", new DateTime(1995, 6, 17)),
                "Lebanon", Random.Shared.Next(100)) {Id = 4};
            player.AddToTeam(1);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("KuroKy", new DateTime(1992, 10, 28)),
                "Germany", Random.Shared.Next(100)) {Id = 5};
            player.AddToTeam(1);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Yatoro", new DateTime(2003, 3, 12)),
                "Ukraine", Random.Shared.Next(100)) {Id = 6};
            player.AddToTeam(2);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("TORONTOTOKYO", new DateTime(1997, 4, 30)),
               "Russia", Random.Shared.Next(100)) {Id = 7};
            player.AddToTeam(2);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Collapse", new DateTime(2002, 2, 25)),
               "Russia", Random.Shared.Next(100)) { Id = 8 };
            player.AddToTeam(2);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Mira", new DateTime(1999, 11, 3)),
               "Ukraine", Random.Shared.Next(100)) {Id = 9};
            player.AddToTeam(2);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Miposhka", new DateTime(1997, 11, 30)),
               "Russia", Random.Shared.Next(100)){ Id = 10 };
            player.AddToTeam(2);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Shadow", new DateTime(1997, 3, 21)),
               "China", Random.Shared.Next(100)) {Id = 11};
            player.AddToTeam(3);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("bLink", new DateTime(1992, 7, 31)),
               "China", Random.Shared.Next(100)) {Id = 12};
            player.AddToTeam(3);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Faith_bian", new DateTime(1998, 3, 21)),
               "China", Random.Shared.Next(100)) {Id = 13};
            player.AddToTeam(3);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("y`", new DateTime(1998, 8, 8)),
               "China", Random.Shared.Next(100)) {Id = 14};
            player.AddToTeam(3);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("iceice", new DateTime(1995, 9, 11)),
               "China", Random.Shared.Next(100)) {Id = 15};
            player.AddToTeam(3);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("V-Tune", new DateTime(2000, 8, 11)),
               "Ukraine", Random.Shared.Next(100)) {Id = 16};
            player.AddToTeam(4);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Dendi", new DateTime(1989, 12, 30)),
               "Ukraine", Random.Shared.Next(100)) {Id = 17};
            player.AddToTeam(4);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("StoneBank", new DateTime(1999, 11, 10)),
               "Ukraine", Random.Shared.Next(100)) {Id = 18};
            player.AddToTeam(4);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Stomanen1", new DateTime(1995, 1, 1)),
               "Bulgaria", Random.Shared.Next(100)) {Id = 19};
            player.AddToTeam(4);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Kidaro", new DateTime(1998, 9, 1)),
               "Ukraine", Random.Shared.Next(100)) {Id = 20};
            player.AddToTeam(4);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("EthEnj", new DateTime(2005, 2, 21)),
               "Belarus", Random.Shared.Next(100)) {Id = 21};
            player.AddToTeam(5);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Toilet", new DateTime(2004, 6, 2)),
               "Belarus", Random.Shared.Next(100)) {Id = 22};
            player.AddToTeam(5);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Pavlusha", new DateTime(2005, 8, 12)),
               "Belarus", Random.Shared.Next(100)) {Id = 23};
            player.AddToTeam(5);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Cheliks", new DateTime(2017, 9, 28)),
               "Belarus", Random.Shared.Next(100)) {Id = 24};
            player.AddToTeam(5);
            await unitOfWork.PlayerRepository.AddAsync(player);

            player = new Player(new Person("Moonlight", new DateTime(2012, 9, 16)),
               "USA", Random.Shared.Next(100)) {Id = 25};
            player.AddToTeam(5);
            await unitOfWork.PlayerRepository.AddAsync(player);

            await unitOfWork.SaveAllAsync();
        }
    }
}
