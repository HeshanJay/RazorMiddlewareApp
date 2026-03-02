namespace AspNetCoreMiddleware;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Request.Headers.Append(
            "X-Timestamp",
            DateTime.Now.ToLongTimeString()
        );

        context.Response.Headers.Append(
            "X-Content-Type-Options",
            "nosniff"
        );

        await next(context);
    }
}

public static class MyCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseMyCustom(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyCustomMiddleware>();
    }
}