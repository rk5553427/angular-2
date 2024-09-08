using Employee_Angular_WebAPI_2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cs = builder.Configuration.GetConnectionString("constr");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(cs));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "MyPolicy",
    builder =>
    {
      builder.WithOrigins("http://localhost:4200")
      .AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
