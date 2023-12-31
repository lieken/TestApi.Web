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


//AddSingleton() : �U�W��q�AAddSingleton()��k�إߤ@�� Singleton �A�ȡC �����n�D�ɷ|�إ� Singleton �A�ȡC �M��A�Ҧ����򪺽ШD�����|�ϥάۦP����ҡC �]���A�q�`�A�C�����ε{���u�إߤ@�� Singleton �A�ȡA�åB�b������ε{���ͩR�g�����ϥθӳ�@��ҡC
//AddTransient() :����k�|�إߤ@�� Transient �A�ȡC �C���ШD�ɡA���|�إߤ@�ӷs�� Transient �A�ȹ�ҡC
//AddScoped() - ����k�إߤ@�� Scoped �A�ȡC �b�d�򤺪��C�ӽШD���إߤ@�ӷs�� Scoped �A�ȹ�ҡC �Ҧp�A�b Web ���ε{�����A�����C�� http �ШD�إ� 1 �ӹ�ҡA���b�ۦP Web �ШD������L�A�Ȧb�I�s�o�ӽШD���ɭԡA���|�ϥάۦP����ҡC �`�N�A���b�@�ӫȤ�ݽШD���O�ۦP���A���b�h�ӫȤ�ݽШD���O���P���C