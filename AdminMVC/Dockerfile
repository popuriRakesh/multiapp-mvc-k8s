FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# ✅ ONLY ONE PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /dist /p:UseAppHost=false

FROM base
WORKDIR /app
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "AdminMVC.dll"]   # change DLL for User
