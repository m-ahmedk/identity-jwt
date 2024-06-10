# Overview
This project is a comprehensive demonstration of using .NET Core Identity for user registration, login, and roles management, along with JWT for secure access to API modules. The project also leverages AutoMapper for efficient object-to-object mapping.

## Key Features
1. User Management:
- __Register__: Allows users to create new accounts.
- __Login__: Enables users to authenticate and receive a JWT token.
- __Roles Management__: Assign and manage user roles to control access to different modules.

2. JWT Authentication:
- Secures API endpoints by requiring a valid JWT token in the request header.
- Verifies the token and checks user roles for accessing specific resources.

3. AutoMapper:
- Simplifies object-to-object mapping, reducing boilerplate code required for data transformations.
        
## Project Structure
- __Controllers__: Handle incoming HTTP requests for registration, login, and accessing secure endpoints.
- __Services__: Contain business logic for user management, token generation, and role verification.
- __Mappings__: Configure AutoMapper profiles for efficient data transfer objects (DTOs) mapping.

## Steps

1. Clone the Repository:

``` 
git clone https://github.com/m-ahmedk/identity-jwt.git
cd your-repo
```

2. Configure Database:
Update the connection string in appsettings.json to point to your database.

3. Run Migrations:
dotnet ef database update

4. Build & Run:
```
dotnet build
dotnet run
```

## Contact
For questions or further assistance, please contact me at m.ahmedk287@gmail.com