using System;
using System.Collections.Generic;
using System.Text;

namespace GradeTracker.Models
{
    public class Student
    {
        // TODO Step 1 (Model): move this class into its own file in a Models folder,
        // with a namespace to match. Nothing about the class itself needs to change.
        public string Name { get; set; } = "";
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Grade:0.#})";
        }
    }
}