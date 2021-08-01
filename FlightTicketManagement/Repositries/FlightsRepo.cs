using FlightTicketManagementEntites;
using FlightTicketManagementEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FlightTicketManagement.Repositries
{
    public class FlightsRepo
    {
        public async Task<List<Regular>> Get_All_Flights()
        {
            var flights = await GlobalHttp.Make_Get_Request<Regular>("api/Flights");

            return flights;
        }

        public async Task<string> Save_Flight(FlightForm flight)
        {
            try
            {
                var response = await GlobalHttp.Make_Post_Request<FlightForm>("api/Flights", flight);

                return response;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Edit_Flight(int id, FlightForm flight)
        {
            try
            {
                var response = await GlobalHttp.Make_Put_Request<FlightForm>("api/Flights/" + id, flight);

                return response;
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete_Flight(int id)
        {
            var response = await GlobalHttp.Make_Delete_Request("api/Flights/" + id);

            return response;
        }
    }
}
