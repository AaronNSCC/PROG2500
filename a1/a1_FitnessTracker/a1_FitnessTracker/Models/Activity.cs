using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace a1_FitnessTracker.Models
{
    public class Activity : INotifyPropertyChanged
    {
        private string _name = String.Empty;
        private int _minutes;
        private int _calories;
        private DateTime _date;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }
        public int Minutes
        {
            get => _minutes;
            set { _minutes = value; OnPropertyChanged(); }
        }

        public int Calories
        {
            get => _calories;
            set { _calories = value; OnPropertyChanged(); }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
