#!/usr/bin/env pwsh

<#
.SYNOPSIS
Builds a compact, batch-queryable sparse-checkout projection from RepositoryProjectGraph.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $PackageInfoDirectory,

  [Parameter(Mandatory = $true)]
  [string] $RepoRoot,

  [Parameter(Mandatory = $true)]
  [string] $GraphPath,

  [Parameter(Mandatory = $true)]
  [string] $OutputPath,

  [Parameter(Mandatory = $true)]
  [string] $SourceCommit,

  [switch] $AllowDirtySource
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
$repositoryRoot = (Resolve-Path -LiteralPath $RepoRoot).Path
$packageInfoRoot = (Resolve-Path -LiteralPath $PackageInfoDirectory).Path
$graphFullPath = (Resolve-Path -LiteralPath $GraphPath).Path
$outputFullPath = [System.IO.Path]::GetFullPath($OutputPath)
$outputDirectory = Split-Path -Parent $outputFullPath

$alwaysIncludedPaths = @(
  '/*'
  '!/*/'
  '/eng'
  '/.config'
)

function New-StringSet {
  $set = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
  return ,$set
}

function Get-ConfigurationKey([string] $ProjectPath, [string] $TargetFramework) {
  return "configuration:$ProjectPath|$TargetFramework"
}

function Get-PackageKey([string] $PackageId) {
  return "package:$PackageId"
}

function Add-TableValue($Table, [string] $Key, [string] $Value) {
  if (-not $Table.ContainsKey($Key)) {
    $Table[$Key] = New-StringSet
  }
  $null = $Table[$Key].Add($Value)
}

function ConvertTo-SortedTable($Table) {
  $result = [ordered]@{}
  foreach ($key in @($Table.Keys | Sort-Object)) {
    $result[$key] = @($Table[$key] | Sort-Object)
  }
  return $result
}

