
# UserOrderViewer App 📋
This project is a demo application designed & developed to test the capabilities of .NET 8 Minimal API in combination with EF Core and React.

The solution consists of two parts: the **demoapp.client** (React.js) and the **demoapp.server** (.NET 8 Minimal API + EF Core).

## Run It 🏃

 1. Run the backend:
  -  `cd demoapp.server`
  -  `dotnet run`
  -  It's also necessary to ensure that you have a running instance of SQL Server and to override the corresponding connection string in `appsettings.Development.json`.
 2. Run the frontend:
  - `cd demoapp.client`
  - `npm start`

...Alternatively, you can start everything with a single command using Docker Compose:
 - `docker-compose up`
 - `docker-compose down -v`