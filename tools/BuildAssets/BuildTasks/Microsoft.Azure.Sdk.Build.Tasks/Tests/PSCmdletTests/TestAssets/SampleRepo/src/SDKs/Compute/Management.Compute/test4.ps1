# Advanced test, generate code using a spec on the local disk
Import-Module "$PSScriptRoot\..\..\..\..\..\AutoRestCodeGenerationModule.psm1"
$configFilePath = $(Resolve-Path "$PSScriptRoot\..\..\..\..\..\TestRestSpecs\readme.md")
Write-Host $configFilePath
Start-AutoRestCodeGenerationWithLocalConfig -ResourceProvider "redis/resource-manager" -AutoRestVersion "latest" -LocalConfigFilePath $configFilePath -SdkGenerationDirectory "$PSScriptRoot\Generated"