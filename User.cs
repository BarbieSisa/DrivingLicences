using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {


        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(3, 20, ErrorMessage = "First name must be between 3 and 20 characters.")]
        public string Fname { get; set; }

        [Required]
        [Range(3, 20, ErrorMessage = "Middle name must be between 3 and 20 characters.")]
        public string Mname { get; set; }

        [Required]
        [Range(3, 20, ErrorMessage = "Last name must be between 3 and 20 characters.")]
        public string Lname { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="EGN must be 10 symbols.")]
        public int EGN { get; set; }

        [Required]
        [StringLength(9, ErrorMessage ="ID card muber must be 9 symbols.")]
        public int IDcardNumber { get; set; } // 1 FK

        [Required]
        public DateTime Birthdate { get; set; }
        
        [Required]
        public Location Location { get; set; }
        
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        private User()
        {
            // implement the foreign key with navigation properties
            // idcartnumber fk to idcard pk dosuments
        }
        public User(string fname, string mname, string lname, int eGN, int iDcardNumber, DateTime birthdate, Location location, string address, string email, string username, string password)
        {
            Fname = fname;
            Mname = mname;
            Lname = lname;
            EGN = eGN;
            IDcardNumber = iDcardNumber;
            Birthdate = birthdate;
            Location = location;
            Address = address;
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
