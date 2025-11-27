FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["AdminMVC.csproj", "./"]
RUN dotnet restore "AdminMVC.csproj"

COPY . .
RUN dotnet publish "AdminMVC.csproj" -c Release -o /dist /p:UseAppHost=false

FROM base
WORKDIR /app
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "AdminMVC.dll"]
