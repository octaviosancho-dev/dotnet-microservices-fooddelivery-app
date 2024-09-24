# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo .csproj específico y restaurar dependencias
COPY ./FoodDelivery.Services.CouponAPI/FoodDelivery.Services.CouponAPI.csproj ./FoodDelivery.Services.CouponAPI/
RUN dotnet restore "./FoodDelivery.Services.CouponAPI/FoodDelivery.Services.CouponAPI.csproj"

# Copiar todo el resto del código del microservicio
COPY ./FoodDelivery.Services.CouponAPI/ ./FoodDelivery.Services.CouponAPI/

# Compilar y publicar el código
WORKDIR /app/FoodDelivery.Services.CouponAPI
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/FoodDelivery.Services.CouponAPI/out .

# Exponer puerto
EXPOSE 7001

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "FoodDelivery.Services.CouponAPI.dll"]
