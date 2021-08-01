using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagementAPI.IServices
{
    public interface ILocationService
    {
        List<Location> Gets();

        Location Get(string pCode);

        void Save(Location oLocation);

        void Update(string pCode, Location oLocation);

        void Delete(string pCode);
    }
}
