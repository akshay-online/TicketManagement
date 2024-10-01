# Ticket Management System

This project is a Ticket Management System built with ASP.NET Core targeting .NET 8. It includes a web application for managing tickets and unit tests for ensuring the application's functionality.

## Project Structure

- **TicketManagement**: The main web application project.
- **TicketTest**: Unit tests for the Ticket Management System using xUnit.
- **TicketsAutoTest**: Automated tests using NUnit and Selenium.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other IDE that supports .NET development.

### Setup

1. Clone the repository:

```
git clone https://github.com/your-repo/ticket-management-system.git
cd ticket-management-system
```
    
1. Open the solution in Visual Studio.

1. Restore the dependencies:

```
dotnet restore
```
    
### Running the Application

1. Navigate to the `TicketManagement` project.
1. Run the application:
```
dotnet run
```

### Running Tests
```
dotnet test
```
#### xUnit Tests

1. Navigate to the `TicketTest` project.
1. Run the tests:
```
dotnet test
```
