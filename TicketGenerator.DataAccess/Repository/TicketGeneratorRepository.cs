using Microsoft.EntityFrameworkCore;
using TicketGenerator.DataAccess.Interfaces;
using TicketGenerator.Entities;
using TicketGenerator.Repository.Context;

namespace TicketGenerator.Repository.Repository
{
    public class TicketGeneratorRepository : ITicketGeneratorRepository
    {
        private readonly DatabaseContext _dbContext;
        public TicketGeneratorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;       
        }
        public async Task<bool> CreateTicket(Ticket ticket, List<Box> boxes)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    ticket.DateCreation = DateTime.UtcNow;
                    var dbTicket = await _dbContext.AddAsync(ticket);
                    await _dbContext.SaveChangesAsync();

                    foreach (var box in boxes)
                    {
                        box.DateCreation = DateTime.UtcNow;
                        var dbBox = await _dbContext.AddAsync(box);
                        await _dbContext.SaveChangesAsync();
                        await _dbContext.AddAsync(new TicketBox { BoxId = dbBox.Entity.Id, TicketId = dbTicket.Entity.Id });
                    }
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return true;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _dbContext.Ticket.ToListAsync();
        }

        public async Task<Ticket> GetTicket(int ticketId)
        {
            return await _dbContext.Ticket.Include(n => n.TicketBoxes)
                    .ThenInclude(tb => tb.Box).FirstOrDefaultAsync(ticket => ticket.Id == ticketId);
        }
    }
}