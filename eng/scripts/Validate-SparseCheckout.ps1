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

.EXAMPLE
./eng/scripts/Validate-SparseCheckout.ps1 -ServiceDirectory advisor -Target Test `
  -CommandArguments --framework,net10.0,--filter,TestCategory!=Live
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $ServiceDirectory,

  [ValidateSet('Build', 'Pack', 'Test', 'GenerateCode')]
  [string] $Target = 'Build',

  [string[]] $MSBuildArguments = @(),

  [string[]] $CommandArguments = @(),

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
$activeClonePath = Join-Path $cloneRoot 'work'

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
  $clonePath = $activeClonePath

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
    'Build' { @('build') + $commonArguments + $CommandArguments }
    'Pack' { @('pack') + $commonArguments + $CommandArguments }
    'Test' { @('test') + $commonArguments + $CommandArguments }
    'GenerateCode' { @('msbuild') + $commonArguments + @('/t:GenerateCode') + $CommandArguments }
  }

  Write-Host "Running in $Mode clone: dotnet $($commandArguments -join ' ')"
  $commandWatch = [System.Diagnostics.Stopwatch]::StartNew()
  Push-Location $clonePath
  try {
    & dotnet @commandArguments | Out-Host
    $exitCode = $LASTEXITCODE
  }
  finally {
    Pop-Location
  }
  $commandWatch.Stop()

  $artifactPath = Join-Path $clonePath 'artifacts'
  $packages = if (Test-Path -LiteralPath $artifactPath) {
    @(Get-ChildItem -LiteralPath $artifactPath -Filter '*.nupkg' -File -Recurse -ErrorAction SilentlyContinue |
      ForEach-Object {
        $relativePath = [System.IO.Path]::GetRelativePath($clonePath, $_.FullName).Replace('\', '/')
        $archive = [System.IO.Compression.ZipFile]::OpenRead($_.FullName)
        try {
          $entries = @($archive.Entries | Sort-Object FullName | ForEach-Object {
            $stream = $_.Open()
            try {
              $hash = [System.Security.Cryptography.SHA256]::HashData($stream)
            }
            finally {
              $stream.Dispose()
            }
            "$($_.FullName)|$($_.Length)|$([Convert]::ToHexString($hash).ToLowerInvariant())"
          })
        }
        finally {
          $archive.Dispose()
        }
        [ordered]@{
          Path = $relativePath
          ContentSha256 = [Convert]::ToHexString(
            [System.Security.Cryptography.SHA256]::HashData(
              [System.Text.Encoding]::UTF8.GetBytes($entries -join "`n"))).ToLowerInvariant()
        }
      } |
      Sort-Object Path)
  }
  else {
    @()
  }

  $testSummary = $null
  if ($Target -eq 'Test') {
    $testResultFiles = @(Get-ChildItem -LiteralPath (Join-Path $clonePath "sdk/$ServiceDirectory") `
      -Filter '*.trx' -File -Recurse -ErrorAction SilentlyContinue)
    $testSummary = [ordered]@{
      Files = $testResultFiles.Count
      Total = 0
      Executed = 0
      Passed = 0
      Failed = 0
      NotExecuted = 0
    }
    foreach ($testResultFile in $testResultFiles) {
      [xml] $testResult = Get-Content -LiteralPath $testResultFile.FullName -Raw
      $counters = $testResult.TestRun.ResultSummary.Counters
      foreach ($name in @('Total', 'Executed', 'Passed', 'Failed', 'NotExecuted')) {
        $value = $counters.GetAttribute($name.ToLowerInvariant())
        if ($value) {
          $testSummary[$name] += [int] $value
        }
      }
    }
    if ($testResultFiles.Count -eq 0) {
      throw "Test command in $Mode clone did not produce a TRX result file. Pass '--logger trx' through CommandArguments."
    }
  }

  $gitChanges = @(& git -C $clonePath status --porcelain)
  if ($LASTEXITCODE -ne 0) {
    throw "Unable to inspect generated changes in '$clonePath'."
  }
  $gitDiff = (& git -C $clonePath --no-pager diff --binary --no-ext-diff) -join "`n"
  if ($LASTEXITCODE -ne 0) {
    throw "Unable to read generated changes in '$clonePath'."
  }
  $untrackedHashes = @($gitChanges | Where-Object { $_ -like '?? *' } | ForEach-Object {
    $relativePath = $_.Substring(3)
    $fullPath = Join-Path $clonePath $relativePath
    if (Test-Path -LiteralPath $fullPath -PathType Leaf) {
      "$relativePath|$([Convert]::ToHexString([System.Security.Cryptography.SHA256]::HashData(
        [System.IO.File]::ReadAllBytes($fullPath))).ToLowerInvariant())"
    }
  } | Sort-Object)
  $comparisonDiff = $gitDiff + "`n" + ($untrackedHashes -join "`n")
  $gitDiffHash = [Convert]::ToHexString(
    [System.Security.Cryptography.SHA256]::HashData(
      [System.Text.Encoding]::UTF8.GetBytes($comparisonDiff))).ToLowerInvariant()

  return [ordered]@{
    Mode = $Mode
    CloneSeconds = [math]::Round($cloneWatch.Elapsed.TotalSeconds, 3)
    CommandSeconds = [math]::Round($commandWatch.Elapsed.TotalSeconds, 3)
    ExitCode = $exitCode
    CheckoutTree = $checkoutTree
    FinalTree = Get-TreeMetrics -Path $clonePath
    Packages = $packages
    Tests = $testSummary
    GitChanges = $gitChanges
    GitDiffSha256 = $gitDiffHash
  }
}

$results = @()
$createdCloneRoot = $false
try {
  $null = New-Item -ItemType Directory -Path $cloneRoot
  $createdCloneRoot = $true
  foreach ($mode in @('Full', 'Sparse')) {
    $results += Invoke-Comparison -Mode $mode
    if ($KeepClones) {
      Move-Item -LiteralPath $activeClonePath -Destination (Join-Path $cloneRoot $mode.ToLowerInvariant())
    }
    else {
      Remove-Item -LiteralPath $activeClonePath -Recurse -Force
    }
  }
}
finally {
  $report = [ordered]@{
    Commit = $commit
    ServiceDirectory = $ServiceDirectory
    Target = $Target
    MSBuildArguments = $MSBuildArguments
    CommandArguments = $CommandArguments
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

if ($Target -eq 'Pack' -and
    ($results[0].Packages | ConvertTo-Json -Compress) -ne
      ($results[1].Packages | ConvertTo-Json -Compress)) {
  throw 'Full and sparse clones produced different package paths or contents.'
}
if ($Target -eq 'Test' -and
    ($results[0].Tests | ConvertTo-Json -Compress) -ne ($results[1].Tests | ConvertTo-Json -Compress)) {
  throw 'Full and sparse clones produced different test counts.'
}
if ($Target -eq 'GenerateCode' -and
    (($results[0].GitChanges | ConvertTo-Json -Compress) -ne
       ($results[1].GitChanges | ConvertTo-Json -Compress) -or
     $results[0].GitDiffSha256 -ne $results[1].GitDiffSha256)) {
  throw 'Full and sparse clones produced different generated changes.'
}
