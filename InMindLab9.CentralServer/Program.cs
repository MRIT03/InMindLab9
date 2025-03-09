using InMindLab9.CentralServer.Hubs;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add Redis backplane for distributed SignalR instances
builder.Services.AddSignalR()
    .AddStackExchangeRedis("localhost:6379", options =>
    {
        options.Configuration.ChannelPrefix = "SignalR";
    });

var app = builder.Build();

app.UseCors("AllowAll");
app.MapHub<ChatHub>("/chathub");

app.Run();
