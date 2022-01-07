#!/bin/bash

# install dependency
echo "Install Depenedencies:"
apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib curl
apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/

# install powershell
echo "Install powershell:"
apk add --no-cache \
    ca-certificates \
    less \
    ncurses-terminfo-base \
    tzdata \
    userspace-rcu

apk -X https://dl-cdn.alpinelinux.org/alpine/edge/main add --no-cache lttng-ust

curl -L https://github.com/PowerShell/PowerShell/releases/download/v7.2.1/powershell-7.2.1-linux-alpine-x64.tar.gz -o /tmp/powershell.tar.gz
mkdir -p /opt/microsoft/powershell/7
tar zxf /tmp/powershell.tar.gz -C /opt/microsoft/powershell/7
chmod +x /opt/microsoft/powershell/7/pwsh
ln -s /opt/microsoft/powershell/7/pwsh /usr/bin/pwsh

# install .Net 6.0, netappCore 3.1
echo "Install dotnet:"
DIRECTORY=$(cd `dirname $0` && pwd)
$DIRECTORY/dotnet-install.sh
$DIRECTORY/dotnet-install.sh -c 3.1

if [ -z ${DOTNET_ROOT+x} ]; then
  echo 'export DOTNET_ROOT=$HOME/.dotnet' >> /etc/profile
  echo 'export PATH=$PATH:$HOME/.dotnet' >> /etc/profile
  source /etc/profile
fi
# export DOTNET_ROOT=$HOME/.dotnet
# export PATH=$PATH:$HOME/.dotnet
dotnet --list-sdks

    
