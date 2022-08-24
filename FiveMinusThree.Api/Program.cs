using FiveMinusThree.Api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using FiveMinusThree.Api.Repository.RefreshTokenRepository;
using FiveMinusThree.Api.Repository.ThemeRepository;
using FiveMinusThree.Api.Repository.ReplyRepository;
using FiveMinusThree.Api.Repository.PostRepository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using FiveMinusThree.Api.Data;
using FiveMinusThree.Api.Services.TokenServices.TokenGenerators;
using FiveMinusThree.Api.Services.TokenServices.TokenValidator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Repository
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient <IReplyRepository,ReplyRepository>();
builder.Services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddTransient<IThemeRepository, ThemeRepository>();
builder.Services.AddTransient<IPostRepository,PostRepository>();
//TokenServices
builder.Services.AddSingleton<RefreshTokenGenerator>();
builder.Services.AddTransient<Authenticator>();
builder.Services.AddSingleton<ValidateRefreshToken>();
builder.Services.AddTransient<AccessTokenGenerator>();
builder.Services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddDbContext<FiveMinusThreeContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Token generation configuration
AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration();
builder.Configuration.Bind("Authentication", authenticationConfiguration);
builder.Services.AddSingleton(authenticationConfiguration);
//Add JWT Authentication
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
