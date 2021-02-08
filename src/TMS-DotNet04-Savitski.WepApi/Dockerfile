FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["TMS-DotNet04-Savitski.WepApi.csproj", "TMS-DotNet04-Savitski.WepApi/"]
RUN dotnet restore "TMS-DotNet04-Savitski.WepApi/TMS-DotNet04-Savitski.WepApi.csproj"
WORKDIR "/src/TMS-DotNet04-Savitski.WepApi"
COPY . .
RUN dotnet build "TMS-DotNet04-Savitski.WepApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TMS-DotNet04-Savitski.WepApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TMS-DotNet04-Savitski.WepApi.dll