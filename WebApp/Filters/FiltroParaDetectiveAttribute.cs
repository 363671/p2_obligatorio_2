using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class FiltroParaDetectiveAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("RolLogueado");

            // si esta logueado un DETECTIVE no debe acceder al ALTA de CASOS
            if (rol == "Detective")
            {
                context.Result = new RedirectToActionResult("Index", "Investigador", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
