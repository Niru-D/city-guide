# 🌆 City Guide API

An ASP.NET Core Web API to manage city details, with basic CRUD operations, authentication, logging, and a clean MVC architecture. The app allows you to retrieve, create, update, and delete city information through a RESTful interface.

---

## 🚀 Features

- **CRUD Operations**: Perform Create, Read, Update, and Delete operations on city details.
- **Authentication**: Secure API endpoints with JWT authentication.
- **Logging**: Integrated logging for better tracking and debugging of requests.
- **Swagger**: Interactive API documentation with Swagger for easy testing and exploration of the API.
- **MVC Architecture**: A clean Model-View-Controller architecture to maintain separation of concerns and scalability.

---

## 📦 Tech Stack

- **.NET 8**: The core framework for the application.
- **Entity Framework Core**: ORM for managing city data in a database.
- **SQL Server**: Relational database.
- **JWT Authentication**: Secure API endpoints with JSON Web Tokens.
- **Swagger UI**: Automatically generated API documentation for easy testing.
- **Logging**: Integrated logging via Microsoft.Extensions.Logging.
  
---

## 🧑‍💻 Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/Niru-D/city-guide.git
cd CityGuide
```

### 2. Install dependencies
Make sure you have .NET 8 SDK installed. If you don't, download it from the official website.
```bash
dotnet restore
```

### 3. Configure the database connection
Open appsettings.json and configure the connection string for your database:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=your-server;Database=CityGuideDb;User Id=your-username;Password=your-password;"
}
```

### 4. Apply migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```

---

## 📄 Swagger Documentation

Once the API is running, you can access the Swagger UI for interactive API documentation by visiting:
https://localhost:port-number/swagger

---

## 🎓 Course Reference

This project is referenced from the **Pluralsight course**: https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-fundamentals/table-of-contents.
