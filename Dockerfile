FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY /src .
RUN dotnet restore Goulash
RUN dotnet build Goulash -c Release -o /app

FROM build AS publish
RUN dotnet publish Goulash -c Release -o /app

FROM base AS final
LABEL org.opencontainers.image.source="https://github.com/loic-sharma/Goulash"
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Goulash.dll"]
