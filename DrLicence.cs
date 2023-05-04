using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class DrLicence
    {
        [Key]
        public int Id { get; set; }
      // public int UsersID { get; set; }
        public OrderStatus LicenceStatus { get; set; }
        public DateTime DateofSubmition { get; set; }
        public TypeofOrder Type { get; set; }
        public List<Documents> Documents { get; set; }

        private DrLicence()
        {
            Documents = new List<Documents>(); // da se mine v onModelCreating
        }

        public DrLicence(OrderStatus licenceStatus, DateTime dateofSubmition, TypeofOrder type, List<Documents> documents)
        {
            LicenceStatus = licenceStatus;
            DateofSubmition = dateofSubmition;
            Type = type;
            Documents = documents;
        }
    }
}
