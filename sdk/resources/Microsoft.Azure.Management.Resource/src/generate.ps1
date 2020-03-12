# Running Start-AutoRestCodeGeneration will overwrite the files present in SdkGenerationDirectory based on AutoRestCodeGenerationFlags
# As ARM has multiple tag packages, it is safer to first Generate the files in a different directory 
# and copy these new set of files to the main Generated folder. This way exisiting files will not be deleted.

# Generate package with resources tag
Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-resources-2019-10" -SdkGenerationDirectory "$PSScriptRoot\Generated\Resources"
# Generate package with subscriptions tag
Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-subscriptions-2019-11" -SdkGenerationDirectory "$PSScriptRoot\Generated\Subscriptions"

# Generate package with policy tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "latest" -AutoRestCodeGenerationFlags "--tag=package-policy-2019-09" -SdkGenerationDirectory "$PSScriptRoot\Generated"
