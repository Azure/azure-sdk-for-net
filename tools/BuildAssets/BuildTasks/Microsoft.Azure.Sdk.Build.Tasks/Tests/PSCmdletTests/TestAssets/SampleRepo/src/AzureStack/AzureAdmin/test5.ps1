# Basic test for non-SDKs directory
Import-Module "$PSScriptRoot\..\..\..\..\AutoRestCodeGenerationModule.psm1"
Start-AutoRestCodeGeneration -ResourceProvider "azsadmin/resource-manager/azurebridge" -AutoRestVersion "latest" -SdkRootDirectory "$PSScriptRoot"