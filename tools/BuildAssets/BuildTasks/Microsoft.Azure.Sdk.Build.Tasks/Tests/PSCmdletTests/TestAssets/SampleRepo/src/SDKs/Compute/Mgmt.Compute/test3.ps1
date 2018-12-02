# Basic test, some generate.ps1s explicitly provide the SdkRootDirectory
Import-Module "$PSScriptRoot\..\..\..\..\..\AutoRestCodeGenerationModule.psm1"
Start-AutoRestCodeGeneration -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest" -SdkRootDirectory "$PSScriptRoot\..\..\"