using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Novotel.Domain.Entities;

namespace Novotel.ViewModels
{
    public class HouseNumberVM
    {
        public HouseNumber? HouseNumber { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? HouseList { get; set; }
    }
}
