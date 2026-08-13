using FluentValidation;

namespace CleanArchitecture.WebApi.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(new
            {
                errors = exception.Errors.Select(error => new
                {
                    field = error.PropertyName,
                    message = error.ErrorMessage
                })
            });
        }
    }
}
