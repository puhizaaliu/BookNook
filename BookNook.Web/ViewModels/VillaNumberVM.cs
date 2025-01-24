using Microsoft.AspNetCore.Mvc.Rendering;
using BookNook.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace BookNook.Web.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumber? VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; }
    }
}
