<#
    This is a template to describe how to call the generateTool.ps1 script to generate the code using AutoRest
#>
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\generateTool.ps1" -ResourceProvider "compute/resource-manager" -SpecsRepoFork "Azure" -SpecsRepoBranch "master" -SpecsRepoName "azure-rest-api-specs" -SdkDirectory "$([System.IO.Path]::GetTempPath())\Compute" -AutoRestVersion "latest" -PowershellInvoker