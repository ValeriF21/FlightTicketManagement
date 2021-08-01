
using System.ComponentModel.DataAnnotations;

namespace FlightTicketManagementEntites
{
    public class Remark
    {
        public Remark() { }

        public Remark(int pType_ID, string pDescription)
        {
            Description = pDescription;
            Type_ID = pType_ID;
        }

        [Key]
        public int ID { get; set;  }
        [MinLength(5, ErrorMessage = "הזן הערה באורך 5 תווים מינימום")]
        public string Description { get; set; }
        public int Type_ID { get; set; }
    }
}
