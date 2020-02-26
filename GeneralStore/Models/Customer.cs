using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //Fat arrow makes it automatically return whatever is on the right side of the arrow.
        //Expression body is the name for the return type....is essentially a read-only property, do not need to store in database
        public string FullName => $"{FirstName}{LastName}";
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}