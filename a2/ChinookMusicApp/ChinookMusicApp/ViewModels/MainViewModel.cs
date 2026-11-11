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
        ShowHomeCommand = new RelayCommand(
            () => CurrentViewModel = home,
            // can only run if you're not currently on the home page
            () => CurrentViewModel != home);
        ShowArtistsCommand = new RelayCommand(
            () => CurrentViewModel = artists,
            // can only run if you're not currently on the artists page
            () => CurrentViewModel != artists);
        ShowAlbumsCommand = new RelayCommand(
            () => CurrentViewModel = albums,
            // can only run if you're not currently on the albums page
            () => CurrentViewModel != albums);
        ShowTracksCommand = new RelayCommand(
            () => CurrentViewModel = tracks,
            // can only run if you're not currently on the tracks page
            () => CurrentViewModel != tracks);

        ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
    }
}
