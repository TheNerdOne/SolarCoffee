# Solar Coffee

A full-stack coffee inventory and sales management system built with .NET 8 and Vue.js 3.

## Technologies

### Backend
- .NET 8.0
- Entity Framework Core 8.0
- PostgreSQL
- ASP.NET Core Identity
- Swagger/OpenAPI

### Frontend
- Vue.js 3
- TypeScript
- Vite
- Axios
- Vue Router

## Project Structure

```
SolarCoffee/
├── SolarCoffee.Data/         # Data access layer & EF Core context
├── SolarCoffee.Services/     # Business logic layer
├── SolarCoffee.Web/          # API endpoints & controllers
└── SolarCoffee.frontend/     # Vue.js frontend application
```

## Getting Started

### Prerequisites
- .NET 8 SDK
- Node.js (LTS version)
- PostgreSQL
- Visual Studio Code or Visual Studio 2022

### Backend Setup

1. Update database connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "solar.dev": "Server=localhost;Database=solardev;Port=5432;Username=your_username;Password=your_password"
  }
}
```

2. Run migrations:
```bash
cd SolarCoffee.Data
dotnet ef database update --startup-project ../SolarCoffee.Web
```

3. Start the API:
```bash
cd ../SolarCoffee.Web
dotnet run
```

### Frontend Setup

1. Install dependencies:
```bash
cd SolarCoffee.frontend
npm install
```

2. Start development server:
```bash
npm run dev
```

## Development

### Database Migrations
Use the provided Makefile commands:

```bash
# Create a new migration
make migrations mname=MigrationName

# Update database
make db
```

### API Documentation
Swagger UI is available at: `https://localhost:5001/swagger`

## Project Features
- Product inventory management
- Sales tracking
- Customer management
- Order processing
- Inventory snapshots
- User authentication

## License
This project is licensed under the MIT License.