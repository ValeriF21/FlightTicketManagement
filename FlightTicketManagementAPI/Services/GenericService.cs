using Dapper;
using FlightTicketManagementAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagementAPI.Services
{
    public class GenericService
    {
        public IEnumerable<T> Execute_Queries<T>(string query, CommandType commandFlight, DynamicParameters parameters = null)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oItems = con.Query<T>(query, parameters, commandType: commandFlight);

                    return oItems;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on: Execute_Flight_Queries in FlightTicketManagementAPI.Services - \n" + ex.Message);
            }
        }
    }
}
