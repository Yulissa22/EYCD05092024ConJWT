//Importar el espacio de nombres donde se encuentra 
//la interfaz IJwtAuthenticationService
using EYCD05092024ConJWT.Auth;

//Importar el espacio de nombres que contiene 
// la definicion de los endpoints de la aplicacion
using EYCD05092024ConJWT.Endpoints;

//Importar el espacio de nombres necesario para 
// configurar la autenticacion basada en tokens JWT
using Microsoft.AspNetCore.Authentication.JwtBearer;

//Importar el espacio de nombres para trabajar
//con tokens de seguridad 
using Microsoft.IdentityModel.Tokens;

// Importar el espacio de nombres para definir la 
//documentacion de la API con Swagger 
using Microsoft.OpenApi.Models;

// Importar el espacio de nombres para trabajar con
// codificacion de texto y bytes
using System.Text;

//crea un objeto "builder" para configurar la aplicacion 
var builder = WebApplication.CreateBuilder(args);

// Agregar un servicio para permitir la exploracion 
// de Api endpoint
builder.Services.AddEndpointsApiExplorer();

//Configurar Swagger para documentar la API
builder.Services.AddSwaggerGen( c =>
{
    //Definir informacion basica de la API en Swagger
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT API", Version = "v1" });

    //Configurar un esquema de seguridad para JWT en Swagger
    var jwtSecuritySchema = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Ingresar tu token de JWT Authentication",

        //Hacer referencia al esquema de seguridad JWT definido anteriormente 
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(jwtSecuritySchema.Reference.Id, jwtSecuritySchema);

    //Agregar un requisito de seguridad para JWT en Swagger
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecuritySchema, Array.Empty<string>() } });
});

//Configurar politica de autorizacion 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedInPolicy", policy =>
    {
        //Requiere que el usuario este autenticado para acceder a recursos protegidos
        policy.RequireAuthenticatedUser();
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



app.Run();

