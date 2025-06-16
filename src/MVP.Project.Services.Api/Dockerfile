#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/MVP.Project.Services.Api/MVP.Project.Services.Api.csproj", "src/MVP.Project.Services.Api/"]
COPY ["src/MVP.Project.Application/MVP.Project.Application.csproj", "src/MVP.Project.Application/"]
COPY ["src/MVP.Project.Domain/MVP.Project.Domain.csproj", "src/MVP.Project.Domain/"]
COPY ["src/MVP.Project.Infra.Data/MVP.Project.Infra.Data.csproj", "src/MVP.Project.Infra.Data/"]
COPY ["src/MVP.Project.Infra.CrossCutting/MVP.Project.Infra.CrossCutting.csproj", "src/MVP.Project.Infra.CrossCutting/"]
RUN dotnet restore "src/MVP.Project.Services.Api/MVP.Project.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/MVP.Project.Services.Api"
RUN dotnet build "MVP.Project.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVP.Project.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVP.Project.Services.Api.dll"]
