using System;

namespace Assignment1WebApi.Models
{
    [Serializable]

    public class Pet
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}