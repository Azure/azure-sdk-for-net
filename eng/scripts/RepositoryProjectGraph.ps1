[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [ValidateSet('Build', 'Forward', 'Reverse', 'ValidateOracle')]
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
  [string] $OraclePath,
  [string] $PackageRootsOnly = 'false',
  [ValidateSet('Projects', 'Inputs', 'All')]
  [string] $ForwardOutputKind = 'Projects'
)

Set-StrictMode -Version 3
$ErrorActionPreference = 'Stop'

function Normalize-AbsolutePath([string] $Path) {
  return [System.IO.Path]::GetFullPath($Path).TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
}

function Get-RelativePath([string] $Root, [string] $Path) {
  return [System.IO.Path]::GetRelativePath($Root, (Normalize-AbsolutePath $Path)).Replace('\', '/')
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

function Get-ProjectKey([string] $Path) { return "project:$Path" }
function Get-PackageKey([string] $Id) { return "package:$Id" }

function Read-Graph([string] $Path) {
  if (!(Test-Path $Path)) {
    throw "Repository project graph does not exist: $Path"
  }
  $graph = Get-Content -Raw $Path | ConvertFrom-Json -Depth 100
  if ($graph.schemaVersion -ne 2) {
    throw "Unsupported repository project graph schema version '$($graph.schemaVersion)'. Expected 2."
  }
  return $graph
}

function New-GraphIndexes($Graph) {
  $nodes = @{}
  $forward = @{}
  $reverse = @{}

  foreach ($node in $Graph.nodes) {
    $nodes[$node.projectPath] = $node
  }

  foreach ($edge in $Graph.edges) {
    $from = Get-ProjectKey $edge.fromProject
    $to = if ($edge.kind -eq 'ProjectReference') { Get-ProjectKey $edge.to } else { Get-PackageKey $edge.to }
    Add-AdjacencyEdge $forward $from $to
    Add-AdjacencyEdge $reverse $to $from
  }

  foreach ($node in $Graph.nodes) {
    if ($node.isShippingLibrary -and $node.packageId) {
      $package = Get-PackageKey $node.packageId
      $project = Get-ProjectKey $node.projectPath
      Add-AdjacencyEdge $forward $package $project
      Add-AdjacencyEdge $reverse $project $package
      Add-AdjacencyEdge $forward $project $package
      Add-AdjacencyEdge $reverse $package $project
    }
  }

  return @{
    Nodes = $nodes
    Forward = $forward
    Reverse = $reverse
  }
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

function Build-Graph {
  if (!$RepoRoot) { throw 'RepoRoot is required for Build.' }
  if (!$RecordsPath) { throw 'RecordsPath is required for Build.' }

  $root = Normalize-AbsolutePath $RepoRoot
  $nodes = @{}
  $edges = @{}
  $inputs = @{}
  $declaredProjects = New-CaseInsensitiveSet
  $roots = [System.Collections.Generic.List[string]]::new()
  $rootSet = New-CaseInsensitiveSet
  $nodeMetadataConflicts = [System.Collections.Generic.List[object]]::new()
  $unresolvedPackageClosure = [System.Collections.Generic.List[object]]::new()
  $packageClosureSummary = $null
  $packageClosureSummaryCount = 0
  $transitivePackageRecordCount = 0
  $packageClosureAttempted = !!$PackageRecordsPath
  $recordPaths = [System.Collections.Generic.List[string]]::new()
  $recordPaths.Add($RecordsPath)
  if ($PackageRecordsPath) {
    if (!(Test-Path $PackageRecordsPath)) {
      throw "Repository package closure records do not exist: $PackageRecordsPath"
    }
    $recordPaths.Add($PackageRecordsPath)
  }

  foreach ($recordPath in $recordPaths) {
    foreach ($line in [System.IO.File]::ReadLines($recordPath)) {
      if ([string]::IsNullOrWhiteSpace($line)) { continue }
      $parts = $line.Split('|')
      switch ($parts[0]) {
      'Node' {
        if ($parts.Length -lt 10) { throw "Invalid node record: $line" }
        $path = Get-RelativePath $root $parts[1]
        if (!$nodes.ContainsKey($path)) {
          $nodes[$path] = [pscustomobject][ordered]@{
            projectPath = $path
            packageId = $parts[3]
            assemblyName = $parts[4]
            packageRoot = if ($parts[5]) { Get-RelativePath $root $parts[5] } else { '' }
            isClientLibrary = $parts[6] -eq 'true'
            isGeneratorLibrary = $parts[7] -eq 'true'
            isTestProject = $parts[8] -eq 'true'
            isShippingLibrary = $parts[9] -eq 'true'
            targetFrameworks = (New-CaseInsensitiveSet)
          }
        } else {
          $packageRoot = if ($parts[5]) { Get-RelativePath $root $parts[5] } else { '' }
          $conflictingFields = [System.Collections.Generic.List[string]]::new()
          if ($nodes[$path].packageId -ne $parts[3]) { $conflictingFields.Add('packageId') }
          if ($nodes[$path].assemblyName -ne $parts[4]) { $conflictingFields.Add('assemblyName') }
          if ($nodes[$path].packageRoot -ne $packageRoot) { $conflictingFields.Add('packageRoot') }
          if ($nodes[$path].isClientLibrary -ne ($parts[6] -eq 'true')) { $conflictingFields.Add('isClientLibrary') }
          if ($nodes[$path].isGeneratorLibrary -ne ($parts[7] -eq 'true')) { $conflictingFields.Add('isGeneratorLibrary') }
          if ($nodes[$path].isTestProject -ne ($parts[8] -eq 'true')) { $conflictingFields.Add('isTestProject') }
          if ($nodes[$path].isShippingLibrary -ne ($parts[9] -eq 'true')) { $conflictingFields.Add('isShippingLibrary') }
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
        if ($parts.Length -lt 6) { throw "Invalid project-reference record: $line" }
        if (!$parts[3]) { continue }
        $from = Get-RelativePath $root $parts[1]
        $to = Get-RelativePath $root $parts[3]
        $key = "ProjectReference|$from|$to|$($parts[4])|$($parts[5])"
        if (!$edges.ContainsKey($key)) {
          $edges[$key] = [pscustomobject][ordered]@{
            kind = 'ProjectReference'
            fromProject = $from
            to = $to
            referenceOutputAssembly = $parts[4]
            outputItemType = $parts[5]
            privateAssets = ''
            includeAssets = ''
            excludeAssets = ''
            version = ''
            viaPackage = ''
            viaVersion = ''
            dependencyPath = ''
            targetFrameworks = (New-CaseInsensitiveSet)
          }
        }
        if ($parts[2]) { $null = $edges[$key].targetFrameworks.Add($parts[2]) }
      }
      'PackageReference' {
        if ($parts.Length -lt 7) { throw "Invalid package-reference record: $line" }
        if (!$parts[3]) { continue }
        $from = Get-RelativePath $root $parts[1]
        $version = if ($parts.Length -ge 8) { $parts[7] } else { '' }
        $key = "PackageReference|$from|$($parts[3])|$($parts[4])|$($parts[5])|$($parts[6])|$version"
        if (!$edges.ContainsKey($key)) {
          $edges[$key] = [pscustomobject][ordered]@{
            kind = 'PackageReference'
            fromProject = $from
            to = $parts[3]
            referenceOutputAssembly = ''
            outputItemType = ''
            privateAssets = $parts[4]
            includeAssets = $parts[5]
            excludeAssets = $parts[6]
            version = $version
            viaPackage = ''
            viaVersion = ''
            dependencyPath = ''
            targetFrameworks = (New-CaseInsensitiveSet)
          }
        }
        if ($parts[2]) { $null = $edges[$key].targetFrameworks.Add($parts[2]) }
      }
      'TransitivePackageReference' {
        if ($parts.Length -lt 7) { throw "Invalid transitive package-reference record: $line" }
        if (!$parts[3]) { continue }
        $transitivePackageRecordCount++
        $from = Get-RelativePath $root $parts[1]
        $key = "TransitivePackageReference|$from|$($parts[3])|$($parts[4])|$($parts[5])|$($parts[6])"
        if (!$edges.ContainsKey($key)) {
          $edges[$key] = [pscustomobject][ordered]@{
            kind = 'TransitivePackageReference'
            fromProject = $from
            to = $parts[3]
            referenceOutputAssembly = ''
            outputItemType = ''
            privateAssets = ''
            includeAssets = ''
            excludeAssets = ''
            version = ''
            viaPackage = $parts[4]
            viaVersion = $parts[5]
            dependencyPath = $parts[6]
            targetFrameworks = (New-CaseInsensitiveSet)
          }
        }
        if ($parts[2]) { $null = $edges[$key].targetFrameworks.Add($parts[2]) }
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
        if ($parts.Length -lt 12) { throw "Invalid package-closure summary record: $line" }
        $packageClosureSummaryCount++
        $packageClosureSummary = [ordered]@{
          rootCount = [int]$parts[1]
          resolvedRootCount = [int]$parts[2]
          derivedEdgeCount = [int]$parts[3]
          unresolvedRootCount = [int]$parts[4]
          metadataRequestCount = [int]$parts[5]
          packageCacheHitCount = [int]$parts[6]
          remoteMetadataRequestCount = [int]$parts[7]
          elapsedSeconds = [double]::Parse($parts[8], [System.Globalization.CultureInfo]::InvariantCulture)
          resolutionMode = $parts[9]
          restoreEquivalent = [bool]::Parse($parts[10])
          transitiveDependencyAssetFiltersApplied = [bool]::Parse($parts[11])
        }
      }
      'Input' {
        if ($parts.Length -lt 5) { throw "Invalid input record: $line" }
        if (!$parts[4]) { continue }
        $from = Get-RelativePath $root $parts[1]
        $path = Get-RelativePath $root $parts[4]
        $key = "$from|$($parts[3])|$path"
        if (!$inputs.ContainsKey($key)) {
          $inputs[$key] = [pscustomobject][ordered]@{
            projectPath = $from
            kind = $parts[3]
            path = $path
            targetFrameworks = (New-CaseInsensitiveSet)
          }
        }
        if ($parts[2]) { $null = $inputs[$key].targetFrameworks.Add($parts[2]) }
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
  $missingProjectReferences = @($edges.Values | Where-Object {
    $_.kind -eq 'ProjectReference' -and !$nodes.ContainsKey($_.to) -and
      ($_.to.StartsWith('sdk/', [System.StringComparison]::OrdinalIgnoreCase) -or $_.to.StartsWith('common/', [System.StringComparison]::OrdinalIgnoreCase))
  } | Sort-Object fromProject, to | ForEach-Object {
    [ordered]@{ fromProject = $_.fromProject; toProject = $_.to }
  })
  $unmappedRepositoryPackages = @($edges.Values | Where-Object {
    $_.kind -eq 'PackageReference' -and
      ($_.to.StartsWith('Azure.', [System.StringComparison]::OrdinalIgnoreCase) -or $_.to.StartsWith('Microsoft.Azure.', [System.StringComparison]::OrdinalIgnoreCase)) -and
      !$packageProjects.ContainsKey($_.to)
  } | Select-Object -ExpandProperty to -Unique | Sort-Object)
  $externalPackages = @($edges.Values | Where-Object { $_.kind -eq 'PackageReference' -and !$packageProjects.ContainsKey($_.to) } | Select-Object -ExpandProperty to -Unique | Sort-Object)
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

  $graph = [ordered]@{
    schemaVersion = 2
    repositoryRoot = $root.Replace('\', '/')
    nodes = @($nodes.Values | Sort-Object projectPath | ForEach-Object {
      $_.targetFrameworks = @($_.targetFrameworks | Sort-Object)
      [pscustomobject]$_
    })
    edges = @($edges.Values | Sort-Object kind, fromProject, to | ForEach-Object {
      $_.targetFrameworks = @($_.targetFrameworks | Sort-Object)
      [pscustomobject]$_
    })
    inputs = @($inputs.Values | Sort-Object projectPath, kind, path | ForEach-Object {
      $_.targetFrameworks = @($_.targetFrameworks | Sort-Object)
      [pscustomobject]$_
    })
    roots = @($roots)
    diagnostics = [ordered]@{
      isComplete = $duplicatePackageIds.Count -eq 0 -and $missingProjectReferences.Count -eq 0 -and
        $missingDeclaredProjects.Count -eq 0 -and $rootsWithoutNodes.Count -eq 0 -and $nodeMetadataConflicts.Count -eq 0 -and
        $packageClosureSummaryConsistent -and (!$packageClosureAttempted -or !$packageClosureHasUnresolved)
      projectCount = $nodes.Count
      edgeCount = $edges.Count
      inputCount = $inputs.Count
      duplicatePackageIds = $duplicatePackageIds
      missingProjectReferences = $missingProjectReferences
      missingDeclaredProjects = $missingDeclaredProjects
      rootsWithoutNodes = $rootsWithoutNodes
      nodeMetadataConflicts = @($nodeMetadataConflicts)
      unmappedRepositoryPackageReferences = $unmappedRepositoryPackages
      externalPackageReferences = $externalPackages
      packageClosureAttempted = $packageClosureAttempted
      packageClosureSummaryCount = $packageClosureSummaryCount
      packageClosureSummaryConsistent = $packageClosureSummaryConsistent
      packageClosure = $packageClosureSummary
      unresolvedExternalPackageClosure = @($unresolvedPackageClosure)
      hasUnresolvedExternalPackageClosure = $packageClosureHasUnresolved
    }
  }

  $parent = Split-Path -Parent $GraphPath
  if ($parent) { New-Item -ItemType Directory -Path $parent -Force | Out-Null }
  $graph | ConvertTo-Json -Depth 100 | Set-Content -Path $GraphPath -Encoding utf8
  Write-Host "Repository project graph: $($nodes.Count) projects, $($edges.Count) edges, $($roots.Count) roots, complete=$($graph.diagnostics.isComplete)"
}

function Invoke-ReverseQuery {
  if (!$OutputPath) { throw 'OutputPath is required for Reverse.' }
  $graph = Read-Graph $GraphPath
  if (!$graph.diagnostics.isComplete) {
    throw "Repository project graph is incomplete. See diagnostics in $GraphPath"
  }
  $indexes = New-GraphIndexes $graph
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
    if (!$reachable.Contains((Get-ProjectKey $root))) { continue }
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
  Write-Host "Reverse query selected $($lines.Count) project/package roots."
}

function Invoke-ForwardQuery {
  if (!$OutputPath) { throw 'OutputPath is required for Forward.' }
  $graph = Read-Graph $GraphPath
  if (!$graph.diagnostics.isComplete) {
    throw "Repository project graph is incomplete. See diagnostics in $GraphPath"
  }
  $indexes = New-GraphIndexes $graph
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

  $seeds = @($requestedRoots | ForEach-Object { Get-ProjectKey $_ })
  $reachable = Get-Reachable $indexes.Forward $seeds
  $lines = [System.Collections.Generic.List[string]]::new()
  if ($ForwardOutputKind -in @('Projects', 'All')) {
    foreach ($node in $graph.nodes) {
      if ($reachable.Contains((Get-ProjectKey $node.projectPath))) {
        $lines.Add("Project|$($node.projectPath)")
      }
    }
  }
  if ($ForwardOutputKind -in @('Inputs', 'All')) {
    foreach ($input in $graph.inputs) {
      if ($reachable.Contains((Get-ProjectKey $input.projectPath))) {
        $lines.Add("Input|$($input.path)")
      }
    }
  }
  Write-Lines $OutputPath @($lines | Sort-Object -Unique)
  Write-Host "Forward query wrote $($lines.Count) records."
}

function Invoke-OracleValidation {
  if (!$OraclePath) { throw 'OraclePath is required for ValidateOracle.' }
  if (!$OutputPath) { throw 'OutputPath is required for ValidateOracle.' }
  $graph = Read-Graph $GraphPath
  $indexes = New-GraphIndexes $graph
  $knownAliases = @{}
  $implementationProjects = @{}
  foreach ($node in $graph.nodes) {
    if (!$node.isShippingLibrary -or !$node.packageId) { continue }
    $knownAliases[$node.packageId] = $node.packageId
    if ($node.assemblyName) { $knownAliases[$node.assemblyName] = $node.packageId }
    if (!$implementationProjects.ContainsKey($node.packageId)) {
      $implementationProjects[$node.packageId] = [System.Collections.Generic.List[string]]::new()
    }
    $implementationProjects[$node.packageId].Add($node.projectPath)
  }

  $closures = @{}
  $missing = [System.Collections.Generic.List[object]]::new()
  $queryDependencies = New-CaseInsensitiveSet
  foreach ($dependency in ($Dependencies -split '\s+' | Where-Object { $_ })) {
    $null = $queryDependencies.Add($dependency)
  }
  $expectedQueryRoots = New-CaseInsensitiveSet
  $checked = 0
  foreach ($line in [System.IO.File]::ReadLines($OraclePath)) {
    if (!$line) { continue }
    $parts = $line.Split('|')
    $project = Get-RelativePath $graph.repositoryRoot $parts[0]
    if ($parts.Length -ge 3 -and $queryDependencies.Contains($parts[2])) {
      $null = $expectedQueryRoots.Add($project)
    }
    if ($parts.Length -lt 3 -or !$knownAliases.ContainsKey($parts[2])) { continue }
    if (!$closures.ContainsKey($project)) {
      $closures[$project] = Get-Reachable $indexes.Forward @((Get-ProjectKey $project))
    }
    $packageId = $knownAliases[$parts[2]]
    $packageKey = Get-PackageKey $packageId
    $implementedProjectReached = $false
    foreach ($implementationProject in $implementationProjects[$packageId]) {
      if ($closures[$project].Contains((Get-ProjectKey $implementationProject))) {
        $implementedProjectReached = $true
        break
      }
    }
    $checked++
    if (!$closures[$project].Contains($packageKey) -and !$implementedProjectReached) {
      $missing.Add([ordered]@{
        projectPath = $project
        targetFramework = $parts[1]
        resolvedAssembly = $parts[2]
        packageId = $packageId
      })
    }
  }

  $queryValidation = $null
  if ($queryDependencies.Count -gt 0) {
    $reachable = Get-Reachable $indexes.Reverse @($queryDependencies | ForEach-Object { Get-PackageKey $_ })
    $actualQueryRoots = New-CaseInsensitiveSet
    foreach ($root in $graph.roots) {
      $node = $indexes.Nodes[$root]
      if ($reachable.Contains((Get-ProjectKey $root)) -and $node.isClientLibrary -and !$node.isGeneratorLibrary) {
        $null = $actualQueryRoots.Add($root)
      }
    }
    $missingQueryRoots = @($expectedQueryRoots | Where-Object { !$actualQueryRoots.Contains($_) } | Sort-Object)
    $extraQueryRoots = @($actualQueryRoots | Where-Object { !$expectedQueryRoots.Contains($_) } | Sort-Object)
    $queryValidation = [ordered]@{
      dependencies = @($queryDependencies | Sort-Object)
      expectedRootCount = $expectedQueryRoots.Count
      actualRootCount = $actualQueryRoots.Count
      missingRoots = $missingQueryRoots
      extraRoots = $extraQueryRoots
    }
  }

  $result = [ordered]@{
    schemaVersion = 1
    checkedResolvedRepositoryReferences = $checked
    missingCount = $missing.Count
    missing = @($missing)
    queryValidation = $queryValidation
  }
  $result | ConvertTo-Json -Depth 20 | Set-Content -Path $OutputPath -Encoding utf8
  Write-Host "Oracle validation checked $checked resolved repository references; missing=$($missing.Count)."
  if ($queryValidation) {
    Write-Host "Oracle query comparison expected $($queryValidation.expectedRootCount) roots and found $($queryValidation.actualRootCount); missing=$($queryValidation.missingRoots.Count), extra=$($queryValidation.extraRoots.Count)."
  }
  if ($queryValidation -and ($queryValidation.missingRoots.Count -gt 0 -or $queryValidation.extraRoots.Count -gt 0)) {
    throw "Source graph query did not match the resolved-reference oracle. See $OutputPath"
  }
  if (!$queryValidation -and $missing.Count -gt 0) {
    throw "Source graph missed $($missing.Count) resolved repository references. See $OutputPath"
  }
}

switch ($Operation) {
  'Build' { Build-Graph }
  'Forward' { Invoke-ForwardQuery }
  'Reverse' { Invoke-ReverseQuery }
  'ValidateOracle' { Invoke-OracleValidation }
}
