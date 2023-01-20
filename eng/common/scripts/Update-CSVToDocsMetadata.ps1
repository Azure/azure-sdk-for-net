param(
  [Parameter(Mandatory = $true)]
  [string]$docsRepo,
  [Parameter(Mandatory = $false)]
  [switch]$dailyDocs
)
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)

$csvMetadata = (Get-CSVMetadata).Where({$_.Hide -ne 'true' -or $_.MSDocService -ne '' })
$monikerizedCSV = @{
    "latest" = $csvMetadata.Where({$_.VersionGA -and $_.Support -ne 'deprecated'});
    "preview" = $csvMetadata.Where({$_.VersionPreview -and $_.Support -ne 'deprecated'});
    "legacy" = $csvMetadata.Where({$_.Support -eq 'deprecated'});
}

function convertCSVToObject($csvObject) {
    $version = $package.VersionPreview  
    if ($moniker -ne 'preview' -and $package.VersionGA) {
        $version = $package.VersionGA
    }
    return [PSCustomObject][ordered]@{
        Name = $csvObject.Package;                
        Version = $version;   
        sdkCSV = fillInCSVBlock($csvObject)
    }
}

function fillInCSVBlock($csvObject) {
    return [PSCustomObject][ordered]@{
        DisplayName = $csvObject.DisplayName;
        ServiceName = $csvObject.ServiceName;           
        Type = $csvObject.Type
        New = $csvObject.New
        RepoPath = $csvObject.RepoPath;
        Support = $csvObject.Support;
        EOLDate = $csvObject.EOLDate;
        Hide = $csvObject.Hide;
        MSDocService = $csvObject.MSDocService
    }
}

function compareAndGetLatest($v1, $v2) {
    if ($v1 -lt $v2) {
        return $v2
    }
    return $v1
}

function UpdateMetadataFromCSV($moniker, $csvPackages) {
    foreach ($package in $csvPackages) {
        $fileName = "$($package.Package).json" -replace "@azure/|@azure-rest/|@azure-tools/|@autorest/|@cadl-lang", ""
        $fullPath = "$docsRepo/metadata/$moniker/$fileName"
        if(!(Test-Path $fullPath)) {
            $docsMetadata = convertCSVToObject($package) | ConvertTo-Json
            Set-Content $fullPath -Value $docsMetadata -Force
        }
        else {
            $docsMetadata = Get-Content $fullPath -Raw | ConvertFrom-Json
            if (!$dailyDocs) {
                $docsMetadata.Version = compareAndGetLatest $docsMetadata.Version $package.Version
            }
            $csvObject = fillInCSVBlock($package) | ConvertTo-Json
            $docsMetadata | Add-Member -MemberType NoteProperty -Name 'sdkCSV' -Value $csvObject -Force
        }
    }
}

$monikers = @('latest', 'preview', 'legacy')
foreach ($moniker in $monikers) {
    UpdateMetadataFromCSV $moniker $monikerizedCSV[$moniker]
}