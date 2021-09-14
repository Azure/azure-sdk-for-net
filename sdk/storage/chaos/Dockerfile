
FROM mcr.microsoft.com/dotnet/aspnet:5.0.9-alpine3.13-amd64

ENV \
    # Unset ASPNETCORE_URLS from aspnet base image
    ASPNETCORE_URLS= \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # SDK version
    DOTNET_SDK_VERSION=5.0.400 \
    # Disable the invariant mode (set in base image)
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetSDK-Alpine-3.13

RUN apk add --no-cache \
        curl \
        icu-libs \
        git \
        wget \
        bash \
        nodejs \
        npm \
        sudo

# Install .NET SDK
RUN wget -O dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-musl-x64.tar.gz \
    && dotnet_sha512='11983f5956bdfb07cf19e74c8bd67c21359825a7fd14bacea12f2f9324d3255b93abbc8b6269402f7781ab0edf60a42f908e0c10f3446346dbcf01d076da2032' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -oxzf dotnet.tar.gz ./packs ./sdk ./templates ./LICENSE.txt ./ThirdPartyNotices.txt \
    && rm dotnet.tar.gz \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

# Install PowerShell global tool
RUN powershell_version=7.1.3 \
    && wget -O PowerShell.Linux.Alpine.$powershell_version.nupkg https://pwshtool.blob.core.windows.net/tool/$powershell_version/PowerShell.Linux.Alpine.$powershell_version.nupkg \
    && powershell_sha512='7add5f5b094c76e8426afa6071df2e8aca429d37cffd640eb5987ad560c4b205d0b1bd6981c0820fdbdea56f694c962a53dfa7b76a1e03af0ca07e5637b75eab' \
    && echo "$powershell_sha512  PowerShell.Linux.Alpine.$powershell_version.nupkg" | sha512sum -c - \
    && mkdir -p /usr/share/powershell \
    && dotnet tool install --add-source / --tool-path /usr/share/powershell --version $powershell_version PowerShell.Linux.Alpine \
    && dotnet nuget locals all --clear \
    && rm PowerShell.Linux.Alpine.$powershell_version.nupkg \
    && chmod 755 /usr/share/powershell/pwsh \
    && ln -s /usr/share/powershell/pwsh /usr/bin/pwsh \
    # To reduce image size, remove the copy nupkg that nuget keeps.
    && find /usr/share/powershell -print | grep -i '.*[.]nupkg$' | xargs rm \
    # Add ncurses-terminfo-base to resolve psreadline dependency
    && apk add --no-cache ncurses-terminfo-base

RUN npm install -g azurite
ENV AZURE_AZURITE_LOCATION=/usr/lib

RUN git clone --branch chaos-prototype --single-branch --no-tags https://github.com/kasobol-msft/azure-sdk-for-net.git \
    && cd azure-sdk-for-net \
    && git checkout cb90b92 \
    && cd ..

RUN dotnet build /azure-sdk-for-net/eng/service.proj \
    --framework net5.0 \
    /p:SDKType=all \
    /p:ServiceDirectory=storage \
    /p:Project=Azure.Storage.* \
    /p:IncludeSrc=false \
    /p:IncludeSamples=false \
    /p:IncludePerf=false \
    /p:IncludeStress=false \
    /p:RunApiCompat=false \
    /p:InheritDocEnabled=false \
    /p:Configuration=Debug \
    /p:CollectCoverage=false \
    /p:UseProjectReferenceToAzureClients=false

RUN curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl" \
    && chmod +x ./kubectl \
    && sudo mv ./kubectl /usr/local/bin/kubectl

ADD ./generate-test-config.ps1 /generate-test-config.ps1

ADD ./run.sh /run.sh
RUN chmod +x /run.sh

CMD bash /run.sh 1 1
