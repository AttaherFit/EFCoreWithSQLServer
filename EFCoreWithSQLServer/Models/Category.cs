﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWithSQLServer.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        [Column(TypeName ="ntext")]
        public string? Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

        public Category()
        {
            // to enable developers to add products to a Category we must
            // initialize the navigation property to an empty collection
            Products = new HashSet<Product>();
        }
    }
}
