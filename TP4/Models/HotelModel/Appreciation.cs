using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WL_TP4.Models.HotelModel
{
    public class Appreciation
    {
        public string Id { get; set; } 

        [Required]
        [Display(Name = "Person Name")]
        public string PersName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }


        [Range(1, 10, ErrorMessage = "Score must be between 1 and 10.")]
        public int Score { get; set; }

        public int? HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
    }
}
