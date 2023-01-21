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
    $metadataObjects = $metadataFiles.foreach({Get-Content $_.FullName -Raw | ConvertFrom-Json})
    $csvPackages = Get-CSVMetadata $MetadataUri

    $onboardingPackages = (MergeCSVAndDocsMetadata -csvPackages $csvPackages -docsMetadata $metadataObjects -moniker $moniker -dailyDocs $DailyDocs)
    # Filter out the unwanted packages by monikers
    if ($moniker -eq 'legacy') {
    $onboardingPackages = $onboardingPackages.Where(
        {$_.Support -eq 'deprecated' -and `
        ($_.Hide -ne 'true' -or $_.MSDocService -ne '')}
    )
    }
    elseif($moniker -eq 'latest') {
        $onboardingPackages = $onboardingPackages.Where({
            $_.Support -ne 'deprecated' -and `
            ($_.Hide -ne 'true' -and $_.New -eq 'true' -or $_.MSDocService -ne '')
        })
    }
    else {
        $onboardingPackages = $onboardingPackages.Where({
            $_.Support -ne 'deprecated' -and `
            ($_.Hide -ne 'true' -and $_.New -eq 'true' -or $_.MSDocService -ne '')
        })
    }
    # Filter out the ones we manually rule out.
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
