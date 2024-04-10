using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TeamManager.App.PlayerUseCases.Commands;
using TeamManager.App.PlayerUseCases.Queries;
using TeamManager.App.TeamUseCases.Queries;
using TeamManager.Domain.Entities;
using TeamManager.UI.Pages;

namespace TeamManager.UI.ViewModels
{
    public partial class TeamsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public TeamsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ObservableCollection<Team> Teams { get; set;} = new();
        public ObservableCollection<Player> Players { get; set;} = new();
        [ObservableProperty]
        Team selectedTeam;
        [RelayCommand]
        async Task UpdateGroupList() => await GetTeams();
        [RelayCommand]
        async Task UpdateMemberList() => await GetPlayers();
        [RelayCommand]
        async Task ShowDetails(Player player) => await GoToDetailsPage(player);
        [RelayCommand]
        async Task ShowAddPlayer() => await GoToAddPlayer();
        [RelayCommand]
        async Task ShowAddTeam() => await GoToAddTeam();
        public async Task GetTeams()
        {
            var teams = await _mediator.Send(new GetAllTeamsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Teams.Clear();
                foreach (var team in teams)
                    Teams.Add(team);
            });
        }
        public async Task GetPlayers()
        {
            Players.Clear();
            if (SelectedTeam != null)
            {
                var players = await _mediator.Send(new GetPlayersByGroupRequest(SelectedTeam.Id));
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    foreach(var player in players)
                        Players.Add(player);
                });
            }
        }
        public async Task GoToDetailsPage(Player player)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "Player", player }
                    };
            await Shell.Current.GoToAsync(nameof(PlayerDetails), parameters);
        }
        public async Task GoToAddPlayer()
        {
            await Shell.Current.GoToAsync(nameof(AddPlayer));
        }
        public async Task GoToAddTeam()
        {
            await Shell.Current.GoToAsync(nameof(AddTeam));
        }
    }
}
