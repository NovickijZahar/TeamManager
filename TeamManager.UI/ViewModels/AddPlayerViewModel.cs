using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.App.PlayerUseCases.Commands;
using TeamManager.App.TeamUseCases.Queries;

namespace TeamManager.UI.ViewModels
{
    public partial class AddPlayerViewModel : ObservableObject, INotifyPropertyChanged
    {
        private readonly IMediator _mediator;

        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            set 
            {
                if (playerName != value)
                {
                    playerName = value;
                    OnPropertyChanged(nameof(PlayerName));
                    OnPropertyChanged(nameof(IsReady));
                }
            }
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
        private DateTime dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set 
            {
                if (dateOfBirth != value)
                {
                    dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                }
            }
        }

        public DateTime MaximumDate { get { return DateTime.Now; } }

        public bool IsReady
        {
            get
            {
                return Country != null && PlayerName != null &&
                    Country != string.Empty && PlayerName != string.Empty && SelectedTeam != null;
            }
        }

        public ObservableCollection<Team> Teams { get; set; } = new();
        
        Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set 
            {
                if (selectedTeam != value)
                {
                    selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                    OnPropertyChanged(nameof(IsReady));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddPlayerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [RelayCommand]
        public async Task AddPlayer() => await Add();
        [RelayCommand]
        async Task UpdateGroupList() => await GetTeams();
        public async Task Add()
        {
            await _mediator.Send(new AddPlayerCommand(PlayerName, DateOfBirth, Country, Points, SelectedTeam.Id));
        }
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
    }
}
