# .Net + Blazor Assesmet

### Description
Task manager for users and task in .net + blazor using entity framwork core.

### Technologies
List the main technologies and tools used in the project.

Example:
- ASP.NET Core (.NET 8)
- Entity Framework Core
- Microsoft SQL Server
- Docker
- Azure Data Studio
- Visual Studio Code

### Setup

#### Prerequisites
Make sure to have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)


### Usage
To run the project it is necessary to create a appSetting.json file with this example 
```json
{
  "ApiKey": "your-key",
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "AppSettings": {
    "SecretKey": "your_secret_key",
    "ApiEndpoint": "https://api.example.com"
  }
}
```
after you should run the migrations 
``` bash
  dotnet ef database update
```

then you should specify wich project you want to start, if the api or backoffice

```bash
dotnet run --project Assesments.Api
dotnet run --project Assesments.BackOffice
