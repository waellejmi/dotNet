namespace TP5.Models.RestosModel
{
    public class Proprietaire
    {
        public int Numero { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gsm { get; set; } = string.Empty;

        public List<Restaurant> LesRestos { get; set; } = new();

    }
}
