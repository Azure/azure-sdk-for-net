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

After this script runs, set PRJobBatchSize to 1 so each consolidated file becomes its own job.

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

.PARAMETER BaseCost
Fixed per-package cost added to every package's weight before bin-packing, expressed in the
same units as the weights file (LOC). Job cost is not purely proportional to LOC:

  job_time = fixed_job_overhead + N_packages * fixed_package_overhead + f(LOC)

Each package in a batch pays its own codegen/restore, snippet update and API export cycle
regardless of size. With BaseCost 0, a batch of 20 small packages and a batch containing one
large package look identical to the packer even though the former does 20x the fixed work.
Setting BaseCost makes package count contribute to the weight, which matters more as
generation (the LOC-proportional term) gets faster. Default is 0, which preserves the
previous pure-LOC behavior.

.PARAMETER PackagesPerBatch
When greater than zero, creates ceil(package count / PackagesPerBatch) buckets and uses
the supplied weights only to balance them. This preserves an existing count-based job
policy while replacing input-order batching with cost-aware batching.

.PARAMETER DefaultMatrixConfigsFile
Optional JSON file containing the default matrix configuration list. Packages without an
explicit CIMatrixConfigs value inherit this list before grouping, matching Create-PrJobMatrix.
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$PackageInfoFolder,
  [Parameter(Mandatory = $true)][string]$WeightsFile,
  [Parameter()][int]$Target = 1800,
  [Parameter()][int]$IndirectTarget = 0,
  [Parameter()][int]$DefaultWeight = 1,
  [Parameter()][ValidateRange(0, [int]::MaxValue)][int]$BaseCost = 0,
  [Parameter()][ValidateRange(0, [int]::MaxValue)][int]$PackagesPerBatch = 0,
  [Parameter()][string]$DefaultMatrixConfigsFile
)

Set-StrictMode -Version 4

if ($IndirectTarget -le 0) { $IndirectTarget = $Target }

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

$defaultMatrixConfigs = @()
if ($DefaultMatrixConfigsFile) {
  if (!(Test-Path $DefaultMatrixConfigsFile)) {
    throw "Default matrix configs file '$DefaultMatrixConfigsFile' does not exist."
  }
  $defaultMatrixConfigs = @(Get-Content $DefaultMatrixConfigsFile -Raw | ConvertFrom-Json)
}

function Expand-MultiMatrixPackages {
  param(
    [object[]]$Packages,
    [object[]]$DefaultMatrixConfigs
  )

  $expanded = [System.Collections.Generic.List[object]]::new()
  foreach ($package in $Packages) {
    $ciParameters = $package.Json.PSObject.Properties["CIParameters"]
    $matrixConfigsProperty = if ($ciParameters) { $ciParameters.Value.PSObject.Properties["CIMatrixConfigs"] } else { $null }
    $matrixConfigs = @()
    if ($matrixConfigsProperty) {
      $matrixConfigs = @($matrixConfigsProperty.Value)
    }
    if ($matrixConfigs.Count -eq 0 -and $DefaultMatrixConfigs.Count -gt 0) {
      if (!$ciParameters) {
        $package.Json | Add-Member -MemberType NoteProperty -Name CIParameters -Value ([PSCustomObject]@{})
        $ciParameters = $package.Json.PSObject.Properties["CIParameters"]
      }
      $ciParameters.Value | Add-Member -MemberType NoteProperty -Name CIMatrixConfigs -Value $DefaultMatrixConfigs -Force
      $matrixConfigs = @($DefaultMatrixConfigs)
    }

    if ($matrixConfigs.Count -le 1) {
      $expanded.Add($package)
      continue
    }

    # Create-PrJobMatrix treats each entry in CIMatrixConfigs independently, so a package
    # configured for [A,B] participates in both the A and B batching groups. Expand the
    # matrix-generation copy here to preserve that behavior before weighted consolidation.
    Remove-Item $package.FilePath -Force
    for ($i = 0; $i -lt $matrixConfigs.Count; $i++) {
      $json = $package.Json | ConvertTo-Json -Depth 100 | ConvertFrom-Json
      $json.CIParameters.CIMatrixConfigs = @($matrixConfigs[$i])
      $expandedPath = Join-Path `
        (Split-Path $package.FilePath -Parent) `
        "$([IO.Path]::GetFileNameWithoutExtension($package.FileName)).matrix-$i.json"
      $json | ConvertTo-Json -Depth 100 | Set-Content $expandedPath -Encoding utf8
      $expanded.Add([PSCustomObject]@{
        FilePath = $expandedPath
        FileName = Split-Path $expandedPath -Leaf
        Json     = $json
      })
    }
  }

  return $expanded.ToArray()
}

