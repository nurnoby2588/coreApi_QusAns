namespace coreApi_QusAns.Model
{
    public class ExceptionHandleingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandleingMiddleware> _logger;

        public ExceptionHandleingMiddleware( RequestDelegate next, ILogger<ExceptionHandleingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);


            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
           // _logger.LogError(exception, "An unexpected error occurred");
           ErrorLog.SaveErrorLog("GlobalSction",exception.ToString());

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync("");
        }
    }
}
