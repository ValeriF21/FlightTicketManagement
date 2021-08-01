using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagementAPI.Common
{
    public class Global
    {
        public static string ConnectionString { get; set; }
    }
}
