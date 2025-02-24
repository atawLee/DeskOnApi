using System.Threading.Tasks;
using System.Windows.Input;
using API;
using CommunityToolkit.Mvvm.Input;

namespace DeskAppOnAPI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public ICommand ApiStartCommand { get; init; }

    public MainWindowViewModel()
    {
        ApiStartCommand = new AsyncRelayCommand(StartApi);
    }

    private async Task StartApi()
    {
        ApiStarter starter = new();
        await starter.StartApi();
    }
}