# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./Services/FoodDelivery.Services.AuthAPI/FoodDelivery.Services.AuthAPI.csproj ./Services/FoodDelivery.Services.AuthAPI/
RUN dotnet restore "./Services/FoodDelivery.Services.AuthAPI/FoodDelivery.Services.AuthAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./Services/FoodDelivery.Services.AuthAPI/ ./Services/FoodDelivery.Services.AuthAPI/

# Compilar y publicar el código
WORKDIR /app/Services/FoodDelivery.Services.AuthAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/Services/FoodDelivery.Services.AuthAPI/out .

# Exponer puerto
EXPOSE 7002

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.AuthAPI.dll"]
