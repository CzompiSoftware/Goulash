FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY /src .
RUN dotnet restore Goulash
RUN dotnet build Goulash -c Release -o /app

FROM build AS publish
RUN dotnet publish Goulash -c Release -o /app

FROM base AS final
LABEL org.opencontainers.image.source="https://github.com/czompisoftware/goulash"
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Goulash.dll"]
