using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class VerificarSesionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var rol = context.HttpContext.Session.GetString("RolLogueado");

        // se verifica si existe un Usuario Logueado
        if (string.IsNullOrEmpty(rol))
        {
            context.Result = new RedirectToActionResult("Login", "Acceso", null);
        }

        base.OnActionExecuting(context);
    }
}