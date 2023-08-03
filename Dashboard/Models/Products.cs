using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
       public string ProductName { get; set; }


        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

    }
}