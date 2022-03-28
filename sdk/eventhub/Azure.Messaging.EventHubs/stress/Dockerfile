FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

WORKDIR /app
COPY ./tests/*.csproj /app
RUN dotnet restore

FROM build-env as publish
WORKDIR /app
COPY . .

ENTRYPOINT [ "dotnet", "run"]