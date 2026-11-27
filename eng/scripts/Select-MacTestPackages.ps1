<#
.SYNOPSIS
Selects approximately one third of direct-package test weight for the PR macOS matrix.

.DESCRIPTION
Partitions direct packages with an applicable macOS matrix into up to three deterministic,
approximately balanced groups and selects one according to the PR number. Package metadata is copied to
an independent directory; the Linux and Windows matrix inputs are not changed. Packages
with an explicitly non-batched matrix are retained because those jobs are not scoped to
individual packages. When weights are unavailable, each package has equal weight.

Selected packages with identical matrix configurations are batched together so that
consolidation cannot discard a selected package's different matrix configuration.
#>
[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$PackageInfoFolder,
  [Parameter(Mandatory = $true)][string]$OutputFolder,
  [Parameter(Mandatory = $true)][string]$WeightsFile,
  [Parameter()][string]$DefaultMatrixFile,
  [Parameter()][array]$MatrixFilters = @(),
  [Parameter()][array]$MatrixReplace = @(),
  [Parameter()][string]$DisplayNameFilter = '.*',
  [Parameter()][long]$SelectionSeed = 0,
  [Parameter()][int]$Target = 240
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'
if ($Target -le 0) { throw 'Target must be greater than zero.' }
if (Test-Path $OutputFolder) { throw "Output folder already exists: $OutputFolder" }
New-Item $OutputFolder -ItemType Directory -Force | Out-Null

$weights = @{}
$useWeights = $false
if (Test-Path $WeightsFile) {
  try {
    $weightData = Get-Content $WeightsFile -Raw | ConvertFrom-Json -AsHashtable
    foreach ($name in $weightData.Keys) {
      $weights[$name] = [math]::Max(1, [int]$weightData[$name])
    }
    $useWeights = $weights.Count -gt 0
  }
  catch {
    Write-Warning "Unable to read test weights; selecting macOS packages by count: $($_.Exception.Message)"
    $weights = @{}
  }
}

$defaultConfigs = if ($DefaultMatrixFile) {
  @(Get-Content $DefaultMatrixFile -Raw | ConvertFrom-Json -AsHashtable)
} else { @() }
$eligibility = [System.Collections.Generic.Dictionary[string, bool]]::new([StringComparer]::Ordinal)
if ($DefaultMatrixFile) {
  . (Join-Path $PSScriptRoot '..' 'common' 'scripts' 'job-matrix' 'job-matrix-functions.ps1')
}

$packages = @(
  Get-ChildItem $PackageInfoFolder -Filter '*.json' -File -Recurse | ForEach-Object {
    $json = Get-Content $_.FullName -Raw | ConvertFrom-Json -AsHashtable
    if ($json.IncludedForValidation -eq $false) {
      $configs = if ($json['CIParameters']) { $json['CIParameters']['CIMatrixConfigs'] } else { $null }
      $effectiveConfigs = if ($configs) { $configs } else { $defaultConfigs }
      $keepNonBatched = @($effectiveConfigs | Where-Object { $_ -and $_.ContainsKey('PRBatching') -and $_.PRBatching -eq $false }).Count -gt 0
      $hasMacMatrix = -not $DefaultMatrixFile
      if ($DefaultMatrixFile) {
        foreach ($config in $effectiveConfigs) {
          $key = ConvertTo-Json -InputObject $config -Depth 100 -Compress
          if (-not $eligibility.ContainsKey($key)) {
            $nonSparse = if ($config['NonSparseParameters']) { $config['NonSparseParameters'] } else { @() }
            $matrix = GenerateMatrixForConfig -ConfigPath $config['Path'] -Selection $config['Selection'] `
              -DisplayNameFilter $DisplayNameFilter `
              -Filters ($MatrixFilters + @('container=^$', 'SupportedClouds=^$|public', 'Pool=.*MacPool$')) `
              -Replace $MatrixReplace -NonSparseParameters $nonSparse
            $eligibility[$key] = [bool]$matrix
          }
          if ($eligibility[$key]) { $hasMacMatrix = $true }
        }
      }
      if (-not $hasMacMatrix) {
        Write-Host "Skipping $($json.ArtifactName): no applicable macOS matrix."
        return
      }
      [PSCustomObject]@{
        File = $_
        Name = [string]$json.ArtifactName
        Weight = if ($weights.ContainsKey($json.ArtifactName)) { $weights[$json.ArtifactName] } else { 1 }
        ConfigKey = if ($configs) { ConvertTo-Json -InputObject $configs -Depth 100 -Compress } else { '' }
        KeepNonBatched = $keepNonBatched
      }
    }
  }
)
if ($packages.Count -eq 0) {
  Write-Host 'No direct packages with an applicable macOS matrix.'
  return
}

$groupCount = [math]::Min(3, $packages.Count)
$groups = @(for ($i = 0; $i -lt $groupCount; $i++) {
  [PSCustomObject]@{ Index = $i; Weight = 0; Items = [System.Collections.ArrayList]::new() }
})
foreach ($package in ($packages | Sort-Object @{ Expression = 'Weight'; Descending = $true }, Name)) {
  $group = $groups | Sort-Object Weight, Index | Select-Object -First 1
  [void]$group.Items.Add($package)
  $group.Weight += $package.Weight
}
$index = [int](($SelectionSeed % $groupCount + $groupCount) % $groupCount)
$chosen = @($groups[$index].Items)
# PRBatching:false matrix entries are emitted without package scoping. Do not remove
# them merely because the package used to carry the configuration was not selected.
$selectedNames = @{}
foreach ($package in $chosen) { $selectedNames[$package.Name] = $true }
foreach ($package in $packages | Where-Object { $_.KeepNonBatched }) {
  if (-not $selectedNames.ContainsKey($package.Name)) {
    $chosen += $package
    $selectedNames[$package.Name] = $true
  }
}
$totalWeight = ($packages | Measure-Object Weight -Sum).Sum
$selectedWeight = ($chosen | Measure-Object Weight -Sum).Sum
Write-Host "macOS selection: $($chosen.Count)/$($packages.Count) direct packages, weight $selectedWeight/$totalWeight, group $($index + 1)/$groupCount ($(if ($useWeights) { 'runtime weights' } else { 'package counts' }))."
foreach ($package in $chosen | Sort-Object Name) { Write-Host "  $($package.Name) (weight $($package.Weight))" }

# Apply-WeightedBatching retains a representative file's metadata, so never merge
# packages with different per-package matrix configurations.
$configGroups = @($chosen | Group-Object ConfigKey -CaseSensitive)
for ($i = 0; $i -lt $configGroups.Count; $i++) {
  $destination = Join-Path $OutputFolder "config-$i"
  New-Item $destination -ItemType Directory -Force | Out-Null
  $fileIndex = 0
  foreach ($package in $configGroups[$i].Group) {
    Copy-Item $package.File.FullName -Destination (Join-Path $destination "$fileIndex.json")
    $fileIndex++
  }
  if ($useWeights) {
    & (Join-Path $PSScriptRoot 'Apply-WeightedBatching.ps1') `
      -PackageInfoFolder $destination -WeightsFile $WeightsFile -Target $Target
  }
}
