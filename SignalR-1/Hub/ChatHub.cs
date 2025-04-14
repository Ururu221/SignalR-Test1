using Microsoft.AspNetCore.SignalR;
using SignalR_1.Hub.Interfaces;

namespace SignalR_1.Hub
{
    public sealed class ChatHub : Hub<IChatClient>
    {
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogWarning("Клиент {ConnectionId} подключился", Context.ConnectionId);
            // Сообщаем всем, что присоединился новый клиент
            await Clients.All.JoinMessage(Context.ConnectionId);

            // Всегда вызывать базовый метод в override
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogCritical("Клиент {ConnectionId} отключился", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToAll(string message)
        {
            _logger.LogInformation("Клиент {ConnectionId} отправил сообщение: {Message}",
                Context.ConnectionId, message);

            // Отправляем сообщение всем (BroadcastMessage — метод в интерфейсе)
            await Clients.All.BroadcastMessage(Context.ConnectionId, message);
        }
    }
}
