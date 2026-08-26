#!/usr/bin/env pwsh

<#
.SYNOPSIS
Extracts the sparse-checkout closure for one PR test batch from a prebuilt checkout graph.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $GraphPath,

  [Parameter(Mandatory = $true)]
  [AllowEmptyString()]
  [string] $ArtifactNames,

  [Parameter(Mandatory = $true)]
  [string] $ExpectedSourceCommit
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$graph = Get-Content -LiteralPath $GraphPath -Raw | ConvertFrom-Json -AsHashtable
$artifacts = @($ArtifactNames -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_ })
if ($graph.schemaVersion -ne 1 -or -not $graph.isComplete -or $artifacts.Count -eq 0) {
  Write-Warning "The sparse checkout graph is unavailable or incomplete: $($graph.failureReason)"
  return $null
}
if (-not ([string] $graph.sourceCommit).Equals($ExpectedSourceCommit, [System.StringComparison]::OrdinalIgnoreCase)) {
  Write-Warning "Sparse checkout graph commit '$($graph.sourceCommit)' does not match job commit '$ExpectedSourceCommit'."
  return $null
}
if (-not $graph.ContainsKey('alwaysIncludedPaths') -or -not $graph.ContainsKey('artifacts') -or
    -not $graph.ContainsKey('adjacency') -or -not $graph.ContainsKey('paths')) {
  Write-Warning 'The sparse checkout graph is missing required indexes.'
  return $null
}

$visited = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
$queue = [System.Collections.Generic.Queue[string]]::new()
foreach ($artifact in $artifacts) {
  if (-not $graph.artifacts.ContainsKey($artifact) -or $null -eq $graph.artifacts[$artifact] -or
      @($graph.artifacts[$artifact]).Count -eq 0) {
    Write-Warning "Artifact '$artifact' has no complete MSBuild seeds; using a full checkout."
    return $null
  }
  foreach ($seed in @($graph.artifacts[$artifact])) {
    if ($visited.Add([string] $seed)) {
      $queue.Enqueue([string] $seed)
    }
  }
}

while ($queue.Count -gt 0) {
  $current = $queue.Dequeue()
  if (-not $graph.adjacency.ContainsKey($current)) {
    continue
  }
  foreach ($next in @($graph.adjacency[$current])) {
    if ($visited.Add([string] $next)) {
      $queue.Enqueue([string] $next)
    }
  }
}

$alwaysIncluded = [System.Collections.Generic.List[string]]::new()
$dynamicPaths = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::Ordinal)
$seen = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
foreach ($path in @($graph.alwaysIncludedPaths)) {
  if ($seen.Add([string] $path)) {
    $alwaysIncluded.Add([string] $path)
  }
}
foreach ($configuration in $visited) {
  if (-not $graph.paths.ContainsKey($configuration)) {
    continue
  }
  foreach ($path in @($graph.paths[$configuration])) {
    if ($seen.Add([string] $path)) {
      $null = $dynamicPaths.Add([string] $path)
    }
  }
}

$result = @($alwaysIncluded) + @($dynamicPaths)
if ($result.Count -eq 0) {
  Write-Warning 'The sparse checkout graph produced no paths; using a full checkout.'
  return $null
}

Write-Host "Sparse checkout closure: artifacts=$($artifacts.Count), reachable=$($visited.Count), paths=$($result.Count)"
return $result
