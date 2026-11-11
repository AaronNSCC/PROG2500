using ChinookMusicApp.Data;
using ChinookMusicApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChinookMusicApp.ViewModels;

// --------- Same pattern as ArtistsViewModel, for tracks ------------

public class TracksViewModel : ViewModelBase
{
    private readonly ChinookContext context; // handed in from App.OnStartup in App.xaml.cs

    public ObservableCollection<Track> Tracks { get; }
    public ICommand ResetCommand { get; }

    // helper method to load all tracks- sorted by name and sort the user selected
    private void LoadTracks()
    {
        // building the query matching tracks with their artists, album, genre, and duration
        var query = context.Tracks
            .Include(t => t.Album)
                .ThenInclude(a => a!.Artist)
            .Include(t => t.Genre)
            // intentionally using .Contains instead of StartsWith
            .Where(t => t.Name.Contains(SearchText));  // blank SearchText will match every title

        // user picks the sorting method 
        if (SelectedSort == "Name (Z-A)") { query = query.OrderByDescending(t => t.Name); }
        else if (SelectedSort == "Genre (A-Z)") { query = query.OrderBy(t => t.Genre!.Name).ThenBy(t => t.Name); }
        else if (SelectedSort == "Album (A-Z)") { query = query.OrderBy(t => t.Album!.Title).ThenBy(t => t.Name); }
        else if (SelectedSort == "Artist (A-Z)") { query = query.OrderBy(t => t.Album!.Artist.Name).ThenBy(t => t.Name); }
        else if (SelectedSort == "Time (longest)") { query = query.OrderByDescending(t => t.Milliseconds).ThenBy(t => t.Name); }
        else if (SelectedSort == "Time (shortest)") { query = query.OrderBy(t => t.Milliseconds).ThenBy(t => t.Name); }
        else { query = query.OrderBy(t => t.Name); }

        var tracks = query.ToList();

        Tracks.Clear();            // start from empty list
        foreach (var track in tracks)
        {
            Tracks.Add(track);    // loop and add each track 
        }
        OnPropertyChanged(nameof(Summary)); // summary text needs to reflect the changes
    }

    private void Reset()
    {
        SearchText = "";                 // clears the search box and reloads
        SelectedSort = "Name (A-Z)";     // resets the dropdown and reloads
    }

    private string searchText = "";
    public string SearchText
    {
        get => searchText;
        set
        {
            if (SetProperty(ref searchText, value))
                LoadTracks();
        }
    }

    // counted once (every track)
    public int TotalTracks { get; }

    // recalculated whenever the UI reads it - LoadTracks announces when it changes
    public string Summary
    {
        get
        {
            return $"Total tracks: {TotalTracks}      Matching tracks: {Tracks.Count}";
        }
    }

    // choices dropdown
    public List<string> SortOptions { get; } = new List<string>
    {
        "Name (A-Z)", "Name (Z-A)", "Genre (A-Z)", "Album (A-Z)", "Artist (A-Z)", "Time (shortest)", "Time (longest)"
    };
    private string selectedSort = "Name (A-Z)";
    public string SelectedSort
    {
        get => selectedSort;
        set
        {
            if (SetProperty(ref selectedSort, value))
                LoadTracks();
        }
    }

    public TracksViewModel(ChinookContext context)
    {
        this.context = context;

        ResetCommand = new RelayCommand(Reset);

        Tracks = new ObservableCollection<Track>();
        TotalTracks = context.Tracks.Count();
        LoadTracks();
    }
}
