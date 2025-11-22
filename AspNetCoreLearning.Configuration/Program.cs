using AspNetCoreLearning.Configuration.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));
builder.Services.Configure<SmtpModel>(builder.Configuration.GetSection("SmtpSettings"));

builder.Configuration
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddJsonFile("appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables();


builder.Services.AddOptions();
// Add services to the container.
builder.Services.AddSingleton<ISmtpSettings, SmtpSettings>();

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
