using System.ComponentModel.DataAnnotations;

namespace CityGuide.Models
{
    public class PointOfInterestCreationDto
    {
        [Required(ErrorMessage ="Sample")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
