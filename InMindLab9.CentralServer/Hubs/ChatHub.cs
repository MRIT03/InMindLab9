using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace InMindLab9.CentralServer.Hubs;


public class ChatHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> ClientsMap = new();

    public override Task OnConnectedAsync()
    {
        string connectionId = Context.ConnectionId;
        ClientsMap[connectionId] = connectionId;
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        ClientsMap.TryRemove(Context.ConnectionId, out _);
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessageToMicroservice(string toConnectionId, string message)
    {
        if (ClientsMap.TryGetValue(toConnectionId, out var connectionId))
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", Context.ConnectionId, message);
        }
    }

    public string GetConnectionId()
    {
        return Context.ConnectionId;
    }
}