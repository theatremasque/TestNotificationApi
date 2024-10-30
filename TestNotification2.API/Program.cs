using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using TestNotification2.API;
using TestNotification2.API.Infrastructure;
using TestNotification2.API.Sender;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddDbContext<NotificationDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Notify")));
builder.Services.AddHangfire(opt => 
    opt.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("Notify")));
builder.Services.AddMediatR(opt => 
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddHangfireServer();

builder.Services.AddSingleton<IMessageCreator, PublicationMessageCreator>(); // stateless 
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.Configure<SmtpSettings>(builder
    .Configuration.GetSection("SmtpSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();