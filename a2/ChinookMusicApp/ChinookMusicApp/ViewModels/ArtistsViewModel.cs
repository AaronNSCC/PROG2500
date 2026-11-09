using System;
using System.Collections.Generic;
using System.Text;

using ChinookMusicApp.Data;

namespace ChinookMusicApp.ViewModels;

public class ArtistsViewModel : ViewModelBase
{
    private readonly ChinookContext context;

    public ArtistsViewModel(ChinookContext context)
    {
        this.context = context;
    }
}
