using System;

namespace TP6.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sections { get; set; }
        public string Director { get; set; }

        public double Rating { get; set; }

        public string WebSite { get; set; }
    }
}