function ConvertTo-CheckoutPath([string] $RelativePath) {
  $path = $RelativePath.Replace('\', '/').Trim('/')
  $segments = @($path -split '/')
  if ($segments.Count -lt 2 -or $segments[0] -eq '..') {
    return $null
  }
  if ($segments[0] -eq 'sdk') {
    if ($segments.Count -lt 3) {
      return $null
    }
    return "/sdk/$($segments[1])/*"
  }
  if ($alwaysIncludedRootDirectories.Contains($segments[0])) {
    return $null
  }
  $directory = [System.IO.Path]::GetDirectoryName($path).Replace('\', '/')
  if ([string]::IsNullOrWhiteSpace($directory) -or $directory -eq '.') {
    return $null
  }
  return "/$($directory.Trim('/'))/*"
}

$packageInfoFiles = @(Get-ChildItem -LiteralPath $packageInfoRoot -Filter '*.json' -File -Recurse | Sort-Object FullName)
if ($packageInfoFiles.Count -eq 0) {
  throw "No package information files were found under '$packageInfoRoot'."
}

$graph = Get-Content -LiteralPath $graphFullPath -Raw | ConvertFrom-Json -Depth 100
if ($graph.schemaVersion -ne 5) {
  throw "Unsupported repository project graph schema version '$($graph.schemaVersion)'. Expected 5."
}
if (-not $graph.diagnostics.isComplete) {
  throw "Repository project graph is incomplete. See diagnostics in '$graphFullPath'."
}
if ($graph.diagnostics.packageClosure.resolutionMode -ne 'nuget-restore-graph') {
  throw "Sparse checkout requires the NuGet restore graph, but '$($graph.diagnostics.packageClosure.resolutionMode)' was used."
}
$sourceCommitProperty = $graph.PSObject.Properties['sourceCommit']
$recordedSourceCommit = if ($null -eq $sourceCommitProperty) { '' } else { [string] $sourceCommitProperty.Value }
if (-not $recordedSourceCommit.Equals($SourceCommit, [System.StringComparison]::OrdinalIgnoreCase)) {
  throw "Repository project graph commit '$recordedSourceCommit' does not match requested sparse-checkout provenance '$SourceCommit'."
}

# A reusable graph must prove it evaluated the Debug inputs used by PR test dependency selection.
$generationProperty = $graph.diagnostics.PSObject.Properties['generation']
if ($null -eq $generationProperty -or $null -eq $generationProperty.Value) {
  throw 'Repository project graph does not describe its generation policy.'
}
$generation = $generationProperty.Value
if (-not $generation.includesInputs -or $generation.configuration -ne 'Debug') {
  throw 'Sparse checkout requires a Debug repository graph with evaluated inputs.'
}

$actualCommit = (& git -C $repositoryRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or -not $actualCommit) {
  throw "Unable to read the source commit under '$repositoryRoot'."
}
if (-not $actualCommit.Equals($SourceCommit, [System.StringComparison]::OrdinalIgnoreCase)) {
  throw "Source commit '$actualCommit' does not match requested sparse-checkout provenance '$SourceCommit'."
}
if (-not $AllowDirtySource) {
  & git -C $repositoryRoot diff --quiet --no-ext-diff HEAD --
  if ($LASTEXITCODE -ne 0) {
    throw "Repository '$repositoryRoot' has tracked changes, so its checkout graph cannot be attributed to commit '$actualCommit'."
  }
}

$alwaysIncludedRootDirectories = New-StringSet
foreach ($path in $alwaysIncludedPaths) {
  if ($path -match '^/([^/*]+)(?:/\*)?$' -and $Matches[1] -ne 'sdk') {
    $null = $alwaysIncludedRootDirectories.Add($Matches[1])
  }
}

# Build direct indexes once. Test jobs will traverse only the configurations for their batch.
$nodesByPath = @{}
$configurationsByPackageRoot = @{}
$configurationsByProjectPath = @{}
$configurationsByRepositoryPackage = @{}
$repositoryPackageKeys = [System.Collections.Generic.Dictionary[string, string]]::new(
  [System.StringComparer]::OrdinalIgnoreCase)
$allConfigurations = New-StringSet
$repositoryPackages = New-StringSet
$paths = @{}
foreach ($node in $graph.nodes) {
  $projectPath = [string] $node.projectPath
  if (-not $projectPath -or $nodesByPath.ContainsKey($projectPath)) {
    throw "Repository graph contains an empty or duplicate project path '$projectPath'."
  }
  $nodesByPath[$projectPath] = $node

  $checkoutPath = ConvertTo-CheckoutPath $projectPath
  $packageRoot = ([string] $node.packageRoot).Replace('\', '/').Trim('/')
  $configurationCount = 0
  foreach ($targetFramework in @($node.targetFrameworks)) {
    $configurationCount++
    $configuration = Get-ConfigurationKey $projectPath ([string] $targetFramework)
    $null = $allConfigurations.Add($configuration)
    Add-TableValue $configurationsByProjectPath $projectPath $configuration
    if ($packageRoot) {
      Add-TableValue $configurationsByPackageRoot $packageRoot $configuration
    }
    if ($checkoutPath) {
      Add-TableValue $paths $configuration $checkoutPath
    }
  }
  if ($configurationCount -eq 0) {
    throw "Project '$projectPath' has no target-framework configurations."
  }

  if ($node.isShippingLibrary -and $node.packageId) {
    $package = Get-PackageKey ([string] $node.packageId)
    if ($repositoryPackageKeys.ContainsKey($package)) {
      throw "Repository graph contains duplicate shipping package identity '$($node.packageId)'."
    }
    $repositoryPackageKeys[$package] = $package
    $null = $repositoryPackages.Add($package)
    foreach ($targetFramework in @($node.targetFrameworks)) {
      Add-TableValue $configurationsByRepositoryPackage $package `
        (Get-ConfigurationKey $projectPath ([string] $targetFramework))
    }
  }
}

$trackedFiles = New-StringSet
foreach ($trackedFile in (& git -C $repositoryRoot ls-files)) {
  $null = $trackedFiles.Add($trackedFile.Replace('\', '/'))
}
if ($LASTEXITCODE -ne 0) {
  throw "Unable to enumerate tracked files under '$repositoryRoot'."
}

# Attach each tracked evaluated input to the configurations that consume it. Repository package
# identities expand to their shipping configurations below, so paths have one canonical owner.
foreach ($graphInput in $graph.inputs) {
  $projectPath = [string] $graphInput.projectPath
  if (-not $nodesByPath.ContainsKey($projectPath)) {
    throw "Input '$($graphInput.path)' references unknown project '$projectPath'."
  }
  $inputPath = ([string] $graphInput.path).Replace('\', '/')
  if (-not $trackedFiles.Contains($inputPath)) {
    continue
  }
  $checkoutPath = ConvertTo-CheckoutPath $inputPath
  if (-not $checkoutPath) {
    continue
  }

  $inputFrameworkCount = 0
  foreach ($targetFramework in @($graphInput.targetFrameworks)) {
    $inputFrameworkCount++
    $configuration = Get-ConfigurationKey $projectPath ([string] $targetFramework)
    if (-not $allConfigurations.Contains($configuration)) {
      throw "Input '$inputPath' references unknown configuration '$configuration'."
    }
    Add-TableValue $paths $configuration $checkoutPath
  }
  if ($inputFrameworkCount -eq 0) {
    throw "Tracked input '$inputPath' has no target-framework configurations."
  }
}

$adjacency = @{}
foreach ($edge in $graph.configurationEdges) {
  $from = Get-ConfigurationKey ([string] $edge.fromProject) ([string] $edge.fromTargetFramework)
  if (-not $allConfigurations.Contains($from)) {
    throw "Configuration edge references unknown source '$from'."
  }

  switch ($edge.kind) {
    'ProjectReference' {
      $to = Get-ConfigurationKey ([string] $edge.to) ([string] $edge.toTargetFramework)
      if (-not $allConfigurations.Contains($to)) {
        throw "Project-reference edge references unknown destination '$to'."
      }
      Add-TableValue $adjacency $from $to
    }
    'PackageReference' {
      $referencedPackage = Get-PackageKey ([string] $edge.to)
      if ($repositoryPackages.Contains($referencedPackage)) {
        # JSON object keys are case-sensitive even though NuGet package identities are not.
        # Always point to the shipping project's canonical package key so casing differences
        # in evaluated PackageReference items cannot break traversal after serialization.
        Add-TableValue $adjacency $from $repositoryPackageKeys[$referencedPackage]
      }
    }
    default {
      throw "Unsupported configuration edge kind '$($edge.kind)'."
    }
  }
}

# Test matrices build both package-reference and project-reference modes. In project-reference
# mode, repository PackageReferences are converted to source ProjectReferences. Following a
# repository package into every configuration of its shipping project conservatively reconstructs
# that source closure from the one package-reference graph without another MSBuild evaluation.
foreach ($package in $configurationsByRepositoryPackage.Keys) {
  foreach ($configuration in $configurationsByRepositoryPackage[$package]) {
    Add-TableValue $adjacency $package $configuration
  }
}

# Package metadata supplies the artifact-to-configuration seeds. Duplicate ArtifactName entries
# conservatively union their directories; one malformed entry makes that artifact unavailable.
$artifactSeeds = @{}
$unavailableArtifacts = New-StringSet
foreach ($packageInfoFile in $packageInfoFiles) {
  $packageInfo = Get-Content -LiteralPath $packageInfoFile.FullName -Raw | ConvertFrom-Json
  $artifactName = [string] $packageInfo.ArtifactName
  $directoryPath = ([string] $packageInfo.DirectoryPath).Replace('\', '/').Trim('/')
  if ([string]::IsNullOrWhiteSpace($artifactName)) {
    Write-Warning "Package info '$($packageInfoFile.FullName)' has no ArtifactName and cannot be queried."
    continue
  }
  if ([string]::IsNullOrWhiteSpace($directoryPath) -or $directoryPath -notmatch '^sdk/[^/]+/[^/]+(?:/|$)') {
    Write-Warning "Artifact '$artifactName' has unsupported directory '$directoryPath'; it will use a full checkout."
    $null = $unavailableArtifacts.Add($artifactName)
    $null = $artifactSeeds.Remove($artifactName)
    continue
  }
  if ($unavailableArtifacts.Contains($artifactName)) {
    continue
  }

  $seeds = New-StringSet
  if ($configurationsByPackageRoot.ContainsKey($directoryPath)) {
    $null = $seeds.UnionWith($configurationsByPackageRoot[$directoryPath])
  }
  # service.proj tests every project below the package directory. Seed those projects even when
  # their inferred PackageRootDirectory is a nested tests/perf directory; otherwise dependencies
  # outside the package's SDK directory can be omitted from the checkout.
  $directoryPrefix = "$directoryPath/"
  foreach ($projectPath in $configurationsByProjectPath.Keys) {
    if ($projectPath.StartsWith($directoryPrefix, [System.StringComparison]::OrdinalIgnoreCase)) {
      $null = $seeds.UnionWith($configurationsByProjectPath[$projectPath])
    }
  }
  if ($seeds.Count -eq 0) {
    Write-Warning "Artifact '$artifactName' has no configurations in the repository graph; it will use a full checkout."
    $null = $unavailableArtifacts.Add($artifactName)
    $null = $artifactSeeds.Remove($artifactName)
    continue
  }
  foreach ($seed in $seeds) {
    Add-TableValue $artifactSeeds $artifactName $seed
  }
}

$artifacts = [ordered]@{}
$artifactNames = New-StringSet
foreach ($artifactName in $artifactSeeds.Keys) { $null = $artifactNames.Add($artifactName) }
foreach ($artifactName in $unavailableArtifacts) { $null = $artifactNames.Add($artifactName) }
foreach ($artifactName in @($artifactNames | Sort-Object)) {
  $artifacts[$artifactName] = if ($unavailableArtifacts.Contains($artifactName)) {
    $null
  } else {
    @($artifactSeeds[$artifactName] | Sort-Object)
  }
}

$projection = [ordered]@{
  schemaVersion = 1
  sourceCommit = $actualCommit
  isComplete = $true
  failureReason = ''
  alwaysIncludedPaths = $alwaysIncludedPaths
  artifacts = $artifacts
  adjacency = ConvertTo-SortedTable $adjacency
  paths = ConvertTo-SortedTable $paths
  diagnostics = [ordered]@{
    sourceGraphSchemaVersion = $graph.schemaVersion
    projectCount = $graph.nodes.Count
    configurationCount = $allConfigurations.Count
    configurationEdgeCount = $graph.configurationEdges.Count
    inputCount = $graph.inputs.Count
    artifactCount = $artifacts.Count
    unavailableArtifactCount = $unavailableArtifacts.Count
  }
}

$null = New-Item -ItemType Directory -Path $outputDirectory -Force
$temporaryPath = "$outputFullPath.$([Guid]::NewGuid().ToString('N')).tmp"
try {
  $projection | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $temporaryPath -Encoding utf8NoBOM
  Move-Item -LiteralPath $temporaryPath -Destination $outputFullPath -Force
} finally {
  Remove-Item -LiteralPath $temporaryPath -Force -ErrorAction SilentlyContinue
}

$stopwatch.Stop()
$outputBytes = (Get-Item -LiteralPath $outputFullPath).Length
Write-Host "Sparse checkout graph: projects=$($graph.nodes.Count), configurations=$($allConfigurations.Count), edges=$($graph.configurationEdges.Count), inputs=$($graph.inputs.Count), artifacts=$($artifacts.Count), unavailable=$($unavailableArtifacts.Count), bytes=$outputBytes, elapsed=$($stopwatch.Elapsed.TotalSeconds.ToString('F2'))s"
