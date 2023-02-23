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
  [string]$ToolVersion = "1.0.0-dev.20230214.3", # // kja TODO update
  [string]$ToolPath = (Join-Path ([System.IO.Path]::GetTempPath()) "codeowners-tool-path"),
  [string]$DevOpsFeed = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json",
  [string]$VsoVariable = "",
  [switch]$IncludeNonUserAliases,
  [switch]$Test
)

function Get-CodeownersTool()
{
  $codeownersToolCommand = Join-Path $ToolPath "retrieve-codeowners"
  # Check if the retrieve-codeowners tool exists or not.
  if (Get-Command $codeownersToolCommand -errorAction SilentlyContinue) {
    return $codeownersToolCommand
  }
  if (!(Test-Path $ToolPath)) {
    New-Item -ItemType Directory -Path $ToolPath | Out-Null
  }
  Write-Host "Installing the retrieve-codeowners tool under tool path: $ToolPath ..."

  # Run command under tool path to avoid dotnet tool install command checking .csproj files. 
  # This is a bug for dotnet tool command. Issue: https://github.com/dotnet/sdk/issues/9623
  Push-Location $ToolPath
  dotnet tool install --tool-path $ToolPath --add-source $DevOpsFeed --version $ToolVersion "Azure.Sdk.Tools.RetrieveCodeOwners" | Out-Null
  Pop-Location
  # Test to see if the tool properly installed.
  if (!(Get-Command $codeownersToolCommand -errorAction SilentlyContinue)) {
    Write-Error "The retrieve-codeowners tool is not properly installed. Please check your tool path: $ToolPath"
    return 
  }
  return $codeownersToolCommand
}

function Get-Codeowners(
  [string]$targetPath,
  [string]$targetDirectory,
  [string]$codeownersFileLocation,
  [bool]$includeNonUserAliases = $false)
{
  # Backward compaitiblity: if $targetPath is not provided, fall-back to the legacy $targetDirectory
  if ([string]::IsNullOrWhiteSpace($targetPath)) {
    $targetPath = $targetDirectory
  }
  if ([string]::IsNullOrWhiteSpace($targetPath)) {
    Write-Error "TargetPath (or TargetDirectory) parameter must be neither null nor whitespace."
    return ,@()
  }

  $codeownersToolCommand = Get-CodeownersTool
  Write-Host "Executing: & $codeownersToolCommand --target-path $targetPath --codeowners-file-path-or-url $codeownersFileLocation --exclude-non-user-aliases:$(!$includeNonUserAliases)"
  $commandOutput = & $codeownersToolCommand `
      --target-path $targetPath `
      --codeowners-file-path-or-url $codeownersFileLocation `
      --exclude-non-user-aliases:$(!$includeNonUserAliases) `
      2>&1

  if ($LASTEXITCODE -ne 0) {
    Write-Host "Command $codeownersToolCommand execution failed (exit code = $LASTEXITCODE). Output string: $commandOutput"
    return ,@()
  } else
  {
    Write-Host "Command $codeownersToolCommand executed successfully (exit code = 0). Output string length: $($commandOutput.length)"
  }

# Assert: $commandOutput is a valid JSON representing:
# - a single CodeownersEntry, if the $targetPath was a single path
# - or a dictionary of CodeownerEntries, keyes by each path resolved from a $targetPath glob path.
#
# For implementation details, see Azure.Sdk.Tools.RetrieveCodeOwners.Program.Main

$codeownersJson = $commandOutput | ConvertFrom-Json
  
  if ($VsoVariable) {
    $codeowners = $codeownersJson.Owners -join ","
    Write-Host "##vso[task.setvariable variable=$VsoVariable;]$codeowners"
  }

  return ,@($codeownersJson.Owners)
}

function TestGetCodeowners([string]$targetPath, [string]$codeownersFileLocation, [bool]$includeNonUserAliases = $false, [string[]]$expectReturn) {
  Write-Host "Test: find owners matching '$targetPath' ..."
  
  $actualReturn = Get-Codeowners -targetPath $targetPath -codeownersFileLocation $codeownersFileLocation -includeNonUserAliases $IncludeNonUserAliases

  if ($actualReturn.Count -ne $expectReturn.Count) {
    Write-Error "The length of actual result is not as expected. Expected length: $($expectReturn.Count), Actual length: $($actualReturn.Count)."
    exit 1
  }
  for ($i = 0; $i -lt $expectReturn.Count; $i++) {
    if ($expectReturn[$i] -ne $actualReturn[$i]) {
      Write-Error "Expect result $expectReturn[$i] is different than actual result $actualReturn[$i]."
      exit 1
    }
  }
}

if ($Test) {
  # Most of tests here have been removed; now instead we should run tests from RetrieveCodeOwnersProgramTests, and in a way as explained in:
  # https://github.com/Azure/azure-sdk-tools/issues/5434
  # https://github.com/Azure/azure-sdk-tools/pull/5103#discussion_r1068680818
  Write-Host "Running reduced test suite at `$PSScriptRoot of $PSSCriptRoot. Please see https://github.com/Azure/azure-sdk-tools/issues/5434 for more."

  $azSdkToolsCodeowners = (Resolve-Path "$PSScriptRoot/../../../.github/CODEOWNERS")
  TestGetCodeowners -targetPath "eng/common/scripts/get-codeowners.ps1" -codeownersFileLocation $azSdkToolsCodeowners -includeNonUserAliases $true -expectReturn @("konrad-jamrozik", "weshaggard", "benbp")
  
  $testCodeowners = (Resolve-Path "$PSScriptRoot/../../../tools/code-owners-parser/Azure.Sdk.Tools.RetrieveCodeOwners.Tests/TestData/test_CODEOWNERS")
  TestGetCodeowners -targetPath "tools/code-owners-parser/Azure.Sdk.Tools.RetrieveCodeOwners.Tests/TestData/InputDir/a.txt" -codeownersFileLocation $testCodeowners -includeNonUserAliases $true -expectReturn @("2star")
  exit 0
}
else {
  return Get-Codeowners -targetPath $TargetPath -targetDirectory $TargetDirectory -codeownersFileLocation $CodeOwnerFileLocation -includeNonUserAliases $IncludeNonUserAliases
}
