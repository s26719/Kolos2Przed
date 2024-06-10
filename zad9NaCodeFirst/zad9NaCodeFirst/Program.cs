using Microsoft.EntityFrameworkCore;
using zad9NaCodeFirst.Context;
using zad9NaCodeFirst.Repositories;
using zad9NaCodeFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(
        "Server=DESKTOP-BHAFUI9\\SQLEXPRESS01;Database=model;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
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

/*dotnet new tool-manifest
dotnet tool install dotnet-ef   // ew --version 8.0.0


dotnet ef migrations add "init"
dotent ef database update*/


/*instaluje w nuget
    najpierw modele z uwzglednieniem polaczen tabel czyli te virtual Icollection

    pozniej tworze context -> alt+insert constructor i dodaje se konstruktory -> dodaje se dbsety dla kazdego modelu

efConfiguration -> czyli tworze po prostu tabele do bazy gdzie uzwgledniam ograniczenia na atrybutach itp. builder.parameter, hasKey, isRequired itp..
    dodaje to do context alt+insert override i wybieram OnModelCreating
    teraz komendami dodaje migracje
    no i koncowki*/