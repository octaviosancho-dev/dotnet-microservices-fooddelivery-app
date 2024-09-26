# FoodDeliveryApp

**FoodDeliveryApp** is an online food delivery and purchase application that allows users to add products to the cart, make purchases, and manage both purchase orders and products. The application follows a microservices architecture, ensuring scalability and ease of maintenance.

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Recent Updates](#recent-updates)
- [Prerequisites](#prerequisites)
- [Setup and Execution](#setup-and-execution)
- [API Documentation](#api-documentation)
- [Technologies Used](#technologies-used)

## Overview

**FoodDeliveryApp** provides a comprehensive solution for purchasing food products. Users can explore products, add them to the cart, complete purchases, and manage their orders. Each component of the application is handled by a specific microservice, enabling independent deployment and maintenance.

![image](https://github.com/user-attachments/assets/c2935573-c298-4f28-8a08-e557b817b8c3)

## Architecture

The application is built with independent microservices for each key functionality:

- **Authentication Service**: Manages user registration, login, and roles.
- **Products Service**: Provides details of available products for purchase.
- **Orders Service**: Manages the flow of purchase orders from creation to delivery.
- **Coupons Service**: Manages the generation and validation of discount coupons.
- **Rewards Service**: Manages the rewards system for users.
- **Shopping Cart Service**: Allows users to add, modify, and remove products from their cart.
- **Emails Service**: Handles email notifications such as order confirmations and status updates.

![image](https://github.com/user-attachments/assets/332e3d51-a293-487a-a24c-3248be3d21f6)

Each microservice is autonomous, with its own database and business logic. Communication between them is handled asynchronously using queues and topics with **RabbitMQ**.

## Recent Updates

- **Docker Integration**: Dockerfiles have been added for each microservice, and the application can now be orchestrated with `docker-compose.yml` to simplify deployment and local testing.
- **Message Bus Hosted on CloudAMQP**: The RabbitMQ message bus has been migrated to CloudAMQP for asynchronous communication between services.
- **Database Migration to PostgreSQL**: The application's database infrastructure has been transitioned from MSSQL to PostgreSQL. Entity Framework Core has been configured to support this change.
- **Deployment on Render.com**: The entire application, including all microservices and PostgreSQL database, is deployed and hosted on Render.com.

## Prerequisites

Ensure you have the following tools installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or any compatible editor)

## Setup and Execution


### Clone the repository

```bash
git clone https://github.com/octaviosancho-dev/dotnet-microservices-fooddelivery-app.git
cd dotnet-microservices-fooddelivery-app
```


## Running the Application Locally

To run the entire application, open Visual Studio 2022 and configure the startup as Multiple startup projects:

![image](https://github.com/user-attachments/assets/7a9c8218-918b-4405-8d05-9499d2596e38)


Each appsettings.json file is configured for production by default. To run the application locally, you need to update the URLs in the ServiceUrls section and connection strings as follows:

- Comment out the production URLs and uncomment the localhost URLs in the appsettings.json files for each service. For example, in FoodDelivery.Web:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-KH8OVIA;Database=FoodDelivery_Auth;Trusted_Connection=True;TrustServerCertificate=True",
  //"PostgreSqlConnection": "Host=dpg-crpkrt08fa8c73e3k4vg-a;Port=5432;Database=UsersDB;Username=fooddeliverydb_is4x_user;Password=jJkIG50sStqzrRzRLBu9fTGdIRZKiyCY;"
  //"DEBUGGING":
  "PostgreSqlConnection": "Host=dpg-crpkrt08fa8c73e3k4vg-a.oregon-postgres.render.com;Port=5432;Database=UsersDB;Username=fooddeliverydb_is4x_user;Password=jJkIG50sStqzrRzRLBu9fTGdIRZKiyCY;"
}
```

```json
"ServiceUrls": {
  //"AuthAPI": "https://fooddelivery-services-authapi.onrender.com",
  //"ProductAPI": "https://fooddelivery-gatewaysolution.onrender.com",
  
  "AuthAPI": "https://localhost:7002",
  "ProductAPI": "https://localhost:7777"
  }
```

- After modifying the necessary configurations, navigate to each service folder and run the service using the command:

```bash
cd FoodDelivery.Services.AuthAPI
dotnet run
```
Repeat the same for each microservice.


## Running the Application via Docker Compose
To run the entire application using Docker Compose, execute the following command in the root directory of the project where the docker-compose.yml file is located:

```bash
docker-compose up
```
This will start all the microservices, PostgreSQL database, and RabbitMQ using the pre-configured Docker containers.

## API Documentation

Swagger is available to interact with the API:

```bash
http://localhost:{port}/swagger/index.html
```

## Technologies Used

- .NET 8
- Docker
- RabbitMQ (hosted on CloudAMQP)
- PostgreSQL (as the main database)
- Entity Framework Core (for data access)
- Render.com (for deployment)
- Swagger (for API documentation)
- Ocelot Gateway (for routing between microservices)
- Stripe Payments API (for payment management)

  
