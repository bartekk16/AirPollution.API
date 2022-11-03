using AirPollution.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//void ConfigureServices(IServiceCollection services)
//{
//    services.AddSingleton

//    services.AddControllersWithViews();
//}

builder.Services.AddSingleton<IHomeService, HomeService>();
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

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

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
