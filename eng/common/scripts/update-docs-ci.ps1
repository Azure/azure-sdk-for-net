#Requires -Version 6.0
# This script is intended to  update docs.ms CI configuration (currently supports Java, Python, C#, JS)
# as part of the azure-sdk release. For details on calling, check `archtype-<language>-release` in each azure-sdk
# repository.

# Where possible, this script adds as few changes as possible to the target config. We only 
# specifically mark a version for Python Preview and Java. This script is intended to be invoked 
# multiple times. Once for each moniker. Currently only supports "latest" and "preview" artifact selection however.
param (
  [Parameter(Mandatory = $true)]
  $ArtifactLocation, # the root of the artifact folder. DevOps $(System.ArtifactsDirectory)
  
  [Parameter(Mandatory = $true)]
  $WorkDirectory, # a clean folder that we can work in
  
  [Parameter(Mandatory = $true)]
  $ReleaseSHA, # the SHA for the artifacts. DevOps: $(Release.Artifacts.<artifactAlias>.SourceVersion) or $(Build.SourceVersion)
  
  [Parameter(Mandatory = $true)]
  $RepoId, # full repo id. EG azure/azure-sdk-for-net  DevOps: $(Build.Repository.Id). Used as a part of VerifyPackages
  
  [Parameter(Mandatory = $true)]
  [ValidateSet("Nuget","NPM","PyPI","Maven")]
  $Repository, # EG: "Maven", "PyPI", "NPM"

  [Parameter(Mandatory = $true)]
  $DocRepoLocation, # the location of the cloned doc repo

  [Parameter(Mandatory = $true)]
  $Configs # The configuration elements informing important locations within the cloned doc repo
)

. (Join-Path $PSScriptRoot common.ps1)

$targets = ($Configs | ConvertFrom-Json).targets

#{
# path_to_config:
# mode:
# monikerid:
# content_folder:
# suffix:
#}

$apiUrl = "https://api.github.com/repos/$repoId"
$pkgs = VerifyPackages -artifactLocation $ArtifactLocation `
  -workingDirectory $WorkDirectory `
  -apiUrl $apiUrl `
  -continueOnError $True 

foreach ($config in $targets) {
  if ($config.mode -eq "Preview") { $includePreview = $true } else { $includePreview = $false }
  $pkgsFiltered = $pkgs | ? { $_.IsPrerelease -eq $includePreview}

  if ($pkgsFiltered) {
    Write-Host "Given the visible artifacts, CI updates against $($config.path_to_config) will be processed for the following packages."
    Write-Host ($pkgsFiltered | % { $_.PackageId + " " + $_.PackageVersion })

    if ($UpdateDocCIFn -and (Test-Path "Function:$UpdateDocCIFn"))
    {
      &$UpdateDocCIFn -pkgs $pkgsFiltered -ciRepo $DocRepoLocation -locationInDocRepo $config.path_to_config -monikerId $config.monikerid
    }
    else
    {
      LogWarning "The function for '$UpdateDocCIFn' was not found.`
      Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
      See https://github.com/Azure/azure-sdk-tools/blob/master/doc/common/common_engsys.md#code-structure"
    }
  }
}