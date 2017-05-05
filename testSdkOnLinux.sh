#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd14="netstandard1.4"
netcore11='netcoreapp1.1'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"
localNugetFeed="./tools/LocalNugetFeed"


sdkdir=$rootdir/src/SDKs

KVMgmtDir=($sdkdir/KeyVault/Management/*.sln)

KVDataPlaneDir=$sdkdir/KeyVault/dataPlane
for kvDir in $KVDataPlaneDir/*
do
    kvItem=`basename $kvDir`
    #printf "$kvItem\n"
    #printf "$kvDir\n"
    #printf "$sdkdir/$kvItem\n"
    if [ -d $kvDir ] && [ "$kvItem" != "Microsoft.Azure.KeyVault.Samples" ]
    then
        if [ -f $KVDataPlaneDir/*.Tests/*.csproj]; then
            kvTestProj=($KVDataPlaneDir/*.Tests/*.csproj)
            dotnet test $kvTestProj -f netcore11
        else
            
        fi
        if [ -f $kvDir/*.csproj]
        then
            $kvProj=($kvDir/*.csproj)
            dotnet build $kvProj -f $netstd14
        fi
        #printf "Samples found .... $sdkdir/$kvItem\n"
    #kvProj=($kvDir/)
    fi
done

: '
#printf "$sdkdir\n"
for folder in $sdkdir/*
do
    item=`basename $folder`
    if [ -d $sdkdir/$item ]
    then
        if [ -f $sdkdir/$item/*.sln ]
        then
            slnFile=($sdkdir/$item/*.sln)
            printf "Restoring :::::: $slnFile for $ubuntu1404\n"
            dotnet restore $slnFile -r $ubuntu1404            
            if [ -d $sdkdir/$item/*.Tests ]
            then
                testProj=($sdkdir/$item/*.Tests/*.csproj)
                printf "Test ------ $testProj for framework $netcore11\n"
                #dotnet build $testProj -f $netcore11
                dotnet test $testProj -f $netcore11
            fi
        fi
    fi
done
'



: '
echo "Restore ClientRuntime for $ubuntu1404"
dotnet restore src/SdkCommon/ClientRuntime.sln -r $ubuntu1404 -s $nugetOrgSource

echo "Build ClientRuntime for $net14"
dotnet build src/SdkCommon/ClientRuntime/ClientRuntime/Microsoft.Rest.ClientRuntime.csproj -f $netstd14
dotnet build src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure/Microsoft.Rest.ClientRuntime.Azure.csproj -f $netstd14
dotnet build src/SdkCommon/ClientRuntime.Azure.Authentication/Microsoft.Rest.ClientRuntime.Azure.Authentication.csproj -f $netstd14

echo "Build ClientRuntime Tests for $netcore11"
dotnet build src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore11
dotnet build src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure.Tests/Microsoft.Rest.ClientRuntime.Azure.Tests.csproj -f $netcore11

echo "Running ClientRuntime Tests $netcore11"
dotnet test src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore11
dotnet test src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure.Tests/Microsoft.Rest.ClientRuntime.Azure.Tests.csproj -f $netcore11
'
#echo "base: "$base
#echo "rootedir: "$rootdir
#echo "netstandard1.4 " $netstd14
#echo "netCore1.1 " $netcore11

            
            #if [ -d $sdkdir/$item/Management.* ]
            #then
            #    sdkProjFile=($sdkdir/$item/Management.*/*.csproj)
            #    printf "Build ------ $sdkProjFile for framework $netstd14\n"
            #    dotnet build $sdkProjFile -f $netstd14
            #fi