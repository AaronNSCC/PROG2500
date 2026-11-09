using System;
using System.Collections.Generic;
using System.Text;

using ChinookMusicApp.Data;

namespace ChinookMusicApp.ViewModels;

public class TracksViewModel : ViewModelBase
{
    private readonly ChinookContext context;

    public TracksViewModel(ChinookContext context)
    {
        this.context = context;
    }
}
