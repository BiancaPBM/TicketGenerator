namespace TicketGenerator.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public int? Superzahl { get; set; }
        public ICollection<TicketBox> TicketBoxes { get; set; }
    }
}