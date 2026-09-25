<#
.SYNOPSIS
Applies weighted LPT bin-packing to PackageInfo files for balanced CI job batching.

.DESCRIPTION
Reads PackageInfo JSON files and a weights file, performs LPT (Longest Processing Time)
bin-packing to create balanced batches, then consolidates the PackageInfo files so that each
batch becomes a single representative file. The ArtifactName of each consolidated file contains
the comma-separated names of all packages in that batch, which flows through to the
ProjectNames parameter in the matrix generation.

Used by the Build and Analyze pre-steps with LOC-derived weights, but the script itself is
weight-source-agnostic — any numeric weight file (package name -> integer) will work.

After this script runs, configure PRJobBatchSizeByPool to control how many consolidated
PackageInfo buckets are combined into each job for each agent pool.

.PARAMETER PackageInfoFolder
Path to the folder containing PackageInfo JSON files.

.PARAMETER WeightsFile
Path to the JSON weights file (artifact name -> weight, e.g. LOC count). The key must match
the `ArtifactName` field of the corresponding PackageInfo JSON.

.PARAMETER Target
Target average weight per bucket for direct packages. Default is 1800. Used to derive
the bucket count via ceil(totalWeight / Target); individual buckets may exceed this
after greedy LPT packing — it's a goal, not a hard cap.

.PARAMETER IndirectTarget
Target average weight per bucket for indirect packages. Defaults to Target if not specified.
Indirect packages only run on Linux, so they can use a higher target than direct packages which run across all platforms.

.PARAMETER DefaultWeight
Weight assigned to packages not found in the weights file. Default is 1.

.PARAMETER PreserveCIMatrixConfigs
Prevents packages with different CI matrix configurations from sharing a consolidated PackageInfo
file. This is required when a later job expands the consolidated ArtifactName back into singleton
test cases under the representative file's matrix.
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$PackageInfoFolder,
  [Parameter(Mandatory = $true)][string]$WeightsFile,
  [Parameter()][int]$Target = 1800,
  [Parameter()][int]$IndirectTarget = 0,
  [Parameter()][int]$DefaultWeight = 1,
  [Parameter()][switch]$PreserveCIMatrixConfigs
)

Set-StrictMode -Version 4

if ($IndirectTarget -le 0) { $IndirectTarget = $Target }
if ($Target -le 0) { throw "Target must be greater than zero." }
if ($IndirectTarget -le 0) { throw "IndirectTarget must be greater than zero." }
if ($DefaultWeight -le 0) { throw "DefaultWeight must be greater than zero." }

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
$expectedPackageNames = @($packages | ForEach-Object { $_.Json.ArtifactName } | Sort-Object)

$totalPkgs = $directPackages.Count + $indirectPackages.Count
$matchedWeights = @($packages | Where-Object { $weights.ContainsKey($_.Json.ArtifactName) }).Count
Write-Host "Packages: $($directPackages.Count) direct, $($indirectPackages.Count) indirect ($matchedWeights/$totalPkgs have weights)"

