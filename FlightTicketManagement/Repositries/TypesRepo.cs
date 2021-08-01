using Type = FlightTicketManagementEntites.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagement.Repositries
{
    public class TypesRepo
    {
        public async Task<List<Type>> Get_All_Types()
        {
            var types = await GlobalHttp.Make_Get_Request<Type>("api/Types");

            return types;
        }
    }
}
