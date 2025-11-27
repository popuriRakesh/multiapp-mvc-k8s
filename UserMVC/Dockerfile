FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY UserMVC.csproj .
RUN dotnet restore "UserMVC.csproj"

COPY . .
RUN dotnet publish -c Release -o /dist

FROM base
WORKDIR /app
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "UserMVC.dll"]
