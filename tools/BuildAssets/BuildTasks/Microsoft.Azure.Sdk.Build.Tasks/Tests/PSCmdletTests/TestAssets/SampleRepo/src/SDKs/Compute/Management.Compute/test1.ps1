# Basic test, this is how most generate.ps1s look like
Import-Module "$PSScriptRoot\..\..\..\..\..\AutoRestCodeGenerationModule.psm1"
Start-AutoRestCodeGeneration -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest"