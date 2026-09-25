PROG 2500 - Lab 3 starter project
Lab Status Board


FIRST THING: DOES IT RUN

Open LabStatusBoard.slnx in Visual Studio and press F5. You should see a board of
lab machines and a Refresh button that changes the CPU numbers. If that does not
happen, tell your instructor before you write any code.


HOW THE LAB IS ORGANISED

There are ten numbered TODO comments spread across four files. Do them in order,
1 through 10. They are numbered by the order you do them, not by the file they
are in, so you will move between files as you go.

  TODO 1   MainWindow.xaml                 use the tile control
  TODO 2   Controls/MachineTile.xaml.cs    Status dependency property
  TODO 3   Controls/MachineTile.xaml       bind Status
  TODO 4   Controls/MachineTile.xaml.cs    CpuLoad dependency property
  TODO 5   Controls/MachineTile.xaml       bind CpuLoad
  TODO 6   Controls/MachineTile.xaml.cs    register the routed event
  TODO 7   Controls/MachineTile.xaml.cs    the event wrapper
  TODO 8   Controls/MachineTile.xaml.cs    raise it on click
  TODO 9   MainWindow.xaml                 attach one handler
  TODO 10  MainWindow.xaml.cs              write the handler

To see all ten in one place: View > Task List, then set the dropdown to Comments.
Double click a row to jump straight to it. The default keyboard shortcut is
Ctrl+\ then T, but that varies by keyboard profile.

If the Task List comes up empty, TODO is not switched on as a token on your
install. Tools > Options > Environment > Task List, and check TODO is listed.

The handout gives you a checkpoint after every couple of TODOs, with what you
should see on screen when you run. If the screen does not match, stop and fix it
before moving on. Debugging one change is easy. Debugging six is not.


WHAT IS ALREADY WRITTEN FOR YOU

  Models/LabMachine.cs                 the machine model, already implements
                                       INotifyPropertyChanged
  Models/MachineStatus.cs              the status enum
  Data/LabRepository.cs                the sample data and the Refresh behaviour
  MainWindow.xaml                      the board layout and the detail pane
  Controls/MachineTile.xaml            the tile layout, with one binding finished
                                       as a worked example
  Controls/MachineTile.xaml.cs         one dependency property finished as a
                                       worked example
  Converters/StatusToBrushConverter.cs for the optional part at the end
  App.xaml                             shared brushes

The MachineName property and its binding are done for you on purpose. Read them
before you start. Everything else in Part 1 is the same shape twice over.


WHAT YOU ARE BUILDING

Right now the markup for a tile sits inside the ItemTemplate in MainWindow.xaml.
It works, but it lives in exactly one place and can never be reused. You are
moving it into a real control with its own inputs, then wiring that control back
to the window with a routed event so that clicking a tile fills in the detail
pane on the right.


SUBMITTING

Commit your work to your course repo under a folder named Lab3. Due Tuesday
September 29, 11:59 PM.
