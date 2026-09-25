FROM mcr.microsoft.com/dotnet/sdk:10.0.400-noble

ARG DEBIAN_FRONTEND=noninteractive
ARG POWERSHELL_VERSION=7.6.5

# Match the hosted Ubuntu test baseline: exact .NET 10 from global.json, current .NET 8/9 SDKs
# (including ASP.NET runtimes), PowerShell, Git, and Node 22 for Azurite.
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        curl \
        git \
        gnupg \
        jq \
        openssh-client \
        python3 \
        unzip \
        wget \
        zip \
    && curl -fsSL https://deb.nodesource.com/setup_22.x | bash - \
    && apt-get update \
    && apt-get install -y --no-install-recommends nodejs \
    && powershell_arch="$(dpkg --print-architecture)" \
    && if [ "$powershell_arch" = 'amd64' ]; then powershell_arch='x64'; fi \
    && curl -fsSL \
        "https://github.com/PowerShell/PowerShell/releases/download/v${POWERSHELL_VERSION}/powershell-${POWERSHELL_VERSION}-linux-${powershell_arch}.tar.gz" \
        -o /tmp/powershell.tar.gz \
    && mkdir -p /opt/microsoft/powershell/7 \
    && tar -xzf /tmp/powershell.tar.gz -C /opt/microsoft/powershell/7 \
    && chmod +x /opt/microsoft/powershell/7/pwsh \
    && ln -s /opt/microsoft/powershell/7/pwsh /usr/local/bin/pwsh \
    && curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh \
    && chmod +x /tmp/dotnet-install.sh \
    && /tmp/dotnet-install.sh --channel 8.0 --quality GA --install-dir /usr/share/dotnet --no-path \
    && /tmp/dotnet-install.sh --channel 9.0 --quality GA --install-dir /usr/share/dotnet --no-path \
    && rm -rf /var/lib/apt/lists/* /tmp/dotnet-install.sh /tmp/powershell.tar.gz

ENV CI=true \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_NOLOGO=1 \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 \
    NUGET_XMLDOC_MODE=skip

WORKDIR /workspace

CMD ["pwsh", "-NoProfile", "-NonInteractive"]
