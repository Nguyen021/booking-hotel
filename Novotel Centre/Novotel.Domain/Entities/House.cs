﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novotel.Domain.Entities
{
    public class House
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Price per night")]
        [Range(10, 10000)]
        public double Price { get; set; }

        public int Sqft { get; set; }

        [Range(1,10)]
        public int Occupancy { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [Display(Name = "House Type")]
        public string? HouseType { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get;set; }
    }
}
