using TheSampleApi.Data;

namespace TheSampleApi.Startup
{
    public static class DependenciesConfig
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpernApiServices();
            builder.Services.AddTransient<CourseData>();
        }
    }
}
