namespace SignalR_1.Hub.Interfaces
{
    public interface IChatClient
    {
        // Уведомление о присоединении
        Task JoinMessage(string userId);

        // Публичное сообщение во время "обычного" SendMessage
        Task BroadcastMessage(string userId, string message);
    }
}
