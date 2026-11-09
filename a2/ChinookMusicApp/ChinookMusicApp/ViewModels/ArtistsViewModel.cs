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

    public ArtistsViewModel(ChinookContext context)
    {
        this.context = context;

        Artists = new ObservableCollection<Artist>(
            context.Artists
            .Include(a => a.Albums)     // to get an album count 
            .OrderBy(a => a.Name)
            .ToList());
    }
}
