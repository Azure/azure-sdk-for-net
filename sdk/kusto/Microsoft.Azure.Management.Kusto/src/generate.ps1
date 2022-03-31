# Generate package with subscriptions tag
# https://github.com/Azure/azure-libraries-for-net/blob/master/tools/BuildToolsForSdk/BuildAssets/psModules/CodeGenerationModules/AutoRestCodeGenerationModule/AutoRestCodeGenerationModule.psm1
# Start-AutoRestCodeGeneration -ResourceProvider "resources/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--tag=package-subscriptions-2020-01" -SdkGenerationDirectory "$PSScriptRoot\Generated\Subscriptions"
# Start-AutoRestCodeGeneration -ResourceProvider "azure-kusto/resource-manager" -AutoRestVersion "v2" -SpecsRepoFork "docohe" -SpecsRepoBranch "dev-azure-kusto-Microsoft.Kusto-2022-02-01"

Start-AutoRestCodeGeneration -ResourceProvider "azure-kusto/resource-manager" -AutoRestVersion "v2"
