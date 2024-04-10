using Microsoft.Maui.Storage;
using TeamManager.UI.ViewModels;

namespace TeamManager.UI.Pages;

public partial class PlayerDetails : ContentPage
{
	public PlayerDetails(PlayerDetailsViewModel playerDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = playerDetailsViewModel;
	}

}