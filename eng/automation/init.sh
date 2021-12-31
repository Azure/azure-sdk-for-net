#!/bin/bash

if [ -z $1 ]; then
    echo "Please input outputfile"
    exit 1
fi
echo $1

pwsh eng/automation/init.ps1

DIRECTORY=$(cd `dirname $0` && pwd)
WORKFOLDER="$(realpath $DIRECTORY/../../)"
echo $WORKFOLDER
export DOTNET_ROOT=$WORKFOLDER/.dotnet
which dotnet
dotnet --list-sdk
echo $1
cat > $1 << EOF
{
  "envs": {
    "PATH": "$PATH:$DOTNET_ROOT",
    "DOTNET_ROOT": "$DOTNET_ROOT"
  }
}
EOF

cat $1