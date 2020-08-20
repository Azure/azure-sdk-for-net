FROM mcr.microsoft.com/dotnet/core/sdk:2.1-bionic AS build

ENV \
    NO_AT_BRIDGE=1 \
    DOCKER_CONTAINER_NAME="ubuntu_netcore2_keyring" \
    PSModuleAnalysisCachePath=/var/cache/microsoft/powershell/PSModuleAnalysisCache/ModuleAnalysisCache \
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetCoreSDK-Ubuntu-18.04

# Install GNOME keyring
RUN apt-get update \
    && apt-get install -y \
        libsecret-1-dev \
        dbus-x11 \
        gnome-keyring

# Install PowerShell
RUN apt-get update \
    && apt-get install --no-install-recommends -y \
        locales \
        ca-certificates \
        gss-ntlmssp \
        openssh-client

RUN powershell_version=6.2.0 \
    && powershell_package=powershell_${powershell_version}-1.ubuntu.18.04_amd64.deb \
    && powershell_package_url=https://github.com/PowerShell/PowerShell/releases/download/v${powershell_version}/${powershell_package} \
    && echo ${powershell_package_url} \
    && curl -sSL ${powershell_package_url} -o /tmp/powershell.deb \
    && apt-get install --no-install-recommends -y /tmp/powershell.deb \
    && apt-get dist-upgrade -y \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/* \
    && locale-gen en_US.UTF-8 && update-locale \
    # remove powershell package
    && rm /tmp/powershell.deb \
    # intialize powershell module cache
    && pwsh \
        -NoLogo \
        -NoProfile \
        -Command " \
          \$ErrorActionPreference = 'Stop' ; \
          \$ProgressPreference = 'SilentlyContinue' ; \
          while(!(Test-Path -Path \$env:PSModuleAnalysisCachePath)) {  \
            Write-Host "'Waiting for $env:PSModuleAnalysisCachePath'" ; \
            Start-Sleep -Seconds 3; \
          }"