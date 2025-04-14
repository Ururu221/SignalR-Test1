using SignalR_1.Hub;

namespace SignalR_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавляем поддержу Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Включаем SignalR
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            // HTTPS
            app.UseHttpsRedirection();

            // Разрешаем отдавать статические файлы (wwwroot)
            // Чтобы мы могли положить index.html, app.js, style.css и проверять
            app.UseDefaultFiles();   // Попытается найти "index.html" по умолчанию
            app.UseStaticFiles();

            // Мапим наш хаб
            app.MapHub<ChatHub>("/chatHub");

            // На корень "/" просто текст
            app.MapGet("/", () => "Hello World!");

            // Запуск приложения
            app.Run();
        }
    }
}
