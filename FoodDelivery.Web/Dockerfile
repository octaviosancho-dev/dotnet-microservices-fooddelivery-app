# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar y compilar el código
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer puerto
EXPOSE 80

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Web.dll"]