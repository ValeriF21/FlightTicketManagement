using Dapper;
using FlightTicketManagementAPI.Common;
using FlightTicketManagementAPI.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FlightTicketManagementEntites;

namespace FlightTicketManagementAPI.Services
{
    public class SearchService : ISearchService
    {
        List<Flight> _oFlights = new List<Flight>();
        GenericService gService = new GenericService();

        public List<Flight> Gets(int? pType_ID, float? pBase_Price, DateTime? pStarting_Departure, DateTime? pDestination_Departure)
        {
            _oFlights = new List<Flight>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pType_ID", pType_ID);
                parameters.Add("@pBase_Price", pBase_Price);
                parameters.Add("@pStarting_Departure", pStarting_Departure);
                parameters.Add("@pDestination_Departure", pDestination_Departure);

                var oFlights = gService.Execute_Queries<Flight>("Search_Flight", CommandType.StoredProcedure, parameters).ToList();

                if (oFlights != null && oFlights.Count() > 0)
                {
                    _oFlights = oFlights;
                }

                return _oFlights;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
