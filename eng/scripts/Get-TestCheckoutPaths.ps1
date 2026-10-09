#!/usr/bin/env pwsh

<#
.SYNOPSIS
Resolves the sparse-checkout paths for one test job, with a conservative full-checkout fallback.

.DESCRIPTION
Locates the published graph and resolver beneath GraphDirectory. The returned object contains the
selected paths, whether narrowing is safe, and any fallback reason. The pipeline caller owns Azure
DevOps-specific logging and variable assignment.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $GraphDirectory,

  [Parameter(Mandatory = $true)]
  [AllowEmptyString()]
  [string] $ArtifactNames,

  [Parameter(Mandatory = $true)]
  [string] $ExpectedSourceCommit
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$fallbackPaths = @('/*', '!SessionRecords', '/sdk/*/**/SessionRecords/*')
$resolver = Get-ChildItem -LiteralPath $GraphDirectory -Filter 'Resolve-SparseCheckoutPaths.ps1' `
  -File -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
$graph = Get-ChildItem -LiteralPath $GraphDirectory -Filter 'checkout-graph.json' `
  -File -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
$paths = @()
$failureReason = ''

if ($resolver -and $graph) {
  try {
    $resolverWarnings = @()
    $paths = @(& $resolver.FullName `
        -GraphPath $graph.FullName `
        -ArtifactNames $ArtifactNames `
        -ExpectedSourceCommit $ExpectedSourceCommit `
        -WarningAction SilentlyContinue `
        -WarningVariable resolverWarnings |
        Where-Object { $null -ne $_ -and -not [string]::IsNullOrWhiteSpace([string] $_) })
    if (!$paths) {
      $failureReason = if ($resolverWarnings.Count -gt 0) {
        @($resolverWarnings | ForEach-Object { $_.ToString() }) -join ' '
      } else {
        'The MSBuild checkout graph produced no paths.'
      }
    }
  }
  catch {
    $failureReason = "Unable to query the MSBuild checkout graph: $($_.Exception.Message)"
  }
}
else {
  $failureReason = 'The MSBuild checkout graph artifact is unavailable.'
}

$isNarrowed = $paths.Count -gt 0
if (!$isNarrowed) {
  $paths = $fallbackPaths
}

return [pscustomobject]@{
  Paths = @($paths)
  IsNarrowed = $isNarrowed
  FailureReason = $failureReason
}
