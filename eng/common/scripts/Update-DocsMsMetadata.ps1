<#
.SYNOPSIS
Updates package README.md for publishing to docs.microsoft.com

.DESCRIPTION
Given a PackageInfo .json file, format the package README.md file with metadata
and other information needed to release reference docs: 

* Adjust README.md content to include metadata
* Insert the package verison number in the README.md title 
* Copy file to the appropriate location in the documentation repository
* Copy PackageInfo .json file to the metadata location in the reference docs
  repository. This enables the Docs CI build to onboard packages which have not
  shipped and for which there are no entries in the metadata CSV files.

.PARAMETER PackageInfoJsonLocations
List of locations of the artifact information .json file. This is usually stored
in build artifacts under packages/PackageInfo/<package-name>.json. Can also be
a single item.

.PARAMETER DocRepoLocation 
Location of the root of the docs.microsoft.com reference doc location. Further
path information is provided by $GetDocsMsMetadataForPackageFn

.PARAMETER Language
Programming language to supply to metadata

.PARAMETER RepoId
GitHub repository ID of the SDK. Typically of the form: 'Azure/azure-sdk-for-js'

#>

param(
  [Parameter(Mandatory = $true)]
  [array]$PackageInfoJsonLocations,
  
  [Parameter(Mandatory = $true)]
  [string]$DocRepoLocation, 

  [Parameter(Mandatory = $true)]
  [string]$Language,

  [Parameter(Mandatory = $true)]
  [string]$RepoId
)

. (Join-Path $PSScriptRoot common.ps1)

$releaseReplaceRegex = "(https://github.com/$RepoId/(?:blob|tree)/)(?:master|main)"
$TITLE_REGEX = "(\#\s+(?<filetitle>Azure .+? (?:client|plugin|shared) library for (?:JavaScript|Java|Python|\.NET|C)))"

function GetAdjustedReadmeContent($ReadmeContent, $PackageInfo, $PackageMetadata) {
  # The $PackageMetadata could be $null if there is no associated metadata entry
  # based on how the metadata CSV is filtered
  $service = $PackageInfo.ServiceDirectory.ToLower()
  if ($PackageMetadata -and $PackageMetadata.ServiceName) {
    # Normalize service name "Key Vault" -> "keyvault"
    # TODO: Use taxonomy for service name -- https://github.com/Azure/azure-sdk-tools/issues/1442
    # probably from metadata
    $service = $PackageMetadata.ServiceName.ToLower().Replace(" ", "")
  }

  # Generate the release tag for use in link substitution
  $tag = "$($PackageInfo.Name)_$($PackageInfo.Version)"
  Write-Host "The tag of package: $tag"
  $date = Get-Date -Format "MM/dd/yyyy"


  $foundTitle = ""
  if ($ReadmeContent -match $TITLE_REGEX) {
    $ReadmeContent = $ReadmeContent -replace $TITLE_REGEX, "`${0} - Version $($PackageInfo.Version) `n"
    $foundTitle = $matches["filetitle"]
  }

  # If this is not a daily dev package, perform link replacement
  if (!$packageInfo.DevVersion) {
    $replacementPattern = "`${1}$tag"
    $ReadmeContent = $ReadmeContent -replace $releaseReplaceRegex, $replacementPattern
  }
  
  $header = @"
---
title: $foundTitle
keywords: Azure, $Language, SDK, API, $($PackageInfo.Name), $service
author: maggiepint
ms.author: magpint
ms.date: $date
ms.topic: reference
ms.prod: azure
ms.technology: azure
ms.devlang: $Language
ms.service: $service
---

"@

  return "$header`n$ReadmeContent"
}

function UpdateDocsMsMetadataForPackage($packageInfoJsonLocation) { 
  if (!(Test-Path $packageInfoJsonLocation)) {
    LogWarning "Package metadata not found for $packageInfoJsonLocation"
    return
  }
  
  $packageInfoJson = Get-Content $packageInfoJsonLocation -Raw
  $packageInfo = ConvertFrom-Json $packageInfoJson
  $originalVersion = [AzureEngSemanticVersion]::ParseVersionString($packageInfo.Version)
  if ($packageInfo.DevVersion) {
    # If the package is of a dev version there may be language-specific needs to 
    # specify the appropriate version. For example, in the case of JS, the dev 
    # version is always 'dev' when interacting with NPM.
    if ($GetDocsMsDevLanguageSpecificPackageInfoFn -and (Test-Path "Function:$GetDocsMsDevLanguageSpecificPackageInfoFn")) { 
      $packageInfo = &$GetDocsMsDevLanguageSpecificPackageInfoFn $packageInfo
    } else {
      # Default: use the dev version from package info as the version for
      # downstream processes
      $packageInfo.Version = $packageInfo.DevVersion
    }
  }

  $packageMetadataArray = (Get-CSVMetadata).Where({ $_.Package -eq $packageInfo.Name -and $_.GroupId -eq $packageInfo.Group -and $_.Hide -ne 'true' -and $_.New -eq 'true' })
  if ($packageMetadataArray.Count -eq 0) { 
    LogWarning "Could not retrieve metadata for $($packageInfo.Name) from metadata CSV. Using best effort defaults."
    $packageMetadata = $null
  } elseif ($packageMetadataArray.Count -gt 1) { 
    LogWarning "Multiple metadata entries for $($packageInfo.Name) in metadata CSV. Using first entry."
    $packageMetadata = $packageMetadataArray[0]
  } else {
    $packageMetadata = $packageMetadataArray[0]
  }

  $readmeContent = Get-Content $packageInfo.ReadMePath -Raw
  $outputReadmeContent = "" 
  if ($readmeContent) { 
    $outputReadmeContent = GetAdjustedReadmeContent $readmeContent $packageInfo $packageMetadata
  }

  $docsMsMetadata = &$GetDocsMsMetadataForPackageFn $packageInfo
  $readMePath = $docsMsMetadata.LatestReadMeLocation
  if ($originalVersion.IsPrerelease) { 
    $readMePath = $docsMsMetadata.PreviewReadMeLocation
  }

  $suffix = $docsMsMetadata.Suffix
  $readMeName = "$($docsMsMetadata.DocsMsReadMeName.ToLower())-readme${suffix}.md"

  $readmeLocation = Join-Path $DocRepoLocation $readMePath $readMeName

  Set-Content -Path $readmeLocation -Value $outputReadmeContent

  # Copy package info file to the docs repo
  $metadataMoniker = 'latest'
  if ($originalVersion.IsPrerelease) {
    $metadataMoniker = 'preview'
  }
  $packageMetadataName = Split-Path $packageInfoJsonLocation -Leaf
  $packageInfoLocation = Join-Path $DocRepoLocation "metadata/$metadataMoniker"
  $packageInfoJson = ConvertTo-Json $packageInfo
  New-Item -ItemType Directory -Path $packageInfoLocation -Force
  Set-Content `
    -Path $packageInfoLocation/$packageMetadataName `
    -Value $packageInfoJson
}

foreach ($packageInfo in $PackageInfoJsonLocations) {
  Write-Host "Updating metadata for package: $packageInfo"
  UpdateDocsMsMetadataForPackage $packageInfo
}
