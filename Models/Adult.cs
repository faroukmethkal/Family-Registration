using System;

namespace Assignment_1.Models
{
    [Serializable]
    public class Adult : Person
    {
        public Job JobTitle { get; set; }
    }
}