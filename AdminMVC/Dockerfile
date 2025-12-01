# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY AdminMVC.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /out /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
EXPOSE 8080
COPY --from=build /out .
ENTRYPOINT ["dotnet", "AdminMVC.dll"]
