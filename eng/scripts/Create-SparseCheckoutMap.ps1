#!/usr/bin/env pwsh

<#
.SYNOPSIS
Builds artifact-to-checkout-path mappings from a RepositoryProjectGraph artifact.
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
  [string] $OutputPath
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

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
  '/.devcontainer'
  '/.github'
  '/.vscode'
  '/common'
  '/doc'
  '/samples'
  '/sdk/core/*'
  '/sdk/common/*'
  '/sdk/identity/*'
  '/sdk/resourcemanager/*'
  '/sdk/template/*'
  '/sdk/tools/*'
)

function Get-ConfigurationKey([string] $ProjectPath, [string] $TargetFramework) {
  return "$ProjectPath|$TargetFramework"
}

function Add-Edge($Table, [string] $From, [string] $To) {
  if (-not $Table.ContainsKey($From)) {
    $Table[$From] = [System.Collections.Generic.List[string]]::new()
  }
  if (-not $Table[$From].Contains($To)) {
    $Table[$From].Add($To)
  }
}

function Get-Reachable($Adjacency, [string[]] $Seeds) {
  $visited = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
  $queue = [System.Collections.Generic.Queue[string]]::new()
  foreach ($seed in $Seeds) {
    if ($seed -and $visited.Add($seed)) {
      $queue.Enqueue($seed)
    }
  }
  while ($queue.Count -gt 0) {
    $current = $queue.Dequeue()
    if ($Adjacency.ContainsKey($current)) {
      foreach ($next in $Adjacency[$current]) {
        if ($visited.Add($next)) {
          $queue.Enqueue($next)
        }
      }
    }
  }
  return ,$visited
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
  return if ([string]::IsNullOrWhiteSpace($directory) -or $directory -eq '.') {
    $null
  } else {
    "/$($directory.Trim('/'))/*"
  }
}

$map = [ordered]@{ '$alwaysIncludedPaths' = $alwaysIncludedPaths }
$alwaysIncludedRootDirectories = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
foreach ($path in $alwaysIncludedPaths) {
  if ($path -match '^/([^/*]+)(?:/\*)?$' -and $Matches[1] -ne 'sdk') {
    $null = $alwaysIncludedRootDirectories.Add($Matches[1])
  }
}

$packageInfoFiles = @(Get-ChildItem -LiteralPath $packageInfoRoot -Filter '*.json' -File -Recurse | Sort-Object FullName)
if ($packageInfoFiles.Count -eq 0) {
  throw "No package information files were found under '$packageInfoRoot'."
}

$graph = Get-Content -LiteralPath $graphFullPath -Raw | ConvertFrom-Json -Depth 100
if ($graph.schemaVersion -ne 3) {
  throw "Unsupported repository project graph schema version '$($graph.schemaVersion)'. Expected 3."
}
if (-not $graph.diagnostics.isComplete) {
  throw "Repository project graph is incomplete. See diagnostics in '$graphFullPath'."
}
if ($graph.diagnostics.packageClosure.resolutionMode -ne 'nuget-restore-graph') {
  throw "Sparse checkout requires the NuGet restore graph, but '$($graph.diagnostics.packageClosure.resolutionMode)' was used."
}

$nodesByPath = @{}
$configurationsByProject = @{}
$forward = @{}
foreach ($node in $graph.nodes) {
  $nodesByPath[$node.projectPath] = $node
  $configurationsByProject[$node.projectPath] = @($node.targetFrameworks | ForEach-Object {
    Get-ConfigurationKey $node.projectPath $_
  })
}
foreach ($edge in $graph.configurationEdges) {
  $from = Get-ConfigurationKey $edge.fromProject $edge.fromTargetFramework
  $to = if ($edge.kind -eq 'ProjectReference') {
    Get-ConfigurationKey $edge.to $edge.toTargetFramework
  } else {
    "package:$($edge.to)"
  }
  Add-Edge $forward $from $to
}

