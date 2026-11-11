using ChinookMusicApp.Data;
using ChinookMusicApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChinookMusicApp.ViewModels;

// --------- Same pattern as ArtistsViewModel, for albums ------------

public class AlbumsViewModel : ViewModelBase
{
    private readonly ChinookContext context; // handed in from App.OnStartup in App.xaml.cs

    public ObservableCollection<Album> Albums { get; }
    public ICommand ResetCommand { get; }

    // helper method to load all albums- sorted by title and sort the user selected
    private void LoadAlbums()
    {
        // building the query matching albums with their artists and tracks
        var query = context.Albums
            .Include(a => a.Artist)
            .Include(a => a.Tracks)
            // intentionally using .Contains instead of StartsWith
            .Where(a => a.Title.Contains(SearchText));  // blank SearchText will match every title

        // user picks the sorting method 
        if (SelectedSort == "Title (Z-A)") { query = query.OrderByDescending(a => a.Title); }
        else if (SelectedSort == "Tracks (desc)") { query = query.OrderByDescending(a => a.Tracks.Count).ThenBy(a => a.Title); }
        else if (SelectedSort == "Tracks (asc)") { query = query.OrderBy(a => a.Tracks.Count).ThenBy(a => a.Title); }
        else if (SelectedSort == "Artist (A-Z)") { query = query.OrderBy(a => a.Artist.Name).ThenBy(a => a.Title); }
        else { query = query.OrderBy(a => a.Title); }

        var albums = query.ToList();

        Albums.Clear();            // start from empty list
        foreach (var album in albums)
        {
            Albums.Add(album);    // loop and add each album 
        }
        OnPropertyChanged(nameof(Summary)); // summary text needs to reflect the changes
    }

    private void Reset()
    {
        SearchText = "";                 // clears the search box and reloads
        SelectedSort = "Title (A-Z)";    // resets the dropdown and reloads
    }

    private string searchText = "";
    public string SearchText
    {
        get => searchText;
        set
        {
            if (SetProperty(ref searchText, value))
                LoadAlbums();
        }
    }

    // counted once (every album)
    public int TotalAlbums { get; }

    // recalculated whenever the UI reads it - LoadAlbums announces when it changes
    public string Summary
    {
        get
        {
            return $"Total albums: {TotalAlbums}      Matching albums: {Albums.Count}";
        }
    }

    // choices dropdown
    public List<string> SortOptions { get; } = new List<string>
    {
        "Title (A-Z)", "Title (Z-A)", "Tracks (desc)", "Tracks (asc)", "Artist (A-Z)"
    };
    private string selectedSort = "Title (A-Z)";
    public string SelectedSort
    {
        get => selectedSort;
        set
        {
            if (SetProperty(ref selectedSort, value))
                LoadAlbums();
        }
    }

    public AlbumsViewModel(ChinookContext context)
    {
        this.context = context;

        ResetCommand = new RelayCommand(Reset);

        Albums = new ObservableCollection<Album>();
        TotalAlbums = context.Albums.Count();
        LoadAlbums();
    }
}
