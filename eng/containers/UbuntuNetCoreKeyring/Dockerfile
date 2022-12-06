FROM mcr.microsoft.com/powershell:7.2.1-ubuntu-focal AS build

ENV \
    NO_AT_BRIDGE=1 \
    DOCKER_CONTAINER_NAME="ubuntu_netcore_keyring" \
     # Unset ASPNETCORE_URLS from aspnet base image
    ASPNETCORE_URLS= \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # SDK version
    DOTNET_SDK_VERSION_5_0=5.0.404 \
    DOTNET_SDK_VERSION_3_1=3.1.416 \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetSDK-Ubuntu-20.04 \
    # Setup Dotnet envs
    DOTNET_ROOT=/usr/share/dotnet  \
    PATH=$PATH:usr/share/dotnet    

# Install apt-add-repository
RUN apt-get update && apt-get install -y software-properties-common

# Install GNOME keyring, git >= 2.35 (for 'git sparse-checkout add' command)
RUN apt-add-repository ppa:git-core/ppa \
    && apt-get update \
    && apt-get install -y \
        libsecret-1-dev \
        dbus-x11 \
        gnome-keyring \
        python \
        curl \
        git


# Install .NET SDK

# Below adapated from https://hub.docker.com/_/microsoft-dotnet-sdk
# https://github.com/dotnet/dotnet-docker/blob/b20c03e0644b42167d66a85fe6077ec2428a47fa/src/sdk/5.0/focal/amd64/Dockerfile
RUN curl -fSL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION_5_0/dotnet-sdk-$DOTNET_SDK_VERSION_5_0-linux-x64.tar.gz \
    && dotnet_sha512='6f9b83b2b661ce3b033a04d4c50ff3a435efa288de1a48f58be1150e64c5dd9d6bd2a4bf40f697dcd7d64ffaac24f14cc4a874e738544c5d0e8113c474fd2ee0' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

# Below adapted from https://hub.docker.com/_/microsoft-dotnet-sdk
# https://github.com/dotnet/dotnet-docker/blob/b20c03e0644b42167d66a85fe6077ec2428a47fa/src/sdk/3.1/focal/amd64/Dockerfile
RUN curl -fSL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION_3_1/dotnet-sdk-$DOTNET_SDK_VERSION_3_1-linux-x64.tar.gz \
    && dotnet_sha512='dec1dcf326487031c45dec0849a046a0d034d6cbb43ab591da6d94c2faf72da8e31deeaf4d2165049181546d5296bb874a039ccc2f618cf95e68a26399da5e7f' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help
