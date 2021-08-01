using FlightTicketManagementEntites;
using FlightTicketManagementEntities;
using System;
using System.Collections.Generic;
using Type = FlightTicketManagementEntites.Type;

namespace FlightTicketManagement.Models
{
    public class FlightsViewModel
    {
        public List<FullFlight> flights { get; set; }
        public Flight flightForm { get; set; }
        public List<Location> locations { get; set; }
        public List<Type> types { get; set; }
        public List<Remark> remarks { get; set; }
    }
}
