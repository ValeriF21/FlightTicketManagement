using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;

namespace FlightTicketManagementAPI.IServices
{
    public interface ISearchService
    {
        List<Flight> Gets(int? pType_ID, float? pBase_Price, DateTime? pStarting_Departure, DateTime? pDestination_Departure);
    }
}
