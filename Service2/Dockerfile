# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# 👇 WORKDIR /src creates a folder named src in the container and goes to it
WORKDIR /src
# restore Copy the .csproj to the "src/Service2/" folder of the container
COPY ["./Service2.csproj", "Service2/"]
RUN dotnet restore "Service2/Service2.csproj"
COPY ["./","Service2"]
WORKDIR /src/Service2
RUN dotnet build "Service2.csproj" -c Release -o /app/build

# Publish Stage
FROM build as publish
RUN dotnet publish "Service2.csproj" -c Release -o /app/publish


# Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=5002
EXPOSE 5002
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Service2.dll"]