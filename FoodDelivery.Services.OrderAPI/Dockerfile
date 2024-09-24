# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.OrderAPI/FoodDelivery.Services.OrderAPI.csproj ./FoodDelivery.Services.OrderAPI/
RUN dotnet restore "./FoodDelivery.Services.OrderAPI/FoodDelivery.Services.OrderAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.OrderAPI/ ./FoodDelivery.Services.OrderAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.OrderAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.OrderAPI/out .

# Exponer puerto
EXPOSE 7004

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.OrderAPI.dll"]
