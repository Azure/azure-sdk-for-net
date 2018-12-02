# Basic test, some generate.ps1s explicitly provide the SdkGenerationDirectory
Import-Module "$PSScriptRoot\..\..\..\..\..\AutoRestCodeGenerationModule.psm1"
Start-AutoRestCodeGeneration -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest" -SdkGenerationDirectory "$PSScriptRoot\Generated"