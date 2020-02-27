using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        //A ForeignKey just like Product...The ForeignKey relates
        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        //Could also do [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }

        public DateTime DateOfTransaction { get; set; }
        public decimal TotalCost
        {
            get
            {
                return (Product!=null)? Product.Price * ProductCount:0;
            }
        }
        [Required]
        public int ProductCount { get; set; }
    }
}