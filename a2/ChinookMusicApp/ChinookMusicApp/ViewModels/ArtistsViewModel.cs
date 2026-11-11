using ChinookMusicApp.Data;
using ChinookMusicApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChinookMusicApp.ViewModels;

public class ArtistsViewModel : ViewModelBase
{
    private readonly ChinookContext context;    // handed in from App.OnStartup in App.xaml.cs

    public ObservableCollection<Artist> Artists { get; }
    public ICommand ResetCommand { get; }

    // helper method to load all artists- sorted by name and sort the user selected
    private void LoadArtists()
    {
        // building the query matching artists with their albums
        var query = context.Artists
            .Include(a => a.Albums)
            // intentionally using .Contains instead of StartsWith- I could search "peas" to get Black Eyed Peas for ex.
            .Where(a => a.Name != null && a.Name.Contains(SearchText));  // blank SearchText will match every name

        // user picks the sorting method 
        if (SelectedSort == "Name (Z-A)") { query = query.OrderByDescending(a => a.Name); }
        else if (SelectedSort == "Albums (desc)") { query = query.OrderByDescending(a => a.Albums.Count).ThenBy(a => a.Name); }
        else if (SelectedSort == "Albums (asc)") { query = query.OrderBy(a => a.Albums.Count).ThenBy(a => a.Name); }
        else { query = query.OrderBy(a => a.Name); }

        var artists = query.ToList();

        Artists.Clear();            // start from empty list
        foreach (var artist in artists)
        {
            Artists.Add(artist);    // loop and add each artist 
        }
        OnPropertyChanged(nameof(Summary)); // summary text needs to reflect the changes
    }

    private void Reset()
    {
        SearchText = "";                // clears the search box and reloads
        SelectedSort = "Name (A-Z)";    // resets the dropdown and reloads
    }

    private string searchText = "";
    public string SearchText
    {
        get => searchText;
        set
        {
            if (SetProperty(ref searchText, value))
                LoadArtists();
        }
    }

    // counted once (every artist)
    public int TotalArtists { get; }

    // recalculated whenever the UI reads it - LoadArtists announces when it changes
    public string Summary
    {
        get
        {
            return $"Total artists: {TotalArtists}      Matching artists: {Artists.Count}";
        }
    }

    // choices dropdown
    public List<string> SortOptions { get; } = new List<string>
    {
        "Name (A-Z)", "Name (Z-A)", "Albums (desc)", "Albums (asc)"
    };
    private string selectedSort = "Name (A-Z)";
    public string SelectedSort
    {
        get => selectedSort;
        set
        {
            if (SetProperty(ref selectedSort, value))
                LoadArtists();
        }
    }

    public ArtistsViewModel(ChinookContext context)
    {
        this.context = context;

        ResetCommand = new RelayCommand(Reset);

        Artists = new ObservableCollection<Artist>();
        TotalArtists = context.Artists.Count();
        LoadArtists();
    }
}
