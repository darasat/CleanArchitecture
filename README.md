# 🏗️ Clean Architecture Implementation in .NET Core

A simple and practical implementation of Clean Architecture pattern in .NET Core, demonstrating separation of concerns through well-defined layers for scalability, maintainability, and testability.

[![.NET Core](https://img.shields.io/badge/.NET%20Core-6.0-blue.svg)](https://dotnet.microsoft.com/)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-green.svg)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## 🎯 Overview

This project demonstrates a Clean Architecture implementation with a simple product management API. The application is organized into distinct layers, each with specific responsibilities:

- **Domain**: Contains business entities and core logic
- **Services**: Implements business use cases and application logic  
- **Infrastructure**: Handles data access and external concerns
- **API**: Provides HTTP endpoints and handles presentation logic
- **Tests**: Contains unit and integration tests

![Clean Architecture Diagram](https://devblogs.microsoft.com/ise/next-level-clean-architecture-boilerplate/)
*Source: Microsoft DevBlogs*

## 🏛️ Architecture Layers

### Domain Layer
- Contains business entities (`Product`)
- Defines core business rules
- No dependencies on external frameworks

### Services Layer  
- Implements business use cases
- Contains service interfaces and implementations
- Depends only on the Domain layer

### Infrastructure Layer
- Handles data persistence
- External service integrations
- Depends on Domain layer

### API Layer
- HTTP controllers and endpoints
- Request/response models
- Depends on Services layer

## 🚀 Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later
- Your favorite IDE (Visual Studio, VS Code, JetBrains Rider)
- [Postman](https://www.postman.com/) or similar for API testing (optional)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/darasat/CleanArchitecture.git
   cd CleanArchitecture
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Build the solution:**
   ```bash
   dotnet build
   ```

4. **Run the API:**
   ```bash
   dotnet run --project CleanArchitectureApi
   ```

The API will be available at `https://localhost:5001` or `http://localhost:5000`

## 🔧 Project Structure

```
CleanArchitecture/
├── CleanArchitectureApi/          # API Layer
│   ├── Controllers/
│   │   └── ProductController.cs
│   ├── Program.cs
│   └── CleanArchitectureApi.csproj
├── Domain/                        # Domain Layer
│   ├── Entities/
│   │   └── Product.cs
│   └── Domain.csproj
├── Infrastructure/                # Infrastructure Layer
│   └── Infrastructure.csproj
├── Services/                      # Services Layer
│   ├── Interfaces/
│   │   └── IProductService.cs
│   ├── Services/
│   │   └── ProductService.cs
│   └── Services.csproj
├── Tests/                         # Test Projects
└── CleanArchitecture.sln
```

## 📡 API Endpoints

### Get All Products
```http
GET /api/product
```

**Response:**
```json
[
    {
        "id": 1,
        "name": "Laptop",
        "price": 1200
    },
    {
        "id": 2,
        "name": "Smartphone", 
        "price": 800
    }
]
```

### Get Product by ID
```http
GET /api/product/{id}
```

**Response:**
```json
{
    "id": 1,
    "name": "Laptop",
    "price": 1200
}
```

### Create New Product
```http
POST /api/product
Content-Type: application/json

{
    "name": "Tablet",
    "price": 500
}
```

**Response:**
```json
{
    "id": 3,
    "name": "Tablet",
    "price": 500
}
```

## 🧪 Testing the API

### Using Swagger UI
1. Run the application
2. Navigate to `https://localhost:5001/swagger`
3. Test the endpoints directly from the browser

### Using curl
```bash
# Get all products
curl -X GET https://localhost:5001/api/product

# Get product by ID
curl -X GET https://localhost:5001/api/product/1

# Create new product
curl -X POST https://localhost:5001/api/product \
  -H "Content-Type: application/json" \
  -d '{"name": "Tablet", "price": 500}'
```

### Using Postman
Import the following endpoints:
- GET: `{{baseUrl}}/api/product`
- GET: `{{baseUrl}}/api/product/{{id}}`
- POST: `{{baseUrl}}/api/product`

Where `{{baseUrl}}` is `https://localhost:5001`

## 🏗️ How to Recreate This Project

If you want to build this project from scratch, follow these steps:

### 1. Create Solution Structure
```bash
mkdir CleanArchitecture && cd CleanArchitecture
dotnet new sln -n CleanArchitecture
dotnet new webapi -n CleanArchitectureApi
dotnet new classlib -n Domain
dotnet new classlib -n Infrastructure
dotnet new classlib -n Services
```

### 2. Add Projects to Solution
```bash
dotnet sln add CleanArchitectureApi/CleanArchitectureApi.csproj
dotnet sln add Domain/Domain.csproj
dotnet sln add Infrastructure/Infrastructure.csproj
dotnet sln add Services/Services.csproj
```

### 3. Configure Project References
```bash
dotnet add CleanArchitectureApi/CleanArchitectureApi.csproj reference Services/Services.csproj
dotnet add Services/Services.csproj reference Domain/Domain.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj
```

## 🔄 Dependency Injection Configuration

The application uses .NET Core's built-in dependency injection container. Services are registered in `Program.cs`:

```csharp
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

## 🚀 Future Enhancements

This implementation can be extended with:

- **Entity Framework Core** for database integration
- **Repository Pattern** in the Infrastructure layer
- **CQRS** (Command Query Responsibility Segregation)
- **MediatR** for handling commands and queries
- **AutoMapper** for object mapping
- **FluentValidation** for input validation
- **Unit Tests** with xUnit and Moq
- **Integration Tests** for API endpoints
- **Authentication & Authorization**
- **Logging** with Serilog
- **Docker** containerization

## 🧪 Running Tests

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 📋 Code Quality

This project follows:
- **SOLID Principles**
- **Clean Code** practices
- **Dependency Inversion**
- **Separation of Concerns**
- **Single Responsibility Principle**

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Diego Alejandro Ramirez**

- 💼 LinkedIn: [diego-alejandro-ramirez-ar](https://www.linkedin.com/in/diego-alejandro-ramirez-ar/)
- 📸 Instagram: [@diego.ramirez_](https://www.instagram.com/diego.ramirez_/?hl=en)
- 🌐 Website: [stratosoft.co](https://stratosoft.co)
- ✍️ Medium: [@darasat](https://medium.com/@darasat)

## 📚 Related Articles

- 📖 [Original Medium Article (Spanish)](https://medium.com/@darasat) - Detailed tutorial on implementing Clean Architecture in .NET Core
- 📖 [Clean Architecture by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- 📖 [Microsoft's Clean Architecture Template](https://devblogs.microsoft.com/ise/next-level-clean-architecture-boilerplate/)

## ⭐ Show Your Support

Give a ⭐️ if this project helped you learn Clean Architecture!

---

**Happy Coding!** 🚀
