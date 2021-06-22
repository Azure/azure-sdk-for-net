$RepoRoot = Resolve-Path "${PSScriptRoot}..\..\..\.."
$EngDir = Join-Path $RepoRoot "eng"
$EngCommonDir = Join-Path $EngDir "common"
$EngCommonScriptsDir = Join-Path $EngCommonDir "scripts"
$EngScriptsDir = Join-Path $EngDir "scripts"

# Import required scripts
. (Join-Path $EngCommonScriptsDir SemVer.ps1)
. (Join-Path $EngCommonScriptsDir ChangeLog-Operations.ps1)
. (Join-Path $EngCommonScriptsDir Package-Properties.ps1)
. (Join-Path $EngCommonScriptsDir logging.ps1)
. (Join-Path $EngCommonScriptsDir Invoke-GitHubAPI.ps1)
. (Join-Path $EngCommonScriptsDir Invoke-DevOpsAPI.ps1)
. (Join-Path $EngCommonScriptsDir artifact-metadata-parsing.ps1)

# Setting expected from common languages settings
$Language = "Unknown"
$PackageRepository = "Unknown"
$packagePattern = "Unknown"
$MetadataUri = "Unknown"

# Import common language settings
$EngScriptsLanguageSettings = Join-path $EngScriptsDir "Language-Settings.ps1"
if (Test-Path $EngScriptsLanguageSettings) {
  . $EngScriptsLanguageSettings
}

if (!(Get-Variable -Name "LanguageShort" -ValueOnly -ErrorAction "Ignore"))
{
  $LanguageShort = $Language
}

if (!(Get-Variable -Name "LanguageDisplayName" -ValueOnly -ErrorAction "Ignore"))
{
  $LanguageDisplayName = $Language
}

# Create a function with the given FunctionName which may or may not be 
# implemented in a language specific way (e.g. in Language-settings.ps1). There
# are two major advantages to this approach: 
# 1. With a default implementation, language-specific implementations are 
#   optional
# 2. No more need to write logic in functions to check whether a given function
#   exists.
# Warning: Once a default implementation is created and used, changes to the 
# default implementation might break code which depends on the implementation. 
# Sample usage:  
# DefaultImplementation `
#   -FunctionName "Get-${Language}-LanguageSpecificMetadata" `
#   -DefaultImplementation { param($input) $input }
# 
# Language specific implementation: 
# Get-javascript-LanguageSpecificMetadata { param($input) $input.Version = 'dev'; $input }
#
# If a language specific implementation is not provided this returns the $input
# object unaltered, but in the case of JS, this returns a $input object with the
# Version property set to 'dev'. There is no need to write implementation for
# any other languages.
function DefaultImplementation() {
  param(
    [Parameter(Mandatory = $true)]
    [string]$FunctionName,

    [Parameter(Mandatory = $true)]
    [scriptblock]$DefaultImplementation
  )

  if (Test-Path "Function:$FunctionName") { 
    return Get-Item "Function:$FunctionName"
  } else { 
    return $DefaultImplementation
  }
}

# Functions with default implementations
$GetDocsMsLanguageSpecificPackageInfo = DefaultImplementation `
  -FunctionName "Get-${Language}-DocsMsVersionForPackage" `
  -DefaultImplementation { param($packageInfo) $packageInfo }

# Transformed Functions
$GetPackageInfoFromRepoFn = "Get-${Language}-PackageInfoFromRepo"
$GetPackageInfoFromPackageFileFn = "Get-${Language}-PackageInfoFromPackageFile"
$PublishGithubIODocsFn = "Publish-${Language}-GithubIODocs"
$UpdateDocsMsPackagesFn = "Update-${Language}-DocsMsPackages"
$GetDocsMsMetadataForPackageFn = "Get-${Language}-DocsMsMetadataForPackage"
$GetGithubIoDocIndexFn = "Get-${Language}-GithubIoDocIndex"
$FindArtifactForApiReviewFn = "Find-${Language}-Artifacts-For-Apireview"
