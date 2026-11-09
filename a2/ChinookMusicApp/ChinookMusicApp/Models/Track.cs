using System;
using System.Collections.Generic;
using System.Text;

namespace ChinookMusicApp.Models;

public partial class Track
{
    // my half of Track class: display only and kept out of Models\Generated
    // src: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings
    public string Duration
    {
        get
        {
            // turns the stored milliseconds into a TimeSpan (length of time)
            TimeSpan length = TimeSpan.FromMilliseconds(Milliseconds);

            // shows as mins:seconds (ex. 343719 ms = 00:05:43)
            return length.ToString(@"h\:mm\:ss");
        }
    }
}
