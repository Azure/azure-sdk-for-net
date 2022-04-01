#!/bin/bash

if [ -z $1 ]; then
    echo "Please input outputfile"
    echo "Usage: init.sh <outputfile>"
    exit 1
fi
echo $1

pwsh eng/scripts/automation/init.ps1

DIRECTORY=$(cd `dirname $0` && pwd)
WORKFOLDER="$(realpath $DIRECTORY/../../../)"
echo $WORKFOLDER
export DOTNET_ROOT=$WORKFOLDER/.dotnet
export PATH=$DOTNET_ROOT:$PATH
which dotnet
dotnet --list-sdks
echo $1
cat > $1 << EOF
{
  "envs": {
    "PATH": "$DOTNET_ROOT:$PATH",
    "DOTNET_ROOT": "$DOTNET_ROOT"
  }
}
EOF

cat $1