function Apply-LPTBatching {
  param(
    [object[]]$Packages,
    [hashtable]$Weights,
    [int]$Target,
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
    $weight = if ($Weights.ContainsKey($name)) {
      [math]::Max([int]$Weights[$name], $DefaultWeight)
    }
    else {
      $DefaultWeight
    }
    [PSCustomObject]@{ Package = $pkg; Weight = $weight; Name = $name }
  })

  # Sort by weight descending (LPT: largest first), then by name for deterministic ties.
  $items = @($items | Sort-Object `
    @{ Expression = "Weight"; Descending = $true }, `
    @{ Expression = "Name"; Descending = $false })

  # Calculate number of buckets
  [int]$totalWeight = 0
  foreach ($i in $items) { $totalWeight += $i.Weight }
  $numBuckets = [math]::Max(1, [math]::Ceiling($totalWeight / $Target))

  # Don't create more buckets than packages
  $numBuckets = [math]::Min($numBuckets, $Packages.Count)

  Write-Host "  $Label`: $($Packages.Count) packages, total weight ${totalWeight}, target ${Target} -> $numBuckets buckets"

  # Create buckets
  $buckets = @()
  for ($b = 0; $b -lt $numBuckets; $b++) {
    $buckets += [PSCustomObject]@{
      Index       = $b
      Items       = [System.Collections.ArrayList]::new()
      TotalWeight = [int]0
    }
  }

  # Greedy LPT: assign each item to the lightest bucket
  foreach ($item in $items) {
    $lightest = $buckets |
      Sort-Object TotalWeight, Index |
      Select-Object -First 1
    [void]$lightest.Items.Add($item)
    $lightest.TotalWeight += $item.Weight
  }

  # Log bucket distribution with collapsible groups
  $bucketIdx = 1
  foreach ($bucket in $buckets) {
    $summary = "Bucket ${bucketIdx}: $($bucket.Items.Count) pkgs, weight $($bucket.TotalWeight)"
    Write-Host "##[group]$summary"
    foreach ($item in ($bucket.Items | Sort-Object Name)) {
      Write-Host "      $($item.Name) (weight $($item.Weight))"
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

function Apply-LPTBatchingByMatrixConfig {
  param(
    [object[]]$Packages,
    [hashtable]$Weights,
    [int]$Target,
    [int]$DefaultWeight,
    [string]$Label
  )

  if (!$PreserveCIMatrixConfigs) {
    Apply-LPTBatching -Packages $Packages -Weights $Weights -Target $Target `
      -DefaultWeight $DefaultWeight -Label $Label
    return
  }

  # Create-PrJobMatrix uses CIMatrixConfigs from the retained representative file. Keep distinct
  # configs in distinct buckets so every expanded singleton runs under its own declared matrix.
  $groups = @{}
  foreach ($package in $Packages) {
    $ciParametersProperty = $package.Json.PSObject.Properties['CIParameters']
    $ciParameters = $ciParametersProperty ? $ciParametersProperty.Value : $null
    $matrixConfigsProperty = $ciParameters ? $ciParameters.PSObject.Properties['CIMatrixConfigs'] : $null
    $matrixConfigs = $matrixConfigsProperty ? $matrixConfigsProperty.Value : $null
    $key = $null -eq $matrixConfigs ? '<default>' :
      ($matrixConfigs | ConvertTo-Json -Depth 100 -Compress)
    if (!$groups.ContainsKey($key)) {
      $groups[$key] = [System.Collections.Generic.List[object]]::new()
    }
    $groups[$key].Add($package)
  }

  $groupIndex = 1
  foreach ($key in @($groups.Keys | Sort-Object)) {
    Apply-LPTBatching -Packages $groups[$key].ToArray() -Weights $Weights -Target $Target `
      -DefaultWeight $DefaultWeight -Label "$Label matrix group $groupIndex/$($groups.Count)"
    $groupIndex++
  }
}

# Apply LPT batching to direct and indirect packages separately
if ($directPackages.Count -gt 0) {
  Apply-LPTBatchingByMatrixConfig -Packages $directPackages -Weights $weights `
    -Target $Target -DefaultWeight $DefaultWeight -Label "Direct"
}

if ($indirectPackages.Count -gt 0) {
  Apply-LPTBatchingByMatrixConfig -Packages $indirectPackages -Weights $weights `
    -Target $IndirectTarget -DefaultWeight $DefaultWeight -Label "Indirect"
}

# Verify
$remainingFiles = @(Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse)
$remaining = $remainingFiles.Count
$actualPackageNames = @(
  $remainingFiles |
    ForEach-Object { (Get-Content $_.FullName | ConvertFrom-Json).ArtifactName -split "," } |
    Sort-Object
)

$missingPackages = @($expectedPackageNames | Where-Object { $_ -notin $actualPackageNames })
$duplicatePackages = @(
  $actualPackageNames |
    Group-Object |
    Where-Object { $_.Count -ne 1 } |
    ForEach-Object { $_.Name }
)

if ($actualPackageNames.Count -ne $expectedPackageNames.Count -or
    $missingPackages.Count -gt 0 -or
    $duplicatePackages.Count -gt 0) {
  throw "Weighted batching verification failed. Missing: [$($missingPackages -join ', ')]. Duplicated: [$($duplicatePackages -join ', ')]."
}

Write-Host "Weighted batching complete. $remaining consolidated PackageInfo files remain."
