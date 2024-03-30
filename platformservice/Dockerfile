FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything
COPY *.csproj ./
# Restore as distinct layers
RUN dotnet restore

COPY . ./
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "platformservice.dll"]

# docker run -p 8080:8080 -d krishnanandpatl/platformservice:5.0 (dotnet default port changed to 8080)
# To revert back docker run --rm -d -p 8000:80 -e ASPNETCORE_HTTP_PORTS=80 mcr.microsoft.com/dotnet/samples:aspnetapp