$trackedFiles = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
foreach ($trackedFile in (& git -C $repositoryRoot ls-files)) {
  $null = $trackedFiles.Add($trackedFile.Replace('\', '/'))
}
if ($LASTEXITCODE -ne 0) {
  throw "Unable to enumerate tracked files under '$repositoryRoot'."
}

foreach ($packageInfoFile in $packageInfoFiles) {
  $packageInfo = Get-Content -LiteralPath $packageInfoFile.FullName -Raw | ConvertFrom-Json
  $artifactName = [string] $packageInfo.ArtifactName
  $directoryPath = ([string] $packageInfo.DirectoryPath).Replace('\', '/').Trim('/')
  if ([string]::IsNullOrWhiteSpace($artifactName) -or [string]::IsNullOrWhiteSpace($directoryPath)) {
    Write-Warning "Package info '$($packageInfoFile.FullName)' is missing ArtifactName or DirectoryPath; it cannot be narrowed."
    continue
  }
  if ($map.Contains($artifactName)) {
    continue
  }
  if ($directoryPath -notmatch '^sdk/[^/]+/[^/]+(?:/|$)') {
    Write-Warning "Artifact '$artifactName' has unsupported directory '$directoryPath'; it will use a full checkout."
    $map[$artifactName] = $null
    continue
  }

  $rootPrefix = "$directoryPath/"
  $entryProjects = @($graph.nodes | Where-Object {
    $_.projectPath -eq $directoryPath -or $_.projectPath.StartsWith($rootPrefix, [System.StringComparison]::OrdinalIgnoreCase)
  } | Select-Object -ExpandProperty projectPath)
  if ($entryProjects.Count -eq 0) {
    Write-Warning "Artifact '$artifactName' has no configurations in the repository graph; it will use a full checkout."
    $map[$artifactName] = $null
    continue
  }

  $seeds = @($entryProjects | ForEach-Object { $configurationsByProject[$_] })
  $reachable = Get-Reachable $forward $seeds
  $checkoutPaths = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::Ordinal)

  foreach ($node in $graph.nodes) {
    $reached = @($configurationsByProject[$node.projectPath] | Where-Object { $reachable.Contains($_) }).Count -gt 0
    if (-not $reached -and $node.isShippingLibrary -and $node.packageId) {
      $reached = $reachable.Contains("package:$($node.packageId)")
    }
    if ($reached) {
      $checkoutPath = ConvertTo-CheckoutPath $node.projectPath
      if ($checkoutPath) {
        $null = $checkoutPaths.Add($checkoutPath)
      }
    }
  }

  foreach ($graphInput in $graph.inputs) {
    $node = $nodesByPath[$graphInput.projectPath]
    $reached = $node.isShippingLibrary -and $node.packageId -and $reachable.Contains("package:$($node.packageId)")
    if (-not $reached) {
      $reached = @($graphInput.targetFrameworks | Where-Object {
        $reachable.Contains((Get-ConfigurationKey $graphInput.projectPath $_))
      }).Count -gt 0
    }
    if (-not $reached -or -not $trackedFiles.Contains([string] $graphInput.path)) {
      continue
    }
    $checkoutPath = ConvertTo-CheckoutPath $graphInput.path
    if ($checkoutPath) {
      $null = $checkoutPaths.Add($checkoutPath)
    }
  }

  if ($checkoutPaths.Count -eq 0) {
    Write-Warning "Artifact '$artifactName' produced an empty closure; it will use a full checkout."
    $map[$artifactName] = $null
  } else {
    $map[$artifactName] = @($checkoutPaths)
  }
}

$null = New-Item -ItemType Directory -Path $outputDirectory -Force
$map | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $outputFullPath -Encoding utf8NoBOM
Write-Host "Sparse checkout map: $($graph.nodes.Count) projects, $($graph.configurationEdges.Count) configuration edges, $($packageInfoFiles.Count) artifacts"
