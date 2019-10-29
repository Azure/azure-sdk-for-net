# Generate package with resources tag
Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-resources-2019-07" -SdkGenerationDirectory "$PSScriptRoot\Generated"

# Generate package with policy tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-policy-2019-06" -SdkGenerationDirectory "$PSScriptRoot\Generated"
