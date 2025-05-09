using System.ComponentModel.DataAnnotations;

namespace TP5.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }

        [Required]
        [MaxLength(30)]
        public string NomPersonne { get; set; } = string.Empty;

        [Required]
        [Range(1, 5)]
        public int Note { get; set; }

        [MaxLength(256)]
        public string? Commentaire { get; set; }

        public int NumResto { get; set; }

        public Restaurant? LeResto { get; set; }
    }
}
