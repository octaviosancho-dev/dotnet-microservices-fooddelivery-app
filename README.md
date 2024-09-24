# FoodDeliveryApp

**FoodDeliveryApp** is an online food delivery and purchase application that allows users to add products to the cart, make purchases, and manage both purchase orders and products. The application follows a microservices architecture, ensuring scalability and ease of maintenance.

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Setup and Execution](#setup-and-execution)
- [API Documentation](#api-documentation)
- [Technologies Used](#technologies-used)

## Overview

**FoodDeliveryApp** provides a comprehensive solution for purchasing food products. Users can explore products, add them to the cart, complete purchases, and manage their orders. Each component of the application is handled by a specific microservice, enabling independent deployment and maintenance.

## Architecture

The application is built with independent microservices for each key functionality:

- **Authentication Service**: Manages user registration, login, and roles.
- **Products Service**: Provides details of available products for purchase.
- **Orders Service**: Manages the flow of purchase orders from creation to delivery.
- **Coupons Service**: Manages the generation and validation of discount coupons.
- **Rewards Service**: Manages the rewards system for users.
- **Shopping Cart Service**: Allows users to add, modify, and remove products from their cart.
- **Emails Service**: Handles email notifications such as order confirmations and status updates.



Each microservice is autonomous, with its own database and business logic. Communication between them is handled asynchronously using queues and topics with **RabbitMQ**.

## Prerequisites

Ensure you have the following tools installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or any compatible editor)

## Setup and Execution

### Clone the repository

```bash
git clone https://github.com/octavio-sancho/FoodDeliveryApp.git
cd FoodDeliveryApp
```
## Run the Application

To manually run each microservice, navigate to the service directory and execute the following command on dotnet console:

```bash
cd FoodDelivery.Services.AuthAPI
dotnet run
```
Repeat this process for each microservice in the application.

## API Documentation

Swagger is available to interact with the API:

```bash
http://localhost:{port}/swagger
```

## Technologies Used

- .NET 8
- Docker
- RabbitMQ (for messaging between microservices)
- Entity Framework Core (for data access)
- Swagger (for API documentation)
- Ocelot Gateway (for routing between microservices)
- Stripe Payments API (for payment management)
