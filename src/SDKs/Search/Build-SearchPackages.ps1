$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
msbuild "$scriptDir\..\..\..\build.proj" /t:PublishNuget /p:Scope="SDKs\Search\Management" /p:NugetPackageName="Microsoft.Azure.Management.Search"
msbuild "$scriptDir\..\..\..\build.proj" /t:PublishNuget /p:Scope="SDKs\Search\DataPlane" /p:NugetPackageName="Microsoft.Azure.Search"
