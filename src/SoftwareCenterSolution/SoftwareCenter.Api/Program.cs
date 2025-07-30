using FluentValidation;
using Marten;
using SoftwareCenter.Api.Vendors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorizationBuilder().AddPolicy("CanAddVendor", pol =>
{
    pol.RequireRole("Manager");
    pol.RequireRole("SoftwareCenter");
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("db") ??
    throw new Exception("Need a connection string.");

builder.Services.AddMarten(config =>
{
    //It will give us a scoped service called IDocumentSession injected to your controller
    config.Connection(connectionString);
}).UseLightweightSessions();

builder.Services.AddScoped<IValidator<CreateVendorRequest>, CreateVendorRequestValidator>();
builder.Services.AddScoped<IValidator<CreateVendorPointOfContactRequest>,
    CreateVendorPointOfContactRequestValidator>();
//It will give us a scoped service called IDocumentSession

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
//request _____ response
//everything after this configuring "middleware"
//that is stuff that will intercept incoming our outgoing HTTP request
//and process them in some way

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication(); //when request is in to see if authenticated
app.UseAuthorization(); //when request is in to see if authorized

app.MapControllers(); //Go find all the controllers and look at th
Console.WriteLine("Fixing to run your API");
app.Run(); //this is a "blocking method" a while(true) {..}
Console.WriteLine("done running your API");

public partial class Program;
