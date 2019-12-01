﻿namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.Product;

    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
            = new HashSet<Sale>();
    }
}