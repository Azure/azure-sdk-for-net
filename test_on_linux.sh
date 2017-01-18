#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
  
dotnet restore

cd $rootdir/src/ResourceManagement/Azure.Fluent/Fluent.Tests
dotnet restore
dotnet build --framework netcoreapp1.0
dotnet test

cd $rootdir/Samples/ResourceManagement/Tests
dotnet restore
dotnet build --framework netcoreapp1.0
dotnet test