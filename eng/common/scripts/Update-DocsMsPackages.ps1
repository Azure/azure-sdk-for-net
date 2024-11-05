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

#>
param (
  [Parameter(Mandatory = $true)]
  [string] $DocRepoLocation, # the location of the cloned doc repo

  [Parameter(Mandatory = $false)]
  [string] $PackageSourceOverride
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

function PackageIsValidForDocsOnboarding($package) {
  if (!(Test-Path "Function:$ValidateDocsMsPackagesFn")) {
    return $true
  }

  return &$ValidateDocsMsPackagesFn `
    -PackageInfo $package `
    -DocRepoLocation $DocRepoLocation
}

$MONIKERS = @('latest', 'preview', 'legacy')
foreach ($moniker in $MONIKERS) {
  try {
    Write-Host "Onboarding packages for moniker: $moniker"
    $metadata = GetMetadata $moniker
    $alreadyOnboardedPackages = &$GetDocsPackagesAlreadyOnboarded $DocRepoLocation $moniker

    # Sort the metadata entries by package name so that the output is
    # deterministic (more simple diffs)
    $sortedMetadata = $metadata | Sort-Object -Property '_DocsOnboardingOrdinal', 'Name'

    $outputPackages = @()
    foreach ($package in $sortedMetadata) {
      $packageIdentity = $package.Name
      if (Test-Path "Function:$GetPackageIdentity") {
        $packageIdentity = &$GetPackageIdentity $package
      }

      if (!($alreadyOnboardedPackages.ContainsKey($packageIdentity))) {
        Write-Host "Evaluating package for onboarding: $($packageIdentity)"
        if ($package.ContainsKey('_SkipDocsValidation') -and $true -eq $package['_SkipDocsValidation']) {
          Write-Host "Skip validation for package: $($packageIdentity)"
        }
        elseif (!(PackageIsValidForDocsOnboarding $package)) {
          LogWarning "Skip adding package that did not pass validation: $($packageIdentity)"
          continue
        }

        Write-Host "Add new package: $($packageIdentity)@$($package.Version)"
        $outputPackages += $package
        continue
      }

      $oldPackage = $alreadyOnboardedPackages[$packageIdentity]

      if ($oldPackage.Version -ne $package.Version) {
        if (!(PackageIsValidForDocsOnboarding $package)) {
          LogWarning "Omitting package that failed validation: $($packageIdentity)@$($package.Version)"
          continue
        }

        Write-Host "Update package: $($packageIdentity)@$($oldPackage.Version) to $($packageIdentity)@$($package.Version)"
        $outputPackages += $package
        continue
      }

      Write-Host "Unchanged package: $($packageIdentity)@$($package.Version)"
      $outputPackages += $package
    }

    &$SetDocsPackageOnboarding $moniker $outputPackages $DocRepoLocation $PackageSourceOverride
  }
  catch {
    Write-Host "Error onboarding packages for moniker: $moniker"
    Write-Host "Error: $_"
    Write-Host "Stacktrace: $($_.ScriptStackTrace)"
    Write-Error $_
    exit 1
  }
}

exit 0
