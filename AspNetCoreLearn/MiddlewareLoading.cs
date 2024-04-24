using AspNetCoreLearn.CustomMiddlewares;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace AspNetCoreLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}







//app.UseLoginMiddleware();

//app.Use(async (HttpContext ctx, RequestDelegate next) =>
//{
//    await ctx.Response.WriteAsync("\nThis is the first middleware\n");
//    await next(ctx);
//});

//app.Use(async (HttpContext ctx, RequestDelegate next) =>
//{
//    await ctx.Response.WriteAsync("\nThis is after the login middleware\n");
//    await next(ctx);
//});

//app.Run(async (HttpContext ctx) =>
//{
//    await ctx.Response.WriteAsync("\nThis is the final middleware\n");
//});










//Dictionary<int, string> countries = new Dictionary<int, string>()
//            {
//                { 1, "United States" },
//                { 2, "Canada" },
//                { 3, "United Kingdom" },
//                { 4, "India" },
//                { 5, "Japan" }
//            };

//app.UseRouting();

//app.UseEndpoints(async endpoints =>
//{
//    endpoints.MapGet("/countries", async context =>
//    {
//        foreach (var country in countries)
//        {
//            await context.Response.WriteAsync($"{country.Key}.{country.Value}\n");
//        }
//    });

//    endpoints.MapGet("/countries/{countryID:int:range(1,100)}", async context =>
//    {
//        context.Response.StatusCode = 404;
//        int countryID = Convert.ToInt32(context.Request.RouteValues["countryID"]);
//        if (countries.ContainsKey(countryID))
//        {
//            await context.Response.WriteAsync($"The country you requested for is {countries[countryID]}");
//        }
//        else
//        {
//            await context.Response.WriteAsync($"No country exists with country ID {countryID}");
//        }
//    });
//    endpoints.MapGet("/countries/{countryID:int:min(101)}", async context =>
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
//    });
//});

//app.Run(async context =>
//{
//    await context.Response.WriteAsync($"You're at the default path {context.Request.Path}");
//});