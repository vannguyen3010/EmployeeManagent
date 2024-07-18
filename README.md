# Employee Management System
# Diagram
![Diagram](https://github.com/user-attachments/assets/f3d354c5-0b9a-4364-8352-a4a47889e7ce)


## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction
The Employee Management System is a web application built to manage employee information, departments, branches, and more. The front-end is developed using Blazor WebAssembly, the back-end is a Web API, and the database used is SQL Server.

## Features
- Add, edit, and delete employees
- Manage departments, branches, countries, cities, and towns
- Track overtime and leave days
- Export data to PDF and Excel

## Technologies Used
- **Front-end:** Blazor WebAssembly
- **Back-end:** ASP.NET Core Web API
- **Database:** SQL Server
- **Tools:** Visual Studio 2022, Entity Framework Core, AutoMapper, Serilog

## Architecture
The system is designed using a client-server architecture:
- **Client:** Blazor WebAssembly application that communicates with the Web API.
- **Server:** ASP.NET Core Web API that handles business logic and database operations.
- **Database:** SQL Server database for data storage.

## Prerequisites
- .NET 8 SDK
- SQL Server
- Visual Studio 2022

## Installation
1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/EmployeeManagementSystem.git
   cd EmployeeManagementSystem
Set up the database:

2. Update the connection string in appsettings.json in the Server project.
Run the database migrations to create the database schema:
bash
Copy code
cd Server
dotnet ef database update

3. Build and run the application:
# Run the API
cd Server
dotnet run

# Run the client
cd ../Client
dotnet run

