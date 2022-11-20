using Basket.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add redis 
IConfiguration configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .Build();

builder.Services.AddStackExchangeRedisCache(options =>
{
     options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
   // options.Configuration = "localhost:6379";
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// Add services to the container.
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
