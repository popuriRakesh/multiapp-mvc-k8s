FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY UserMVC.csproj ./
RUN dotnet restore "UserMVC.csproj"

COPY . .
RUN dotnet publish "UserMVC.csproj" -c Release -o /dist /p:UseAppHost=false

FROM base
WORKDIR /app
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "UserMVC.dll"]
