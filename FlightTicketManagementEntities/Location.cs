
using System.ComponentModel.DataAnnotations;

namespace FlightTicketManagementEntites
{
    public class Location
    {
        public Location()
        {
        }

        public Location(string pCode, string pAirport, string pCountry)
        {
            Code = pCode;
            Airport = pAirport;
            Country = pCountry;
        }

        
        public string Code { get; set; }
        
        
        public string Airport { get; set; }

        
        public string Country { get; set; }
    }
}
