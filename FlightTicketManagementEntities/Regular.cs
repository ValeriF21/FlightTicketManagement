using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTicketManagementEntities
{
    public class Regular: FullFlight
    {
        public override int Calculate_Price()
        {
            return (int)(Base_Price * 1.17);
        }
    }
}
