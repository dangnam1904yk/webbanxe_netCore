using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using webbanxe.Models;

namespace webbanxe.Models.ModelView
{
    public class ViewBike
    {
        public Bike Bike { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> ListTypeBike { get; set; }

    }
}
