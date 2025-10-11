FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OneManDev_PI.csproj", "./"]
RUN dotnet restore "./OneManDev_PI.csproj"
COPY . .
RUN dotnet build "OneManDev_PI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OneManDev_PI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneManDev_PI.dll"]
