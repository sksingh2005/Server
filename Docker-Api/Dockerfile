# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Add Zscaler cert (optional if your environment requires it)
COPY ["zscaler-root-cert.crt", "/etc/ssl/certs/zscaler-root-cert.crt"]
RUN mkdir -p /usr/local/share/ca-certificates
COPY ["zscaler-root-cert.crt", "/usr/local/share/ca-certificates/zscaler-root-cert.crt"]
RUN cat /usr/local/share/ca-certificates/zscaler-root-cert.crt >> /etc/ssl/certs/ca-certificates.crt

# Restore dependencies (important: copy only csproj first for caching)
COPY Docker-Api.csproj .
RUN dotnet restore Docker-Api.csproj

# Now copy the rest of the files and build
COPY . .
RUN dotnet publish Docker-Api.csproj -c Release -o /api

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /api .

# Expose port (match Program.cs/launchSettings.json)
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "Docker-Api.dll"]
