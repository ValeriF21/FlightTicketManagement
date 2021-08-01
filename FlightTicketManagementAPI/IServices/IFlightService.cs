using FlightTicketManagementEntites;
using FlightTicketManagementEntities;
using System;
using System.Collections.Generic;

namespace FlightTicketManagementAPI.IServices
{
    public interface IFlightService
    {
        List<Regular> Gets();

        FullFlight Get(int id);

        string Save(Flight oFlight);

        void Update(int id, Flight oFlight);

        void Delete(int id);
    }
}
