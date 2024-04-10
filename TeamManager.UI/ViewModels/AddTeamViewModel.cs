using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.App.TeamUseCases.Commands;

namespace TeamManager.UI.ViewModels
{
    public partial class AddTeamViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;

        private string teamName;
        public string TeamName
        {
            get { return teamName; }
            set
            {
                if (teamName != value)
                {
                    teamName = value;
                    OnPropertyChanged(nameof(TeamName));
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
        private DateTime createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set
            {
                if (createdDate != value)
                {
                    createdDate = value;
                    OnPropertyChanged(nameof(CreatedDate));
                }
            }
        }

        public DateTime MaximumDate { get { return DateTime.Now; } }

        public bool IsReady
        {
            get { return Country != null && TeamName != null &&
                    Country != string.Empty && TeamName != string.Empty; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddTeamViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [RelayCommand]
        public async Task AddTeam() => await Add();
        public async Task Add()
        {
            await _mediator.Send(new AddTeamCommand(TeamName, Country, CreatedDate));
        }

    }
}
