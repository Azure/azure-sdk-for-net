FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build

RUN apt-get update && apt-get install -y libsecret-1-dev dbus-x11 gnome-keyring

ENV NO_AT_BRIDGE=1
ENV DOCKER_CONTAINER_NAME=".Net Core 2.1 with Keyring"
