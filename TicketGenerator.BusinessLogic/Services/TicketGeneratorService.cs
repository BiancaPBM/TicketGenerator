using AutoMapper;
using TicketGenerator.BusinessLogic.Interfaces;
using TicketGenerator.DataAccess.Interfaces;
using TicketGenerator.DTOs;
using TicketGenerator.Entities;

namespace TicketGenerator.BusinessLogic.Services
{
    public class TicketGeneratorService : ITicketGeneratorService
    {
        private readonly IMapper _mapper;
        private readonly ITicketGeneratorRepository _ticketGeneratorRepository;
        public TicketGeneratorService(ITicketGeneratorRepository ticket, IMapper mapper)
        {
            _ticketGeneratorRepository = ticket;
            _mapper = mapper;
        }
        public async Task<bool> CreateTicket(TicketBoxDto ticketBox)
        {   
            var ticket = _mapper.Map<Ticket>(ticketBox);
            var boxes = _mapper.Map<List<Box>>(ticketBox.Boxes);
            return await _ticketGeneratorRepository.CreateTicket(ticket, boxes);
        }

        public async Task<List<TicketDto>> GetAllTickets()
        {
           var tickets = await _ticketGeneratorRepository.GetAllTickets();
            return _mapper.Map<List<TicketDto>>(tickets);
        }

        public async Task<TicketBoxDto> GetTicket(int ticketId)
        {
            var ticket = await _ticketGeneratorRepository.GetTicket(ticketId);   
           return  _mapper.Map<TicketBoxDto>(ticket);
        }
    }
}