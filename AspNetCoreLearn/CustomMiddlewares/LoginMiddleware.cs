using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace AspNetCoreLearn.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if (ctx.Request.Method == "POST")
            {
                StreamReader reader = new StreamReader(ctx.Request.Body);
                string body = await reader.ReadToEndAsync();
                Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
                if (queryDict.ContainsKey("password") && queryDict.ContainsKey("username"))
                {
                    var username = queryDict["username"];
                    var password = queryDict["password"];

                    if (username == "admin@example.com" && password == "admin1234")
                    {
                        ctx.Response.StatusCode = 200;
                        await ctx.Response.WriteAsync("\nLogin Successful\n");
                    }
                    else
                    {
                        ctx.Response.StatusCode = 400;
                        await ctx.Response.WriteAsync("\nIncorrect username or password\n");
                    }
                }
                else
                {
                    ctx.Response.StatusCode = 400;
                    if (queryDict.ContainsKey("password"))
                    {
                        await ctx.Response.WriteAsync("\nUsername is missing!\n");
                    }
                    else if (queryDict.ContainsKey("username"))
                    {
                        await ctx.Response.WriteAsync("\nPassword is missing!\n");
                    }
                }
            }
            else 
            {
                ctx.Response.StatusCode = 400;
                await ctx.Response.WriteAsync("\nThis is not a POST request!\n");
            }
            await _next(ctx);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
