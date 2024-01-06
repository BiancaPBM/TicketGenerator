

using TicketGenerator.DTOs;

namespace TicketGenerator.BusinessLogic.Interfaces
{
    public interface ITicketGeneratorService
    {
        public Task<List<TicketDto>> GetAllTickets();
        public Task<TicketBoxDto> GetTicket(int ticketId);
        public Task<bool> CreateTicket(TicketBoxDto ticketBox);
    }
}
