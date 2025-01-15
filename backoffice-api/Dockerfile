FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Usa l'immagine SDK .NET per la build e la gestione delle migrazioni
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backoffice-api/backoffice-api.csproj", "backoffice-api/"]
RUN dotnet restore "backoffice-api/backoffice-api.csproj"
COPY . .
WORKDIR "/src/backoffice-api"
RUN dotnet build "backoffice-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "backoffice-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backoffice-api.dll"]
