FROM mcr.microsoft.com/powershell:7.1.4-ubuntu-focal AS build

ENV \
    NO_AT_BRIDGE=1 \
    DOCKER_CONTAINER_NAME="ubuntu_netcore_keyring" \
     # Unset ASPNETCORE_URLS from aspnet base image
    ASPNETCORE_URLS= \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # SDK version
    DOTNET_SDK_VERSION_5.0=5.0.401 \
    DOTNET_SDK_VERSION_3_1=3.1.413 \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetSDK-Ubuntu-20.04 \
    # Setup Dotnet envs
    DOTNET_ROOT=/usr/share/dotnet  \
    PATH=$PATH:usr/share/dotnet    

# Install GNOME keyring
RUN apt-get update \
    && apt-get install -y \
        libsecret-1-dev \
        dbus-x11 \
        gnome-keyring \
        python \
        curl

# Below taken from https://hub.docker.com/_/microsoft-dotnet-sdk
# https://github.com/dotnet/dotnet-docker/blob/ca43690e6e4ac9c21a990a012dc2eb07e78daf08/src/sdk/5.0/focal/amd64/Dockerfile

# Install .NET SDK
RUN curl -SL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION_5.0/dotnet-sdk-$DOTNET_SDK_VERSION_5.0-linux-x64.tar.gz \
    && dotnet_sha512='a444d44007709ceb68d8f72dec0531e17f85f800efc0007ace4fa66ba27f095066930e6c6defcd2f85cdedea2fec25e163f5da461c1c2b8563e5cd7cb47091e0' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

RUN curl -SL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION_3_1/dotnet-sdk-$DOTNET_SDK_VERSION_3_1-linux-x64.tar.gz \
    && dotnet_sha512='2a0824f11aba0b79d3f9a36af0395649bc9b4137e61b240a48dccb671df0a5b8c2086054f8e495430b7ed6c344bb3f27ac3dfda5967d863718a6dadeca951a83' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help
