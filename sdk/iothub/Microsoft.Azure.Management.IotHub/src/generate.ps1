# Important to note: 
# Configuration for the code generation including target swagger file and code generation settings can be found here:
# https://github.com/Azure/azure-rest-api-specs/tree/master/specification/iothub/resource-manager

try
{
	Start-AutoRestCodeGeneration -ResourceProvider "iothub/resource-manager" -AutoRestVersion "v2"
}
catch
{
	Write-Error "If you have problems running this script, see the instructions at https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/78/Mgmt-.NET-SDK-release-process"
	Write-Error "If you get an error stating that Start-AutoRestCodeGeneration script is not available, you probably need to run:"
	Write-Host "`t > msbuild ../../../../eng/mgmt.proj /t:Util /p:UtilityName=InstallPsModules"
}
