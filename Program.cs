using ApiRest.Services;
using webapi;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<Context>("Data Source=CDINFWSW1009\\SQLEXPRESS12;Initial Catalog=TareasDb;Integrated Security=SSPI;Persist Security Info=False;Encrypt=False");
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IAnimalPerroService>(a=>new AnimalService());
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
