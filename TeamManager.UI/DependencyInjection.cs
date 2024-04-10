using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.App.PlayerUseCases.Commands;
using TeamManager.App.TeamUseCases.Commands;
using TeamManager.UI.Pages;
using TeamManager.UI.ViewModels;

namespace TeamManager.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<Teams>()
                .AddTransient<PlayerDetails>()
                .AddTransient<AddPlayer>()
                .AddTransient<AddTeam>()
                .AddTransient<EditPlayer>();
            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<TeamsViewModel>()
                .AddTransient<PlayerDetailsViewModel>()
                .AddTransient<AddPlayerViewModel>()
                .AddTransient<AddTeamViewModel>()
                .AddTransient<EditPlayerViewModel>();
            return services;
        }
    }
}
