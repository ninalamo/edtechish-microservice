FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["edtechish.domain/edtechish.domain.csproj", "edtechish.domain/"]
RUN dotnet restore "edtechish.domain/edtechish.domain.csproj"
COPY . .
WORKDIR "/src/edtechish.domain"
RUN dotnet build "edtechish.domain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "edtechish.domain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "edtechish.domain.dll"]
