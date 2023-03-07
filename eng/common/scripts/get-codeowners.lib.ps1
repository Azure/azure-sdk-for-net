function Get-CodeownersTool([string] $ToolPath, [string] $DevOpsFeed, [string] $ToolVersion)
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

<#
.SYNOPSIS
A function that given as input $TargetPath param, returns the owners
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

.PARAMETER CodeownersFileLocation
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
Optional. If provided, the determined owners, based on $TargetPath matched against CODEOWNERS file at $CodeownersFileLocation, 
will be output to Azure DevOps pipeline log as variable named $VsoVariable.

Reference:
https://learn.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch
https://learn.microsoft.com/en-us/azure/devops/pipelines/scripts/logging-commands?view=azure-devops&tabs=bash#logging-command-format

.PARAMETER IncludeNonUserAliases
Optional. Whether to include in the returned owners list aliases that are team aliases, e.g. Azure/azure-sdk-team

.PARAMETER Test
Optional. Whether to run the script against hard-coded tests.

#>
function Get-Codeowners(
  [string] $TargetPath,
  [string] $TargetDirectory,
  [string] $ToolPath = (Join-Path ([System.IO.Path]::GetTempPath()) "codeowners-tool"),
  [string] $DevOpsFeed = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json",
  [string] $ToolVersion = "1.0.0-dev.20230306.3",
  [string] $VsoVariable = "",
  [string] $CodeownersFileLocation = "",
  [switch] $IncludeNonUserAliases
  )
{
  if ([string]::IsNullOrWhiteSpace($CodeownersFileLocation)) {
    # The $PSScriptRoot is assumed to be azure-sdk-tools/eng/common/scripts/get-codeowners.ps1
    $CodeOwnersFileLocation = (Resolve-Path $PSScriptRoot/../../../.github/CODEOWNERS)
  }

  # Backward compaitiblity: if $TargetPath is not provided, fall-back to the legacy $TargetDirectory
  if ([string]::IsNullOrWhiteSpace($TargetPath)) {
    $TargetPath = $TargetDirectory
  }
  if ([string]::IsNullOrWhiteSpace($TargetPath)) {
    Write-Error "TargetPath (or TargetDirectory) parameter must be neither null nor whitespace."
    return ,@()
  }

  $codeownersToolCommand = Get-CodeownersTool -ToolPath $ToolPath -DevOpsFeed $DevOpsFeed -ToolVersion $ToolVersion
  Write-Host "Executing: & $codeownersToolCommand --target-path $TargetPath --codeowners-file-path-or-url $CodeownersFileLocation --exclude-non-user-aliases:$(!$IncludeNonUserAliases)"
  $commandOutput = & $codeownersToolCommand `
      --target-path $TargetPath `
      --codeowners-file-path-or-url $CodeownersFileLocation `
      --exclude-non-user-aliases:$(!$IncludeNonUserAliases) `
      2>&1

  if ($LASTEXITCODE -ne 0) {
    Write-Host "Command $codeownersToolCommand execution failed (exit code = $LASTEXITCODE). Output string: $commandOutput"
    return ,@()
  } else
  {
    Write-Host "Command $codeownersToolCommand executed successfully (exit code = 0). Command output string length: $($commandOutput.length)"
  }

# Assert: $commandOutput is a valid JSON representing:
# - a single CodeownersEntry, if the $TargetPath was a single path
# - or a dictionary of CodeownerEntries, keyes by each path resolved from a $TargetPath glob path.
#
# For implementation details, see Azure.Sdk.Tools.RetrieveCodeOwners.Program.Main

$codeownersJson = $commandOutput | ConvertFrom-Json
  
  if ($VsoVariable) {
    $codeowners = $codeownersJson.Owners -join ","
    Write-Host "##vso[task.setvariable variable=$VsoVariable;]$codeowners"
  }

  return ,@($codeownersJson.Owners)
}