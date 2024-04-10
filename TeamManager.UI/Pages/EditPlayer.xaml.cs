using TeamManager.UI.ViewModels;

namespace TeamManager.UI.Pages;

public partial class EditPlayer : ContentPage
{
	public EditPlayer(EditPlayerViewModel editPlayerViewModel)
	{
		InitializeComponent();
		BindingContext = editPlayerViewModel;
	}

    private async void Button_Pressed(object sender, EventArgs e)
    {
        await DisplayAlert("Message", "Player data has been successfully changed", "Ok");
    }
}