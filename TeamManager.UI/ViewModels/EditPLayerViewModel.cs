using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamManager.App.PlayerUseCases.Commands;
using TeamManager.App.TeamUseCases.Queries;

namespace TeamManager.UI.ViewModels
{
    public partial class EditPlayerViewModel : ObservableObject, IQueryAttributable, INotifyPropertyChanged
    {
        public Player Player { get; set; }

        private readonly IMediator _mediator;

        public EditPlayerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                    OnPropertyChanged(nameof(IsReady));
                }
            }
        }
        private int points;
        public int Points
        {
            get { return points; }
            set
            {
                if (points != value)
                {
                    points = value;
                    OnPropertyChanged(nameof(Points));
                }
            }
        }
        private Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (selectedTeam != value)
                {
                    selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                }
            }
        }

        private bool isReady;
        public bool IsReady
        {
            get { return Country != string.Empty; }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Player = query["Player"] as Player;
            OnPropertyChanged(nameof(Player));
            Country = Player.Country;
            Points = (int)Player.Points;
        }
        public ObservableCollection<Team> Teams { get; set; } = new();


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [RelayCommand]
        async Task UpdateGroupList() => await GetTeams();
        [RelayCommand]
        async Task UpdateMember() => await Update();
        public async Task Update()
        {
            await _mediator.Send(new EditPlayerCommand(Country, Points, SelectedTeam.Id, Player));
        }
        public async Task GetTeams()
        {
            var teams = await _mediator.Send(new GetAllTeamsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Teams.Clear();
                foreach (var team in teams)
                    Teams.Add(team);
                SelectedTeam = teams.FirstOrDefault(team => team.Id == Player.TeamId);
            });
        }
    }
}
