#!/usr/bin/env pwsh

<#
.SYNOPSIS
Compares an unchanged service.proj command in full and directory-level sparse clones.

.DESCRIPTION
Generates a sparse-checkout manifest from the exact service.proj entry projects and
their transitive ProjectReference graph, creates disposable local clones, and runs
the same command in each clone. Local clones validate correctness and working-tree
materialization only; they do not measure network transfer.

.EXAMPLE
./eng/scripts/Validate-SparseCheckout.ps1 -ServiceDirectory advisor -Target Pack `
  -MSBuildArguments /p:IncludeTests=false,/p:Configuration=Release
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $ServiceDirectory,

  [ValidateSet('Build', 'Pack', 'Test', 'GenerateCode')]
  [string] $Target = 'Build',

  [string[]] $MSBuildArguments = @(),

  [string] $OutputDirectory,

  [switch] $KeepClones
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..')).Path
$workingTreeChanges = @(& git -C $repoRoot status --porcelain)
if ($LASTEXITCODE -ne 0) {
  throw 'Unable to inspect the source working tree.'
}
if ($workingTreeChanges.Count -ne 0) {
  throw 'The source working tree must be clean so the manifest and comparison clones use identical content.'
}

if (-not $OutputDirectory) {
  $OutputDirectory = Join-Path ([System.IO.Path]::GetTempPath()) "azsdk-sparse-checkout-$ServiceDirectory-$([guid]::NewGuid().ToString('N'))"
}
$OutputDirectory = [System.IO.Path]::GetFullPath($OutputDirectory)
if ((Test-Path -LiteralPath $OutputDirectory) -and
    @(Get-ChildItem -LiteralPath $OutputDirectory -Force).Count -ne 0) {
  throw "Output directory '$OutputDirectory' must be empty."
}
$manifestPath = Join-Path $OutputDirectory 'manifest.txt'
$projectGraphPath = "$manifestPath.projects"
$reportPath = Join-Path $OutputDirectory 'report.json'
$cloneRoot = Join-Path $OutputDirectory 'clones'

$null = New-Item -ItemType Directory -Path $OutputDirectory -Force

$commonArguments = @(
  'eng/service.proj'
  "/p:ServiceDirectory=$ServiceDirectory"
) + $MSBuildArguments

$manifestArguments = @(
  'msbuild'
  'eng/service.proj'
  '/t:GenerateSparseCheckoutManifest'
  "/p:ServiceDirectory=$ServiceDirectory"
  "/p:SparseCheckoutManifestPath=$manifestPath"
) + $MSBuildArguments

Write-Host "Generating sparse-checkout manifest for sdk/$ServiceDirectory"
& dotnet @manifestArguments
if ($LASTEXITCODE -ne 0) {
  throw "Manifest generation failed with exit code $LASTEXITCODE."
}

$manifest = @(Get-Content -LiteralPath $manifestPath | Where-Object { $_ })
if ($manifest.Count -eq 0) {
  throw 'Manifest generation produced no directory roots.'
}

$commit = (& git -C $repoRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0) {
  throw 'Unable to resolve the source commit.'
}

function Get-TreeMetrics([string] $Path) {
  $materialized = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
  foreach ($line in (& git -C $Path ls-files -v)) {
    if ($line -notmatch '^S (.+)$') {
      $null = $materialized.Add($line.Substring(2))
    }
  }
  if ($LASTEXITCODE -ne 0) {
    throw "Unable to list files in '$Path'."
  }

  [long] $bytes = 0
  foreach ($line in (& git -C $Path ls-tree -r -l HEAD)) {
    if ($line -match '^\d+ blob [0-9a-f]+\s+(\d+)\t(.+)$' -and $materialized.Contains($Matches[2])) {
      $bytes += [long] $Matches[1]
    }
  }
  if ($LASTEXITCODE -ne 0) {
    throw "Unable to measure files in '$Path'."
  }

  return [ordered]@{
    FileCount = $materialized.Count
    FileBytes = $bytes
  }
}

function Invoke-Comparison([string] $Mode) {
  $clonePath = Join-Path $cloneRoot $Mode.ToLowerInvariant()

  $cloneWatch = [System.Diagnostics.Stopwatch]::StartNew()
  & git clone --quiet --no-checkout --shared $repoRoot $clonePath
  if ($LASTEXITCODE -ne 0) {
    throw "Failed to create $Mode clone."
  }

  if ($Mode -eq 'Sparse') {
    & git -C $clonePath sparse-checkout init --cone
    if ($LASTEXITCODE -ne 0) {
      throw 'Failed to initialize sparse checkout.'
    }
    $checkoutRoots = @('eng', '.config', 'common') + $manifest
    & git -C $clonePath sparse-checkout set --cone @checkoutRoots
    if ($LASTEXITCODE -ne 0) {
      throw 'Failed to apply sparse-checkout roots.'
    }
  }

  & git -C $clonePath -c advice.detachedHead=false checkout --quiet --detach $commit
  if ($LASTEXITCODE -ne 0) {
    throw "Failed to checkout $commit in $Mode clone."
  }
  $cloneWatch.Stop()
  $checkoutTree = Get-TreeMetrics -Path $clonePath

  $commandArguments = switch ($Target) {
    'Build' { @('build') + $commonArguments }
    'Pack' { @('pack') + $commonArguments }
    'Test' { @('test') + $commonArguments }
    'GenerateCode' { @('msbuild') + $commonArguments + @('/t:GenerateCode') }
  }

  Write-Host "Running in $Mode clone: dotnet $($commandArguments -join ' ')"
  $commandWatch = [System.Diagnostics.Stopwatch]::StartNew()
  Push-Location $clonePath
  try {
    & dotnet @commandArguments
    $exitCode = $LASTEXITCODE
  }
  finally {
    Pop-Location
  }
  $commandWatch.Stop()

  $artifactPath = Join-Path $clonePath 'artifacts'
  $packages = if (Test-Path -LiteralPath $artifactPath) {
    @(Get-ChildItem -LiteralPath $artifactPath -Filter '*.nupkg' -File -Recurse -ErrorAction SilentlyContinue |
      ForEach-Object { [System.IO.Path]::GetRelativePath($clonePath, $_.FullName).Replace('\', '/') } |
      Sort-Object)
  }
  else {
    @()
  }

  return [ordered]@{
    Mode = $Mode
    CloneSeconds = [math]::Round($cloneWatch.Elapsed.TotalSeconds, 3)
    CommandSeconds = [math]::Round($commandWatch.Elapsed.TotalSeconds, 3)
    ExitCode = $exitCode
    CheckoutTree = $checkoutTree
    FinalTree = Get-TreeMetrics -Path $clonePath
    Packages = $packages
  }
}

$results = @()
$createdCloneRoot = $false
try {
  $null = New-Item -ItemType Directory -Path $cloneRoot
  $createdCloneRoot = $true
  $results += Invoke-Comparison -Mode Full
  $results += Invoke-Comparison -Mode Sparse
}
finally {
  $report = [ordered]@{
    Commit = $commit
    ServiceDirectory = $ServiceDirectory
    Target = $Target
    MSBuildArguments = $MSBuildArguments
    Manifest = $manifest
    ProjectGraph = @(Get-Content -LiteralPath $projectGraphPath)
    Results = $results
    Note = 'Local shared clones validate correctness and materialized working-tree size, not network transfer.'
  }
  $report | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $reportPath
  Write-Host "Comparison report: $reportPath"

  if (-not $KeepClones -and $createdCloneRoot -and (Test-Path -LiteralPath $cloneRoot)) {
    Remove-Item -LiteralPath $cloneRoot -Recurse -Force
  }
}

if ($results.Count -ne 2 -or ($results | Where-Object ExitCode -ne 0)) {
  throw 'One or more comparison commands failed. See the report for details.'
}

if (Compare-Object $results[0].Packages $results[1].Packages) {
  throw 'Full and sparse clones produced different package sets.'
}
