# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.RewardsAPI/FoodDelivery.Services.RewardsAPI.csproj ./FoodDelivery.Services.RewardsAPI/
RUN dotnet restore "./FoodDelivery.Services.RewardsAPI/FoodDelivery.Services.RewardsAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.RewardsAPI/ ./FoodDelivery.Services.RewardsAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.RewardsAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.RewardsAPI/out .

# Exponer puerto
EXPOSE 7187

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.RewardsAPI.dll"]
