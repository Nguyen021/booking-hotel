using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umoozi.Domain.Entities
{
    public class House
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Range(10, 100000)]
        [Display(Name = "Price Per Night")]
        public double Price { get; set; }

        [Range(1,100)]
        [Display(Name = "Square Feet Of Room")]
        public int SquareFeet { get; set; }

        [Range(1,20)]
        public int Occupancy { get; set; }

        [Display(Name = "Image Url")]
        public string? ImgUrl { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
