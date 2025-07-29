var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//everything after this configuring "middleware"
//that is stuff that will intercept incoming our outgoing HTTP request
//and process them in some way

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers(); //Go find all the controllers and look at th
Console.WriteLine("Fixing to run your API");
app.Run(); //this is a "blocking method" a while(true) {..}
Console.WriteLine("done running your API");

public partial class Program;
