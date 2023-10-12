<#
.SYNOPSIS
Move metadata JSON and package-level overview markdown files for deprecated packages to the legacy folder.

.DESCRIPTION
Move onboarding information to the "legacy" moniker for whose support is "deprecated" in the Metadata CSV.
Only one version of a package can be documented in the "legacy" moniker. If multiple versions are available,
the "latest" version will be used and the "preview" version will be deleted.

.PARAMETER DocRepoLocation
The location of the target docs repository.
#>

param(
    [Parameter(Mandatory = $true)]
    [string] $DocRepoLocation
)

. (Join-Path $PSScriptRoot common.ps1)

Set-StrictMode -Version 3

function getPackageMetadata($moniker) { 
    $jsonFiles = Get-ChildItem -Path (Join-Path $DocRepoLocation "metadata/$moniker") -Filter *.json
    $metadata = @{}

    foreach ($jsonFile in $jsonFiles) {
        $packageMetadata = Get-Content $jsonFile -Raw | ConvertFrom-Json -AsHashtable
        $packageIdentity = $packageMetadata.Name
        if (Test-Path "Function:$GetPackageIdentity") {
            $packageIdentity = &$GetPackageIdentity $packageMetadata
        }

        $metadata[$packageIdentity] = @{ File = $jsonFile; Metadata = $packageMetadata }
    }
    
    return $metadata
}

function getPackageInfoFromLookup($packageIdentity, $version, $lookupTable) { 
    if ($lookupTable.ContainsKey($packageIdentity)) {
        if ($lookupTable[$packageIdentity]['Metadata'].Version -eq $version) {
            # Only return if the version matches
            return $lookupTable[$packageIdentity]
        }
    }

    return $null 
}

function moveToLegacy($packageInfo) { 
    $docsMsMetadata = &$GetDocsMsMetadataForPackageFn -PackageInfo $packageInfo['Metadata']

    Write-Host "Move to legacy: $($packageInfo['Metadata'].Name)"
    $packageInfoPath = $packageInfo['File']
    Move-Item "$($packageInfoPath.Directory)/$($packageInfoPath.BaseName).*" "$DocRepoLocation/metadata/legacy/" -Force

    $readmePath = "$DocRepoLocation/$($docsMsMetadata.PreviewReadMeLocation)/$($docsMsMetadata.DocsMsReadMeName)-readme.md"
    if (Test-Path $readmePath) {
        Move-Item `
            $readmePath `
            "$DocRepoLocation/$($docsMsMetadata.LegacyReadMeLocation)/" `
            -Force
    }
}

function deletePackageInfo($packageInfo) { 
    $docsMsMetadata = &$GetDocsMsMetadataForPackageFn -PackageInfo $packageInfo['Metadata']

    Write-Host "Delete superseded package: $($packageInfo['Metadata'].Name)"
    $packageInfoPath = $packageInfo['File']
    Remove-Item "$($packageInfoPath.Directory)/$($packageInfoPath.BaseName).*" -Force

    $readmePath = "$DocRepoLocation/$($docsMsMetadata.PreviewReadMeLocation)/$($docsMsMetadata.DocsMsReadMeName)-readme.md"
    if (Test-Path $readmePath) {
        Remove-Item $readmePath -Force
    }
}

$metadataLookup = @{ 
    'latest'  = getPackageMetadata 'latest'
    'preview' = getPackageMetadata 'preview'
}
$deprecatedPackages = (Get-CSVMetadata).Where({ $_.Support -eq 'deprecated' })

foreach ($package in $deprecatedPackages) {
    $packageIdentity = $package.Package
    if (Test-Path "Function:$GetPackageIdentityFromCsvMetadata") {
        $packageIdentity = &$GetPackageIdentityFromCsvMetadata $package
    }

    $packageInfoPreview = $packageInfoLatest = $null
    if ($package.VersionPreview) {
        $packageInfoPreview = getPackageInfoFromLookup `
            -packageIdentity $packageIdentity `
            -version $package.VersionPreview `
            -lookupTable $metadataLookup['preview']
    }

    if ($package.VersionGA) { 
        $packageInfoLatest = getPackageInfoFromLookup `
            -packageIdentity $packageIdentity `
            -version $package.VersionGA `
            -lookupTable $metadataLookup['latest']
    }

    if (!$packageInfoPreview -and !$packageInfoLatest) {
        # Nothing to move or delete
        continue
    }

    if ($packageInfoPreview -and $packageInfoLatest) {
        # Delete metadata JSON and package-level overview markdown files for
        # the preview version instead of moving both. This mitigates situations
        # where the "latest" verison doesn't have a package-level overview 
        # markdown file and the "preview" version does.
        deletePackageInfo $packageInfoPreview
        moveToLegacy $packageInfoLatest
    } else {
        moveToLegacy ($packageInfoPreview ?? $packageInfoLatest)
    }
}
