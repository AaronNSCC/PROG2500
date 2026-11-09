using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ChinookMusicApp.Models;

using ChinookMusicApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ChinookMusicApp.ViewModels;

public class ArtistsViewModel : ViewModelBase
{
    private readonly ChinookContext context;

    public ObservableCollection<Artist> Artists { get; }

    // helper method to load all artists- sorted by name 
    private void LoadArtists()
    {
        // loads all artists (.Where() will filter out whatever doesn't contain the SearchText)
        var artists = context.Artists
            .Include(a => a.Albums)
            // intentionally using .Contains instead of StartsWith- I could search "peas" to get Black Eyed Peas for ex.
            .Where(a => a.Name != null && a.Name.Contains(SearchText))  // blank SearchText will match every name
            .OrderBy(a => a.Name)
            .ToList();

        Artists.Clear();            // start from empty list
        foreach (var artist in artists)
        {
            Artists.Add(artist);    // loop and add each artist 
        }
        OnPropertyChanged(nameof(Summary)); // summary text needs to reflect the changes
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

    public ArtistsViewModel(ChinookContext context)
    {
        this.context = context;

        Artists = new ObservableCollection<Artist>();
        TotalArtists = context.Artists.Count();
        LoadArtists();
    }
}
