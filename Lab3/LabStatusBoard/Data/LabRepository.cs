using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LabStatusBoard.Models;

namespace LabStatusBoard.Data
{
    public static class LabRepository
    {
        private static readonly Random Random = new Random();

        public static ObservableCollection<LabMachine> CreateSampleMachines()
        {
            return new ObservableCollection<LabMachine>
            {
                new LabMachine { Name = "IT201-01", Room = "IT 201", Status = MachineStatus.Available,   CpuLoad = 6,  LastSeen = DateTime.Now.AddMinutes(-1) },
                new LabMachine { Name = "IT201-02", Room = "IT 201", Status = MachineStatus.InUse,       CpuLoad = 63, LastSeen = DateTime.Now },
                new LabMachine { Name = "IT201-03", Room = "IT 201", Status = MachineStatus.InUse,       CpuLoad = 41, LastSeen = DateTime.Now },
                new LabMachine { Name = "IT201-04", Room = "IT 201", Status = MachineStatus.Offline,     CpuLoad = 0,  LastSeen = DateTime.Now.AddHours(-19) },
                new LabMachine { Name = "IT201-05", Room = "IT 201", Status = MachineStatus.Available,   CpuLoad = 3,  LastSeen = DateTime.Now.AddMinutes(-4) },
                new LabMachine { Name = "IT201-06", Room = "IT 201", Status = MachineStatus.Maintenance, CpuLoad = 12, LastSeen = DateTime.Now.AddMinutes(-52) },
                new LabMachine { Name = "IT204-01", Room = "IT 204", Status = MachineStatus.InUse,       CpuLoad = 88, LastSeen = DateTime.Now },
                new LabMachine { Name = "IT204-02", Room = "IT 204", Status = MachineStatus.Available,   CpuLoad = 5,  LastSeen = DateTime.Now.AddMinutes(-2) },
                new LabMachine { Name = "IT204-03", Room = "IT 204", Status = MachineStatus.Offline,     CpuLoad = 0,  LastSeen = DateTime.Now.AddDays(-3) },
                new LabMachine { Name = "IT204-04", Room = "IT 204", Status = MachineStatus.InUse,       CpuLoad = 55, LastSeen = DateTime.Now },
                new LabMachine { Name = "IT204-05", Room = "IT 204", Status = MachineStatus.Available,   CpuLoad = 8,  LastSeen = DateTime.Now.AddMinutes(-7) },
                new LabMachine { Name = "IT204-06", Room = "IT 204", Status = MachineStatus.Maintenance, CpuLoad = 15, LastSeen = DateTime.Now.AddMinutes(-33) }
            };
        }

        /// <summary>
        /// Jiggles the CPU load on every machine that is not offline, so the board
        /// has something changing to look at. Called by the Refresh button.
        /// </summary>
        public static void SimulateActivity(IEnumerable<LabMachine> machines)
        {
            foreach (LabMachine machine in machines)
            {
                if (machine.Status == MachineStatus.Offline)
                {
                    continue;
                }

                machine.CpuLoad = Math.Clamp(machine.CpuLoad + Random.Next(-15, 26), 0, 99);
                machine.LastSeen = DateTime.Now;
            }
        }
    }
}
