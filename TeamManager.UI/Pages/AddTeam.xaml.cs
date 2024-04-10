using TeamManager.UI.ViewModels;

namespace TeamManager.UI.Pages;

public partial class AddTeam : ContentPage
{
	public AddTeam(AddTeamViewModel addTeamViewModel)
	{
		InitializeComponent();
		BindingContext = addTeamViewModel;
	}

    private async void Button_Pressed(object sender, EventArgs e)
    {
        await DisplayAlert("Message", "The team was created successfully", "Ok");
    }
}