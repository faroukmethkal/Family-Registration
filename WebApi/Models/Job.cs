using System;

namespace Assignment1WebApi.Models
{
    [Serializable]

    public class Job
    {
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}