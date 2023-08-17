using App.Core.Application.Exceptions;
using Newtonsoft.Json;

namespace App.EndPoints.API.CustomMiddleWares
{
    public class CustomExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // مدیریت استثناها
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (ex is ValidationException validationException)
            {
                // در صورت که اکسپشن نوع ValidationException باشد
                context.Response.StatusCode = 400; // Bad Request
                var errors = validationException.Errors
                                .ToList();

                var errorResponse = new
                {
                    Errors = errors
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
            else
            {
                // در غیر این صورت، برای خطاهای دیگر
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = ex.Message }));
            }
        }


    }
}
