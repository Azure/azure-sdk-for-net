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

function GetDocsMetadataForMoniker($moniker) {
  $searchPath = Join-Path $DocRepoLocation 'metadata' $moniker
  if (!(Test-Path $searchPath)) {
    return @()
  }
  $paths = Get-ChildItem -Path $searchPath -Filter *.json

  $metadata = @()
  foreach ($path in $paths) {
    $fileContents = Get-Content $path -Raw
    $fileObject = ConvertFrom-Json -InputObject $fileContents
    $versionGa = ''
    $versionPreview = ''
    if ($moniker -eq 'latest') {
      $versionGa = $fileObject.Version
    } else {
      $versionPreview = $fileObject.Version
    }

    $entry = @{
      Package = $fileObject.Name;
      VersionGA = $versionGa;
      VersionPreview = $versionPreview;
      RepoPath = $fileObject.ServiceDirectory;
      Type = $fileObject.SdkType;
      New = $fileObject.IsNewSdk;
    }
    if ($fileObject.PSObject.Members.Name -contains "Group")
    {
      $entry.Add("GroupId", $fileObject.Group)
    }
    $metadata += $entry
  }

  return $metadata
}

function GetDocsMetadata() {
  # Read metadata from docs repo
  $metadataByPackage = @{}
  foreach ($package in GetDocsMetadataForMoniker 'latest') {
    if ($metadataByPackage.ContainsKey($package.Package)) {
      LogWarning "Duplicate package in latest metadata: $($package.Package)"
    }
    Write-Host "Adding latest package: $($package.Package)"
    $metadataByPackage[$package.Package] = $package
  }

  foreach ($package in GetDocsMetadataForMoniker 'preview') {
    if ($metadataByPackage.ContainsKey($package.Package)) {
      # Merge VersionPreview of each object
      Write-Host "Merging preview package version for $($package.Package))"
      $metadataByPackage[$package.Package].VersionPreview = $package.VersionPreview
    } else {
      Write-Host "Adding preview package: $($package.Package)"
      $metadataByPackage[$package.Package] = $package
    }
  }

  # TODO - Add a call to GetDocsMetadataForMoniker for 'legacy' when that is implemented

  return $metadataByPackage.Values
}

if ($UpdateDocsMsPackagesFn -and (Test-Path "Function:$UpdateDocsMsPackagesFn")) {

  try {
    $docsMetadata = GetDocsMetadata
    &$UpdateDocsMsPackagesFn -DocsRepoLocation $DocRepoLocation -DocsMetadata $docsMetadata -PackageSourceOverride $PackageSourceOverride -DocValidationImageId $ImageId
  } catch {
    LogError "Exception while updating docs.ms packages"
    LogError $_
    LogError $_.ScriptStackTrace
    exit 1
  }

} else {
  LogError "The function for '$UpdateFn' was not found.`
  Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
  See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
  exit 1
}

# Exit 0 so DevOps doesn't fail the build when the last command called by the
# domain-specific function exited with a non-zero exit code.
exit 0
