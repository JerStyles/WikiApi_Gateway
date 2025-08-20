# Wikidata Explorer

A clean, layered ASP.NET Core Web API for querying and exposing Wikipedia data, following best practices for configuration, separation of concerns, and maintainability.

## Project Structure

- **Configuration & Settings**
  - `appsettings.json`: Centralized configuration (API endpoints, etc.)
  - `Settings/WikipediaApiSettings.cs`: Strongly-typed settings class
- **Data Models & DTOs**
  - `Models/WikipediaModels.cs`: Raw models matching Wikipedia API responses
  - `DTOs/`: Clean, public-facing data transfer objects (DTOs)
- **Service Layer**
  - `Services/IWikipediaService.cs`: Service interface (business logic contract)
  - `Services/WikipediaService.cs`: Implementation (fetches, transforms, and returns data)
- **Controller Layer**
  - `Controllers/WikipediaController.cs`: Thin API controller exposing endpoints
- **Entry Point**
  - `Program.cs`: Configures DI, settings, middleware, and starts the app

## How It Works

1. **Configuration**: All external values (like Wikipedia API URLs) are stored in `appsettings.json` and mapped to a POCO for type safety.
2. **Models & DTOs**: Models mirror the raw Wikipedia API; DTOs are what your API returns to clients.
3. **Service Layer**: Handles all business logic, HTTP calls, and data transformation. Exposes simple async methods.
4. **Controller**: Receives HTTP requests, validates input, and delegates to the service layer. No business logic here.
5. **Startup**: `Program.cs` wires everything together, registers services, and configures middleware.

## Getting Started

1. **Clone the repository**
2. **Configure your settings**
   - Edit `appsettings.json` with your Wikipedia API endpoints or credentials if needed.
3. **Build and run**
   - Using the .NET CLI:
     ```sh
     dotnet build
     dotnet run --project wikidata_explorer.sln
     ```
   - Or use the provided VS Code tasks (`build`, `watch`, `publish`).
4. **Explore the API**
   - Swagger UI is available at `/swagger` when running locally.

## Example API Endpoints

- `GET /api/wikipedia/search?query=...` — Search Wikipedia articles
- `GET /api/wikipedia/pages` — List available Wikipedia page endpoints

## Best Practices Followed

- All configuration is externalized and strongly typed
- Models and DTOs are clearly separated
- Business logic is isolated in services
- Controllers are thin and focused
- Dependency Injection is used throughout
- Global exception handling is configured

## Contributing

1. Fork the repo and create your branch
2. Make your changes (keep layers clean and follow the blueprint)
3. Submit a pull request

## License

MIT License
