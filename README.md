# ShopSuite.Api

ShopSuite.Api is a .NET 8 Web API project designed to provide backend services for managing shop-related operations. It features modular architecture with clear separation of concerns, including services, repositories, and API endpoints. The project supports JWT-based authentication and is configured for multiple environments (Development, Beta, Production).

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Configuration](#configuration)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Product Management:** CRUD operations for products.
- **Authentication:** JWT-based authentication for secure API access.
- **Repository Pattern:** Abstracted data access layer for maintainability.
- **Environment Configuration:** Supports Development, Beta, and Production settings.
- **Logging:** Configurable logging levels for diagnostics.

## Tech Stack

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core** (assumed for data access)
- **SQL Server** (default connection)
- **JWT Authentication**

## Configuration

Configuration files are located in the `ShopSuite.Api` project:

- `appsettings.json` (default)
- `appsettings.Development.json`
- `appsettings.Beta.json`
- `appsettings.Production.json`

### Settings to Update

- **ConnectionStrings:** Update with your SQL Server details.
- **Jwt:** Set your secret key, issuer, and audience for authentication.
- **Logging:** Adjust log levels as needed.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server instance

### Setup

1. **Clone the repository:**

2. **Configure the database connection:**
Edit `appsettings.Development.json` with your SQL Server details.

3. **Restore NuGet packages:**

4. **Build the project:**

5. **Run database migrations (if applicable):**

6. **Run the API:**

## Project Structure

- **Controllers:** API endpoints for products and authentication.
- **Services:** Business logic implementations.
- **Repositories:** Data access layer.

## API Endpoints

### Products

- `GET /api/products`  
Retrieve all products.

- `GET /api/products/{id}`  
Retrieve product by ID.

- `POST /api/products`  
Create a new product.

- `PUT /api/products/{id}`  
Update an existing product.

- `DELETE /api/products/{id}` 
Delete a product.

## Authentication

ShopSuite.Api uses JWT for authentication. After logging in, include the token in the `Authorization` header for protected endpoints:

## Usage Examples

### Example: Get All Products

```http
GET /api/products HTTP/1.1
Host: localhost:5000
Authorization: Bearer your_jwt_token
```

# Response
```json
{
  "products": [
    {
      "id": 1,
      "name": "Product 1",
      "price": 9.99,
      "description": "Description for product 1",
      "stock": 100
    },
    {
      "id": 2,
      "name": "Product 2",
      "price": 19.99,
      "description": "Description for product 2",
      "stock": 50
    }
  ]
}

```

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.


**For further documentation, refer to the source code and XML comments.**
