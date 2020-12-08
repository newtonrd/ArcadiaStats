FROM node:latest AS node_base

RUN echo "NODE Version:" && node --version
RUN echo "NPM Version:" && npm --version

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
COPY --from=node_base . .
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY --from=node_base . .
WORKDIR /src
COPY WebUI/WebUI.csproj WebUI/
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
RUN dotnet restore WebUI/WebUI.csproj
COPY . .
WORKDIR /src/WebUI
RUN dotnet build WebUI.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish WebUI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArcadiaStats.WebUI.dll"]