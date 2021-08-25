autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
Start-AutoRestCodeGeneration -ResourceProvider "storage/resource-manager" -AutoRestVersion "v2" -SdkGenerationDirectory "$PSScriptRoot\Generated"
