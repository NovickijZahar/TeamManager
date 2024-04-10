using TeamManager.UI.Pages;
using TeamManager.UI.ViewModels;

namespace TeamManager.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlayerDetails), typeof(PlayerDetails));
            Routing.RegisterRoute(nameof(AddPlayer), typeof(AddPlayer));
            Routing.RegisterRoute(nameof(AddTeam), typeof(AddTeam));
            Routing.RegisterRoute(nameof(EditPlayer), typeof(EditPlayer));
        }
    }
}
