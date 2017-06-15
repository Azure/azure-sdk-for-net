#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd16="netstandard1.6"
netcore11='netcoreapp1.1'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"

echo Restoring...
dotnet --info
dotnet restore FluentSDK.sln -r $ubuntu1404
dotnet restore FluentSamples.sln -r $ubuntu1404
dotnet restore FluentTests.sln -r $ubuntu1404

echo Building... 
dotnet build FluentSDK.sln -f $netstd16
dotnet build FluentSamples.sln -f $netstd16
dotnet build FluentTests.sln -f $netcore11

echo Running Samples Tests
cd $rootdir/Tests/Samples.Tests
dotnet test Samples.Tests.csproj -f $netcore11

echo Running Fluent Tests
cd $rootdir/Tests/Fluent.Tests
dotnet test Fluent.Tests.csproj -f $netcore11
