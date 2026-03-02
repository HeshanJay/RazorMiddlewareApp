namespace AspNetCoreMiddleware;

public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;

    public MyCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.Headers.Append(
            "X-Timestamp",
            DateTime.Now.ToLongTimeString()
        );
        context.Response.Headers.Append(
            "X-Content-Type-Options",
            "nosniff"
        );

        await _next(context);
    }
}