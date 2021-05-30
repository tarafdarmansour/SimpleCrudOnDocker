#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY *.sln .
COPY SimpleCrudOnDocker/*.csproj ./SimpleCrudOnDocker/
RUN dotnet restore 
COPY SimpleCrudOnDocker/. ./SimpleCrudOnDocker/
WORKDIR /src/SimpleCrudOnDocker
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "SimpleCrudOnDocker.dll"]

