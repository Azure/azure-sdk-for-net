#!/bin/bash

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd14="netstandard1.4"
#netcore11='netcoreapp1.1'
netcore20='netcoreapp2.0'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"
localNugetFeed="./tools/LocalNugetFeed"
sdkdir=$rootdir/src/SDKs
azStackDir=$rootdir/src/AzureStack

restoreBuildCR() {
    echo "Restore ClientRuntime for $ubuntu1404"
    dotnet restore src/SdkCommon/ClientRuntime.sln -r $ubuntu1404

    echo "Build ClientRuntime for $net14"
    #dotnet restore src/SdkCommon/ClientRuntime/ClientRuntime/Microsoft.Rest.ClientRuntime.csproj
    dotnet build src/SdkCommon/ClientRuntime/ClientRuntime/Microsoft.Rest.ClientRuntime.csproj -f $netstd14
    dotnet build src/SdkCommon/ClientRuntime.Azure/ClientRuntime.Azure/Microsoft.Rest.ClientRuntime.Azure.csproj -f $netstd14
    dotnet build src/SdkCommon/Auth/Az.Auth/Az.Authentication/Microsoft.Rest.ClientRuntime.Azure.Authentication.csproj -f $netstd14

    echo "Running ClientRuntime Tests $netcore20"
    #dotnet test src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore20
    dotnet test src/SdkCommon/ClientRuntime/ClientRuntime.Tests/Microsoft.Rest.ClientRuntime.Tests.csproj -f $netcore20
    dotnet test src/SdkCommon/ClientRuntime.Azure/Tests/CR.Azure.NetCore.Tests/CR.Azure.NetCore.Tests.csproj -f $netcore20
    #dotnet test src/SdkCommon/Auth/Az.Auth/Az.Auth.Tests//ClientRuntime.Azure.Tests/Microsoft.Rest.ClientRuntime.Azure.Tests.csproj -f $netcore20
    

}

restoreBuildAzStack() {
    for dirPath in $azStackDir/*
    do
        dirName=`basename $dirPath`
        if [ -d $azStackDir/$dirName ]; then
            childDir=($azStackDir/$dirName)
            printf "$azStackDir/$dirName\n"
            if [ -f $childDir/*.sln ]; then
                slnFile=($childDir/*.sln)
                printf "Restoring :::::: $slnFile for $ubuntu1404\n"
                dotnet restore $slnFile -r $ubuntu1404
            fi
            if [ -d $childDir/*.Tests ]; then
                testProj=($childDir/*.Tests/*.csproj)
                if [ -f $testProj ]; then
                    printf "Test ------ $testProj for framework $netcore20\n"
                    dotnet build $testProj -f $netcore20
                    dotnet test $testProj -f $netcore20
                fi
            fi
        fi
    done
}

restoreBuildRepo() {
    #printf "$sdkdir\n"
    for folder in $sdkdir/*
    #for folder in $sdkdir/Resource
    do
        item=`basename $folder`
        if [ -d $sdkdir/$item ]; then
            printf "$sdkdir/$item\n"
            if [ -f $sdkdir/$item/*.sln ]; then
                slnFile=($sdkdir/$item/*.sln)
                skipRestore=$( skip_Rps $slnFile )
                if [ "$skipRestore" == false ]; then
                    printf "Restoring :::::: $slnFile for $ubuntu1404\n"
                    dotnet restore $slnFile -r $ubuntu1404
                fi
                if [ -d $sdkdir/$item/*.Tests ]; then
                    testProj=$(find $sdkdir/$item/*.Test*/ -name "*.csproj")
                    for tp in $testProj
                    do
                        skipTest=$( skip_Rps $tp )
                        printf "$skipRp\n"
                        if [ "$skipTest" == "false" ]; then
                            printf "Test ------ $tp for framework $netcore20\n"
                            dotnet build $tp -f $netcore20
                            dotnet test $tp -f $netcore20
                        fi
                    done
                fi
            fi
        fi
    done
}

