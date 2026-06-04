#  ASP.NET Core Web API Project

Modern backend development practices using ASP.NET Core, Entity Framework Core and layered architecture.

##  Project Overview

This project was developed during my internship at Süvari as part of backend development training and API architecture practices.

The main goal of the project is to build a secure, maintainable and scalable RESTful API by applying layered architecture principles and modern backend development concepts.

---

#  Architecture

The project is designed using a layered architecture approach:

* **Core Layer** → Business rules and domain models
* **DataAccess Layer** → Database operations and repositories
* **Entities Layer** → Entity definitions
* **API Layer** → Controllers and HTTP endpoints

This structure improves:

* maintainability
* separation of concerns
* scalability
* testability

---

#  Features

* RESTful API development
* CRUD operations
* JWT Authentication & Authorization
* Password Hashing & Salting
* Dependency Injection
* Layered Architecture
* Entity Framework Core integration
* SQL Server database management
* API testing with Postman
* AutoMapper usage
* Scoped / Transient / Singleton service lifetimes
* JSON-based data exchange

---

#  Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* AutoMapper
* Dependency Injection
* Postman
* C#

---

#  Security

The project includes:

* JWT-based authentication
* Authorization mechanisms
* Password hashing & salting
* Secure API endpoint structure

---

#  Project Structure

```bash
API/
 ├── API
 ├── Business
 ├── Core
 ├── DataAccess
 ├── Entities
```

---

#  Getting Started

## Clone the repository

```bash
git clone <repo-url>
```

## Install dependencies

```bash
dotnet restore
```

## Run the project

```bash
dotnet run
```

---

#  API Testing

API endpoints were tested using Postman.

Example operations:

* User authentication
* CRUD operations
* Authorized requests

---

#  Learning Outcomes

Throughout this project, I improved my knowledge in:

* backend architecture
* API security
* dependency injection
* database management
* layered architecture
* RESTful API design principles

---

#  Developer

Gamze Sabah
Backend Developer | ASP.NET Core | .NET

