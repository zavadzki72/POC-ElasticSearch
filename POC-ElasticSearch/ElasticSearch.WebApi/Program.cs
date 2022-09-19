using AutoMapper;
using ElasticSearch.WebApi;
using ElasticSearch.WebApi.Interfaces;
using ElasticSearch.WebApi.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration((config) => {
    config.AddProfile(new MapProfile());
});
mapperConfig.AssertConfigurationIsValid();
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ITeamQuery, TeamQuery>();

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
