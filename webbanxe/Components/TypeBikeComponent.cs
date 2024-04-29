using Microsoft.AspNetCore.Mvc;
using webbanxe.Data;

namespace webbanxe.Components
{ 
    [ViewComponent(Name = "TypeBike")]
    public class TypeBikeComponent:ViewComponent
    {
            private DataContext _context;
            public TypeBikeComponent(DataContext context)
            {
                _context = context;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
                var listType = from m in _context.TypeBike.ToList() select m;

                return await Task.FromResult((IViewComponentResult)View("Default", listType));
            }
        }

}
