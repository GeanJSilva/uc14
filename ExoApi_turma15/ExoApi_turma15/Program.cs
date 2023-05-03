using ExoApi_turma15.Contexts;
using ExoApi_turma15.Interfaces;
using ExoApi_turma15.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Regras do Cors:
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("https:\\localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
        );
}
);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultChallengeScheme = "JwtBearer";
        options.DefaultAuthenticateScheme = "JwtBearer";
    }
).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao")),
            ClockSkew = TimeSpan.FromMinutes(60),
            ValidAudience = "exoapi",
            ValidIssuer = "exoapi"
        };
    }
);

builder.Services.AddScoped<SqlContext, SqlContext>();
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

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

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
