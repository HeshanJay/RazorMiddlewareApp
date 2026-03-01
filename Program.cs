var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Use(async (context, next) =>
{
    context.Request.Headers.Append(
        "X-Timestamp",
        DateTime.Now.ToLongTimeString()
    );

    context.Response.Headers.Append(
        "X-Content-Type-Options",
        "nosniff"
    );

    await next();
});

// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Hello World!");
// });

app.Run();
