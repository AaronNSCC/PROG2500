using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections.ObjectModel;

namespace a1_FitnessTracker.Models
{
    public class FitnessSummary : INotifyPropertyChanged
    {
        private int _minutesGoal = 120;
        public int MinutesGoal
        {
            get => _minutesGoal;
            set { _minutesGoal = value; OnPropertyChanged(); OnPropertyChanged(nameof(GoalProgressText)); }
        }

        private int _caloriesGoal = 2000;
        public int CaloriesGoal
        {
            get => _caloriesGoal;
            set { _caloriesGoal = value; OnPropertyChanged(); OnPropertyChanged(nameof(GoalProgressText)); }
        }

        // List that holds every activity - announces when activities are added/removed
        public ObservableCollection<Activity> Activities { get; } = new ObservableCollection<Activity>();

        public int TotalMinutes => Activities.Sum(a => a.Minutes); // for each activity in activities- sum the mins
        public int TotalCalories => Activities.Sum(a => a.Calories); // for each activity in activities- sum the cals

        public string GoalProgressText => $"{TotalMinutes} / {MinutesGoal} mins, {TotalCalories} / {CaloriesGoal} cals";

        public FitnessSummary() // constructor method
        {
            // when an activity is added/removed the totals need to be re-read by the UI
            Activities.CollectionChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(TotalMinutes));
                OnPropertyChanged(nameof(TotalCalories));
                OnPropertyChanged(nameof(GoalProgressText));
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
