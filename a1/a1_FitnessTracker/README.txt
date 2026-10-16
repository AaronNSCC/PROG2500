PROG 2500 - Assignment 1: Fitness Tracker
Aaron Thomas - W0515027

Enhancements to be marked:

1. Buttons disable until inputs are filled.
	* MainWindow.xaml (Window.Resources): AddActivityButtonStyle and SetGoalsButtonStyle
	- Add Activity and Set Goals buttons are diabled until all fields have a value.
	- Using DataTriggers in the button styles- bind to input controls and set IsEnabled.

2. Input validation with helpful messages
	* MainWindow.xaml.cs: AddActivityButton_Click
	- Minutes and calories must be whole numbers greater than 0. 
	- Using int.TryParse so letters or empty input won't crash the app.

3. Custom UI theme using resources
	* App.xaml: color palette and font resources
	* MainWindow.xaml (Window.Resources): GroupBox + style, TitleTextStyle, BaseButtonStyle, and input field/label styles.
	- Color palette and font defined as resources in App.xaml and re-used by every style. 
	- GroupBox style with HeaderTemplate to style the header text.
	- BaseButtonStyle with rounded corners - Add Activity and Set Goals button inherit using BasedOn while adding their own triggers.

4. Goals applied with a Set Goals button
   * MainWindow.xaml: MinutesGoalTextBox, CaloriesGoalTextBox
   * MainWindow.xaml.cs: SetGoalsButton_Click
   - Goal Textboxes use two-way binding with UpdateTriggerSource=Explicit so new goals only take effect once the button is clicked.

AI USAGE
I used Claude while building this assignment (never copy-paste) to:
	- Explain concepts I was unsure about and answer questions I have about them.
	- Plan the order to build each section and estimate time it might take.
	- Suggesting color palette based on reference image.
	- Finding bugs (ex. typo in a binding name).