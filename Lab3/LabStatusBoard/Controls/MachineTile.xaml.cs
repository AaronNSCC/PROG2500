using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LabStatusBoard.Models;

namespace LabStatusBoard.Controls
{
    public partial class MachineTile : UserControl
    {
        // ====================================================================
        // PART 1: the three inputs the tile needs from outside.
        //
        // These are dependency properties, not ordinary C# properties. Only a
        // dependency property can be the target of a binding, and the tiles are
        // bound from the DataTemplate in MainWindow, so ordinary properties will
        // compile and then quietly do nothing.
        // ====================================================================

        // --------------------------------------------------------------------
        // WORKED EXAMPLE. MachineName is finished. Read it, then copy the shape.
        //
        // The four arguments to Register are:
        //   1. the property name, as a string
        //   2. the type of the value it holds
        //   3. the type that owns it, which is this control
        //   4. metadata, here just the value to use when nobody sets one
        // --------------------------------------------------------------------
        public static readonly DependencyProperty MachineNameProperty =
            DependencyProperty.Register(
                nameof(MachineName),
                typeof(string),
                typeof(MachineTile),
                new PropertyMetadata(string.Empty));

        public string MachineName
        {
            get => (string)GetValue(MachineNameProperty);
            set => SetValue(MachineNameProperty, value);
        }

        // --------------------------------------------------------------------
        // TODO 2
        // Register a dependency property called Status, of type MachineStatus,
        // owned by MachineTile, defaulting to MachineStatus.Available. Then write
        // its wrapper property, the same way MachineName has one above.
        //
        // Remember the naming rule: the field is StatusProperty, the property is
        // Status. WPF finds one from the other by name, so a typo breaks it.
        // --------------------------------------------------------------------
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(
                nameof(Status),
                typeof(MachineStatus),
                typeof(MachineTile),
                new PropertyMetadata(MachineStatus.Available));

        public MachineStatus Status
        {
            get => (MachineStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }


        // --------------------------------------------------------------------
        // TODO 4
        // Same again for CpuLoad, of type int, defaulting to 0.
        // --------------------------------------------------------------------
        public static readonly DependencyProperty CpuLoadProperty =
            DependencyProperty.Register(
                nameof(CpuLoad),
                typeof(int),
                typeof(MachineTile),
                new PropertyMetadata(0));

        public int CpuLoad
        {
            get => (int)GetValue(CpuLoadProperty);
            set => SetValue(CpuLoadProperty, value);
        }

        // ====================================================================
        // PART 2: telling the window that this tile was clicked.
        // ====================================================================

        // --------------------------------------------------------------------
        // TODO 6
        // Declare the routed event. Use EventManager.RegisterRoutedEvent with:
        //   name     nameof(MachineSelected)
        //   strategy RoutingStrategy.Bubble, so it travels up to the ItemsControl
        //   handler  typeof(RoutedEventHandler)
        //   owner    typeof(MachineTile)
        // Store it in a public static readonly RoutedEvent called
        // MachineSelectedEvent.
        // --------------------------------------------------------------------
        public static readonly RoutedEvent MachineSelectedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(MachineSelected),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(MachineTile));


        // --------------------------------------------------------------------
        // TODO 7
        // Add the event wrapper so other code can subscribe with += or from XAML:
        //
        //     public event RoutedEventHandler MachineSelected
        //     {
        //         add => AddHandler(...);
        //         remove => RemoveHandler(...);
        //     }
        //
        // Fill in the event you registered in TODO 6.
        // --------------------------------------------------------------------
        public event RoutedEventHandler MachineSelected
        {
            add => AddHandler(MachineSelectedEvent, value);
            remove => RemoveHandler(MachineSelectedEvent, value);
        }


        public MachineTile()
        {
            InitializeComponent();
        }

        // --------------------------------------------------------------------
        // TODO 8
        // Raise the event when the tile is clicked. Uncomment the method below
        // and add the RaiseEvent call. The argument is:
        //
        //     new RoutedEventArgs(MachineSelectedEvent, this)
        //
        // The "this" says which element the event is coming from. That is what
        // e.OriginalSource reports at the other end.
        // --------------------------------------------------------------------
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            // your RaiseEvent call goes here
            RaiseEvent(new RoutedEventArgs(MachineSelectedEvent, this));
            
        }


    }
}
