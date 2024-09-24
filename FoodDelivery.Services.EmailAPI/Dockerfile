# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.EmailAPI/FoodDelivery.Services.EmailAPI.csproj ./FoodDelivery.Services.EmailAPI/
RUN dotnet restore "./FoodDelivery.Services.EmailAPI/FoodDelivery.Services.EmailAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.EmailAPI/ ./FoodDelivery.Services.EmailAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.EmailAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.EmailAPI/out .

# Exponer puerto
EXPOSE 7029

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.EmailAPI.dll"]
