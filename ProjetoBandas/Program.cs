using ProjetoBandas;
using ProjetoBandas.Entidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

BandasContext.Bandas = new List<Banda>()
{

    new Banda{ Id = 1, Nome = "Metallica", AnoFormacao = DateTime.Now.AddYears(-20) },
    new Banda{ Id = 2, Nome = "Iron Maiden", AnoFormacao = DateTime.Now.AddYears(-22) },
    new Banda{ Id = 3, Nome = "Deep Purple", AnoFormacao = DateTime.Now.AddYears(-25) }
};


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

