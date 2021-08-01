using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTicketManagementEntities
{
    public class LowCost: FullFlight
    {
        public override int Calculate_Price()
        {
            return (int)(Base_Price * 0.9);
        }

        public static explicit operator LowCost(Regular v)
        {
            return new LowCost
            {
                ID = v.ID,
                StartingPoint = v.StartingPoint,
                Starting_Airport = v.Starting_Airport,
                Starting_Country = v.Starting_Country,
                Destination = v.Destination,
                Destintaion_Airport = v.Destintaion_Airport,
                Destintaion_Country = v.Destintaion_Country,
                StartingPoint_Departure = v.StartingPoint_Departure,
                StartingPoint_Arrival = v.StartingPoint_Arrival,
                Destination_Departure = v.Destination_Departure,
                Destination_Arrival = v.Destination_Arrival,
                Description = v.Description,
                Base_Price = v.Base_Price,
                Type_ID = v.Type_ID,
                Remarks = v.Remarks
            };
        }
    }
}
