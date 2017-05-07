#!/bin/bash

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd14="netstandard1.4"
netcore11='netcoreapp1.1'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"
localNugetFeed="./tools/LocalNugetFeed"

skip_Rps() {
    retVal=false
    #printf "checking......$1\n"
    if [[ ("$1" =~ "Authorization")  || ( "$1" =~ "Gallery" ) || ("$1" =~ "Automation") || ( "$1" =~ "Intune" ) || ( "$1" =~ "DataLake.Store" ) 
                || ( "$1" =~ "Monitor" ) || ( "$1" =~ "RedisCache" ) || ( "$1" =~ "Search" ) || ( "$1" =~ "KeyVault.Tests" ) 
                || ( "$1" =~ "KeyVault.TestFramework") ]]; then                
        retVal=true
    fi
    echo $retVal
}

echo "Restore ClientRuntime for $ubuntu1404"
dotnet restore src/SdkCommon/ClientRuntime.sln -r $ubuntu1404

echo "Build ClientRuntime for $net14"
#dotnet restore src/SdkCommon/ClientRuntime/ClientRuntime/Microsoft.Rest.ClientRuntime.csproj
dotnet build src/SdkCommon/ClientRuntime/ClientRuntime/Microsoft.Rest.ClientRuntime.csproj -f $netstd14
dotnet build src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure/Microsoft.Rest.ClientRuntime.Azure.csproj -f $netstd14
dotnet build src/SdkCommon/ClientRuntime.Azure.Authentication/Microsoft.Rest.ClientRuntime.Azure.Authentication.csproj -f $netstd14

#echo "Build ClientRuntime Tests for $netcore11"
#dotnet build src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore11
#dotnet build src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore11
#dotnet build src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure.Tests/Microsoft.Rest.ClientRuntime.Azure.Tests.csproj -f $netcore11

echo "Running ClientRuntime Tests $netcore11"
#dotnet test src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore11
dotnet test src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore11
dotnet test src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure.Tests/Microsoft.Rest.ClientRuntime.Azure.Tests.csproj -f $netcore11

KVMgmtDir=($sdkdir/KeyVault/Management/*.sln)
if [ -f $KVMgmtDir ]; then
    dotnet restore $KVMgmtDir -r ubuntu1404
fi

sdkdir=$rootdir/src/SDKs

#printf "$sdkdir\n"
for folder in $sdkdir/*
do
    item=`basename $folder`
    if [ -d $sdkdir/$item ]; then
        #printf "$sdkdir/$item\n"
        if [ -f $sdkdir/$item/*.sln ]; then
            slnFile=($sdkdir/$item/*.sln)
            skipRestore=$( skip_Rps $slnFile )
            if [ "$skipRestore" == false ]; then
                printf "Restoring :::::: $slnFile for $ubuntu1404\n"
                dotnet restore $slnFile -r $ubuntu1404
            fi
            if [ -d $sdkdir/$item/*.Tests ]; then
                testProj=($sdkdir/$item/*.Tests/*.csproj)
                skipTest=$( skip_Rps $testProj )
                #printf "$skipRp\n"
                if [ "$skipTest" == "false" ]; then
                    printf "Test ------ $testProj for framework $netcore11\n"
                    #dotnet build $testProj -f $netcore11
                    dotnet test $testProj -f $netcore11
                fi
            fi
        fi
    fi
done

kvDataPSln=($sdkdir/KeyVault/dataPlane/*.sln)
if [ -f $kvDataPSln ]; then
    dotnet restore $kvDataPSln -r ubuntu1404
fi
KVDataPlaneDir=$sdkdir/KeyVault/dataPlane
for kvDir in $KVDataPlaneDir/*
do
    kvItem=`basename $kvDir`
    if [ -d $kvDir ] && [ "$kvItem" != "Microsoft.Azure.KeyVault.Samples" ]
    then
        if [[ "$kvItem" =~ "Tests" ]]; then
            kvTestProj=($kvDir/*.csproj)
            kvTProj=$( skip_Rps $kvSdkProj )
                if [ "$kvTProj" == "false" ]; then
                    printf "KV TestProject ... $kvTestProj\n"
                    dotnet restore $kvTestProj -r $ubuntu1404
                    dotnet test $kvTestProj -f $netcore11
                fi
        else
            if [ -f $kvDir/*.csproj ]; then
                kvSdkProj=($kvDir/*.csproj)
                kvProj=$( skip_Rps $kvSdkProj )
                if [ "$kvProj" == "false" ]; then
                    dotnet restore $kvSdkProj -r $ubuntu1404
                    dotnet build $kvSdkProj -f $netstd14
                fi
            fi
        fi
    fi
done

: '
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


else
            if [ -d $sdkDir/$item/Management ]; then
                printf "Found mgmt $sdkDir/$item/Management\n"
            fi
            if [ -f $sdkDir/$item/Management/*.sln ]; then
                mgmtSln=($sdkDir/$item/Management/*.sln)
                printf "Restoring ## $mgmtSln\n"
                if [ -d $sdkdir/$item/*.Tests ]; then
                    mgmtTestProj=($sdkdir/$item/*.Tests/*.csproj)
                    printf "Test ## $mgmtTestProj for framework $netcore11\n"
                fi #mgmtTestProject
            fi #mgmgtSln
        fi #mgmtSln else


                #if [[ $("$testProj" =~ "Authorization")  || $( "$testProj" =~ "Gallery" ) || $("$testProj" =~ "Automation") || $( "$testProj" =~ "InTune" ) || $( "$testProj" =~ "DataLake.Store" ) ]]; then
                #if [[ ("$testProj" =~ "Authorization")  || ( "$testProj" =~ "Gallery" ) || ("$testProj" =~ "Automation") || ( "$testProj" =~ "Intune" ) || ( "$testProj" =~ "DataLake.Store" ) 
                #|| ( "$testProj" =~ "Monitor" ) || ( "$testProj" =~ "RedisCache" ) ]]; then
'