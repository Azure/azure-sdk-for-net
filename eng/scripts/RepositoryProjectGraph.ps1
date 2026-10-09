[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [ValidateSet('Build', 'Forward', 'Reverse')]
  [string] $Operation,

  [Parameter(Mandatory = $true)]
  [string] $GraphPath,

  [string] $RepoRoot,
  [string] $RecordsPath,
  [string] $PackageRecordsPath,
  [string] $OutputPath,
  [string] $Dependencies,
  [string] $RootProjects,
  [string] $RootProjectsPath,
  [string] $PackageRootsOnly = 'false'
)

Set-StrictMode -Version 3
$ErrorActionPreference = 'Stop'

function Normalize-AbsolutePath([string] $Path) {
  return [System.IO.Path]::GetFullPath($Path).TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
}

function Get-RelativePath([string] $Root, [string] $Path) {
  return [System.IO.Path]::GetRelativePath($Root, (Normalize-AbsolutePath $Path)).Replace('\', '/')
}

function Get-SourceCommit([string] $Root) {
  if (!(Test-Path -LiteralPath (Join-Path $Root '.git'))) {
    return ''
  }
  $commit = @(& git -C $Root rev-parse HEAD 2>$null)
  if ($LASTEXITCODE -ne 0 -or $commit.Count -ne 1) {
    throw "Unable to read the source commit under '$Root'."
  }
  return ([string] $commit[0]).Trim()
}

function New-CaseInsensitiveSet {
  $set = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
  return ,$set
}

function Add-AdjacencyEdge($Table, [string] $From, [string] $To) {
  if (!$Table.ContainsKey($From)) {
    $Table[$From] = [System.Collections.Generic.List[string]]::new()
  }
  if (!$Table[$From].Contains($To)) {
    $Table[$From].Add($To)
  }
}

function Add-SetTableValue($Table, [string] $Key, [string] $Value) {
  if (!$Table.ContainsKey($Key)) {
    $Table[$Key] = New-CaseInsensitiveSet
  }
  $null = $Table[$Key].Add($Value)
}

function ConvertTo-SortedSetTable($Table) {
  $result = [ordered]@{}
  foreach ($key in @($Table.Keys | Sort-Object)) {
    $result[$key] = @($Table[$key] | Sort-Object)
  }
  return $result
}

function Get-PackageKey([string] $Id) { return "package:$Id" }
function Get-ConfigurationKey([string] $Path, [string] $TargetFramework) { return "configuration:$Path|$TargetFramework" }

function Read-Graph([string] $Path) {
  if (!(Test-Path $Path)) {
    throw "Repository project graph does not exist: $Path"
  }
  $graph = Get-Content -Raw $Path | ConvertFrom-Json -Depth 100
  if ($graph.schemaVersion -ne 1) {
    throw "Unsupported repository project graph schema version '$($graph.schemaVersion)'. Expected 1."
  }
  return $graph
}

function New-GraphIndexes($Graph) {
  $nodes = @{}
  $configurationsByProject = @{}
  $forward = @{}
  $reverse = @{}

  foreach ($node in $Graph.nodes) {
    $nodes[$node.projectPath] = $node
    $configurationsByProject[$node.projectPath] = [System.Collections.Generic.List[string]]::new()
    foreach ($targetFramework in $node.targetFrameworks) {
      $configurationsByProject[$node.projectPath].Add((Get-ConfigurationKey $node.projectPath $targetFramework))
    }
  }

  foreach ($edge in $Graph.configurationEdges) {
    $from = Get-ConfigurationKey $edge.fromProject $edge.fromTargetFramework
    $to = switch ($edge.kind) {
      'ProjectReference' { Get-ConfigurationKey $edge.to $edge.toTargetFramework }
      'PackageReference' { Get-PackageKey $edge.to }
      default { throw "Unsupported repository project graph edge kind '$($edge.kind)'." }
    }
    Add-AdjacencyEdge $forward $from $to
    # Non-assembly project references are source/build inputs (for example analyzers), but
    # ResolveReferences does not place their output in ReferencePath. Keep them for forward
    # sparse-checkout traversal without selecting dependents in the reverse query.
    if ($edge.kind -ne 'ProjectReference' -or $edge.referenceOutputAssembly) {
      Add-AdjacencyEdge $reverse $to $from
    }
  }

  foreach ($node in $Graph.nodes) {
    if ($node.isShippingLibrary -and $node.packageId) {
      $package = Get-PackageKey $node.packageId
      foreach ($configuration in $configurationsByProject[$node.projectPath]) {
        Add-AdjacencyEdge $reverse $package $configuration
      }
    }
  }

  return @{
    Nodes = $nodes
    ConfigurationsByProject = $configurationsByProject
    Forward = $forward
    Reverse = $reverse
  }
}

function Test-ProjectReached($Indexes, $Reachable, [string] $ProjectPath) {
  if (!$Indexes.ConfigurationsByProject.ContainsKey($ProjectPath)) { return $false }
  foreach ($configuration in $Indexes.ConfigurationsByProject[$ProjectPath]) {
    if ($Reachable.Contains($configuration)) { return $true }
  }
  return $false
}

function Test-ProjectOutputReached($Indexes, $Reachable, $Node) {
  return (Test-ProjectReached $Indexes $Reachable $Node.projectPath) -or
    ($Node.isShippingLibrary -and $Node.packageId -and $Reachable.Contains((Get-PackageKey $Node.packageId)))
}

function Get-Reachable($Adjacency, [string[]] $Seeds) {
  $visited = New-CaseInsensitiveSet
  $queue = [System.Collections.Generic.Queue[string]]::new()
  foreach ($seed in $Seeds) {
    if ($seed -and $visited.Add($seed)) {
      $queue.Enqueue($seed)
    }
  }

  while ($queue.Count -gt 0) {
    $current = $queue.Dequeue()
    if (!$Adjacency.ContainsKey($current)) {
      continue
    }
    foreach ($next in $Adjacency[$current]) {
      if ($visited.Add($next)) {
        $queue.Enqueue($next)
      }
    }
  }
  return ,$visited
}

function Write-Lines([string] $Path, [string[]] $Lines) {
  $parent = Split-Path -Parent $Path
  if ($parent) {
    New-Item -ItemType Directory -Path $parent -Force | Out-Null
  }
  [System.IO.File]::WriteAllLines($Path, $Lines)
}

function Get-PeakWorkingSetMiB {
  return [long] [Math]::Ceiling([System.Diagnostics.Process]::GetCurrentProcess().PeakWorkingSet64 / 1MB)
}

function Build-Graph {
  if (!$RepoRoot) { throw 'RepoRoot is required for Build.' }
  if (!$RecordsPath) { throw 'RecordsPath is required for Build.' }

  $totalStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $root = Normalize-AbsolutePath $RepoRoot
  $nodes = @{}
  $configurationEdges = @{}
  $directPackageReferences = @{}
  $checkoutRoots = @{}
  $declaredProjects = New-CaseInsensitiveSet
  $roots = [System.Collections.Generic.List[string]]::new()
  $rootSet = New-CaseInsensitiveSet
  $nodeMetadataConflicts = [System.Collections.Generic.List[object]]::new()
  $inferredProjectReferenceConfigurations = [System.Collections.Generic.List[object]]::new()
  $unresolvedPackageClosure = [System.Collections.Generic.List[object]]::new()
  $packageClosureSummary = $null
  $packageClosureSummaryCount = 0
  $graphGeneration = $null
  $graphGenerationRecordCount = 0
  $transitivePackageRecordCount = 0
  $packageClosureAttempted = !!$PackageRecordsPath
  $recordPaths = [System.Collections.Generic.List[string]]::new()
  $recordCount = 0L
  $recordBytes = 0L
  $recordPaths.Add($RecordsPath)
  if ($PackageRecordsPath) {
    if (!(Test-Path $PackageRecordsPath)) {
      throw "Repository package closure records do not exist: $PackageRecordsPath"
    }
    $recordPaths.Add($PackageRecordsPath)
  }

  # Record parsing is intentionally timed apart from artifact shaping and JSON serialization.
  $readStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  foreach ($recordPath in $recordPaths) {
    $recordBytes += (Get-Item -LiteralPath $recordPath).Length
    foreach ($line in [System.IO.File]::ReadLines($recordPath)) {
      if ([string]::IsNullOrWhiteSpace($line)) { continue }
      $recordCount++
      $parts = $line.Split('|')
      switch ($parts[0]) {
      'GraphGeneration' {
        if ($parts.Length -lt 3) { throw "Invalid graph-generation record: $line" }
        $graphGenerationRecordCount++
        $graphGeneration = [ordered]@{
          configuration = $parts[1]
          includesInputCheckoutRoots = [bool]::Parse($parts[2])
        }
      }
      'Node' {
        if ($parts.Length -lt 8) { throw "Invalid node record: $line" }
        $path = Get-RelativePath $root $parts[1]
        if (!$nodes.ContainsKey($path)) {
          $nodes[$path] = [pscustomobject][ordered]@{
            projectPath = $path
            packageId = $parts[3]
            packageRoot = if ($parts[4]) { Get-RelativePath $root $parts[4] } else { '' }
            isClientLibrary = $parts[5] -eq 'true'
            isGeneratorLibrary = $parts[6] -eq 'true'
            isShippingLibrary = $parts[7] -eq 'true'
            targetFrameworks = (New-CaseInsensitiveSet)
          }
        } else {
          $packageRoot = if ($parts[4]) { Get-RelativePath $root $parts[4] } else { '' }
          $conflictingFields = [System.Collections.Generic.List[string]]::new()
          if ($nodes[$path].packageId -ne $parts[3]) { $conflictingFields.Add('packageId') }
          if ($nodes[$path].packageRoot -ne $packageRoot) { $conflictingFields.Add('packageRoot') }
          if ($nodes[$path].isClientLibrary -ne ($parts[5] -eq 'true')) { $conflictingFields.Add('isClientLibrary') }
          if ($nodes[$path].isGeneratorLibrary -ne ($parts[6] -eq 'true')) { $conflictingFields.Add('isGeneratorLibrary') }
          if ($nodes[$path].isShippingLibrary -ne ($parts[7] -eq 'true')) { $conflictingFields.Add('isShippingLibrary') }
          if ($conflictingFields.Count -gt 0) {
            $nodeMetadataConflicts.Add([ordered]@{
              projectPath = $path
              targetFramework = $parts[2]
              fields = @($conflictingFields)
            })
          }
        }
        if ($parts[2]) { $null = $nodes[$path].targetFrameworks.Add($parts[2]) }
      }
      'ProjectReference' {
        if ($parts.Length -lt 5) { throw "Invalid project-reference record: $line" }
        if (!$parts[3]) { continue }
        $from = Get-RelativePath $root $parts[1]
        $to = Get-RelativePath $root $parts[3]
        $toTargetFramework = if ($parts.Length -ge 9) { $parts[8] } else { '' }
        $configurationKey = "ProjectReference|$from|$($parts[2])|$to|$toTargetFramework"
        if (!$configurationEdges.ContainsKey($configurationKey)) {
          $configurationEdges[$configurationKey] = [pscustomobject][ordered]@{
            kind = 'ProjectReference'
            fromProject = $from
            fromTargetFramework = $parts[2]
            to = $to
            toTargetFramework = $toTargetFramework
            referenceOutputAssembly = $parts[4] -ne 'false'
          }
        }
      }
      'PackageReference' {
        if ($parts.Length -lt 7) { throw "Invalid package-reference record: $line" }
        if (!$parts[3]) { continue }
        $from = Get-RelativePath $root $parts[1]
        $packageReferenceKey = "$from|$($parts[3])"
        if (!$directPackageReferences.ContainsKey($packageReferenceKey)) {
          $directPackageReferences[$packageReferenceKey] = [pscustomobject][ordered]@{
            fromProject = $from
            to = $parts[3]
          }
        }
        $configurationKey = "PackageReference|$from|$($parts[2])|$($parts[3])"
        if (!$configurationEdges.ContainsKey($configurationKey)) {
          $configurationEdges[$configurationKey] = [pscustomobject][ordered]@{
            kind = 'PackageReference'
            fromProject = $from
            fromTargetFramework = $parts[2]
            to = $parts[3]
          }
        }
      }
      'TransitivePackageReference' {
        if ($parts.Length -lt 4) { throw "Invalid transitive package-reference record: $line" }
        if (!$parts[3]) { continue }
        $transitivePackageRecordCount++
        $from = Get-RelativePath $root $parts[1]
        # The NuGet record describes why this repository package was reached. The artifact
        # stores only the resulting reachability edge, merging duplicate direct/transitive paths.
        $configurationKey = "PackageReference|$from|$($parts[2])|$($parts[3])"
        if (!$configurationEdges.ContainsKey($configurationKey)) {
          $configurationEdges[$configurationKey] = [pscustomobject][ordered]@{
            kind = 'PackageReference'
            fromProject = $from
            fromTargetFramework = $parts[2]
            to = $parts[3]
          }
        }
      }
      'UnresolvedPackageClosure' {
        if ($parts.Length -lt 6) { throw "Invalid unresolved package-closure record: $line" }
        $unresolvedPackageClosure.Add([ordered]@{
          projectPath = Get-RelativePath $root $parts[1]
          targetFramework = $parts[2]
          packageId = $parts[3]
          version = $parts[4]
          reason = $parts[5]
        })
      }
      'PackageClosureSummary' {
        if ($parts.Length -ne 10) { throw "Invalid package-closure summary record: $line" }
        $packageClosureSummaryCount++
        $packageClosureSummary = [ordered]@{
          rootCount = [int]$parts[1]
          resolvedRootCount = [int]$parts[2]
          derivedEdgeCount = [int]$parts[3]
          unresolvedRootCount = [int]$parts[4]
          elapsedSeconds = [double]::Parse($parts[5], [System.Globalization.CultureInfo]::InvariantCulture)
          restoreEquivalent = [bool]::Parse($parts[6])
          projectContextCount = [int]$parts[7]
          restoreRequestCount = [int]$parts[8]
          selectedPackageCount = [int]$parts[9]
        }
      }
      'CheckoutRoot' {
        if ($parts.Length -lt 4) { throw "Invalid checkout-root record: $line" }
        if (!$parts[3]) { continue }
        $from = Get-RelativePath $root $parts[1]
        Add-SetTableValue $checkoutRoots (Get-ConfigurationKey $from $parts[2]) $parts[3]
      }
      'Root' {
        if ($parts.Length -lt 2) { throw "Invalid root record: $line" }
        if (!$parts[1]) { continue }
        $path = Get-RelativePath $root $parts[1]
        if ($rootSet.Add($path)) { $roots.Add($path) }
      }
      'DeclaredProject' {
        if ($parts.Length -lt 2) { throw "Invalid declared-project record: $line" }
        if ($parts[1]) { $null = $declaredProjects.Add((Get-RelativePath $root $parts[1])) }
      }
      default { throw "Unknown repository project graph record: $line" }
      }
    }
  }
  $readStopwatch.Stop()

  $modelStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $unmappedConfigurationEdges = @($configurationEdges.GetEnumerator() | Where-Object {
    $_.Value.kind -eq 'ProjectReference' -and !$_.Value.toTargetFramework
  })
  foreach ($entry in $unmappedConfigurationEdges) {
    $edge = $entry.Value
    $configurationEdges.Remove($entry.Key)
    if (!$nodes.ContainsKey($edge.to) -or $nodes[$edge.to].targetFrameworks.Count -eq 0) {
      $configurationEdges[$entry.Key] = $edge
      continue
    }

    $inferredProjectReferenceConfigurations.Add([ordered]@{
      fromProject = $edge.fromProject
      fromTargetFramework = $edge.fromTargetFramework
      toProject = $edge.to
    })
    foreach ($toTargetFramework in $nodes[$edge.to].targetFrameworks) {
      $key = "$($entry.Key)|$toTargetFramework"
      $configurationEdges[$key] = [pscustomobject][ordered]@{
        kind = $edge.kind
        fromProject = $edge.fromProject
        fromTargetFramework = $edge.fromTargetFramework
        to = $edge.to
        toTargetFramework = $toTargetFramework
        referenceOutputAssembly = $edge.referenceOutputAssembly
      }
    }
  }

  $configurationKeys = New-CaseInsensitiveSet
  $sdkConfigurationKeys = New-CaseInsensitiveSet
  foreach ($node in $nodes.Values) {
    foreach ($targetFramework in $node.targetFrameworks) {
      $configurationKey = Get-ConfigurationKey $node.projectPath $targetFramework
      $null = $configurationKeys.Add($configurationKey)
      if ($node.projectPath.StartsWith('sdk/', [System.StringComparison]::OrdinalIgnoreCase)) {
        $null = $sdkConfigurationKeys.Add($configurationKey)
      }
    }
  }
  $unknownCheckoutRootConfigurations = @($checkoutRoots.Keys | Where-Object {
    !$configurationKeys.Contains($_)
  } | Sort-Object)
  $missingCheckoutRootConfigurations = @($sdkConfigurationKeys | Where-Object {
    !$checkoutRoots.ContainsKey($_)
  } | Sort-Object)
  $unsupportedCheckoutRoots = @(
    foreach ($entry in $checkoutRoots.GetEnumerator()) {
      foreach ($path in $entry.Value) {
        if ($path -notmatch '^/sdk/[^/]+/\*$') {
          [ordered]@{ configuration = $entry.Key; path = $path }
        }
      }
    }
  )
  $checkoutRootCount = 0
  foreach ($configurationCheckoutRoots in $checkoutRoots.Values) {
    $checkoutRootCount += $configurationCheckoutRoots.Count
  }
  $checkoutRootsComplete = $unknownCheckoutRootConfigurations.Count -eq 0 -and
    $missingCheckoutRootConfigurations.Count -eq 0 -and $unsupportedCheckoutRoots.Count -eq 0
  $missingConfigurationReferences = @($configurationEdges.Values | Where-Object {
    !$configurationKeys.Contains((Get-ConfigurationKey $_.fromProject $_.fromTargetFramework)) -or
      ($_.kind -eq 'ProjectReference' -and !$configurationKeys.Contains((Get-ConfigurationKey $_.to $_.toTargetFramework)))
  } | Sort-Object kind, fromProject, fromTargetFramework, to, toTargetFramework | ForEach-Object {
    [ordered]@{
      kind = $_.kind
      fromProject = $_.fromProject
      fromTargetFramework = $_.fromTargetFramework
      to = $_.to
      toTargetFramework = $_.toTargetFramework
    }
  })

  $packageProjects = @{}
  foreach ($node in $nodes.Values) {
    if (!$node.isShippingLibrary -or !$node.packageId) { continue }
    if (!$packageProjects.ContainsKey($node.packageId)) {
      $packageProjects[$node.packageId] = [System.Collections.Generic.List[string]]::new()
    }
    $packageProjects[$node.packageId].Add($node.projectPath)
  }

  $duplicatePackageIds = @($packageProjects.GetEnumerator() | Where-Object { $_.Value.Count -gt 1 } | Sort-Object Key | ForEach-Object {
    [ordered]@{ packageId = $_.Key; projects = @($_.Value | Sort-Object) }
  })
  $missingProjectReferences = @($configurationEdges.Values | Where-Object {
    $_.kind -eq 'ProjectReference' -and !$nodes.ContainsKey($_.to) -and
      ($_.to.StartsWith('sdk/', [System.StringComparison]::OrdinalIgnoreCase) -or $_.to.StartsWith('common/', [System.StringComparison]::OrdinalIgnoreCase))
  } | Sort-Object fromProject, to -Unique | ForEach-Object {
    [ordered]@{ fromProject = $_.fromProject; toProject = $_.to }
  })
  $unmappedRepositoryPackages = @($directPackageReferences.Values | Where-Object {
      ($_.to.StartsWith('Azure.', [System.StringComparison]::OrdinalIgnoreCase) -or $_.to.StartsWith('Microsoft.Azure.', [System.StringComparison]::OrdinalIgnoreCase)) -and
      !$packageProjects.ContainsKey($_.to)
  } | Select-Object -ExpandProperty to -Unique | Sort-Object)
  $externalPackages = @($directPackageReferences.Values | Where-Object {
    !$packageProjects.ContainsKey($_.to)
  } | Select-Object -ExpandProperty to -Unique | Sort-Object)
  $missingDeclaredProjects = @($declaredProjects | Where-Object { !$nodes.ContainsKey($_) } | Sort-Object)
  $rootsWithoutNodes = @($roots | Where-Object { !$nodes.ContainsKey($_) } | Sort-Object)
  $packageClosureSummaryConsistent = !$packageClosureAttempted
  if ($packageClosureAttempted -and $packageClosureSummaryCount -eq 1 -and $null -ne $packageClosureSummary) {
    $packageClosureSummaryConsistent =
      $packageClosureSummary.resolvedRootCount + $packageClosureSummary.unresolvedRootCount -eq $packageClosureSummary.rootCount -and
      $packageClosureSummary.derivedEdgeCount -eq $transitivePackageRecordCount -and
      (($packageClosureSummary.unresolvedRootCount -eq 0) -eq ($unresolvedPackageClosure.Count -eq 0))
  }
  $packageClosureHasUnresolved = $externalPackages.Count -gt 0
  if ($packageClosureAttempted) {
    $packageClosureHasUnresolved = !$packageClosureSummaryConsistent -or
      $packageClosureSummary.unresolvedRootCount -gt 0 -or $unresolvedPackageClosure.Count -gt 0
  }
  $requiresExactConfigurationGraph = $packageClosureAttempted

  # External package identities are retained in diagnostics, while the query graph contains
  # only repository package identities that can lead to source or test checkout paths.
  $repositoryConfigurationEdges = @($configurationEdges.Values | Where-Object {
    $_.kind -eq 'ProjectReference' -or $packageProjects.ContainsKey($_.to)
  })

  $graph = [ordered]@{
    schemaVersion = 1
    repositoryRoot = $root.Replace('\', '/')
    sourceCommit = Get-SourceCommit $root
    nodes = @($nodes.Values | Sort-Object projectPath | ForEach-Object {
      $_.targetFrameworks = @($_.targetFrameworks | Sort-Object)
      [pscustomobject]$_
    })
    configurationEdges = @($repositoryConfigurationEdges | Sort-Object kind, fromProject, fromTargetFramework, to, toTargetFramework)
    checkoutRoots = ConvertTo-SortedSetTable $checkoutRoots
    roots = @($roots)
    diagnostics = [ordered]@{
      isComplete = $duplicatePackageIds.Count -eq 0 -and $missingProjectReferences.Count -eq 0 -and
        $missingDeclaredProjects.Count -eq 0 -and $rootsWithoutNodes.Count -eq 0 -and $nodeMetadataConflicts.Count -eq 0 -and
        $missingConfigurationReferences.Count -eq 0 -and
        (!$requiresExactConfigurationGraph -or $inferredProjectReferenceConfigurations.Count -eq 0) -and
        $packageClosureSummaryConsistent -and (!$packageClosureAttempted -or !$packageClosureHasUnresolved) -and
        $graphGenerationRecordCount -le 1
      projectCount = $nodes.Count
      configurationCount = $configurationKeys.Count
      configurationEdgeCount = $repositoryConfigurationEdges.Count
      checkoutRoots = [ordered]@{
        isComplete = $checkoutRootsComplete
        configurationCount = $checkoutRoots.Count
        rootCount = $checkoutRootCount
        unknownConfigurations = $unknownCheckoutRootConfigurations
        missingConfigurations = $missingCheckoutRootConfigurations
        unsupportedRoots = $unsupportedCheckoutRoots
      }
      duplicatePackageIds = $duplicatePackageIds
      missingProjectReferences = $missingProjectReferences
      missingDeclaredProjects = $missingDeclaredProjects
      rootsWithoutNodes = $rootsWithoutNodes
      nodeMetadataConflicts = @($nodeMetadataConflicts)
      configurationGraph = [ordered]@{
        isExact = $inferredProjectReferenceConfigurations.Count -eq 0
        inferredProjectReferences = @($inferredProjectReferenceConfigurations)
        missingReferences = $missingConfigurationReferences
      }
      unmappedRepositoryPackageReferences = $unmappedRepositoryPackages
      externalPackageReferences = $externalPackages
      packageClosureAttempted = $packageClosureAttempted
      packageClosureSummaryCount = $packageClosureSummaryCount
      packageClosureSummaryConsistent = $packageClosureSummaryConsistent
      packageClosure = $packageClosureSummary
      generation = $graphGeneration
      graphGenerationRecordCount = $graphGenerationRecordCount
      unresolvedExternalPackageClosure = @($unresolvedPackageClosure)
      hasUnresolvedExternalPackageClosure = $packageClosureHasUnresolved
    }
  }
  $modelStopwatch.Stop()

  $writeStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $parent = Split-Path -Parent $GraphPath
  if ($parent) { New-Item -ItemType Directory -Path $parent -Force | Out-Null }
  $graph | ConvertTo-Json -Depth 100 | Set-Content -Path $GraphPath -Encoding utf8
  $writeStopwatch.Stop()
  $totalStopwatch.Stop()
  Write-Host "Repository project graph: $($nodes.Count) projects, $($configurationKeys.Count) configurations, $($repositoryConfigurationEdges.Count) repository configuration edges, $($roots.Count) roots, complete=$($graph.diagnostics.isComplete)"
  Write-Host ("Repository project graph timing: operation=Build records={0} recordBytes={1} recordParsing={2:F2}s model={3:F2}s write={4:F2}s elapsed={5:F2}s peakWorkingSet={6}MiB" -f `
    $recordCount, $recordBytes, $readStopwatch.Elapsed.TotalSeconds, $modelStopwatch.Elapsed.TotalSeconds, `
    $writeStopwatch.Elapsed.TotalSeconds, $totalStopwatch.Elapsed.TotalSeconds, (Get-PeakWorkingSetMiB))
}

function Invoke-ReverseQuery {
  if (!$OutputPath) { throw 'OutputPath is required for Reverse.' }
  $totalStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $readStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $graph = Read-Graph $GraphPath
  $readStopwatch.Stop()
  if (!$graph.diagnostics.isComplete) {
    throw "Repository project graph is incomplete. See diagnostics in $GraphPath"
  }
  $indexStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $indexes = New-GraphIndexes $graph
  $indexStopwatch.Stop()
  $queryStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $requestedDependencies = @($Dependencies -split '\s+' | Where-Object { $_ })
  $knownPackages = New-CaseInsensitiveSet
  foreach ($node in $graph.nodes) {
    if ($node.isShippingLibrary -and $node.packageId) { $null = $knownPackages.Add($node.packageId) }
  }
  $unknownDependencies = @($requestedDependencies | Where-Object { !$knownPackages.Contains($_) })
  if ($unknownDependencies.Count -gt 0) {
    throw "The repository project graph has no shipping project for: $($unknownDependencies -join ', ')"
  }
  $seeds = @($requestedDependencies | ForEach-Object { Get-PackageKey $_ })
  $reachable = Get-Reachable $indexes.Reverse $seeds
  $lines = [System.Collections.Generic.List[string]]::new()
  $seen = New-CaseInsensitiveSet

  foreach ($root in $graph.roots) {
    if (!(Test-ProjectReached $indexes $reachable $root)) { continue }
    $node = $indexes.Nodes[$root]
    if (!$node.isClientLibrary -or $node.isGeneratorLibrary) { continue }
    $line = if ($PackageRootsOnly -eq 'true') {
      (Normalize-AbsolutePath (Join-Path $graph.repositoryRoot $node.packageRoot))
    } else {
      '$(RepoRoot)' + $root
    }
    if ($seen.Add($line)) { $lines.Add($line) }
  }
  Write-Lines $OutputPath @($lines)
  $queryStopwatch.Stop()
  $totalStopwatch.Stop()
  Write-Host "Reverse query selected $($lines.Count) project/package roots."
  Write-Host ("Repository project graph timing: operation=Reverse read={0:F2}s index={1:F2}s queryAndWrite={2:F2}s elapsed={3:F2}s peakWorkingSet={4}MiB" -f `
    $readStopwatch.Elapsed.TotalSeconds, $indexStopwatch.Elapsed.TotalSeconds, $queryStopwatch.Elapsed.TotalSeconds, `
    $totalStopwatch.Elapsed.TotalSeconds, (Get-PeakWorkingSetMiB))
}

function Invoke-ForwardQuery {
  if (!$OutputPath) { throw 'OutputPath is required for Forward.' }
  $totalStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $readStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $graph = Read-Graph $GraphPath
  $readStopwatch.Stop()
  if (!$graph.diagnostics.isComplete) {
    throw "Repository project graph is incomplete. See diagnostics in $GraphPath"
  }
  $indexStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $indexes = New-GraphIndexes $graph
  $indexStopwatch.Stop()
  $queryStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $requestedRoots = [System.Collections.Generic.List[string]]::new()
  if ($RootProjectsPath) {
    foreach ($line in [System.IO.File]::ReadLines($RootProjectsPath)) {
      if ($line) {
        $root = if ([System.IO.Path]::IsPathRooted($line)) { Get-RelativePath $graph.repositoryRoot $line } else { $line.Replace('\', '/') }
        $requestedRoots.Add($root)
      }
    }
  } elseif ($RootProjects) {
    foreach ($root in ($RootProjects -split ';')) {
      if ($root) {
        $path = if ([System.IO.Path]::IsPathRooted($root)) { Get-RelativePath $graph.repositoryRoot $root } else { $root.Replace('\', '/') }
        $requestedRoots.Add($path)
      }
    }
  } else {
    foreach ($root in $graph.roots) { $requestedRoots.Add($root) }
  }

  $unknownRoots = @($requestedRoots | Where-Object { !$indexes.Nodes.ContainsKey($_) })
  if ($unknownRoots.Count -gt 0) {
    throw "The repository project graph does not contain: $($unknownRoots -join ', ')"
  }

  $seeds = @($requestedRoots | ForEach-Object { $indexes.ConfigurationsByProject[$_] })
  $reachable = Get-Reachable $indexes.Forward $seeds
  $lines = [System.Collections.Generic.List[string]]::new()
  foreach ($node in $graph.nodes) {
    if (Test-ProjectOutputReached $indexes $reachable $node) {
      $lines.Add("Project|$($node.projectPath)")
    }
  }
  Write-Lines $OutputPath @($lines | Sort-Object -Unique)
  $queryStopwatch.Stop()
  $totalStopwatch.Stop()
  Write-Host "Forward query wrote $($lines.Count) records."
  Write-Host ("Repository project graph timing: operation=Forward read={0:F2}s index={1:F2}s queryAndWrite={2:F2}s elapsed={3:F2}s peakWorkingSet={4}MiB" -f `
    $readStopwatch.Elapsed.TotalSeconds, $indexStopwatch.Elapsed.TotalSeconds, $queryStopwatch.Elapsed.TotalSeconds, `
    $totalStopwatch.Elapsed.TotalSeconds, (Get-PeakWorkingSetMiB))
}

switch ($Operation) {
  'Build' { Build-Graph }
  'Forward' { Invoke-ForwardQuery }
  'Reverse' { Invoke-ReverseQuery }
}
