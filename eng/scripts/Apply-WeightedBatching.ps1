<#
.SYNOPSIS
Applies weighted LPT bin-packing to PackageInfo files for balanced CI test batching.

.DESCRIPTION
Reads PackageInfo JSON files and a test weights file, performs LPT (Longest Processing Time)
bin-packing to create balanced batches, then consolidates the PackageInfo files so that each
batch becomes a single representative file. The ArtifactName of each consolidated file contains
the comma-separated names of all packages in that batch, which flows through to the
ProjectNames parameter in the matrix generation.

After this script runs, set PRJobBatchSize to 1 so each consolidated file becomes its own job.

.PARAMETER PackageInfoFolder
Path to the folder containing PackageInfo JSON files.

.PARAMETER WeightsFile
Path to the JSON weights file (package name → seconds).

.PARAMETER TargetSeconds
Target maximum time per bucket in seconds. Default is 1800 (30 minutes).

.PARAMETER DefaultWeight
Weight assigned to packages not found in the weights file. Default is 1.
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$PackageInfoFolder,
  [Parameter(Mandatory = $true)][string]$WeightsFile,
  [Parameter()][int]$TargetSeconds = 1800,
  [Parameter()][int]$DefaultWeight = 1
)

Set-StrictMode -Version 4

# Load weights
$weights = @{}
if (Test-Path $WeightsFile) {
  try {
    $content = Get-Content $WeightsFile -Raw | ConvertFrom-Json
    $content.PSObject.Properties | ForEach-Object { $weights[$_.Name] = [int]$_.Value }
  }
  catch {
    Write-Warning "Failed to load weights: $($_.Exception.Message). Skipping weighted batching."
    return
  }
}

if ($weights.Count -eq 0) {
  Write-Host "No weights available. Skipping weighted batching."
  return
}

# Load all PackageInfo files
$packageFiles = Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse
$packages = @($packageFiles | ForEach-Object {
  $json = Get-Content $_.FullName | ConvertFrom-Json
  [PSCustomObject]@{
    FilePath = $_.FullName
    FileName = $_.Name
    Json     = $json
  }
})

if ($packages.Count -eq 0) {
  Write-Host "No PackageInfo files found. Skipping weighted batching."
  return
}

# Separate direct and indirect packages
$directPackages = @($packages | Where-Object { $_.Json.IncludedForValidation -eq $false })
$indirectPackages = @($packages | Where-Object { $_.Json.IncludedForValidation -eq $true })

$totalPkgs = $directPackages.Count + $indirectPackages.Count
$matchedWeights = @($packages | Where-Object { $weights.ContainsKey($_.Json.ArtifactName) }).Count
Write-Host "Packages: $($directPackages.Count) direct, $($indirectPackages.Count) indirect ($matchedWeights/$totalPkgs have weights)"

function Apply-LPTBatching {
  param(
    [object[]]$Packages,
    [hashtable]$Weights,
    [int]$TargetSeconds,
    [int]$DefaultWeight,
    [string]$Label
  )

  if ($Packages.Count -le 1) {
    Write-Host "  $Label`: Only $($Packages.Count) package(s), no batching needed."
    return
  }

  # Build weighted items
  $items = @(foreach ($pkg in $Packages) {
    $name = $pkg.Json.ArtifactName
    $weight = if ($Weights.ContainsKey($name)) { [int]$Weights[$name] } else { $DefaultWeight }
    [PSCustomObject]@{ Package = $pkg; Weight = $weight; Name = $name }
  })

  # Sort by weight descending (LPT: largest first)
  $items = @($items | Sort-Object Weight -Descending)

  # Calculate number of buckets
  [int]$totalWeight = 0
  foreach ($i in $items) { $totalWeight += $i.Weight }
  $numBuckets = [math]::Max(1, [math]::Ceiling($totalWeight / $TargetSeconds))

  # Don't create more buckets than packages
  $numBuckets = [math]::Min($numBuckets, $Packages.Count)

  Write-Host "  $Label`: $($Packages.Count) packages, total weight ${totalWeight}s, target ${TargetSeconds}s -> $numBuckets buckets"

  # Create buckets
  $buckets = @()
  for ($b = 0; $b -lt $numBuckets; $b++) {
    $buckets += [PSCustomObject]@{
      Items       = [System.Collections.ArrayList]::new()
      TotalWeight = [int]0
    }
  }

  # Greedy LPT: assign each item to the lightest bucket
  foreach ($item in $items) {
    $lightest = $buckets | Sort-Object TotalWeight | Select-Object -First 1
    [void]$lightest.Items.Add($item)
    $lightest.TotalWeight += $item.Weight
  }

  # Log bucket distribution with collapsible groups
  $bucketIdx = 1
  foreach ($bucket in $buckets) {
    $summary = "Bucket ${bucketIdx}: $($bucket.Items.Count) pkgs, weight $($bucket.TotalWeight)s ($([math]::Round($bucket.TotalWeight / 60, 1))m)"
    Write-Host "##[group]$summary"
    foreach ($item in ($bucket.Items | Sort-Object Name)) {
      Write-Host "      $($item.Name) ($($item.Weight)s)"
    }
    Write-Host "##[endgroup]"
    $bucketIdx++
  }

  # Consolidate: for each bucket, keep one representative file with all names
  foreach ($bucket in $buckets) {
    $batchItems = @($bucket.Items)
    if ($batchItems.Count -eq 0) { continue }

    # Use the first (heaviest) package as the representative
    $representative = $batchItems[0].Package
    $allNames = ($batchItems | ForEach-Object { $_.Name }) -join ","

    # Update the representative's ArtifactName to contain all package names
    $representative.Json.ArtifactName = $allNames
    $representative.Json | ConvertTo-Json -Depth 100 | Set-Content $representative.FilePath -Encoding utf8

    # Delete the other package files in this batch
    for ($i = 1; $i -lt $batchItems.Count; $i++) {
      Remove-Item $batchItems[$i].Package.FilePath -Force
    }
  }

  Write-Host "  $Label`: Consolidated $($Packages.Count) files into $numBuckets batch files."
}

# Apply LPT batching to direct and indirect packages separately
if ($directPackages.Count -gt 0) {
  Apply-LPTBatching -Packages $directPackages -Weights $weights `
    -TargetSeconds $TargetSeconds -DefaultWeight $DefaultWeight -Label "Direct"
}

if ($indirectPackages.Count -gt 0) {
  Apply-LPTBatching -Packages $indirectPackages -Weights $weights `
    -TargetSeconds $TargetSeconds -DefaultWeight $DefaultWeight -Label "Indirect"
}

# Verify
$remaining = @(Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse).Count
Write-Host "Weighted batching complete. $remaining consolidated PackageInfo files remain."
