using FiveMinusThree.Api.Repository;
using FiveMinusThree.Api.Repository.TokenValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using FiveMinusThree.Api.Repository.TokenGenerators;
using FiveMinusThree.Api.Repository.RefreshTokenRepository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using FiveMinusThree.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<RefreshTokenGenerator>();
builder.Services.AddTransient<Authenticator>();
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddSingleton<ValidateRefreshToken>();
builder.Services.AddTransient<AccessTokenGenerator>();
builder.Services.AddTransient<IRefreshTokenRepository, TempTokenRepository>();
builder.Services.AddDbContext<FiveMinusThreeContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Token generation configuration
AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration();
builder.Configuration.Bind("Authentication", authenticationConfiguration);

builder.Services.AddSingleton(authenticationConfiguration);
//Add JWT decoding
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o=>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfiguration.AccessTokenSecret)),
            ValidIssuer = authenticationConfiguration.Issuer,
            ValidAudience = authenticationConfiguration.Audience,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ClockSkew = TimeSpan.Zero,
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
