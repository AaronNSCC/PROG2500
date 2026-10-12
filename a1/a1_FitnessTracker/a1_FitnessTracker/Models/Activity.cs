using System;
using System.Collections.Generic;
using System.Text;

namespace a1_FitnessTracker.Models
{
    public class Activity
    {
        public string Name { get; set; } = String.Empty;
        public int Minutes { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; }

    }
}
