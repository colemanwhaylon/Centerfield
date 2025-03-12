# Centerfield

This repository contains a REST API service designed to test your ability to build a robust backend system. The project demonstrates how business logic can be implemented as code, focusing on key features such as entity management and API responses.

## Features

- API endpoints for managing coffee shops
- CRUD operations on coffee shops (Create, Read, Update, Delete)
- Filters for coffee shop search by rating or open status
- Sequential GUID generation for new coffee shop entries
- Integration with an in-memory database for testing

## Technologies Used

- .NET 9
- ASP.NET Core
- Entity Framework Core
- LINQ queries for data manipulation
- SQLite

## Setup and Installation

1. Clone this repository:
    ```bash
    git clone https://github.com/colemanwhaylon/Centerfield.git
    ```

2. Navigate to the project folder and restore dependencies:
    ```bash
    cd Centerfield
    dotnet restore
    ```

3. Run the project:
    ```bash
    dotnet run
    ```

4. API will be available at `http://localhost:5119`.

## API Documentation

- `GET /coffeeshops/all`: Retrieve all coffee shops
- `GET /coffeeshops/filter`: Filter coffee shops based on rating or open status
- `POST /coffeeshops`: Create a new coffee shop entry

## License

This project is licensed under the [CC0-1.0 license](LICENSE).
