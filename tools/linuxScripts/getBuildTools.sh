getBuildTools()
{
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