mono --version
./tools/linuxScripts/getBuildTools.sh
nuget restore src/SdkCommon/ClientRuntime.sln -NoCache -OutputDirectory restoredPackages -Source https://api.nuget.org/v3/index.json
msbuild build.proj /t:build /p:Scope=SdkCommon/ClientRuntime
mono restoredPackages/xunit.runner.console/2.3.1/tools/net452/xunit.console.exe src/SdkCommon/ClientRuntime/Tests/ClientRuntime.FullDesktop.Tests/bin/Debug/net452/ClientRuntime.FullDesktop.Tests.dll
msbuild build.proj /t:build /p:Scope=SdkCommon/ClientRuntime.Azure
mono restoredPackages/xunit.runner.console/2.3.1/tools/net452/xunit.console.exe src/SdkCommon/ClientRuntime.Azure/Tests/CR.Azure.FullDesktop.Tests/bin/Debug/net452/CR.Azure.FullDesktop.Tests.dll