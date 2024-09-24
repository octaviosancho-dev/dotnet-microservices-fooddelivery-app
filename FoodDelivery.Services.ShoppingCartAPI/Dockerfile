# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.ShoppingCartAPI/FoodDelivery.Services.ShoppingCartAPI.csproj ./FoodDelivery.Services.ShoppingCartAPI/
RUN dotnet restore "./FoodDelivery.Services.ShoppingCartAPI/FoodDelivery.Services.ShoppingCartAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.ShoppingCartAPI/ ./FoodDelivery.Services.ShoppingCartAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.ShoppingCartAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.ShoppingCartAPI/out .

# Exponer puerto
EXPOSE 7003

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.ShoppingCartAPI.dll"]
