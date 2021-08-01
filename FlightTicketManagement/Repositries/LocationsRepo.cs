using FlightTicketManagementEntites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FlightTicketManagement.Repositries
{
    public class LocationsRepo
    {
        public async Task<List<Location>> Get_All_Locations()
        {
            var locations = await GlobalHttp.Make_Get_Request<Location>("api/Locations");
    
            return locations;
        }

        public async Task<string> Save_Location(Location location)
        {
            var response = await GlobalHttp.Make_Post_Request<Location>("api/Locations", location);

            return response;
        }

        public async Task<string> Edit_Location(string Code, Location location)
        {
            try
            {
                var response = await GlobalHttp.Make_Put_Request<Location>("api/Locations/" + Code, location);

                return response;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete_Location(string code)
        {
            var response = await GlobalHttp.Make_Delete_Request("api/Locations/" + code);

            return response;
        }
    }
}
