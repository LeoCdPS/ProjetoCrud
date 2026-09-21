using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var conectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");


// Configuração do Entity Framework Core para usar o MySQL como banco de dados.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        conectionString,
        ServerVersion.AutoDetect(conectionString)
    )
);


// Configuração de autenticação JWT (JSON Web Token) para proteger a API.
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/shop-api";
        options.Audience = "shop-api";
    });



// Configuração de HSTS (HTTP Strict Transport Security) para reforçar a segurança do aplicativo.
builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(365);
    options.IncludeSubDomains = true;
    options.Preload = true;
});



// Configuração de Rate Limiting para limitar o número de solicitações que um cliente pode fazer em um determinado período de tempo.
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("api", limiter =>
    {
        limiter.PermitLimit = 10;
        limiter.Window = TimeSpan.FromMinutes(1);
        limiter.QueueLimit = 0;
    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});


// Configuração de CORS (Cross-Origin Resource Sharing) para permitir que o frontend acesse a API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFront", policy =>
    {
        policy.WithOrigins(
            "http://ambulatorial.gearhostpreview.com",
            "https://ambulatorial.gearhostpreview.com",

            // Frontend local
            "http://127.0.0.1:5500",
            "http://localhost:5500"
        )
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors("PermitirFront");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRateLimiter();
app.MapControllers();
app.Run();