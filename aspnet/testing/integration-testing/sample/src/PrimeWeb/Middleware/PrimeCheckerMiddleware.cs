using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using PrimeWeb.Services;
using System;
using System.Threading.Tasks;

namespace PrimeWeb.Middleware
{
    public class PrimeCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly PrimeCheckerOptions _options;

        public PrimeCheckerMiddleware(RequestDelegate next,
            PrimeCheckerOptions options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (!request.Path.HasValue ||
                request.Path != _options.Path)
            {
                await _next.Invoke(context);
            }
            else
            {
                int numberToCheck;
                try
                {
                    numberToCheck = int.Parse(request.QueryString.Value.Replace("?", ""));
                    var primeService = new PrimeService();
                    if (primeService.IsPrime(numberToCheck))
                    {
                        await context.Response.WriteAsync(numberToCheck + " is prime!");
                    }
                    else
                    {
                        await context.Response.WriteAsync(numberToCheck + " is NOT prime!");
                    }
                }
                catch
                {
                    await context.Response.WriteAsync(String.Format("Pass in a number to check in the form {0}?5", _options.Path));
                }
            }
        }
    }
}
