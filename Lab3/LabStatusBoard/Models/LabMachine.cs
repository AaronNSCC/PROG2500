using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabStatusBoard.Models
{
    public class LabMachine : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _room = string.Empty;
        private MachineStatus _status;
        private int _cpuLoad;
        private DateTime _lastSeen;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Room
        {
            get => _room;
            set { _room = value; OnPropertyChanged(); }
        }

        public MachineStatus Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public int CpuLoad
        {
            get => _cpuLoad;
            set { _cpuLoad = value; OnPropertyChanged(); }
        }

        public DateTime LastSeen
        {
            get => _lastSeen;
            set { _lastSeen = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
