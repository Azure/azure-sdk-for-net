<#
.SYNOPSIS
Measures a NuGet global-packages directory for the pipeline cache experiment.

.DESCRIPTION
Writes one machine-readable NUGET_CACHE_METRICS JSON line and an Azure Pipelines
summary containing logical file size, compressed .nupkg size, file count, and
package ID/version count. A missing cache directory is reported as an empty cache.
#>

param(
    [Parameter(Mandatory = $true)]
    [string] $Path,

    [Parameter(Mandatory = $true)]
    [string] $Label
)

$ErrorActionPreference = 'Stop'
$resolvedPath = [System.IO.Path]::GetFullPath($Path)
$files = @()
$packageVersionCount = 0

if (Test-Path $resolvedPath) {
    # A NuGet global-packages folder is organized as <package ID>/<version>/..., so the
    # second-level directory count describes the dependency working set more usefully
    # than a raw package ID count.
    $files = @(Get-ChildItem -Path $resolvedPath -File -Recurse -Force)
    $packageVersionCount = @(
        Get-ChildItem -Path $resolvedPath -Directory -Force |
            ForEach-Object { Get-ChildItem -Path $_.FullName -Directory -Force }
    ).Count
}

$logicalBytes = [long](($files | Measure-Object -Property Length -Sum).Sum ?? 0)
$nupkgBytes = [long](($files | Where-Object Extension -EQ '.nupkg' | Measure-Object -Property Length -Sum).Sum ?? 0)
$metrics = [ordered]@{
    label = $Label
    path = $resolvedPath
    fileCount = $files.Count
    packageVersionCount = $packageVersionCount
    logicalBytes = $logicalBytes
    logicalMiB = [Math]::Round($logicalBytes / 1MB, 1)
    nupkgBytes = $nupkgBytes
    nupkgMiB = [Math]::Round($nupkgBytes / 1MB, 1)
}

$json = $metrics | ConvertTo-Json -Compress
Write-Host "NUGET_CACHE_METRICS $json"

# Add a compact, human-readable measurement to the Azure Pipelines run summary while
# retaining the single-line JSON above for automated comparison of experiment runs.
$summaryPath = Join-Path $env:AGENT_TEMPDIRECTORY "nuget-cache-$([Guid]::NewGuid().ToString('N')).md"
@"
## NuGet cache: $Label

| Metric | Value |
| --- | ---: |
| Logical size | $($metrics.logicalMiB) MiB |
| `.nupkg` size | $($metrics.nupkgMiB) MiB |
| Files | $($metrics.fileCount) |
| Package ID/version pairs | $($metrics.packageVersionCount) |
"@ | Set-Content -Path $summaryPath

Write-Host "##vso[task.uploadsummary]$summaryPath"
