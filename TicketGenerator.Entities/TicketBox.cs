using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketGenerator.Entities
{
    public class TicketBox
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int BoxId {  get; set; }
        public Box Box { get; set; }
    }
}
