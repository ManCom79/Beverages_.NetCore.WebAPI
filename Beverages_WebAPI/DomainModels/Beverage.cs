using System.ComponentModel.DataAnnotations;

namespace Beverages_WebAPI.DomainModels
{
    public class Beverage
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
