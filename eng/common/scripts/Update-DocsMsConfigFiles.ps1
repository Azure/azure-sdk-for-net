param(
  [Parameter(Mandatory = $true)]
  [string]$DocsRepo,
  [Parameter(Mandatory = $false)]
  [string]$PackageSourceOverride,
  [Parameter(Mandatory = $false)]
  [switch]$DailyDocs
  
)
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers/Metadata-Helpers.ps1)

function GetOnboardingPackages($moniker) {
    # Get all metadata jsons
    $metadataFiles = Get-ChildItem "$DocsRepo/metadata/$moniker/*" -File -Include *.json
    $csvPackages = Get-CSVMetadata $MetadataUri
    $metadataObjects = $metadataFiles.foreach({Get-Content $_.FullName -Raw | ConvertFrom-Json})

    # Filter logic
    if ($moniker -eq 'legacy') {
        $csvPackages = $csvPackages.Where(
            {$_.Support -eq 'deprecated' -and `
            ($_.Hide -ne 'true' -or $_.MSDocService -ne '')}
        )
    }
    elseif($moniker -eq 'latest') {
        $csvPackages = $csvPackages.Where({
            $_.Support -ne 'deprecated' -and `
            ($_.Hide -ne 'true' -and $_.New -eq 'true' -or $_.MSDocService -ne '') -and `
            $_.VersionGA -ne ''
        })
    }
    else {
        $csvPackages = $csvPackages.Where({
            $_.Support -ne 'deprecated' -and `
            ($_.Hide -ne 'true' -and $_.New -eq 'true' -or $_.MSDocService -ne '') -and `
            $_.VersionPreview -ne ''
        })
    }
    $onboardingPackages = MergeCSVToDocsMetadata -csvPackages $csvPackages -docsMetadata $metadataObjects -moniker $moniker -dailyDocs $DailyDocs
    $onboardingPackages = $onboardingPackages.Where({$_.ManuallyOverride -ne 'off'})
    return $onboardingPackages
}

$monikers = @('latest', 'preview', 'legacy')
foreach ($moniker in $monikers) {
    $onboardingPackages = GetOnboardingPackages $moniker
    if ($WriteDocsMsConfigFn -and (Test-Path "Function:$WriteDocsMsConfigFn")) {
        Write-Host "Updating $moniker config jsons..."
        &$WriteDocsMsConfigFn $DocsRepo $moniker $onboardingPackages
    }
}
