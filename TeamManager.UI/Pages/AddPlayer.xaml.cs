using TeamManager.UI.ViewModels;

namespace TeamManager.UI.Pages;

public partial class AddPlayer : ContentPage
{
	public AddPlayer(AddPlayerViewModel addPlayerViewModel)
	{
		InitializeComponent();
		BindingContext = addPlayerViewModel;
	}

    private async void Button_Pressed(object sender, EventArgs e)
    {
        await DisplayAlert("Message", "The player was added successfully", "Ok");
    }
}