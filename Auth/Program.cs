using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using TodoStudent.Auth;
using TodoStudent.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Initialize EF Core.

#region EFCore

var connectionString = Environment.GetEnvironmentVariable("AUTH_CONNECTION_STRING") ??
                       "Host=portainer.main.kaboom.pro;Database=todo_auth;Username=postgres;Password=devversionsuck";

builder.Services.AddDbContext<AuthContext>(options => options.UseNpgsql(connectionString));

#endregion

#region Auth

// Adding Authentification helper.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { options.TokenValidationParameters = AuthService.BuilderParamethers; });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserEntity", policy => { policy.RequireClaim("Entity", "User"); });
});

#endregion

#region Services

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();

#endregion

// AutoMapper.
builder.Services.AddAutoMapper(typeof(Mappings));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Create DB.

var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AuthContext>();
await db.Database.EnsureCreatedAsync();

app.Run();