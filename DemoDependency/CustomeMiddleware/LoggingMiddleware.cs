namespace DemoDependency.CustomeMiddleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            Console.WriteLine($"[{DateTime.Now}] Request: {context.Request.Method} {context.Request.Path}");

            // Call next middleware
            await _next(context);

            Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
        

    }
    }
}
