using Microsoft.AspNetCore.Mvc;
using TicketGenerator.BusinessLogic.Interfaces;
using TicketGenerator.DTOs;

namespace TicketGenerator.Controllers
{
    [Route("/api/tickets")]
    [ApiController]
    public class TicketGeneratorController : ControllerBase
    {
        private readonly ITicketGeneratorService _ticketGeneratorService;
        public TicketGeneratorController(ITicketGeneratorService ticketGeneratorService)
        {
            this._ticketGeneratorService = ticketGeneratorService;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = new List<TicketDto>();
            try
            {
                tickets = await _ticketGeneratorService.GetAllTickets();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(tickets);
        }

        // GET api/tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            TicketBoxDto ticketboxes;
            try
            {
               ticketboxes = await _ticketGeneratorService.GetTicket(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(ticketboxes);
        }

        // POST api/tickets
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketBoxDto ticketBox)
        {
            var hasBeenCreated = false;
            try
            {
                hasBeenCreated  = await _ticketGeneratorService.CreateTicket(ticketBox);
            }
            catch {
                throw;
            }
            return Ok(hasBeenCreated);
        }    
    }
}
