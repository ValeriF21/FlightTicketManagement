using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightTicketManagementEntites
{
    public class Type
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }

        public float Base_Multiplication { get; set; }

        public float Base_Addition { get; set; }

        public List<Remark> remarks;

        public Type()
        {
            remarks = new List<Remark>();
        }
    }
}