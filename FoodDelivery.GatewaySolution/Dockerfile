# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Imagen ligera de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto 80 (o el puerto donde escuche Ocelot)
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "FoodDelivery.GatewaySolution.dll"]
