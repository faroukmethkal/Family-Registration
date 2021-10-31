using System;

namespace Assignment1WebApi.Models
{
    [Serializable]

    public class Interest
    {
        public string Type { get; set; }
        public string Description { get; set; }
    }
}