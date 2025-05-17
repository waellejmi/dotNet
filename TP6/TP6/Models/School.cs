using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TP6.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sections { get; set; }
        public string Director {  get; set; }

        [Range(0,5)]
        public double Rating { get; set; }
        public string? WebSite { get; set; }

    }
}
