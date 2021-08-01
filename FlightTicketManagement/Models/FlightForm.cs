using System;
using System.ComponentModel.DataAnnotations;

namespace FlightTicketManagementEntites
{
    public class FlightForm
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "אנא בחר נקודת יציאה")]
        public string StartingPoint { get; set; }
        public string Destination { get; set; }
        public DateTime StartingPoint_Departure { get; set; }
        public DateTime StartingPoint_Arrival { get; set; }
        public DateTime Destination_Departure { get; set; }
        public DateTime Destination_Arrival { get; set; }

        [Required(ErrorMessage = "אנא בחר מחיר בסיס"), RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "המחיר מכיל ספרות בלבד")]
        public float Base_Price { get; set; }
        public int Type_ID { get; set; }
    }
}
