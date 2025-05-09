using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WL_TP4.Models.HotelModel
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters.")]
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int Stars { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "City must be between 2 and 20 characters.")]
        public string City { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Website")]
        [UIHint("OpenInNewWindow")]
        public string WebSite { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone Number")]
        public string Tel {get; set; }
      


        public virtual ICollection<Appreciation> Appreciations { get; set; } = new List<Appreciation>();


        public string Country { get; set; }


    }
}
