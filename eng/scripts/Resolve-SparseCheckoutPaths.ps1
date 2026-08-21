#!/usr/bin/env pwsh

<#
.SYNOPSIS
Resolves the checkout-path union for one PR test batch.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $MapPath,

  [Parameter(Mandatory = $true)]
  [AllowEmptyString()]
  [string] $ArtifactNames
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$map = Get-Content -LiteralPath $MapPath -Raw | ConvertFrom-Json -AsHashtable
$alwaysIncludedPathsKey = '$alwaysIncludedPaths'
$artifacts = @($ArtifactNames -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_ })
if ($artifacts.Count -eq 0 -or -not $map.ContainsKey($alwaysIncludedPathsKey)) {
  Write-Warning 'The sparse checkout map or artifact batch is incomplete; using a full checkout.'
  return $null
}

$paths = [System.Collections.Generic.List[string]]::new()
$seen = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
foreach ($path in @($map[$alwaysIncludedPathsKey])) {
  if ($seen.Add([string] $path)) {
    $paths.Add([string] $path)
  }
}

foreach ($artifact in $artifacts) {
  if (-not $map.ContainsKey($artifact) -or $null -eq $map[$artifact] -or @($map[$artifact]).Count -eq 0) {
    Write-Warning "Artifact '$artifact' has no complete MSBuild closure; using a full checkout."
    return $null
  }
  foreach ($path in @($map[$artifact])) {
    if ($seen.Add([string] $path)) {
      $paths.Add([string] $path)
    }
  }
}

return @($paths)
