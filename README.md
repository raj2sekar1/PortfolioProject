# Portfolio Performance API

A .NET 8 Web API to manage investment portfolios and calculate performance over time.

## Features

- Create and manage portfolios
- Add/update/remove assets and transactions
- Calculate total value, gains/losses, and allocations
- In-memory storage (can be swapped with EF Core)
- Swagger UI enabled

## Tech Stack

- ASP.NET Core Web API (.NET 8)
- XUnit for unit testing

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [VS2022](https://visualstudio.microsoft.com/downloads/)

### Run Locally

```bash
dotnet run
```

Open solution - .\PortfolioProject\PortfolioAPI\PortfolioAPI.sln

Open browser at: `http://localhost:5000/swagger`

API is accessible at `http://localhost:8080/swagger`

## Running Tests

```bash
dotnet test
```

## Sample Data

refer - SampleIRequestResponse.md

## Sample API Request

- Add Portfolio
- Add Asset
- Add Transaction
- Get Portfolios
- Retrieve Portfolio Performance
