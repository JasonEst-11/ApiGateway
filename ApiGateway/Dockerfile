# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# 👇 WORKDIR /src creates a folder named src in the container and goes to it
WORKDIR /src
# restore Copy the .csproj to the "src/ApiGateway/" folder of the container
COPY ["./ApiGateway.csproj", "ApiGateway/"]
RUN dotnet restore "ApiGateway/ApiGateway.csproj"
COPY ["./","ApiGateway"]
WORKDIR /src/ApiGateway
RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build

# Publish Stage
FROM build as publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish


# Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS build
ENV ASPNETCORE_HTTP_PORTS=5000
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","ApiGateway.dll"]