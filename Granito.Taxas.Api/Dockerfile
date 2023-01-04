#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./Granito.Taxas.Api.csproj", "Granito.Taxas.Api/"]
RUN dotnet restore "Granito.Taxas.Api/Granito.Taxas.Api.csproj"
COPY . .
WORKDIR "/src/Granito.Taxas.Api"
RUN dotnet build "Granito.Taxas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Granito.Taxas.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Granito.Taxas.Api.dll"]