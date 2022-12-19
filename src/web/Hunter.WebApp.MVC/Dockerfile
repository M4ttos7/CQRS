#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/web/Hunter.WebApp.MVC/Hunter.WebApp.MVC.csproj", "src/web/Hunter.WebApp.MVC/"]
RUN dotnet restore "src/web/Hunter.WebApp.MVC/Hunter.WebApp.MVC.csproj"
COPY . .
WORKDIR "/src/src/web/Hunter.WebApp.MVC"
RUN dotnet build "Hunter.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hunter.WebApp.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hunter.WebApp.MVC.dll"]