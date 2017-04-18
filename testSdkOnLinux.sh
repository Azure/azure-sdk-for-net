#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"

dotnet build build.proj
dotnet Test build.proj

armdir=$rootdir/src/SDKs
for folder in $armdir/*

cd $armdir/AnalysisServices/AnalysisServices.Tests
dotnet test
cd $armdir 

cd $armdir/Billing/Management.Billing
dotnet test
cd $armdir 

cd $armdir/Cdn/Cdn.Tests
dotnet test
cd $armdir 

cd $armdir/SDKs/CognitiveServices
dotnet test
cd $armdir 
