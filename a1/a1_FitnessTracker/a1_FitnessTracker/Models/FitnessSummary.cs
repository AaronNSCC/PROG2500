using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

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
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
