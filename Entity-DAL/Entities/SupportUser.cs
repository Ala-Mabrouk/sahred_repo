using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_DAL.Entities
{
    public class SupportUser

    {   

        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lastname is required!")]
        public string LastName { get; set; }

       [Required(ErrorMessage ="Email is required!")]
       [EmailAddress(ErrorMessage ="Please enter a valid email adresse!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password  is required!")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
      
        public string Role { get; set; }
        
        public int Level { get; set; }
    }
}
