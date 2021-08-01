using FlightTicketManagement.Models;
using FlightTicketManagementEntites;
using Type = FlightTicketManagementEntites.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagement.Repositries
{
    public class RemarksRepo
    {
        public async Task<List<Remark>> Get_All_Remarks()
        {
            var remarks = await GlobalHttp.Make_Get_Request<Remark>("api/Remarks");

            return remarks;
        }

        public async Task<string> Save_Remark(Remark remark)
        {
            var response = await GlobalHttp.Make_Post_Request<Remark>("api/remarks", remark);

            return response;
        }

        public async Task<string> Edit_Location(int id, Remark remark)
        {
            try
            {
                var response = await GlobalHttp.Make_Put_Request<Remark>("api/Remarks/" + id, remark);

                return response;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete_Remark(int id)
        {
            var response = await GlobalHttp.Make_Delete_Request("api/remarks/" + id);

            return response;
        }
    }
}