restoreBuildCog() {
    cogMgmtDir=($sdkdir/CognitiveServices/management)
    cogDataDir=($sdkdir/CognitiveServices/dataPlane)

    if [ -f $cogMgmtDir/*.sln ]; then
        cogMgmtSlnFile=($cogMgmtDir/*.sln)
        printf "Restoring :::::: $cogMgmtSlnFile for $ubuntu1404\n"
        dotnet restore $cogMgmtSlnFile -r $ubuntu1404
    fi

    if [ -d $cogMgmtDir/*.Tests ]; then
        cogMgmtTestProj=($cogMgmtDir/*.Tests/*.csproj)
        printf "Test ------ $cogMgmtTestProj for framework $netcore20\n"
        dotnet test $cogMgmtTestProj -f $netcore20
    fi


    for cogDir in $cogDataDir/*
    do
        #printf "cogDir ==== $cogDir\n"
        cogDirName=`basename $cogDir`
        if [ -f $cogDir/*.sln ]; then
            cogDataProjSlnFile=($cogDir/*.sln)
            printf "Restoring :::::: $cogDataProjSlnFile for $ubuntu1404\n"
            dotnet restore $cogDataProjSlnFile -r $ubuntu1404
        fi
        if [ -d $cogDir/*.Tests ]; then
            cogDataTestProj=($cogDir/*.Tests/*.csproj)
            printf "Test ------ $cogDataTestProj for framework $netcore20\n"
            dotnet test $cogDataTestProj -f $netcore20
        fi
    done
}

restoreBuildKV() {
    KVMgmtDir=($sdkdir/KeyVault/Management/*.sln)
    if [ -f $KVMgmtDir ]; then
        dotnet restore $KVMgmtDir -r ubuntu1404
    fi

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
                        dotnet test $kvTestProj -f $netcore20
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
}

skip_Rps() {
    retVal=false
    #printf "checking......$1\n"
    if [[ ("$1" =~ "Authorization")  || ( "$1" =~ "Gallery" ) || ("$1" =~ "Automation") || ( "$1" =~ "Intune" ) || ( "$1" =~ "DataLake.Store" ) 
                || ( "$1" =~ "Monitor" ) || ( "$1" =~ "RedisCache" ) || ( "$1" =~ "Search" ) || ( "$1" =~ "KeyVault.Tests" ) 
                || ( "$1" =~ "DeviceProvisioningServices") || ("$1" =~ "ServerManagement") || ( "$1" =~ "BotService")
                || ("$1" =~ "Batch") || ("$1" =~ "KeyVault")
                || ( "$1" =~ "KeyVault.TestFramework") || ( "$1" =~ "Subscription.FullDesktop.Tests") ]]; then                
        retVal=true
    fi
    echo $retVal
}

getBuildTools() {
    copyFromRootDir="https://raw.githubusercontent.com/Azure/azure-sdk-for-net/BuildToolsForSdk"                     
    printf "Updating Build tools .....\n"
    
    if [ ! -d ./tools/SdkBuildTools ]; then
        mkdir ./tools/SdkBuildTools
    fi
    if [ ! -d ./tools/SdkBuildTools/targets ]; then
        mkdir ./tools/SdkBuildTools/targets
    fi

    if [ ! -d ./tools/SdkBuildTools/targets/core ]; then
        mkdir ./tools/SdkBuildTools/targets/core
    fi

    if [ ! -d ./tools/SdkBuildTools/tasks ]; then
        mkdir ./tools/SdkBuildTools/tasks
    fi

    if [ ! -d ./tools/SdkBuildTools/tasks/net46 ]; then
        mkdir ./tools/SdkBuildTools/tasks/net46
    fi

    curl -s $copyFromRootDir/tools/BuildAssets/targets/additional.targets > ./tools/SdkBuildTools/targets/additional.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/common.Build.props > ./tools/SdkBuildTools/targets/common.Build.props
    curl -s $copyFromRootDir/tools/BuildAssets/targets/common.NugetPackage.props > ./tools/SdkBuildTools/targets/common.NugetPackage.props
    curl -s $copyFromRootDir/tools/BuildAssets/targets/common.targets > ./tools/SdkBuildTools/targets/common.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/signing.targets > ./tools/SdkBuildTools/targets/signing.targets
	curl -s $copyFromRootDir/tools/BuildAssets/targets/ideCmd.targets > ./tools/SdkBuildTools/targets/ideCmd.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/utility.targets > ./tools/SdkBuildTools/targets/utility.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/core/_AzSdk.props > ./tools/SdkBuildTools/targets/core/_AzSdk.props
    curl -s $copyFromRootDir/tools/BuildAssets/targets/core/_build.proj > ./tools/SdkBuildTools/targets/core/_build.proj
    curl -s $copyFromRootDir/tools/BuildAssets/targets/core/_Directory.Build.props > ./tools/SdkBuildTools/targets/core/_Directory.Build.props
    curl -s $copyFromRootDir/tools/BuildAssets/targets/core/_Directory.Build.targets > ./tools/SdkBuildTools/targets/core/_Directory.Build.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/core/_test.props > ./tools/SdkBuildTools/targets/core/_test.props
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/common.tasks > ./tools/SdkBuildTools/tasks/common.tasks
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.Framework.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.Framework.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.Tasks.Core.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.Tasks.Core.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.Utilities.Core.dll > ./tools/SdkBuildTools/tasks/net46Microsoft.Build.Utilities.Core.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Collections.Immutable.dll > ./tools/SdkBuildTools/tasks/net46/System.Collections.Immutable.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Reflection.Metadata.dll > ./tools/SdkBuildTools/tasks/net46/System.Reflection.Metadata.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Runtime.InteropServices.RuntimeInformation.dll > ./tools/SdkBuildTools/tasks/net46/System.Runtime.InteropServices.RuntimeInformation.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Threading.Thread.dll > ./tools/SdkBuildTools/tasks/net46/System.Threading.Thread.dll    
}

getBuildTools
restoreBuildCR
restoreBuildRepo
restoreBuildCog
restoreBuildKV
restoreBuildAzStack