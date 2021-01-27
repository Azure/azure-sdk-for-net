try
{
	Start-AutoRestCodeGeneration -ResourceProvider "digitaltwins/resource-manager" -AutoRestVersion "v2"
}
catch
{
	Write-Error "If you have problems running this script, see the instructions at https://github.com/Azure/adx-documentation-pr/blob/master/engineering/adx_netsdk_process.md#sdk-generation-from-updated-spec"
	Write-Error "If you get an error stating that Start-AutoRestCodeGeneration script is not available, you probably need to run:"
	Write-Host "`t > msbuild ../../../../eng/mgmt.proj /t:Util /p:UtilityName=InstallPsModules"
}
