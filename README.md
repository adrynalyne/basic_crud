# REST Names API

This project is a small ASP.NET Core Web API that demonstrates basic CRUD operations against a `NameItem` resource.

CRUD stands for:

- Create
- Read
- Update
- Delete

These are the four most common operations performed on stored data. In web APIs, CRUD operations are often exposed through HTTP endpoints.

## How CRUD relates to REST

REST is an architectural style for designing networked applications around resources.

In this project, the main resource is a name entry:

- A collection of names: `/api/names`
- A single name: `/api/names/{id}`

CRUD maps neatly to common HTTP methods:

- `POST /api/names` creates a new name
- `GET /api/names` reads all names
- `GET /api/names/{id}` reads one name
- `PUT /api/names/{id}` updates an existing name
- `DELETE /api/names/{id}` deletes a name

This does not make every API fully RESTful by itself, but it is the usual starting point for a resource-based API design.

## What this project uses

- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI for interactive API testing

The application stores data in a local SQLite database file:

- `restnames.db`

The database is created automatically on startup.

## Project structure

- [Program.cs](E:/Source/REST/Program.cs) configures services, Entity Framework, and Swagger
- [Controllers/NamesController.cs](E:/Source/REST/Controllers/NamesController.cs) exposes the API endpoints
- [Models/NameItem.cs](E:/Source/REST/Models/NameItem.cs) defines the resource model
- [Data/AppDbContext.cs](E:/Source/REST/Data/AppDbContext.cs) defines the Entity Framework database context
- [appsettings.json](E:/Source/REST/appsettings.json) stores the SQLite connection string

## Running the project

1. Make sure you have the .NET 10 SDK installed.
2. From the project folder, run:

```powershell
dotnet run
```

3. Open the Swagger UI in your browser.

By default, the launch settings currently use:

- `https://localhost:7228`
- `http://localhost:5147`

Swagger is configured at the site root, so opening the app URL should bring up the API UI.

## Using the API

### Create a name

`POST /api/names`

Example request body:

```json
{
  "name": "Ada Lovelace"
}
```

If no `id` is supplied, the API creates one automatically.

### Read all names

`GET /api/names`

Returns the full list of saved names.

### Read one name

`GET /api/names/{id}`

Returns a single name record by its GUID.

### Update a name

`PUT /api/names/{id}`

Example request body:

```json
{
  "id": "11111111-1111-1111-1111-111111111111",
  "name": "Grace Hopper"
}
```

The route id and body id must match.

### Delete a name

`DELETE /api/names/{id}`

Deletes the matching record and returns `204 No Content`.

## Example workflow

1. Create a name with `POST /api/names`
2. Copy the returned `id`
3. Fetch it with `GET /api/names/{id}`
4. Change it with `PUT /api/names/{id}`
5. Remove it with `DELETE /api/names/{id}`

## Notes

- This project is intentionally small and focused on the basics.
- It is a good starting point for learning CRUD and resource-oriented API design.
