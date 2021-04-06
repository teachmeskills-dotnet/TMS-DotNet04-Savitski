FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["Savatski.Diploma.Bot.csproj", "Savatski.Diploma.Bot/"]
RUN dotnet restore "Savatski.Diploma.Bot/Savatski.Diploma.Bot.csproj"
WORKDIR "/src/Savatski.Diploma.Bot"
COPY . .
RUN dotnet build "Savatski.Diploma.Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Savatski.Diploma.Bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Savatski.Diploma.Bot.dll