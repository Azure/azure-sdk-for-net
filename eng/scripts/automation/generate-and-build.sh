#!/bin/bash

if [ -z $1 ]; then
    echo "Please input inputfile"
    echo "Usage: generate-and-build.sh <inputfile> <outputfile>"
    exit 1
fi

if [ -z $2 ]; then
    echo "Please input outputfile"
    echo "Usage: generate-and-build.sh <inputfile> <outputfile>"
    exit 1
fi

pwsh eng/automation/Invoke-GenerateAndBuild.ps1 -inputJsonFile $1 -outputJsonFile $2

if [ "$?" != "0" ]; then
  echo "Failed to generate code."
  exit 1
fi

cat $2