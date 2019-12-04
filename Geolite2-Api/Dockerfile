#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Geolite2-Api/Geolite2-Api.csproj", "Geolite2-Api/"]
RUN dotnet restore "Geolite2-Api/Geolite2-Api.csproj"
COPY . .
WORKDIR "/src/Geolite2-Api"
RUN dotnet build "Geolite2-Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Geolite2-Api.csproj" -c Release -o /app/publish

FROM base AS final
#Download current maxmind database
RUN curl -O https://geolite.maxmind.com/download/geoip/database/GeoLite2-Country.tar.gz
RUN mkdir /maxmind
RUN tar -C /maxmind -zxvf GeoLite2-Country.tar.gz --strip-components 1
ENV GeoIP__Database /maxmind/GeoLite2-Country.mmdb

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Geolite2-Api.dll"]