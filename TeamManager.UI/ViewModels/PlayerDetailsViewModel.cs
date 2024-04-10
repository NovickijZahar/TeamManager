using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using TeamManager.App.TeamUseCases.Queries;
using TeamManager.UI.Pages;

namespace TeamManager.UI.ViewModels
{
    
    public partial class PlayerDetailsViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public Player Player { get; set; }
        public ICommand DeletePhotoCommand { get; private set; }
        public ICommand AddPhotoCommand { get; private set; }
        private readonly IMediator _mediator;
        public PlayerDetailsViewModel(IMediator mediator)
        {
            DeletePhotoCommand = new Command(Delete_Photo);
            AddPhotoCommand = new Command(async () => await Add_Photo());
            _mediator = mediator;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Player = query["Player"] as Player;
            OnPropertyChanged(nameof(Player));
            Id = Player.Id;
            Age = (new DateTime(1, 1, 1) + (DateTime.Now - Player.PersonalData.DateOfBirth)).Year - 1;
            var teams = await _mediator.Send(new GetAllTeamsRequest());
            TeamName = teams.FirstOrDefault(team => team.Id == Player.TeamId).Name;
        }
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
                }
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value; 
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [RelayCommand]
        async Task ShowEditPlayer(Player player) => await GoToEditPlayerPage(player);

        public async Task GoToEditPlayerPage(Player player)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "Player", player }
                    };
            await Shell.Current.GoToAsync(nameof(EditPlayer), parameters);
        }
        private async Task Add_Photo()
        {
            var res = await FilePicker.PickAsync(new PickOptions{
                                                FileTypes = FilePickerFileType.Images});
            string localFilePath = "C:\\Users\\Zahar\\source\\repos\\TeamManager\\TeamManager.UI\\Images";
            localFilePath = System.IO.Path.Combine(localFilePath, $"{Id}.png");
            if (res != null)
            {
                using Stream sourceStream = await res.OpenReadAsync();
                if (File.Exists(localFilePath))
                {
                    File.Delete(localFilePath);
                }
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
            }
            OnPropertyChanged(nameof(Id));
        }
        private void Delete_Photo()
        {
            string localFilePath = "C:\\Users\\Zahar\\source\\repos\\TeamManager\\TeamManager.UI\\Images";
            localFilePath = System.IO.Path.Combine(localFilePath, $"{Id}.png");
            if (File.Exists(localFilePath))
            {
                File.Delete(localFilePath);
            }
            OnPropertyChanged(nameof(Id));
        }
    }
}
