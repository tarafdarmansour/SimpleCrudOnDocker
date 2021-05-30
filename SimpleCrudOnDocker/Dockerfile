#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpleCrudOnDocker/SimpleCrudOnDocker.csproj", "SimpleCrudOnDocker/"]
RUN dotnet restore "SimpleCrudOnDocker/SimpleCrudOnDocker.csproj"
COPY . .
WORKDIR "/src/SimpleCrudOnDocker"
RUN dotnet build "SimpleCrudOnDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleCrudOnDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCrudOnDocker.dll"]