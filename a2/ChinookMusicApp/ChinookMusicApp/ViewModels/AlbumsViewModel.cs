using System;
using System.Collections.Generic;
using System.Text;

using ChinookMusicApp.Data;

namespace ChinookMusicApp.ViewModels;

public class AlbumsViewModel : ViewModelBase
{
    private readonly ChinookContext context;

    public AlbumsViewModel(ChinookContext context)
    {
        this.context = context;
    }
}
