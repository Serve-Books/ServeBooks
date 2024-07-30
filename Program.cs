using Microsoft.EntityFrameworkCore;
using ServeBooks.Data;
using ServeBooks.Services.Libros;
using ServeBooks.Services.Prestamos;
using ServeBooks.Services.Correos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ServeBooks.Services;
using Libreria.Sevices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt =>
opt.UseMySql(builder.Configuration.GetConnectionString("MysqlConnection"),
Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>{
    options.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5242", //Add the Environment variable  Users
        ValidAudience = "http://localhost:5242", //Audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mcjfnvjfnvhbvncfjccmkcc-nduxhdbhcbfhcbfhvcrvyecbcd@"))
    };
});

builder.Services.AddScoped<ILibrosRepository, LibrosRepository>();
builder.Services.AddScoped<IPrestamosRepository, PrestamosRepository>();
builder.Services.AddScoped<ICorreoRepository, CorreoRepository>();
builder.Services.AddScoped<IJwtRepository, JwtRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


