using TicketGenerator.Entities;

namespace TicketGenerator.DataAccess.Interfaces
{
    public interface ITicketGeneratorRepository
    {
        public Task<List<Ticket>> GetAllTickets();
        public Task<Ticket> GetTicket(int ticketId);
        public Task<bool> CreateTicket(Ticket ticketBox,List<Box> boxes);
    }
}
