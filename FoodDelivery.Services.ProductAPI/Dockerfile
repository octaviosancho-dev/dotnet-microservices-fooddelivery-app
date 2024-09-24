# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.ProductAPI/FoodDelivery.Services.ProductAPI.csproj ./FoodDelivery.Services.ProductAPI/
RUN dotnet restore "./FoodDelivery.Services.ProductAPI/FoodDelivery.Services.ProductAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.ProductAPI/ ./FoodDelivery.Services.ProductAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.ProductAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.ProductAPI/out .

# Exponer puerto
EXPOSE 7000

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.ProductAPI.dll"]
