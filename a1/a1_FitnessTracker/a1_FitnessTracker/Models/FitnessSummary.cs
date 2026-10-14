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
            set { _minutesGoal = value; OnPropertyChanged(); }
        }

        private int _caloriesGoal = 2000;
        public int CaloriesGoal
        {
            get => _caloriesGoal;
            set { _caloriesGoal = value; OnPropertyChanged(); }
        }

        // List that holds every activity - announces when activities are added/removed
        public ObservableCollection<Activity> Activities { get; } = new ObservableCollection<Activity>();

        public int TotalMinutes => Activities.Sum(a => a.Minutes);
        public int TotalCalories => Activities.Sum(a => a.Calories);

        public FitnessSummary() // constructor method
        {
            // when an activity is added/removed the totals need to be re-read by the UI
            Activities.CollectionChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(TotalMinutes));
                OnPropertyChanged(nameof(TotalCalories));
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
