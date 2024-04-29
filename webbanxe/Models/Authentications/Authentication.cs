using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;

namespace webbanxe.Models.Authentications
{
    public class Authentication:ActionFilterAttribute
    {
        public const int ROLE_ADMIN= 1;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(context.HttpContext.Session.GetString("username") == null)
            {   
                if(context.HttpContext.Session.GetString("role")== null)
                {
                    context.Result = 
                    new RedirectToRouteResult(

                           new RouteValueDictionary
                                 {
                                     {"Controller","Account" },
                                     {"Action","Login" }
                            });
                }
                else
                {
                    context.Result =
                    new RedirectToRouteResult(

                           new RouteValueDictionary
                                 {
                                     {"Controller","Account" },
                                     {"Action","Login" }
                            });
                }
            }
            else
            {
                if (Int32.Parse(context.HttpContext.Session.GetString("role")) != ROLE_ADMIN)
                {
                    context.Result = new RedirectToRouteResult(

                    new RouteValueDictionary
                    {
                        {"Controller","Home" },
                        {"Action","Index" }
                    });
                }
                
            }
        }
    }
}
