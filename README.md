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

## Brief Note C# and familiarity of above frameworks.
- I've used C# and these tools for quite some time now.  Refactoring and optimizing is still something that must be done but they're great tools to use.

## Setup and Installation (Execution Instructions)

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

5. From Visual Studio 2022, simply double-click on the file named "CenterfieldAPI.http" and click the "Send request" links to generate another preview window with results of the http call or use an external API testing tool like Postman.

## API Documentation

- `GET /coffeeshops/all`: Retrieve all coffee shops
- `GET /coffeeshops/e4534063-6068-08dd-adb0-1f377114ced2`: Get by Id
- `GET /coffeeshops/filter?minRating=4.95&isOpen=true`: Filter coffee shops based on rating or open status
- `POST /coffeeshops`: Create a new coffee shop entry

## TODO's (Next Steps to make this production-ready)
1. Incorporate rate-limiting.
2. Add Authorization and Authentication.
3. Stress test it thoroughly.
4. Write many more tests.
5. Cache some of the data with Redis.


## License

This project is licensed under the [CC0-1.0 license](LICENSE).
