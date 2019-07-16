FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./EmployeeService/
# COPY utils/*.csproj ./utils/
WORKDIR /app/EmployeeService
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY EmployeeService/. ./EmployeeService/
# COPY utils/. ./utils/
WORKDIR /app/EmployeeService
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
COPY --from=build /app/EmployeeService/EmployeeService/out ./
ENTRYPOINT ["dotnet", "EmployeeService.dll"]