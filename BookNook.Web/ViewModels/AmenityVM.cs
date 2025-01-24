using Microsoft.AspNetCore.Mvc.Rendering;
using BookNook.Domain.Entities;


namespace BookNook.Web.ViewModels
{
    public class AmenityVM
    {
        public Amenity? Amenity { get; set; }
        [Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; }
    }
}
