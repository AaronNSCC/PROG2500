using System.Configuration;
using System.Data;
using System.Windows;
using ChinookMusicApp.Data;
using ChinookMusicApp.ViewModels;

namespace ChinookMusicApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var context = new ChinookContext();

        var home = new HomeViewModel();
        var artists = new ArtistsViewModel(context);
        var albums = new AlbumsViewModel(context);
        var tracks = new TracksViewModel(context);

        var main = new MainViewModel(home, artists, albums, tracks);
        var window = new MainWindow { DataContext = main };
        window.Show();

    }
}
