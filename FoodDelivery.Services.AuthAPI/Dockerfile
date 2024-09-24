# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.AuthAPI/FoodDelivery.Services.AuthAPI.csproj ./FoodDelivery.Services.AuthAPI/
RUN dotnet restore "./FoodDelivery.Services.AuthAPI/FoodDelivery.Services.AuthAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.AuthAPI/ ./FoodDelivery.Services.AuthAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.AuthAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.AuthAPI/out .

# Exponer puerto
EXPOSE 7002

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.AuthAPI.dll"]
