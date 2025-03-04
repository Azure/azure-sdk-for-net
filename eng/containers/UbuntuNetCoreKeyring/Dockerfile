FROM mcr.microsoft.com/azure-powershell:10.3.0-ubuntu-20.04 AS build

ENV \
    NO_AT_BRIDGE=1 \
    DOCKER_CONTAINER_NAME="ubuntu_netcore_keyring" \
     # Unset ASPNETCORE_URLS from aspnet base image
    ASPNETCORE_URLS= \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # SDK version
    DOTNET_SDK_VERSION_8_0=8.0.405\
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

# https://builds.dotnet.microsoft.com/dotnet/release-metadata/8.0/releases.json
RUN curl -fSL --output dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/a91ddad4-a3c2-4303-9efc-1ca6b7af850c/be1763df9211599df1cf1c6f504b3c41/dotnet-sdk-$DOTNET_SDK_VERSION_8_0-linux-x64.tar.gz \
    && dotnet_sha512='2499faa1520e8fd9a287a6798755de1a3ffef31c0dc3416213c8a9bec64861419bfc818f1c1c410b86bb72848ce56d4b6c74839afd8175a922345fc649063ec6' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && if [ ! -e /usr/bin/dotnet ]; then ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet; fi \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

# Below adapated from https://hub.docker.com/_/microsoft-dotnet-sdk
# https://github.com/dotnet/dotnet-docker/blob/b20c03e0644b42167d66a85fe6077ec2428a47fa/src/sdk/5.0/focal/amd64/Dockerfile
RUN curl -fSL --output dotnet.tar.gz https://builds.dotnet.microsoft.com/dotnet/Sdk/$DOTNET_SDK_VERSION_6_0/dotnet-sdk-$DOTNET_SDK_VERSION_6_0-linux-x64.tar.gz \
    && dotnet_sha512='ee0a77d54e6d4917be7310ff0abb3bad5525bfb4beb1db0c215e65f64eb46511f5f12d6c7ff465a1d4ab38577e6a1950fde479ee94839c50e627020328a702de' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && if [ ! -e /usr/bin/dotnet ]; then ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet; fi \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

# Below adapted from https://hub.docker.com/_/microsoft-dotnet-sdk
# https://github.com/dotnet/dotnet-docker/blob/b20c03e0644b42167d66a85fe6077ec2428a47fa/src/sdk/3.1/focal/amd64/Dockerfile
RUN curl -fSL --output dotnet.tar.gz https://builds.dotnet.microsoft.com/dotnet/Sdk/$DOTNET_SDK_VERSION_3_1/dotnet-sdk-$DOTNET_SDK_VERSION_3_1-linux-x64.tar.gz \
    && dotnet_sha512='dec1dcf326487031c45dec0849a046a0d034d6cbb43ab591da6d94c2faf72da8e31deeaf4d2165049181546d5296bb874a039ccc2f618cf95e68a26399da5e7f' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help
