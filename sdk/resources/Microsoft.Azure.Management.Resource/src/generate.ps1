# Generate package with subscriptions tag
Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-2019-11" -SdkGenerationDirectory "$PSScriptRoot\Generated"

# Generate package with resources tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-resources-2019-10" -SdkGenerationDirectory "$PSScriptRoot\Generated"

# Generate package with policy tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-policy-2019-09" -SdkGenerationDirectory "$PSScriptRoot\Generated"
