<#
.SYNOPSIS
Update docs.microsoft.com CI configuration with provided metadata

.DESCRIPTION
Update docs.microsoft.com CI configuration with metadata in the docs.microsoft.com repo's
/metadata folder. The docs.microsoft.com repo's /metadata folder allows onboarding of
packages which have not released to a central package manager.

* Onboard new packages, update existing tracked packages, leave other packages
  in place. (This is implemented on a per-language basis by
  $UpdateDocsMsPackagesFn)

.PARAMETER DocRepoLocation
Location of the docs.microsoft.com reference docs repo.

.PARAMETER PackageSourceOverride
Optional parameter to supply a different package source (useful for daily dev
docs generation from pacakges which are not published to the default feed). This
variable is meant to be used in the domain-specific business logic in
&$UpdateDocsMsPackagesFn

.PARAMETER ImageId
Optional The docker image for package validation in format of '$containerRegistry/$imageName:$tag'.
e.g. azuresdkimages.azurecr.io/jsrefautocr:latest

#>
param (
  [Parameter(Mandatory = $true)]
  [string] $DocRepoLocation, # the location of the cloned doc repo

  [Parameter(Mandatory = $false)]
  [string] $PackageSourceOverride,

  [Parameter(Mandatory = $false)]
  [string] $ImageId
)

. (Join-Path $PSScriptRoot common.ps1)
. "$PSScriptRoot/../../scripts/docs/Docs-Onboarding.ps1"

Set-StrictMode -Version 3

function GetMetadata($moniker) {
  $jsonFiles = Get-ChildItem -Path (Join-Path $DocRepoLocation "metadata/$moniker") -Filter *.json
  $metadata = @()
  foreach ($jsonFile in $jsonFiles) {
    # Converting to a hashtable gives more beneficial semantics for handling
    # metadata (easier to check existence of property, easier to add new
    # properties)
    $metadata += Get-Content $jsonFile -Raw | ConvertFrom-Json -AsHashtable
  }

  return $metadata
}

function ValidatePackage($package) {
  if (!(Test-Path "Function:$ValidateDocsMsPackagesFn")) {
    return $true
  }

  # TODO: Ensure parameters are correct here
  return &$ValidateDocsMsPackagesFn $package
}

$MONIKERS = @('latest', 'preview', 'legacy')
foreach ($moniker in $MONIKERS) {
  try {
    Write-Host "Onboarding packages for moniker: $moniker"
    $metadata = GetMetadata $moniker
    $alreadyOnboardedPackages = &$GetDocsPackagesAlreadyOnboarded $DocRepoLocation $moniker

    # Sort the metadata entries by package name so that the output is
    # deterministic (more simple diffs)
    $sortedMetadata = $metadata | Sort-Object -Property Name

    $outputPackages = @()
    foreach ($package in $sortedMetadata) {
      if (!($alreadyOnboardedPackages.ContainsKey($package.Name))) {
        if (!(ValidatePackage $package)) {
          LogWarning "Skip adding package that did not pass validation: $($package.Name)"
          continue
        }

        Write-Host "Add new package: $($package.Name)@$($package.Version)"
        $outputPackages += $package
        continue
      }

      $oldPackage = $alreadyOnboardedPackages[$package.Name]

      if ($oldPackage.Version -ne $package.Version) {
        if (!(ValidatePackage $package)) {
          LogWarning "Omitting package that failed validation: $($package.Name)@$($package.Version)"
          continue
        }

        Write-Host "Update package: $($package.Name)@$($oldPackage.Version) to $($package.Name)@$($package.Version)"
        $outputPackages += $package
        continue
      }

      Write-Host "Unchanged package: $($package.Name)@$($package.Version)"
      $outputPackages += $package
    }

    &$SetDocsPackageOnboarding $moniker $outputPackages $DocRepoLocation $PackageSourceOverride
  } catch {
    Write-Host "Error onboarding packages for moniker: $moniker"
    Write-Host "Error: $_"
    Write-Error $_
  }
}
