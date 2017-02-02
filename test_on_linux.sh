#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
  
dotnet restore

echo Running Samples Tests
cd $rootdir/Samples/Tests
dotnet restore
dotnet build --framework netcoreapp1.0
dotnet test

echo Running Fluent Tests
cd $rootdir/src/ResourceManagement/Azure.Fluent/Fluent.Tests
dotnet restore
dotnet build --framework netcoreapp1.0
dotnet test
