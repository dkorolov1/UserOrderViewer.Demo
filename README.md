# UserOrderViewer App 📋
This project is a demo application designed & developed to explore the capabilities of **.NET 8 Minimal API** in conjunction with **EF Core** and **React** (leveraging Hooks and Context API)

The solution consists of two parts: the **demoapp.client** (React App) and the **demoapp.server** (.NET 8 Minimal API + EF Core Backend).

## Run It 🏃

#### Run Components Individually:

**1. Run the backend:**
  -  `cd demoapp.server`
  -  `dotnet run`
  
It's also necessary to ensure that you have a running instance of SQL Server and to override the corresponding connection string in `appsettings.Development.json`.
  
  **2. Run the frontend:**
  - `cd demoapp.client`
  - `npm start`

#### Deploy with Docker Compose:

Alternatively, you can start everything with a single command using **Docker Compose**:
 - `docker-compose up`
 - `docker-compose down -v`

# Test It Out 🎇

![enter image description here](https://i.postimg.cc/q79m23Lz/2024-08-14-22-55-12.gif)
