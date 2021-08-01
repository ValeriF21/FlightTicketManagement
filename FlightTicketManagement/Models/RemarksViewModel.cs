using Type = FlightTicketManagementEntites.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightTicketManagementEntites;

namespace FlightTicketManagement.Models
{
    public class RemarksViewModel
    {
        public RemarksViewModel()
        {
            types = new List<Type>();
            remarks = new List<Remark>();
        }

        public List<Type> types { get; set; }

        public List<Remark> remarks { get; set; }
    }
}
