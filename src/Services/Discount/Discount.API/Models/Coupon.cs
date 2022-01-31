﻿using System.ComponentModel.DataAnnotations;

namespace Discount.API.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}