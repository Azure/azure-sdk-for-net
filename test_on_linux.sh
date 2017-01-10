#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
  
dotnet restore

cd $rootdir/src/ResourceManagement/Azure.Fluent
dotnet restore
dotnet build --framework netcoreapp1.0
dotnet test
