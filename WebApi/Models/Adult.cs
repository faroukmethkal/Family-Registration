using System;

namespace  Assignment1WebApi.Models
{
    [Serializable]

    public class Adult : Person
    {
        public Job JobTitle { get; set; }
    }
}