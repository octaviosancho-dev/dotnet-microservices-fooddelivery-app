# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.ProductAPI.csproj ./
RUN dotnet restore "./FoodDelivery.Services.ProductAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./ ./

# Compilar y publicar el código
WORKDIR /app
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer puerto
EXPOSE 7000

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.ProductAPI.dll"]