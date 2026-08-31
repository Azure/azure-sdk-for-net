#!/usr/bin/env pwsh

<#
.SYNOPSIS
Builds the reusable sparse-checkout projection published by PR matrix generation.

.DESCRIPTION
Reuses a compatible canonical repository graph when available, otherwise generates a fresh graph.
Any graph or projection failure produces an explicit incomplete checkout artifact so downstream test
jobs retain their full-checkout fallback. The returned object contains status and failure details;
the pipeline caller owns Azure DevOps-specific logging.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $RepoRoot,

  [Parameter(Mandatory = $true)]
  [string] $PackageInfoDirectory,

  [Parameter(Mandatory = $true)]
  [string] $OutputDirectory,

  [Parameter(Mandatory = $true)]
  [string] $SourceCommit
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$graphPath = Join-Path $RepoRoot 'artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json'
$checkoutGraphPath = Join-Path $OutputDirectory 'checkout-graph.json'
$taskProject = Join-Path $RepoRoot 'eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj'
$serviceProject = Join-Path $RepoRoot 'eng/service.proj'
$resolverPath = Join-Path $RepoRoot 'eng/scripts/Resolve-SparseCheckoutPaths.ps1'
$repositoryGraphResult = ''
$checkoutGraphResult = ''
$reuseFailureReason = ''
$failureReason = ''

New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

function New-SparseCheckoutProjection {
  $arguments = @(
    'msbuild', '/nologo', '/nr:false', '/v:minimal', '/t:CreateSparseCheckoutGraph',
    $taskProject,
    "/p:SparseCheckoutPackageInfoDirectory=$PackageInfoDirectory",
    "/p:SparseCheckoutRepoRoot=$RepoRoot",
    "/p:SparseCheckoutSourceGraphPath=$graphPath",
    "/p:SparseCheckoutOutputPath=$checkoutGraphPath",
    "/p:SparseCheckoutSourceCommit=$SourceCommit")
  & dotnet @arguments | Out-Host
  if ($LASTEXITCODE -ne 0) {
    throw "Sparse checkout projection failed with exit code $LASTEXITCODE."
  }
}

try {
  # Language-Settings.ps1 normally leaves a canonical graph at the service.proj default path.
  # Validate it through projection before reuse because provenance and input policy also matter.
  $reusedGraph = $false
  if (Test-Path -LiteralPath $graphPath) {
    try {
      New-SparseCheckoutProjection
      $reusedGraph = $true
      $repositoryGraphResult = 'reused'
    }
    catch {
      $reuseFailureReason = $_.Exception.Message -replace "`r?`n", ' '
      Remove-Item -LiteralPath $checkoutGraphPath -Force -ErrorAction SilentlyContinue
    }
  }

  if (!$reusedGraph) {
    # ForceDirect and other passes that skip dependency selection still need one reusable graph.
    $arguments = @(
      'msbuild', '/m', '/nr:false', '/nologo', '/tl:off',
      '/t:GenerateRepositoryProjectGraphWithProjectGraph', $serviceProject,
      "/p:RepositoryProjectGraphReaderPath=$graphPath",
      '/p:SkipServiceProjectImports=true',
      '/p:IncludeRepositoryProjectGraphInputCheckoutRoots=true',
      '/p:IncludeSrc=false', '/p:IncludeStress=false', '/p:IncludeSamples=false', '/p:IncludePerf=false',
      '/p:RunApiCompat=false', '/p:InheritDocEnabled=false', '/p:BuildProjectReferences=false')
    & dotnet @arguments | Out-Host
    if ($LASTEXITCODE -ne 0) {
      throw "RepositoryProjectGraph generation failed with exit code $LASTEXITCODE."
    }

    New-SparseCheckoutProjection
    $repositoryGraphResult = 'generated'
  }
  $checkoutGraphResult = 'available'
}
catch {
  # Sparse checkout is only an optimization. Publish an incomplete artifact so a later job can
  # distinguish an intentional full checkout from missing or partially generated graph data.
  $failureReason = $_.Exception.Message -replace "`r?`n", ' '
  [ordered]@{
    schemaVersion = 1
    sourceCommit = $SourceCommit
    isComplete = $false
    failureReason = $failureReason
    alwaysIncludedPaths = @()
    artifacts = @{}
    adjacency = @{}
    paths = @{}
    diagnostics = @{}
  } | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $checkoutGraphPath -Encoding utf8NoBOM
  $checkoutGraphResult = 'fallback'
}

Copy-Item -LiteralPath $resolverPath -Destination (Join-Path $OutputDirectory 'Resolve-SparseCheckoutPaths.ps1') -Force

return [pscustomobject]@{
  RepositoryGraphResult = $repositoryGraphResult
  CheckoutGraphResult = $checkoutGraphResult
  ReuseFailureReason = $reuseFailureReason
  FailureReason = $failureReason
}
