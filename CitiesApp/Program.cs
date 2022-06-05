using Microsoft.EntityFrameworkCore;
using Ru_Cities_Lab.Models;


var builder = WebApplication.CreateBuilder(args);
string con = @"Server=(localdb)\mssqllocaldb;Database=citiesBd;Trusted_Connection=True;";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
