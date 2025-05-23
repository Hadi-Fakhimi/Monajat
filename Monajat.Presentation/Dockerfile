FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Monajat.Presentation/Monajat.Presentation.csproj Monajat.Presentation/
COPY Monajat.Application/Monajat.Application.csproj Monajat.Application/
COPY Monajat.Core/Monajat.Core.csproj Monajat.Core/
COPY Monajat.Infra.Data/Monajat.Infra.Data.csproj Monajat.Infra.Data/
COPY Monajat.Infra.IoC/Monajat.Infra.IoC.csproj Monajat.Infra.IoC/
RUN dotnet restore Monajat.Presentation/Monajat.Presentation.csproj

COPY . .

WORKDIR /src/Monajat.Presentation

RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Monajat.Presentation.dll"]
