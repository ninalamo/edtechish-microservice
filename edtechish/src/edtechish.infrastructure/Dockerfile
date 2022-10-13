FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["edtechish.infrastructure/edtechish.infrastructure.csproj", "edtechish.infrastructure/"]
RUN dotnet restore "edtechish.infrastructure/edtechish.infrastructure.csproj"
COPY . .
WORKDIR "/src/edtechish.infrastructure"
RUN dotnet build "edtechish.infrastructure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "edtechish.infrastructure.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "edtechish.infrastructure.dll"]
