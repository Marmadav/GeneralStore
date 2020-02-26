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
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        //A ForeignKey just like Product
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        //Could also do [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }

        public DateTime DateOfTransaction { get; set; }
        public decimal TotalCost => Product.Price * ProductCount;
        
        public int ProductCount { get; set; }
    }
}