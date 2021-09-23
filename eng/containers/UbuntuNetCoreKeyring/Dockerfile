FROM mcr.microsoft.com/powershell:7.1.4-ubuntu-focal AS build

ENV \
    NO_AT_BRIDGE=1 \
    DOCKER_CONTAINER_NAME="ubuntu_netcore_keyring" \
     # Unset ASPNETCORE_URLS from aspnet base image
    ASPNETCORE_URLS= \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # SDK version
    DOTNET_SDK_VERSION=5.0.401 \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetSDK-Ubuntu-20.04

# Install GNOME keyring
RUN apt-get update \
    && apt-get install -y \
        libsecret-1-dev \
        dbus-x11 \
        gnome-keyring \
        python \
        curl

# Below taken from https://hub.docker.com/_/microsoft-dotnet-sdk
# 5.0.401-focal-amd64, 5.0-focal-amd64, 5.0.401-focal, 5.0-focal	Dockerfile	Ubuntu 20.04	09/14/2021

# Install .NET SDK
RUN curl -SL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz \
    && dotnet_sha512='a444d44007709ceb68d8f72dec0531e17f85f800efc0007ace4fa66ba27f095066930e6c6defcd2f85cdedea2fec25e163f5da461c1c2b8563e5cd7cb47091e0' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    #&& tar -C /usr/share/dotnet -oxzf dotnet.tar.gz ./packs ./sdk ./templates ./LICENSE.txt ./ThirdPartyNotices.txt \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help
