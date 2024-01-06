using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketGenerator.Entities;

namespace TicketGenerator.Repository.Context
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base( options ) {
            _configuration = configuration;
        }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketBox> TicketBox { get; set; }
        public DbSet<Box> Box { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TicketBox>()
                .HasKey(tb => new { tb.TicketId, tb.BoxId });

            modelBuilder.Entity<TicketBox>()
                .HasOne(tb => tb.Ticket)
                .WithMany(t => t.TicketBoxes)
                .HasForeignKey(tb => tb.TicketId);

            modelBuilder.Entity<TicketBox>()
                .HasOne(tb => tb.Box)
                .WithMany(b => b.TicketBoxes)
                .HasForeignKey(tb => tb.BoxId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["Database:ConnectionString"]);
            }
        }
    }
}
