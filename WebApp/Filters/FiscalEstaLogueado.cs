using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class FiscalEstaLogueado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("RolLogueado");
            
            // si esta logueado un FISCAL
            if (rol == "Fiscal")
            {
                context.Result = new RedirectToActionResult("Index", "Investigador", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
