param(
    [Parameter(Mandatory = $true)]
    [string] $DocRepoLocation
)

. (Join-Path $PSScriptRoot common.ps1)

Set-StictMode -Version 3

function getPackageMetadata($moniker) { 
    $jsonFiles = Get-ChildItem -Path (Join-Path $DocRepoLocation "metadata/$moniker") -Filter *.json
    $metadata = @{}

    foreach ($jsonFile in $jsonFiles) {
        $packageMetadata = Get-Content $jsonFile -Raw | ConvertFrom-Json -AsHashtable
        $packageIdentity = $packageMetadata.Name
        if (Test-Path "Function:$GetPackageIdentity") {
            $packageIdentity = &$GetPackageIdentity $packageMetadata
        }

        $metadata[$packageIdentity] = @{ File = $jsonFile; metadata = $packageMetadata }
    }
    
    return $metadata
}

function getPackageMetadataFileLocation($packageIdentity, $lookupTable) { 
    if ($lookupTable.ContainsKey[$packageIdentity]) { 
        return $lookupTable[$packageIdentity]['File']
    }

    return $null 
}

$metadataLookup = @{ 
    'latest' = getPackageMetadata 'latest'
    'preview' = getPackageMetadata 'preview'
    'legacy' = getPackageMetadata 'legacy'
}
$deprecatedPackages = (Get-CSVMetadata).Where({ $_.Support -eq 'deprecated' })

foreach ($package in $deprecatedPackages) {
    $packageIdentity = $package.Package
    $metadata = &$GetDocsMsMetadataForPackageFn -PackageInfo $packageMetadata

    # TODO: Ensure this works
    if (Test-Path "Function:$GetPackageIdentity") {
        $packageIdentity = &$GetPackageIdentity $package
    }

    $previewMetadataPath = getPackageMetadataFileLocation `
        -packageIdentity $packageIdentity `
        -lookupTable $metadataLookup['preview']

    $latestMetadataPath = getPackageMetadataFileLocation `
        -packageIdentity $packageIdentity `
        -lookupTable $metadataLookup['latest']

    if ($previewMetadataPath) { 
        Write-Host "Package $packageIdentity is deprecated but has file in preview metadata folder. Moving to legacy."
        Move-Item $previewMetadataPath "$DocRepoLocation/metadata/legacy/" -Force
        Move-Item `
            "$($metadata.PreviewReadMeLocation)/$($metadata.DocsMsReadMeName)-readme.md" `
            "$DocRepoLocation/metadata/legacy/$($metadata.DocsMsReadMeName)-readme.md" `
            -Force
    }

    if ($latestMetadataPath) { 
        Write-Host "Package $packageIdentity is deprecated but has file in latest metadata folder. Moving to legacy. (might overwrite preview version if it exists in metadata/legacy)"
        Move-Item $latestMetadataPath "$DocRepoLocation/metadata/legacy/" -Force
        Move-Item `
            "$($metadata.LatestReadMeLocation)/$($metadata.DocsMsReadMeName)-readme.md" `
            "$DocRepoLocation/metadata/legacy/$($metadata.DocsMsReadMeName)-readme.md" `
            -Force
    }
}
