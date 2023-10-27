using AutoMapper;
using MCF_AppData.Database;
using MCF_AppService.Services.BpkbAppService;
using MCF_AppService.Services.LoginAppService;
using MCF_BackEnd.ConfigProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LoginDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LoginDbConnection")));

builder.Services.AddDbContext<FirstDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("FirstDbConnection")));

builder.Services.AddDbContext<SecondDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecondDbConnection")));

// Add services to the container.
// AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Config());
});
var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<ILoginAppService, LoginAppService>();
builder.Services.AddTransient<IBpkbAppService, BpkbAppService>();

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
