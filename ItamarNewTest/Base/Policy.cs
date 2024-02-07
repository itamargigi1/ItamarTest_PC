using System;
using ItamarNewTest.Enums;

namespace ItamarNewTest.Policies
{
    public abstract class Policy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
