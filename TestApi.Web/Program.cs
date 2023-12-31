using Microsoft.Extensions.Configuration;
using TestApi.Web.Core.Helper;
using TestApi.Web.Service.Interface;
using TestApi.Web.Service.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDatabaseService, DatabaseService>();

builder.Services.AddTransient(provider =>
{
     return new DapperHelper(builder.Configuration.GetConnectionString("localhost"));
});
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


//AddSingleton() : 顧名思義，AddSingleton()方法建立一個 Singleton 服務。 首次要求時會建立 Singleton 服務。 然後，所有後續的請求中都會使用相同的實例。 因此，通常，每個應用程式只建立一次 Singleton 服務，並且在整個應用程式生命週期中使用該單一實例。
//AddTransient() :此方法會建立一個 Transient 服務。 每次請求時，都會建立一個新的 Transient 服務實例。
//AddScoped() - 此方法建立一個 Scoped 服務。 在範圍內的每個請求中建立一個新的 Scoped 服務實例。 例如，在 Web 應用程式中，它為每個 http 請求建立 1 個實例，但在相同 Web 請求中的其他服務在呼叫這個請求的時候，都會使用相同的實例。 注意，它在一個客戶端請求中是相同的，但在多個客戶端請求中是不同的。