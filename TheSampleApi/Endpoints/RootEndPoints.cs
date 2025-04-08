namespace TheSampleApi.Endpoints
{
    public static class RootEndPoints
    {
        public static void AddRootEndPoints(this WebApplication app)
        {
            app.MapGet("/", () => "Hello World");
        }
    }
}
