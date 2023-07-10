using NovaEnergies.Core.Clients;
using NovaEnergies.Core.Services;
using NovaEnergies.Core.Settings;
using AutoMapper;
using NovaEnergies.Core.Profiles;
using NovaEnergies.Core.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching(x => x.MaximumBodySize = 1024);

var providerOneSettings = builder.Configuration.GetSection("ProviderOneSettings").Get<ProviderOneSettings>();
var providerTwoSettings = builder.Configuration.GetSection("ProviderTwoSettings").Get<ProviderTwoSettings>();

builder.Services.AddSingleton<ProviderOneSettings>(providerOneSettings);
builder.Services.AddSingleton<ProviderTwoSettings>(providerTwoSettings);

builder.Services.AddSingleton<ISearchService, SearchService>();
builder.Services.AddSingleton<IExecutionHttpRequestClient, ExecutionHttpRequestClient>();

builder.Services.AddSingleton<IProviderApiClient, Provider1ApiClient>();
builder.Services.AddSingleton<IProviderApiClient, Provider2ApiClient>();

builder.Services.AddAutoMapper(s => s.AddProfile<AutoMapperProfile>());
builder.Services.AddSingleton<IMessageHelper, MessageHelper>();



var app = builder.Build();


app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

//app.Use(async (context, next) =>
//{
//    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
//    {
//        Public = true,
//        MaxAge = TimeSpan.FromSeconds(120)
//    };
//    await next();
//});

app.UseAuthorization();

app.MapControllers();

app.Run();
