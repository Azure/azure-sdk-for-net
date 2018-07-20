<#
    This is a template to describe how to call the generateTool.ps1 script to generate the code using AutoRest
#>
# Generate code from a local rest spec into a user defined directory
Start-AutoRestCodeGenerationWithLocalConfig -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest" -LocalConfigFile "<localrepo>/compute/resource-manager/readme.md" -SdkRootDirectory "src\SDKs\"
# Generate code from a repo spec into a user defined directory 
Start-AutoRestCodeGeneration -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest" -SdkGenerationDirectory "Generated"
# Generate code from a repo spec (azure-sdk-for-net psSdkJson6 branch) 
Start-AutoRestCodeGeneration -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest"