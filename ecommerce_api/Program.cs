using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var origenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!.Split(",https://localhost:5000");
//var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(opciones => {
    opciones.AddDefaultPolicy( configuracion=>
    {   //por si no funciona origenes permitidos prueba este
        //configuracion.WithOrigins("http://localhost:4200",
        //    "https://localhost:5000"
        //    ).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        configuracion.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod().AllowCredentials();

    });
    opciones.AddPolicy("libre", configuracion =>
    {
        configuracion.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
