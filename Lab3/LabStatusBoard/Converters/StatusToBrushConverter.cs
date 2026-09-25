using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using LabStatusBoard.Models;

namespace LabStatusBoard.Converters
{
    /// <summary>
    /// Turns a MachineStatus into a colour. Provided for the optional part of the
    /// lab. Nothing uses it until you wire it up in MachineTile.xaml.
    ///
    /// Note that it returns a Brush, not a Color. Background wants a Brush.
    /// </summary>
    public class StatusToBrushConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            MachineStatus status = value is MachineStatus s ? s : MachineStatus.Offline;

            return status switch
            {
                MachineStatus.Available => new SolidColorBrush(Color.FromRgb(0x2E, 0x7D, 0x32)),
                MachineStatus.InUse => new SolidColorBrush(Color.FromRgb(0x15, 0x65, 0xC0)),
                MachineStatus.Maintenance => new SolidColorBrush(Color.FromRgb(0xEF, 0x6C, 0x00)),
                _ => new SolidColorBrush(Color.FromRgb(0x9E, 0x9E, 0x9E))
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException("StatusToBrushConverter is one way only.");
        }
    }
}
