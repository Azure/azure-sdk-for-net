#!/bin/bash

if [ -z $1 ]; then
    echo "Please input inputfile"
    exit 1
fi
echo $1

if [ -z $2 ]; then
    echo "Please input outputfile"
    exit 1
fi

echo $2

pwsh eng/automation/Invoke-MockTest.ps1 -inputJsonFile $1 -outputJsonFile $2