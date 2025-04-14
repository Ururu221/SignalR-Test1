// Создаем connection к нашему хабу ("/chatHub")
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")  // Адрес нашего хаба
    .build();

// Функция, которая выводит текст в блок #messagesArea
function appendMessage(text) {
    const messagesArea = document.getElementById("messagesArea");
    const p = document.createElement("p");
    p.innerText = text;
    messagesArea.appendChild(p);
}

// Подписываемся на метод JoinMessage (из интерфейса IChatClient)
connection.on("JoinMessage", (userId) => {
    appendMessage(`[JoinMessage] Клиент ${userId} зашел в чат`);
});

// Подписываемся на метод BroadcastMessage
connection.on("BroadcastMessage", (userId, message) => {
    appendMessage(`[BroadcastMessage] ${userId}: ${message}`);
});

// Запускаем соединение
connection.start()
    .then(() => {
        appendMessage("Соединение установлено!");
    })
    .catch(err => {
        console.error(err);
    });

// Вешаем обработчик на кнопку "Отправить"
const sendBtn = document.getElementById("sendBtn");
sendBtn.addEventListener("click", async () => {
    const messageInput = document.getElementById("messageInput");
    const message = messageInput.value;
    if (!message) return;

    try {
        // Вызываем метод сервера: "SendMessageToAll"
        await connection.invoke("SendMessageToAll", message);
        messageInput.value = "";
    } catch (err) {
        console.error(err);
    }
});
