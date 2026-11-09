using ChinookMusicApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace ChinookMusicApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private object currentViewModel;
    public object CurrentViewModel
    {
        get => currentViewModel;
        set => SetProperty(ref currentViewModel, value);
    }
    public ICommand ShowHomeCommand { get; }
    public ICommand ShowArtistsCommand { get; }
    public ICommand ShowAlbumsCommand { get; }
    public ICommand ShowTracksCommand { get; }
    public ICommand ExitCommand { get; }

    public MainViewModel(HomeViewModel home, ArtistsViewModel artists,
                         AlbumsViewModel albums, TracksViewModel tracks)
    {
        currentViewModel = home;
        ShowHomeCommand = new RelayCommand(() => CurrentViewModel = home);
        ShowArtistsCommand = new RelayCommand(() => CurrentViewModel = artists);
        ShowAlbumsCommand = new RelayCommand(() => CurrentViewModel = albums);
        ShowTracksCommand = new RelayCommand(() => CurrentViewModel = tracks);

        ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
    }
}
