using System.Collections.ObjectModel;
using System.Windows;
using LabStatusBoard.Controls;
using LabStatusBoard.Data;
using LabStatusBoard.Models;

namespace LabStatusBoard
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<LabMachine> Machines { get; }

        public MainWindow()
        {
            InitializeComponent();

            Machines = LabRepository.CreateSampleMachines();
            DataContext = this;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LabRepository.SimulateActivity(Machines);
        }

        // --------------------------------------------------------------------
        // TODO 10
        // This one handler runs for every tile on the board, because the event
        // bubbles up from whichever tile was clicked to the ItemsControl that
        // TODO 9 attached it to.
        //
        // Three things to do in here:
        //   1. get the tile out of the event args. Use e.OriginalSource.
        //      Not sender, which is the ItemsControl, the same object every time.
        //      And not e.Source either: the tiles are built from a DataTemplate,
        //      and when a routed event leaves a template WPF re-points Source at
        //      the ContentPresenter hosting it, to hide the template internals.
        //      e.OriginalSource is never re-pointed, so it is still the tile.
        //   2. get the LabMachine off that tile's DataContext. The ItemsControl
        //      put it there when it built the tile, so you do not have to look
        //      anything up.
        //   3. set DetailFields.DataContext to that machine, hide
        //      DetailPlaceholder, and show DetailFields.
        //
        // A pattern-matching if handles steps 1 and 2 in one line:
        //
        //     if (e.OriginalSource is MachineTile tile && tile.DataContext is LabMachine machine)
        //
        // Visibility values are Visibility.Visible and Visibility.Collapsed.
        // --------------------------------------------------------------------
        private void OnMachineSelected(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MachineTile tile && tile.DataContext is LabMachine machine)
            {
                DetailFields.DataContext = machine;
                DetailPlaceholder.Visibility = Visibility.Collapsed;
                DetailFields.Visibility = Visibility.Visible;
            }

        }
    }
}
