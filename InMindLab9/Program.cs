using InMindLab9.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddSignalR();

var app = builder.Build();
app.UseStaticFiles();
app.UseCors("AllowAll");

app.MapHub<ChatHub>("/chathub");

app.Run();