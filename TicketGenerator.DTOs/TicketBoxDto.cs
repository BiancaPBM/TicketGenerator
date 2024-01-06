
namespace TicketGenerator.DTOs
{
    public class TicketBoxDto
    {
        public string Name { get; set; }
        public int? Superzahl { get; set; }
        public List<BoxDto> Boxes { get; set; } 
    }
}
