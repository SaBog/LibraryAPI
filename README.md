# Library Web Api

### Description

The Web API project implements KRID operations as is using EF Core (does not implement borrow/return of a book to the user). For authentication, the user model email and password are required. You can perform read operations without authentication. With authentication you can perform the entire list of operations.

### Technologies 
* .Net 7.0;
* Entity Framework Core;
* MS SQLr;
* AutoMapper;
* MediatR;
* Authentication via bearer token;
* Swagger;
* EF Fluent API.

### Web API functionality:
1. Getting a list of all books;
2. Obtaining a specific book by its identifier;
3. Obtaining a book by its ISBN;
4. Adding a new book;
5. Changing information about this book; (PUT)
6. Deleting a book.
7. Authentication

### Setup

1. In project explorer find **"appsettings.json"** and set your connection string.
2. In Visual Studio open Package Manager Console (use Library.DAL project) and use command:
> Update-Database
3. Launch the project
