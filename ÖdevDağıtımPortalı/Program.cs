using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ÖdevDaðýtým.API.Data;
using ÖdevDaðýtým.API.Models;
using ÖdevDaðýtým.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// SQL Server ve DbContext Ayarý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity Ayarý
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<DataSeeder>();

// Generic Repository Kaydý
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Özel Repository Kayýtlarý
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Kaydý (En Hýzlý ve Garantili Yöntem)
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ÖdevDaðýtým.API.Helpers.MappingProfile>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedAsync();
}

app.Run();
