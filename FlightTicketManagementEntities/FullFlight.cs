using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = FlightTicketManagementEntites.Type;

namespace FlightTicketManagementEntities
{
    public class FullFlight: Flight
    {
        public FullFlight() { }
        public string Starting_Airport { get; set; }
        public string Starting_Country { get; set; }
        public string Destintaion_Airport { get; set; }
        public string Destintaion_Country { get; set; }
        public string Description { get; set; }
        public List<Remark> Remarks { get; set; }
    }
}
