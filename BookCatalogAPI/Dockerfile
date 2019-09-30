FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BookCatalogAPI/BookCatalogAPI.csproj", "BookCatalogAPI/"]
RUN dotnet restore "BookCatalogAPI/BookCatalogAPI.csproj"
COPY . .
WORKDIR "/src/BookCatalogAPI"
RUN dotnet build "BookCatalogAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookCatalogAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookCatalogAPI.dll"]