#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NajotNur/src/NajotNurService/NajotNur.API/NajotNur.API.csproj", "NajotNur/src/NajotNurService/NajotNur.API/"]
COPY ["NajotNur/src/NajotNurService/NajotNur.Application/NajotNur.Application.csproj", "NajotNur/src/NajotNurService/NajotNur.Application/"]
COPY ["NajotNur/src/NajotNurService/NajotNur.Infrastructure/NajotNur.Infrastructure.csproj", "NajotNur/src/NajotNurService/NajotNur.Infrastructure/"]
COPY ["NajotNur/src/NajotNurService/NajotNur.Domain/NajotNur.Domain.csproj", "NajotNur/src/NajotNurService/NajotNur.Domain/"]
RUN dotnet restore "./NajotNur/src/NajotNurService/NajotNur.API/./NajotNur.API.csproj"
COPY . .
WORKDIR "/src/NajotNur/src/NajotNurService/NajotNur.API"
RUN dotnet build "./NajotNur.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NajotNur.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NajotNur.API.dll"]