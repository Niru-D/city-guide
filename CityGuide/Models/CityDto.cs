namespace CityGuide.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int NumberOfPointsOfInterests
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = [];

        
    }
}
