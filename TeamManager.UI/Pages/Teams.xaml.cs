using TeamManager.Persistence.Data;
using TeamManager.UI.ViewModels;

namespace TeamManager.UI.Pages;

public partial class Teams : ContentPage
{
    public Teams(TeamsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

}