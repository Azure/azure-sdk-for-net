# Running Start-AutoRestCodeGeneration will overwrite the files present in SdkGenerationDirectory based on AutoRestCodeGenerationFlags
# As ARM has multiple tag packages, it is safer to first Generate the files in a different directory
# and copy these new set of files to the main Generated folder. This way exisiting files will not be deleted.

# Generate package with resources tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-resources-2021-04" -SdkGenerationDirectory "$PSScriptRoot\Generated\Resources"

# Generate package with templatespecs tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-templatespecs-2021-05" -SdkGenerationDirectory "$PSScriptRoot\Generated\TemplateSpecs"

# Generate package with subscriptions tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-subscriptions-2021-01" -SdkGenerationDirectory "$PSScriptRoot\Generated\Subscriptions"

# # Generate package with policy tag
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-policy-2021-06" -SdkGenerationDirectory "$PSScriptRoot\GeneratedPolicy202106"

# Generate package with deployment scripts
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-deploymentscripts-2019-10-preview" -SdkGenerationDirectory "$PSScriptRoot\Generated\DeploymentScripts"

# Generate package with privatelink tag
Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-privatelinks-2020-05" -SdkGenerationDirectory "$PSScriptRoot\Generated\PrivateLinks"
