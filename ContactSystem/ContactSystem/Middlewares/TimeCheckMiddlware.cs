namespace ContactSystem.Server.Middlewares
{
    public class TimeCheckMiddlware
    {
        private readonly RequestDelegate _next;

        public TimeCheckMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var now = DateTime.Now.TimeOfDay;
            var start = new TimeSpan(9, 0, 0);
            var end = new TimeSpan(18, 0, 0);

            if (now >= start && now <= end)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Bu xizmat faqat 09:00 dan 18:00 gacha ishlaydi.");
            }
        }
    }
}
