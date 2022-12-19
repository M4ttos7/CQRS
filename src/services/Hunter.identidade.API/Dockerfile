#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/Hunter.identidade.API/Hunter.identidade.API.csproj", "src/services/Hunter.identidade.API/"]
RUN dotnet restore "src/services/Hunter.identidade.API/Hunter.identidade.API.csproj"
COPY . .
WORKDIR "/src/src/services/Hunter.identidade.API"
RUN dotnet build "Hunter.identidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hunter.identidade.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hunter.identidade.API.dll"]