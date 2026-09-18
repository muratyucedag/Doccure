using Doccure.MarketService.Context;
using Doccure.MarketService.Services.CartServices;
using Doccure.MarketService.Services.CheckoutServices;
using Doccure.MarketService.Services.ProductServices;
using Doccure.MarketService.Services.RedisServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketContext>();   
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IRedisService, RedisService>();
builder.Services.AddSingleton<ICartService, CartService>();
//builder.Services.AddScoped<ICheckoutService, CheckoutService>();
//builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICheckoutService, CheckoutService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7153/");
});

builder.Services.AddAutoMapper(typeof(Program));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
