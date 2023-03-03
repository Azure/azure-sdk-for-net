<#
.SYNOPSIS
A script that given as input $TargetPath param, returns the owners
of that path, as determined by CODEOWNERS file passed in $CodeOwnersFileLocation
param.

.PARAMETER TargetPath
Required*. Path to file or directory whose owners are to be determined from a 
CODEOWNERS file. e.g. sdk/core/azure-amqp/ or sdk/core/foo.txt.

*for backward compatibility, you might provide $TargetDirectory instead.

.PARAMETER TargetDirectory
Obsolete. Replaced by $TargetPath. Kept for backward-compatibility.
If both $TargetPath and $TargetDirectory are provided, $TargetDirectory is
ignored.

.PARAMETER CodeOwnerFileLocation
Optional. An absolute path to the CODEOWNERS file against which the $TargetPath param
will be checked to determine its owners.

.PARAMETER ToolVersion
Optional. The NuGet package version of the package containing the "retrieve-codeowners" 
tool, around which this script is a wrapper.

.PARAMETER ToolPath
Optional. The place to check the "retrieve-codeowners" tool existence.

.PARAMETER DevOpsFeed
Optional. The NuGet package feed from which the "retrieve-codeowners" tool is to be installed.

NuGet feed:
https://dev.azure.com/azure-sdk/public/_artifacts/feed/azure-sdk-for-net/NuGet/Azure.Sdk.Tools.RetrieveCodeOwners

Pipeline publishing the NuGet package to the feed, "tools - code-owners-parser":
https://dev.azure.com/azure-sdk/internal/_build?definitionId=3188

.PARAMETER VsoVariable 
Optional. If provided, the determined owners, based on $TargetPath matched against CODEOWNERS file at $CodeOwnerFileLocation, 
will be output to Azure DevOps pipeline log as variable named $VsoVariable.

Reference:
https://learn.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch
https://learn.microsoft.com/en-us/azure/devops/pipelines/scripts/logging-commands?view=azure-devops&tabs=bash#logging-command-format

.PARAMETER IncludeNonUserAliases
Optional. Whether to include in the returned owners list aliases that are team aliases, e.g. Azure/azure-sdk-team

.PARAMETER Test
Optional. Whether to run the script against hard-coded tests.

#>
param (
  [string]$TargetPath = "",
  [string]$TargetDirectory = "",
  # The path used assumes the script is located in azure-sdk-tools/eng/common/scripts/get-codeowners.ps1
  [string]$CodeOwnerFileLocation = (Resolve-Path $PSScriptRoot/../../../.github/CODEOWNERS),
  # The $ToolVersion 1.0.0-dev.20230214.3 includes following PR:
  #    Use CodeownersFile.UseRegexMatcherDefault everywhere where applicable + remove obsolete tests
  #    https://github.com/Azure/azure-sdk-tools/pull/5437
  # 
  # but not this one:
  #    Remove the obsolete, prefix-based CODEOWNERS matcher & related tests
  #    https://github.com/Azure/azure-sdk-tools/pull/5431
  [string]$ToolVersion = "1.0.0-dev.20230223.4",
  [string]$ToolPath = (Join-Path ([System.IO.Path]::GetTempPath()) "codeowners-tool"),
  [string]$DevOpsFeed = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json",
  [string]$VsoVariable = "",
  [switch]$IncludeNonUserAliases,
  [switch]$Test
)

. $PSScriptRoot/get-codeowners-functions.ps1

return Get-Codeowners `
  -ToolVersion $ToolVersion `
  -ToolPath $ToolPath `
  -DevOpsFeed $DevOpsFeed `
  -VsoVariable $VsoVariable `
  -targetPath $TargetPath `
  -targetDirectory $TargetDirectory `
  -codeownersFileLocation $CodeOwnerFileLocation `
  -includeNonUserAliases $IncludeNonUserAliases

