using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novotel.Domain.Entities
{
    public class HouseNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int House_Number { get; set; }

        [ForeignKey("House")]
        [DisplayName("House Id")]
        public int HouseId { get; set; }

        [ValidateNever]
        public House House { get; set; }
        public string? SpecialDetails { get; set; }
        public string? Status { get; set; }
    }
}
