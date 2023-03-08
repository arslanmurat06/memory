using ChannelPubSub;
using ChannelPubSub.BackgroundServices;
using ChannelPubSub.PubSub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPub, Pub>();
builder.Services.AddSingleton<ISub, Sub>();
builder.Logging.AddConsole();

builder.Services.AddSingleton<IMessageBroker, MessageBroker>();
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

