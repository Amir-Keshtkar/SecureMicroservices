using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MoviesContext>(x => x.UseInMemoryDatabase("Movies"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SeedDatabase(app);
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
static void SeedDatabase(IHost host){
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    var moviesContext = services.GetRequiredService<MoviesContext>();
    MovieContextSead.SeedAsync(moviesContext);
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
