# SignalR_1

A simple ASP.NET Core application demonstrating a real-time chat using SignalR.

## Overview
- **Program.cs**: Configures and runs the web application, adds SignalR, Swagger, and static file serving.
- **ChatHub.cs**: Defines the Hub, handling client connections (`OnConnectedAsync`, `OnDisconnectedAsync`) and sending messages.
- **wwwroot**: Contains static files (HTML, CSS, JavaScript) for testing the chat interface.
