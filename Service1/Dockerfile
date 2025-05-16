# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# 👇 WORKDIR /src creates a folder named src in the container and goes to it
WORKDIR /src
# restore Copy the .csproj to the "src/Service1/" folder of the container
COPY ["./Service1.csproj", "Service1/"]
RUN dotnet restore "Service1/Service1.csproj"
COPY ["./","Service1"]
WORKDIR /src/Service1
RUN dotnet build "Service1.csproj" -c Release -o /app/build

# Publish Stage
FROM build as publish
RUN dotnet publish "Service1.csproj" -c Release -o /app/publish


# Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS build
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Service1.dll"]