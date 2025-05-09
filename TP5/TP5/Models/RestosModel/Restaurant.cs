using System.ComponentModel.DataAnnotations.Schema;

namespace TP5.Models.RestosModel
{
    public class Restaurant
    {
        public int CodeResto { get; set; }
        public string NomResto { get; set; } = string.Empty;
        public string Specialite { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Tel { get; set; } = string.Empty;


        public int NumProp { get; set; }
        public Proprietaire? LeProprio { get; set; }

        public List<Avis> LesAvis { get; set; } = new();

    }
}
