using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagement.Models
{
    public class LocationsViewModel
    {
        [Key, StringLength(3, MinimumLength = 3, ErrorMessage = "אורך הקוד חייב להיות 3 תווים"), RegularExpression("^[A-Z]", ErrorMessage = "הקוד מכיל אותיות גדולות בלבד")]
        public string Code { get; set; }

        [RegularExpression("^[A-Za-z]", ErrorMessage = "הזן אותיות באנגלית בלבד")]
        public string Airport { get; set; }

        [RegularExpression("^[A-Za-z]", ErrorMessage = "הזן אותיות באנגלית בלבד")]
        public string Country { get; set; }
        public List<Location> locations { get; set; }
    }
}
