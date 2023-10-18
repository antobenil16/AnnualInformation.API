using AnnualInformation.API;
using AnnualInformation.API.Data;
using AnnualInformation.API.Service;
using AnnualInformation.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers();
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddTransient<IBankService,BankService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(typeof(MappingConfig));
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
