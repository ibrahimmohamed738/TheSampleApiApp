using TheSampleApi.Endpoints;
using TheSampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();


app.MappAllHealthChecks();

app.AddRootEndPoints();
app.AddErrorEndPoints();
app.AddCourseEndPoints();

app.Run();