$packages = @(Expand-MultiMatrixPackages -Packages $packages -DefaultMatrixConfigs $defaultMatrixConfigs)

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
    [int]$Target,
    [int]$DefaultWeight,
    [int]$BaseCost,
    [int]$PackagesPerBatch,
    [string]$Label
  )

  if ($Packages.Count -le 1) {
    Write-Host "  $Label`: Only $($Packages.Count) package(s), no batching needed."
    return
  }

  # Build weighted items. BaseCost models the fixed per-package cost that is paid regardless
  # of package size, so batches full of small packages are not treated as nearly free.
  $items = @(foreach ($pkg in $Packages) {
    $name = $pkg.Json.ArtifactName
    $weight = if ($Weights.ContainsKey($name)) { [int]$Weights[$name] } else { $DefaultWeight }
    [PSCustomObject]@{ Package = $pkg; Weight = $weight + $BaseCost; Name = $name }
  })

  # Sort by weight descending (LPT: largest first)
  $items = @($items | Sort-Object Weight -Descending)

  # Calculate number of buckets
  [long]$totalWeight = 0
  foreach ($i in $items) { $totalWeight += $i.Weight }
  $numBuckets = if ($PackagesPerBatch -gt 0) {
    [math]::Ceiling($Packages.Count / $PackagesPerBatch)
  }
  else {
    [math]::Ceiling($totalWeight / $Target)
  }
  $numBuckets = [math]::Max(1, $numBuckets)

  # Don't create more buckets than packages
  $numBuckets = [math]::Min($numBuckets, $Packages.Count)

  $sizing = if ($PackagesPerBatch -gt 0) { "${PackagesPerBatch} packages/batch" } else { "target ${Target}" }
  Write-Host "  $Label`: $($Packages.Count) packages, total weight ${totalWeight} (base cost ${BaseCost}/pkg), ${sizing} -> $numBuckets buckets"

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
    [int]$BaseCost,
    [int]$PackagesPerBatch,
    [string]$Label
  )

  $groups = @($Packages | Group-Object {
    $ciParameters = $_.Json.PSObject.Properties["CIParameters"]
    $matrixConfigs = if ($ciParameters) { $ciParameters.Value.PSObject.Properties["CIMatrixConfigs"] } else { $null }
    if ($matrixConfigs -and $matrixConfigs.Value) {
      $matrixConfigs.Value | ConvertTo-Json -Depth 100 -Compress
    }
    else {
      ""
    }
  })

  $groupNumber = 0
  foreach ($group in $groups) {
    $groupNumber++
    $groupLabel = if ($groups.Count -gt 1) { "$Label matrix group $groupNumber/$($groups.Count)" } else { $Label }
    Apply-LPTBatching -Packages @($group.Group) -Weights $Weights -Target $Target `
      -DefaultWeight $DefaultWeight -BaseCost $BaseCost -PackagesPerBatch $PackagesPerBatch -Label $groupLabel
  }
}

if ($directPackages.Count -gt 0) {
  Apply-LPTBatchingByMatrixConfig -Packages $directPackages -Weights $weights `
    -Target $Target -DefaultWeight $DefaultWeight -BaseCost $BaseCost `
    -PackagesPerBatch $PackagesPerBatch -Label "Direct"
}

if ($indirectPackages.Count -gt 0) {
  Apply-LPTBatchingByMatrixConfig -Packages $indirectPackages -Weights $weights `
    -Target $IndirectTarget -DefaultWeight $DefaultWeight -BaseCost $BaseCost `
    -PackagesPerBatch $PackagesPerBatch -Label "Indirect"
}

# Verify
$remaining = @(Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse).Count
Write-Host "Weighted batching complete. $remaining consolidated PackageInfo files remain."
