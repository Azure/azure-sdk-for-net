#Requires -Version 7.0

# VALIDATION ONLY: this orchestrator compares the production graph with independently collected
# MSBuildProjectReferenceOracle evidence. It is not imported by Language-Settings.ps1 or graph
# generation, and it writes only beneath artifacts/validation/RepositoryProjectGraph by default.
[CmdletBinding()]
param(
  [switch] $DependencyRelation,
  [switch] $ReuseFreshGraph,
  [string] $RepoRoot,
  [string] $OutputRoot
)

Set-StrictMode -Version 3
$ErrorActionPreference = 'Stop'

function New-CaseInsensitiveSet {
  return ,([System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase))
}

function New-CaseInsensitiveDictionary {
  return ,([System.Collections.Generic.Dictionary[string, object]]::new([System.StringComparer]::OrdinalIgnoreCase))
}

function Normalize-AbsolutePath([string] $Path) {
  if ([string]::IsNullOrWhiteSpace($Path)) {
    throw 'A non-empty path is required.'
  }
  return [System.IO.Path]::GetFullPath($Path).TrimEnd(
    [System.IO.Path]::DirectorySeparatorChar,
    [System.IO.Path]::AltDirectorySeparatorChar)
}

function Get-NormalizedPackageRoot([string] $Root, [string] $Path) {
  $candidate = if ([System.IO.Path]::IsPathRooted($Path)) { $Path } else { Join-Path $Root $Path }
  return Normalize-AbsolutePath $candidate
}

function Get-SortedUniqueLines([object[]] $Lines) {
  $set = New-CaseInsensitiveSet
  foreach ($line in $Lines) {
    if ($null -ne $line -and $set.Add([string] $line)) { }
  }
  [string[]] $result = @($set)
  [System.Array]::Sort($result, [System.StringComparer]::OrdinalIgnoreCase)
  return $result
}

function Write-Utf8Lines([string] $Path, [object[]] $Lines) {
  $parent = Split-Path -Parent $Path
  if ($parent) {
    New-Item -ItemType Directory -Path $parent -Force | Out-Null
  }
  [System.IO.File]::WriteAllLines(
    $Path,
    [string[]]@(Get-SortedUniqueLines $Lines),
    [System.Text.UTF8Encoding]::new($false))
}

function Get-RelativePath([string] $Root, [string] $Path) {
  return [System.IO.Path]::GetRelativePath($Root, (Normalize-AbsolutePath $Path)).Replace('\', '/')
}

function Get-PackageInfoUniverse([string] $PackageInfoDirectory, [string] $RepositoryRoot) {
  $packages = [System.Collections.Generic.List[object]]::new()
  $names = New-CaseInsensitiveDictionary
  $roots = New-CaseInsensitiveDictionary

  foreach ($file in @(Get-ChildItem -LiteralPath $PackageInfoDirectory -Filter '*.json' -File -Recurse | Sort-Object FullName)) {
    $package = Get-Content -Raw -LiteralPath $file.FullName | ConvertFrom-Json -Depth 100
    foreach ($property in @('Name', 'ArtifactName', 'DirectoryPath', 'IncludedForValidation')) {
      if ($package.PSObject.Properties.Name -notcontains $property) {
        throw "PackageInfo '$($file.FullName)' does not contain '$property'."
      }
    }
    if ([string]::IsNullOrWhiteSpace([string] $package.Name) -or
        [string]::IsNullOrWhiteSpace([string] $package.ArtifactName) -or
        [string]::IsNullOrWhiteSpace([string] $package.DirectoryPath)) {
      throw "PackageInfo '$($file.FullName)' has an empty identity or directory."
    }
    if ([bool] $package.IncludedForValidation) {
      throw "The complete PackageInfo universe must begin with IncludedForValidation=false: '$($file.FullName)'."
    }

    $entry = [pscustomobject][ordered]@{
      Name = [string] $package.Name
      ArtifactName = [string] $package.ArtifactName
      DirectoryPath = Get-NormalizedPackageRoot $RepositoryRoot ([string] $package.DirectoryPath)
      IncludedForValidation = $false
      SourceFile = $file.FullName
    }
    if ($names.ContainsKey($entry.Name)) {
      throw "Production PackageInfo discovery emitted duplicate package identity '$($entry.Name)'."
    }
    if ($roots.ContainsKey($entry.DirectoryPath)) {
      throw "Production PackageInfo directory '$($entry.DirectoryPath)' maps to both '$($roots[$entry.DirectoryPath].Name)' and '$($entry.Name)'."
    }
    $names.Add($entry.Name, $entry)
    $roots.Add($entry.DirectoryPath, $entry)
    $packages.Add($entry)
  }

  if ($packages.Count -eq 0) {
    throw "Production PackageInfo discovery emitted no packages under '$PackageInfoDirectory'."
  }
  return $packages.ToArray()
}

function Convert-MSBuildProjectReferenceOracleRecordsToRelation(
  [string] $RecordsPath,
  [object[]] $PackageInfos,
  [string] $RepositoryRoot) {
  $packagesByName = New-CaseInsensitiveDictionary
  foreach ($package in $PackageInfos) {
    $packagesByName.Add([string] $package.Name, $package)
  }

  $relation = New-CaseInsensitiveSet
  $rawRecords = New-CaseInsensitiveSet
  $projects = New-CaseInsensitiveSet
  $configurations = New-CaseInsensitiveSet
  $targetFrameworks = New-CaseInsensitiveSet
  foreach ($line in [System.IO.File]::ReadLines($RecordsPath)) {
    if ([string]::IsNullOrWhiteSpace($line)) { continue }
    $parts = $line.Split('|')
    if ($parts.Length -ne 4 -or @($parts | Where-Object { $_ -match '[\r\n\t]' }).Count -gt 0) {
      throw "Invalid MSBuildProjectReferenceOracle record: $line"
    }
    $root = Get-NormalizedPackageRoot $RepositoryRoot $parts[1]
    $project = Normalize-AbsolutePath $parts[2]
    $normalizedRecord = "$($parts[0])`t$root`t$project`t$($parts[3])"
    $null = $rawRecords.Add($normalizedRecord)
    $null = $projects.Add($project)
    $null = $configurations.Add("$project|$($parts[3])")
    if ($parts[3]) { $null = $targetFrameworks.Add($parts[3]) }

    if ($packagesByName.ContainsKey($parts[0])) {
      $canonicalName = [string] $packagesByName[$parts[0]].Name
      $null = $relation.Add("$canonicalName`t$root")
    }
  }

  return [pscustomobject][ordered]@{
    Relation = @(Get-SortedUniqueLines @($relation))
    RawRecords = @(Get-SortedUniqueLines @($rawRecords))
    RawRecordCount = $rawRecords.Count
    ProjectCount = $projects.Count
    ConfigurationCount = $configurations.Count
    TargetFrameworks = @(Get-SortedUniqueLines @($targetFrameworks))
  }
}

function Get-ConfigurationKey([string] $ProjectPath, [string] $TargetFramework) {
  return "configuration:$ProjectPath|$TargetFramework"
}

function Get-PackageKey([string] $PackageId) {
  return "package:$PackageId"
}

function Add-AdjacencyValue($Table, [string] $From, [string] $To) {
  if (!$Table.ContainsKey($From)) {
    $Table[$From] = New-CaseInsensitiveSet
  }
  $null = $Table[$From].Add($To)
}

function New-DependencyGraphModel($Graph) {
  $nodes = New-CaseInsensitiveDictionary
  $configurationsByProject = New-CaseInsensitiveDictionary
  $packageConfigurations = New-CaseInsensitiveDictionary
  $reverse = New-CaseInsensitiveDictionary
  $forward = New-CaseInsensitiveDictionary
  $projectForward = New-CaseInsensitiveDictionary

  foreach ($node in $Graph.nodes) {
    $nodes.Add([string] $node.projectPath, $node)
    $configurations = [System.Collections.Generic.List[string]]::new()
    foreach ($targetFramework in $node.targetFrameworks) {
      $configurations.Add((Get-ConfigurationKey $node.projectPath $targetFramework))
    }
    $configurationsByProject.Add([string] $node.projectPath, $configurations)
    if ($node.isShippingLibrary -and $node.packageId) {
      if (!$packageConfigurations.ContainsKey([string] $node.packageId)) {
        $packageConfigurations.Add([string] $node.packageId, (New-CaseInsensitiveSet))
      }
      foreach ($configuration in $configurations) {
        $null = $packageConfigurations[$node.packageId].Add($configuration)
      }
    }
  }

  foreach ($edge in $Graph.configurationEdges) {
    $from = Get-ConfigurationKey $edge.fromProject $edge.fromTargetFramework
    $to = switch ($edge.kind) {
      'ProjectReference' { Get-ConfigurationKey $edge.to $edge.toTargetFramework }
      'PackageReference' { Get-PackageKey $edge.to }
      default { throw "Unsupported repository project graph edge kind '$($edge.kind)'." }
    }
    Add-AdjacencyValue $forward $from $to
    if ($edge.kind -ne 'ProjectReference' -or $edge.referenceOutputAssembly) {
      Add-AdjacencyValue $reverse $to $from
    }
    if ($edge.kind -eq 'ProjectReference') {
      Add-AdjacencyValue $projectForward $from $to
    }
  }

  # This is the production reverse-query boundary: a shipping package identity reaches every
  # concrete configuration of the physical project that produces it.
  foreach ($package in $packageConfigurations.Keys) {
    $packageKey = Get-PackageKey $package
    foreach ($configuration in $packageConfigurations[$package]) {
      Add-AdjacencyValue $reverse $packageKey $configuration
    }
  }

  return [pscustomobject][ordered]@{
    Graph = $Graph
    Nodes = $nodes
    ConfigurationsByProject = $configurationsByProject
    PackageConfigurations = $packageConfigurations
    Reverse = $reverse
    Forward = $forward
    ProjectForward = $projectForward
  }
}

function Get-Reachable($Adjacency, [string[]] $Seeds) {
  $visited = New-CaseInsensitiveSet
  $queue = [System.Collections.Generic.Queue[string]]::new()
  foreach ($seed in $Seeds) {
    if ($seed -and $visited.Add($seed)) { $queue.Enqueue($seed) }
  }
  while ($queue.Count -gt 0) {
    $current = $queue.Dequeue()
    if (!$Adjacency.ContainsKey($current)) { continue }
    foreach ($next in $Adjacency[$current]) {
      if ($visited.Add($next)) { $queue.Enqueue($next) }
    }
  }
  return ,$visited
}

function Test-ProjectReached($Model, $Reachable, [string] $ProjectPath) {
  if (!$Model.ConfigurationsByProject.ContainsKey($ProjectPath)) { return $false }
  foreach ($configuration in $Model.ConfigurationsByProject[$ProjectPath]) {
    if ($Reachable.Contains($configuration)) { return $true }
  }
  return $false
}

function Get-GraphDependencyRelation($Graph, [object[]] $PackageInfos) {
  if ($Graph.schemaVersion -ne 1) {
    throw "Unsupported repository project graph schema version '$($Graph.schemaVersion)'. Expected 1."
  }
  if (!$Graph.diagnostics.isComplete) {
    throw 'Repository project graph is incomplete.'
  }

  $model = New-DependencyGraphModel $Graph
  $relation = New-CaseInsensitiveSet
  foreach ($package in $PackageInfos) {
    if (!$model.PackageConfigurations.ContainsKey([string] $package.Name)) {
      throw "The repository project graph has no shipping project for production PackageInfo '$($package.Name)'."
    }
    $reachable = Get-Reachable $model.Reverse @((Get-PackageKey $package.Name))
    foreach ($root in $Graph.roots) {
      if (!(Test-ProjectReached $model $reachable $root)) { continue }
      $node = $model.Nodes[$root]
      if (!$node.isClientLibrary -or $node.isGeneratorLibrary) { continue }
      $packageRoot = Get-NormalizedPackageRoot $Graph.repositoryRoot $node.packageRoot
      $null = $relation.Add("$($package.Name)`t$packageRoot")
    }
  }
  return [pscustomobject][ordered]@{
    Relation = @(Get-SortedUniqueLines @($relation))
    Model = $model
  }
}

function Compare-DependencyRelations([string[]] $MSBuildProjectReferenceOracle, [string[]] $Graph) {
  $oracleSet = New-CaseInsensitiveSet
  $graphSet = New-CaseInsensitiveSet
  foreach ($line in $MSBuildProjectReferenceOracle) { $null = $oracleSet.Add($line) }
  foreach ($line in $Graph) { $null = $graphSet.Add($line) }
  return [pscustomobject][ordered]@{
    MSBuildProjectReferenceOracleOnly = @(Get-SortedUniqueLines @($oracleSet | Where-Object { !$graphSet.Contains($_) }))
    GraphOnly = @(Get-SortedUniqueLines @($graphSet | Where-Object { !$oracleSet.Contains($_) }))
  }
}

function Get-PackageInfoRootIndex([object[]] $PackageInfos) {
  $roots = New-CaseInsensitiveDictionary
  foreach ($package in $PackageInfos) {
    if ($roots.ContainsKey([string] $package.DirectoryPath)) {
      throw "PackageInfo directory '$($package.DirectoryPath)' does not map to exactly one object."
    }
    $roots.Add([string] $package.DirectoryPath, $package)
  }
  return ,$roots
}

function Convert-RelationToPackageInfoRelation([string[]] $Relation, [object[]] $PackageInfos) {
  $roots = Get-PackageInfoRootIndex $PackageInfos
  $mapped = New-CaseInsensitiveSet
  $unmapped = New-CaseInsensitiveSet
  foreach ($line in $Relation) {
    $parts = $line.Split("`t")
    if ($parts.Length -ne 2) { throw "Invalid dependency relation line: $line" }
    if ($roots.ContainsKey($parts[1])) {
      $package = $roots[$parts[1]]
      $null = $mapped.Add("$($parts[0])`t$($package.ArtifactName)`t$($package.DirectoryPath)")
    } else {
      $null = $unmapped.Add($line)
    }
  }
  return [pscustomobject][ordered]@{
    Mapped = @(Get-SortedUniqueLines @($mapped))
    Unmapped = @(Get-SortedUniqueLines @($unmapped))
  }
}

function Get-IndirectPackageInfoSelection(
  [string[]] $Relation,
  [object[]] $PackageInfos,
  [string[]] $ChangedPackageNames) {
  $changed = New-CaseInsensitiveSet
  foreach ($name in $ChangedPackageNames) { if ($name) { $null = $changed.Add($name) } }
  if ($changed.Count -eq 0) { return @() }

  $selectedRoots = New-CaseInsensitiveSet
  foreach ($line in $Relation) {
    $parts = $line.Split("`t")
    if ($parts.Length -ne 2) { throw "Invalid dependency relation line: $line" }
    if ($changed.Contains($parts[0])) { $null = $selectedRoots.Add($parts[1]) }
  }

  $roots = Get-PackageInfoRootIndex $PackageInfos
  $selected = [System.Collections.Generic.List[object]]::new()
  foreach ($root in @(Get-SortedUniqueLines @($selectedRoots))) {
    if (!$roots.ContainsKey($root)) { continue }
    $package = $roots[$root]
    # Language-Settings compares the PackageInfo object against LocatedPackages before adding it.
    if ($changed.Contains([string] $package.Name)) { continue }
    $selected.Add([pscustomobject][ordered]@{
      Name = [string] $package.Name
      ArtifactName = [string] $package.ArtifactName
      DirectoryPath = [string] $package.DirectoryPath
      IncludedForValidation = $true
    })
  }
  return $selected.ToArray()
}

function Read-DependencyProvenance([string] $RecordsPath, [string] $PackageRecordsPath, $Model) {
  $directPackages = New-CaseInsensitiveDictionary
  $transitivePackages = New-CaseInsensitiveDictionary
  $directPackageIdentities = New-CaseInsensitiveSet
  $transitivePackageIdentities = New-CaseInsensitiveSet
  $p2pPackageIdentities = New-CaseInsensitiveSet
  $nugetOnlyIdentities = New-CaseInsensitiveSet

  foreach ($edge in $Model.Graph.configurationEdges | Where-Object { $_.kind -eq 'ProjectReference' }) {
    if ($Model.Nodes.ContainsKey([string] $edge.to)) {
      $node = $Model.Nodes[$edge.to]
      if ($node.isShippingLibrary -and $node.packageId) { $null = $p2pPackageIdentities.Add([string] $node.packageId) }
    }
  }

  foreach ($line in [System.IO.File]::ReadLines($RecordsPath)) {
    if (!$line.StartsWith('PackageReference|', [System.StringComparison]::Ordinal)) { continue }
    $parts = $line.Split('|')
    if ($parts.Length -lt 4) { throw "Invalid PackageReference record: $line" }
    $project = Get-RelativePath $Model.Graph.repositoryRoot $parts[1]
    $configuration = Get-ConfigurationKey $project $parts[2]
    if (!$directPackages.ContainsKey($configuration)) {
      $directPackages.Add($configuration, (New-CaseInsensitiveSet))
    }
    $null = $directPackages[$configuration].Add($parts[3])
    $null = $directPackageIdentities.Add($parts[3])
  }

  foreach ($line in [System.IO.File]::ReadLines($PackageRecordsPath)) {
    if (!$line.StartsWith('TransitivePackageReference|', [System.StringComparison]::Ordinal)) { continue }
    $parts = $line.Split('|')
    if ($parts.Length -lt 4) { throw "Invalid TransitivePackageReference record: $line" }
    $project = Get-RelativePath $Model.Graph.repositoryRoot $parts[1]
    $configuration = Get-ConfigurationKey $project $parts[2]
    if (!$transitivePackages.ContainsKey($configuration)) {
      $transitivePackages.Add($configuration, (New-CaseInsensitiveSet))
    }
    $null = $transitivePackages[$configuration].Add($parts[3])
    $null = $transitivePackageIdentities.Add($parts[3])
  }

  # NuGet-only means the package reaches a specific project/TFM only through the flattened
  # TransitivePackageReference records. The same identity may legitimately be direct elsewhere.
  foreach ($configuration in $transitivePackages.Keys) {
    foreach ($package in $transitivePackages[$configuration]) {
      if (!$directPackages.ContainsKey($configuration) -or
          !$directPackages[$configuration].Contains($package)) {
        $null = $nugetOnlyIdentities.Add($package)
      }
    }
  }
  return [pscustomobject][ordered]@{
    DirectPackages = $directPackages
    TransitivePackages = $transitivePackages
    DirectPackageIdentities = $directPackageIdentities
    TransitivePackageIdentities = $transitivePackageIdentities
    P2PPackageIdentities = $p2pPackageIdentities
    NuGetOnlyIdentities = @(Get-SortedUniqueLines @($nugetOnlyIdentities))
  }
}

function Get-RootProjectConfigurations($Model, [string] $PackageRoot) {
  $seeds = [System.Collections.Generic.List[string]]::new()
  foreach ($root in $Model.Graph.roots) {
    $node = $Model.Nodes[$root]
    if (!$node.isClientLibrary -or $node.isGeneratorLibrary) { continue }
    $rootPath = Get-NormalizedPackageRoot $Model.Graph.repositoryRoot $node.packageRoot
    if (![System.StringComparer]::OrdinalIgnoreCase.Equals($rootPath, $PackageRoot)) { continue }
    foreach ($configuration in $Model.ConfigurationsByProject[$root]) { $seeds.Add($configuration) }
  }
  return $seeds.ToArray()
}

function Get-MismatchClassification(
  [string] $RelationLine,
  $Model,
  $Provenance) {
  $parts = $RelationLine.Split("`t")
  if ($parts.Length -ne 2) { throw "Invalid dependency relation line: $RelationLine" }
  $package = $parts[0]
  $seeds = Get-RootProjectConfigurations $Model $parts[1]
  $reachable = Get-Reachable $Model.ProjectForward $seeds

  if ($Model.PackageConfigurations.ContainsKey($package)) {
    foreach ($configuration in $Model.PackageConfigurations[$package]) {
      if ($reachable.Contains($configuration)) { return 'direct-p2p' }
    }
  }
  foreach ($configuration in $reachable) {
    if ($Provenance.DirectPackages.ContainsKey($configuration) -and
        $Provenance.DirectPackages[$configuration].Contains($package)) {
      return 'direct-repository-package-reference'
    }
  }
  foreach ($configuration in $reachable) {
    if ($Provenance.TransitivePackages.ContainsKey($configuration) -and
        $Provenance.TransitivePackages[$configuration].Contains($package)) {
      return 'nuget-derived-transitive-package-reference'
    }
  }
  return 'unclassified'
}

function Get-MismatchClassifications($Comparison, $Model, $Provenance) {
  $result = [System.Collections.Generic.List[string]]::new()
  foreach ($side in @('MSBuildProjectReferenceOracleOnly', 'GraphOnly')) {
    foreach ($line in $Comparison.$side) {
      $classification = Get-MismatchClassification $line $Model $Provenance
      $result.Add("$side`t$classification`t$line")
    }
  }
  return [string[]]@(Get-SortedUniqueLines @($result))
}

function Get-FileHashValue([string] $Path) {
  return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Format-CommandLine([string] $FilePath, [string[]] $ArgumentList) {
  $formatted = foreach ($argument in $ArgumentList) {
    if ($argument -match '[\s"]') { '"' + $argument.Replace('"', '\"') + '"' } else { $argument }
  }
  return "$FilePath $($formatted -join ' ')"
}

function Invoke-LoggedNativeCommand(
  [string] $Name,
  [string] $FilePath,
  [string[]] $ArgumentList,
  [string] $LogPath) {
  $commandLine = Format-CommandLine $FilePath $ArgumentList
  Write-Host "[$Name] $commandLine"
  $parent = Split-Path -Parent $LogPath
  if ($parent) { New-Item -ItemType Directory -Path $parent -Force | Out-Null }
  $stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  & $FilePath @ArgumentList 2>&1 |
    Tee-Object -FilePath $LogPath |
    ForEach-Object { Write-Host $_ }
  $exitCode = $LASTEXITCODE
  $stopwatch.Stop()
  $result = [pscustomobject][ordered]@{
    name = $Name
    command = $commandLine
    elapsedSeconds = [Math]::Round($stopwatch.Elapsed.TotalSeconds, 3)
    exitCode = $exitCode
    logPath = $LogPath
  }
  if ($exitCode -ne 0) {
    throw "Validation command '$Name' failed with exit code $exitCode. See '$LogPath'."
  }
  return $result
}

function Get-LoggedPeakWorkingSet([string] $LogPath) {
  $values = [System.Collections.Generic.List[double]]::new()
  foreach ($line in [System.IO.File]::ReadLines($LogPath)) {
    foreach ($match in [regex]::Matches($line, '(?:processPeak|peakWorkingSet)=([0-9.]+)MiB')) {
      $values.Add([double]::Parse($match.Groups[1].Value, [System.Globalization.CultureInfo]::InvariantCulture))
    }
  }
  if ($values.Count -eq 0) { return $null }
  return ($values | Measure-Object -Maximum).Maximum
}

function Assert-ValidationCondition([bool] $Condition, [string] $Message) {
  if (!$Condition) { throw $Message }
}

function Test-CanonicalGraphContract(
  $Graph,
  [string] $RecordsPath,
  [string] $PackageRecordsPath,
  [string] $RepositoryRoot,
  [string] $SourceCommit) {
  $root = Normalize-AbsolutePath $RepositoryRoot
  Assert-ValidationCondition ($Graph.schemaVersion -eq 1) 'Canonical graph schema must be 1.'
  Assert-ValidationCondition ($Graph.sourceCommit -eq $SourceCommit) 'Canonical graph source commit is stale.'
  Assert-ValidationCondition (
    [System.StringComparer]::OrdinalIgnoreCase.Equals(
      (Normalize-AbsolutePath $Graph.repositoryRoot), $root)) 'Canonical graph repository root is incorrect.'
  Assert-ValidationCondition $Graph.diagnostics.isComplete 'Canonical graph diagnostics are incomplete.'
  Assert-ValidationCondition $Graph.diagnostics.configurationGraph.isExact 'Canonical configuration graph is inferred.'
  Assert-ValidationCondition $Graph.diagnostics.checkoutRoots.isComplete 'Canonical checkout roots are incomplete.'
  Assert-ValidationCondition ($Graph.diagnostics.generation.configuration -eq 'Debug') 'Canonical graph was not generated in Debug.'
  Assert-ValidationCondition $Graph.diagnostics.generation.includesInputCheckoutRoots 'Canonical graph omits evaluated input checkout roots.'
  Assert-ValidationCondition (
    $Graph.diagnostics.packageClosure.restoreEquivalent -eq $false) 'Canonical package closure incorrectly claims restore equivalence.'
  Assert-ValidationCondition (
    $Graph.diagnostics.packageClosure.unresolvedRootCount -eq 0) 'Canonical graph contains unresolved NuGet roots.'

  foreach ($diagnostic in @(
      'duplicatePackageIds', 'missingProjectReferences', 'missingDeclaredProjects',
      'rootsWithoutNodes', 'nodeMetadataConflicts')) {
    Assert-ValidationCondition (@($Graph.diagnostics.$diagnostic).Count -eq 0) "Canonical graph diagnostic '$diagnostic' is non-empty."
  }
  Assert-ValidationCondition (
    @($Graph.diagnostics.configurationGraph.inferredProjectReferences).Count -eq 0) 'Canonical graph contains inferred project-reference configurations.'
  Assert-ValidationCondition (
    @($Graph.diagnostics.configurationGraph.missingReferences).Count -eq 0) 'Canonical graph contains missing configuration references.'

  $nodePaths = New-CaseInsensitiveSet
  $configurationKeys = New-CaseInsensitiveSet
  $shippingPackages = New-CaseInsensitiveSet
  foreach ($node in $Graph.nodes) {
    Assert-ValidationCondition ($nodePaths.Add([string] $node.projectPath)) "Duplicate graph node '$($node.projectPath)'."
    Assert-ValidationCondition (@($node.targetFrameworks).Count -gt 0) "Graph node '$($node.projectPath)' has no target frameworks."
    foreach ($targetFramework in $node.targetFrameworks) {
      Assert-ValidationCondition (![string]::IsNullOrWhiteSpace([string] $targetFramework)) "Graph node '$($node.projectPath)' has an empty target framework."
      Assert-ValidationCondition (
        $configurationKeys.Add((Get-ConfigurationKey $node.projectPath $targetFramework))) "Duplicate graph configuration '$($node.projectPath)|$targetFramework'."
    }
    if ($node.isShippingLibrary -and $node.packageId) {
      Assert-ValidationCondition ($shippingPackages.Add([string] $node.packageId)) "Duplicate shipping package identity '$($node.packageId)'."
    }
  }
  Assert-ValidationCondition ($nodePaths.Count -eq $Graph.diagnostics.projectCount) 'Graph project diagnostic count is inconsistent.'
  Assert-ValidationCondition ($configurationKeys.Count -eq $Graph.diagnostics.configurationCount) 'Graph configuration diagnostic count is inconsistent.'

  $sourceKinds = [ordered]@{}
  $sourceRecords = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
  $declaredProjects = New-CaseInsensitiveSet
  $declaredRoots = New-CaseInsensitiveSet
  $sourceProjectReferences = 0
  $sourceNonAssemblyProjectReferences = 0
  foreach ($line in [System.IO.File]::ReadLines($RecordsPath)) {
    Assert-ValidationCondition (![string]::IsNullOrWhiteSpace($line)) 'Source record file contains a blank record.'
    Assert-ValidationCondition ($sourceRecords.Add($line)) "Source record file contains duplicate record '$line'."
    $parts = $line.Split('|')
    $expectedFields = switch ($parts[0]) {
      'GraphGeneration' { 3 }
      'Node' { 16 }
      'ProjectReference' { 9 }
      'PackageReference' { 8 }
      'CheckoutRoot' { 4 }
      'Root' { 2 }
      'DeclaredProject' { 2 }
      default { throw "Unknown source record kind in '$line'." }
    }
    Assert-ValidationCondition ($parts.Length -eq $expectedFields) "Invalid source record field count in '$line'."
    if (!$sourceKinds.Contains($parts[0])) { $sourceKinds[$parts[0]] = 0 }
    $sourceKinds[$parts[0]]++
    switch ($parts[0]) {
      'DeclaredProject' { $null = $declaredProjects.Add((Get-RelativePath $root $parts[1])) }
      'Root' { $null = $declaredRoots.Add((Get-RelativePath $root $parts[1])) }
      'ProjectReference' {
        $sourceProjectReferences++
        Assert-ValidationCondition (![string]::IsNullOrWhiteSpace($parts[8])) "ProjectReference has no concrete destination TFM: '$line'."
        if ($parts[4] -eq 'false') { $sourceNonAssemblyProjectReferences++ }
      }
      'CheckoutRoot' {
        Assert-ValidationCondition ($parts[3] -match '^/sdk/[^/]+/\*$') "Unsupported checkout root '$($parts[3])'."
        Assert-ValidationCondition (!$parts[3].StartsWith('/artifacts/', [System.StringComparison]::OrdinalIgnoreCase)) "Generated artifact root was serialized: '$line'."
      }
    }
  }
  Assert-ValidationCondition (!$sourceKinds.Contains('Input')) 'Exact input records must not be serialized.'
  foreach ($project in $declaredProjects) {
    Assert-ValidationCondition ($nodePaths.Contains($project)) "Declared project '$project' has no graph node."
  }
  foreach ($project in $declaredRoots) {
    Assert-ValidationCondition ($nodePaths.Contains($project)) "Declared root '$project' has no graph node."
  }
  Assert-ValidationCondition ($declaredRoots.Count -eq @($Graph.roots).Count) 'Serialized root count is inconsistent.'

  $packageKinds = [ordered]@{}
  $packageRecords = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
  $summary = $null
  $summaryCount = 0
  $transitiveCount = 0
  $unresolvedCount = 0
  foreach ($line in [System.IO.File]::ReadLines($PackageRecordsPath)) {
    Assert-ValidationCondition (![string]::IsNullOrWhiteSpace($line)) 'Package record file contains a blank record.'
    Assert-ValidationCondition ($packageRecords.Add($line)) "Package record file contains duplicate record '$line'."
    $parts = $line.Split('|')
    switch ($parts[0]) {
      'TransitivePackageReference' {
        Assert-ValidationCondition ($parts.Length -eq 4) "Invalid transitive package record '$line'."
        $transitiveCount++
      }
      'UnresolvedPackageClosure' {
        Assert-ValidationCondition ($parts.Length -eq 6) "Invalid unresolved package record '$line'."
        $unresolvedCount++
      }
      'PackageClosureSummary' {
        Assert-ValidationCondition ($parts.Length -eq 10) "Invalid package closure summary '$line'."
        $summary = $parts
        $summaryCount++
      }
      default { throw "Unknown package record kind in '$line'." }
    }
    if (!$packageKinds.Contains($parts[0])) { $packageKinds[$parts[0]] = 0 }
    $packageKinds[$parts[0]]++
  }
  Assert-ValidationCondition ($summaryCount -eq 1) 'Package record file must contain exactly one summary.'
  Assert-ValidationCondition ([int] $summary[3] -eq $transitiveCount) 'Package closure derived-edge count is inconsistent.'
  Assert-ValidationCondition ([int] $summary[4] -eq $unresolvedCount) 'Package closure unresolved-root count is inconsistent.'
  Assert-ValidationCondition ([int] $summary[1] -eq ([int] $summary[2] + [int] $summary[4])) 'Package closure root count is inconsistent.'
  Assert-ValidationCondition $Graph.diagnostics.packageClosureSummaryConsistent 'Canonical package closure summary is inconsistent.'

  $model = New-DependencyGraphModel $Graph
  $canonicalProjectReferences = 0
  $canonicalNonAssemblyProjectReferences = 0
  foreach ($edge in $Graph.configurationEdges) {
    $from = Get-ConfigurationKey $edge.fromProject $edge.fromTargetFramework
    Assert-ValidationCondition ($configurationKeys.Contains($from)) "Configuration edge has unknown source '$from'."
    $to = switch ($edge.kind) {
      'ProjectReference' {
        $canonicalProjectReferences++
        Assert-ValidationCondition (
          $edge.PSObject.Properties.Name -contains 'referenceOutputAssembly') "ProjectReference edge omits referenceOutputAssembly."
        if (!$edge.referenceOutputAssembly) { $canonicalNonAssemblyProjectReferences++ }
        Get-ConfigurationKey $edge.to $edge.toTargetFramework
      }
      'PackageReference' {
        Assert-ValidationCondition ($shippingPackages.Contains([string] $edge.to)) "Package edge has non-repository destination '$($edge.to)'."
        Get-PackageKey $edge.to
      }
      default { throw "Unsupported canonical edge kind '$($edge.kind)'." }
    }
    if ($edge.kind -eq 'ProjectReference') {
      Assert-ValidationCondition ($configurationKeys.Contains($to)) "ProjectReference has unknown destination '$to'."
    }
    Assert-ValidationCondition (
      $model.Forward.ContainsKey($from) -and $model.Forward[$from].Contains($to)) "Forward index omits '$from' -> '$to'."
    $expectReverse = $edge.kind -ne 'ProjectReference' -or $edge.referenceOutputAssembly
    $hasReverse = $model.Reverse.ContainsKey($to) -and $model.Reverse[$to].Contains($from)
    Assert-ValidationCondition ($hasReverse -eq $expectReverse) "Reverse index is inconsistent for '$from' -> '$to'."
  }
  Assert-ValidationCondition ($canonicalProjectReferences -eq $sourceProjectReferences) 'Canonical graph omitted a source ProjectReference.'
  Assert-ValidationCondition ($canonicalNonAssemblyProjectReferences -eq $sourceNonAssemblyProjectReferences) 'Canonical non-assembly ProjectReference count is inconsistent.'
  Assert-ValidationCondition (@($Graph.configurationEdges).Count -eq $Graph.diagnostics.configurationEdgeCount) 'Graph edge diagnostic count is inconsistent.'
  Assert-ValidationCondition (@($Graph.checkoutRoots.PSObject.Properties).Count -eq $Graph.diagnostics.checkoutRoots.configurationCount) 'Checkout-root configuration count is inconsistent.'
  $checkoutRootCount = 0
  foreach ($property in $Graph.checkoutRoots.PSObject.Properties) {
    Assert-ValidationCondition ($configurationKeys.Contains($property.Name)) "Checkout roots reference unknown configuration '$($property.Name)'."
    foreach ($checkoutRoot in @($property.Value)) {
      Assert-ValidationCondition ($checkoutRoot -match '^/sdk/[^/]+/\*$') "Canonical graph contains unsupported checkout root '$checkoutRoot'."
      $checkoutRootCount++
    }
  }
  Assert-ValidationCondition ($checkoutRootCount -eq $Graph.diagnostics.checkoutRoots.rootCount) 'Checkout-root diagnostic count is inconsistent.'

  return [pscustomobject][ordered]@{
    sourceRecordCount = $sourceRecords.Count
    sourceRecordKinds = $sourceKinds
    packageRecordCount = $packageRecords.Count
    packageRecordKinds = $packageKinds
    declaredProjectCount = $declaredProjects.Count
    sourceProjectReferenceCount = $sourceProjectReferences
    nonAssemblyProjectReferenceCount = $sourceNonAssemblyProjectReferences
    shippingPackageCount = $shippingPackages.Count
    checkoutRootCount = $checkoutRootCount
    queryIndexEdgeChecks = @($Graph.configurationEdges).Count
  }
}

function Test-LanguageSettingsUnionSemantics([string[]] $Relation, [object[]] $PackageInfos) {
  $sets = [System.Collections.Generic.List[object]]::new()
  if ($PackageInfos.Count -gt 0) { $sets.Add(@([string] $PackageInfos[0].Name)) }
  if ($PackageInfos.Count -gt 2) { $sets.Add(@([string] $PackageInfos[0].Name, [string] $PackageInfos[2].Name)) }
  $sample = [System.Collections.Generic.List[string]]::new()
  for ($index = 0; $index -lt $PackageInfos.Count; $index += 17) {
    $sample.Add([string] $PackageInfos[$index].Name)
  }
  $sets.Add($sample.ToArray())

  $rootIndex = Get-PackageInfoRootIndex $PackageInfos
  foreach ($changedNames in $sets) {
    $changed = New-CaseInsensitiveSet
    foreach ($name in $changedNames) { $null = $changed.Add($name) }
    $expected = New-CaseInsensitiveSet
    foreach ($line in $Relation) {
      $parts = $line.Split("`t")
      if (!$changed.Contains($parts[0]) -or !$rootIndex.ContainsKey($parts[1])) { continue }
      $dependent = $rootIndex[$parts[1]]
      if (!$changed.Contains([string] $dependent.Name) -and !$expected.Add([string] $dependent.Name)) { }
    }
    $actual = @(Get-IndirectPackageInfoSelection $Relation $PackageInfos $changedNames)
    $actualNames = New-CaseInsensitiveSet
    foreach ($package in $actual) {
      Assert-ValidationCondition $package.IncludedForValidation "Indirect package '$($package.Name)' was not marked IncludedForValidation=true."
      Assert-ValidationCondition (!$changed.Contains([string] $package.Name)) "Direct package '$($package.Name)' was duplicated as indirect."
      Assert-ValidationCondition ($actualNames.Add([string] $package.Name)) "Indirect package '$($package.Name)' was duplicated."
    }
    Assert-ValidationCondition (
      $actualNames.SetEquals($expected)) "Language-Settings union mapping differs for '$($changedNames -join ', ')'."
  }
  Assert-ValidationCondition (
    @($PackageInfos | Where-Object IncludedForValidation).Count -eq 0) 'Validation mapping mutated a direct PackageInfo object.'
  return $sets.Count
}

function Invoke-DependencyRelationValidation(
  [string] $RepositoryRoot,
  [string] $ValidationRoot,
  [bool] $ReuseGraph = $false) {
  $validationStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $repositoryRoot = Normalize-AbsolutePath $RepositoryRoot
  $validationRoot = Normalize-AbsolutePath $ValidationRoot
  $sourceDirectory = Join-Path $validationRoot 'source'
  $relationDirectory = Join-Path $validationRoot 'dependency-relation'
  $packageInfoDirectory = Join-Path $relationDirectory 'package-info'
  $graphPath = Join-Path $sourceDirectory 'repository-project-graph.reader.json'
  $recordsPath = "$graphPath.records"
  $packageRecordsPath = "$graphPath.packages.records"
  $restoreDirectory = Join-Path $sourceDirectory 'nuget-restore'
  $oracleRawPath = Join-Path $relationDirectory 'msbuild-project-reference-oracle.raw.records'
  $provenancePath = Join-Path $relationDirectory 'provenance.json'

  # Validation evidence is commit- and host-specific. Remove only this validator-owned output so
  # no PackageInfo, graph, restore, or relation data can be inherited from an earlier run.
  if (!$ReuseGraph -and (Test-Path -LiteralPath $validationRoot)) {
    Remove-Item -LiteralPath $validationRoot -Recurse -Force
  }
  New-Item -ItemType Directory -Path $sourceDirectory, $relationDirectory -Force | Out-Null

  $commands = [System.Collections.Generic.List[object]]::new()
  $sourceCommit = (& git -C $repositoryRoot rev-parse HEAD).Trim()
  if ($LASTEXITCODE -ne 0 -or !$sourceCommit) { throw 'Unable to read the source commit.' }
  $previousProvenance = $null
  if ($ReuseGraph) {
    foreach ($path in @($graphPath, $recordsPath, $packageRecordsPath, $provenancePath, $packageInfoDirectory)) {
      if (!(Test-Path -LiteralPath $path)) {
        throw "Cannot reuse validation input because '$path' does not exist."
      }
    }
    $previousProvenance = Get-Content -Raw -LiteralPath $provenancePath | ConvertFrom-Json -Depth 100
    if ($previousProvenance.sourceCommit -ne $sourceCommit) {
      throw "Cannot reuse validation input for source commit '$($previousProvenance.sourceCommit)' at '$sourceCommit'."
    }
  }

  # Generate the identity universe through the same production script that creates PackageInfo
  # for matrix generation. Its JSON output therefore includes the final DirectoryPath semantics.
  $packageInfoLog = Join-Path $relationDirectory 'package-info.log'
  if ($ReuseGraph) {
    $commands.Add(($previousProvenance.commands | Where-Object name -eq 'package-info-discovery' | Select-Object -First 1))
  } else {
    $commands.Add((Invoke-LoggedNativeCommand 'package-info-discovery' 'pwsh' @(
      '-NoProfile', '-NonInteractive', '-File',
      (Join-Path $repositoryRoot 'eng/common/scripts/Save-Package-Properties.ps1'),
      '-outDirectory', $packageInfoDirectory
    ) $packageInfoLog))
  }
  $packageInfoReadStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $packageInfos = @(Get-PackageInfoUniverse $packageInfoDirectory $repositoryRoot)
  $packageInfoReadStopwatch.Stop()
  Write-Utf8Lines (Join-Path $relationDirectory 'package-universe.tsv') @(
    $packageInfos | ForEach-Object {
      "$($_.Name)`t$($_.ArtifactName)`t$($_.DirectoryPath)`t$($_.IncludedForValidation)"
    })

  # Validation-only oracle: one standard ResolveReferences traversal captures the established
  # ProjectDependsOn dependency-selection semantics for every candidate and inner TFM. Package
  # identity intersection happens only after the complete ReferencePath relation is collected.
  $oracleLog = Join-Path $relationDirectory 'msbuild-project-reference-oracle.log'
  $collectorTargets = Join-Path $repositoryRoot 'eng/tools/RepositoryProjectGraph/CollectMSBuildProjectReferenceOracle.targets'
  $commands.Add((Invoke-LoggedNativeCommand 'msbuild-project-reference-oracle' 'dotnet' @(
    'build', '/nologo', '/nr:false', '/tl:off',
    '/t:CollectRepositoryDependencyRelationWithMSBuildProjectReferenceOracle',
    (Join-Path $repositoryRoot 'eng/service.proj'),
    "/p:CustomAfterTraversalTargets=$collectorTargets",
    '/p:IncludeSrc=false', '/p:IncludeStress=false', '/p:IncludeSamples=false',
    '/p:IncludePerf=false', '/p:RunApiCompat=false', '/p:InheritDocEnabled=false',
    '/p:BuildProjectReferences=false', "/p:OutputProjectFilePath=$oracleRawPath"
  ) $oracleLog))
  $oracleRelationStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $oracle = Convert-MSBuildProjectReferenceOracleRecordsToRelation $oracleRawPath $packageInfos $repositoryRoot
  Write-Utf8Lines (Join-Path $relationDirectory 'msbuild-project-reference-oracle-records.tsv') $oracle.RawRecords
  $oracleRelationStopwatch.Stop()

  # Generate into a validator-owned source directory. Both line-record files, synthetic restore
  # output, and canonical JSON are fresh for this invocation rather than reused from artifacts/obj.
  $graphLog = Join-Path $sourceDirectory 'graph-generation.log'
  if ($ReuseGraph) {
    $commands.Add(($previousProvenance.commands | Where-Object name -eq 'repository-project-graph' | Select-Object -First 1))
  } else {
    $commands.Add((Invoke-LoggedNativeCommand 'repository-project-graph' 'dotnet' @(
      'msbuild', '/m', '/nr:false', '/nologo', '/tl:off',
      '/t:GenerateRepositoryProjectGraphWithProjectGraph',
      (Join-Path $repositoryRoot 'eng/service.proj'),
      '/p:IncludeRepositoryProjectGraphInputCheckoutRoots=true',
      '/p:IncludeSrc=false', '/p:IncludeSamples=false', '/p:IncludePerf=false',
      '/p:IncludeStress=false', '/p:RunApiCompat=false', '/p:InheritDocEnabled=false',
      '/p:BuildProjectReferences=false',
      "/p:RepositoryProjectGraphReaderPath=$graphPath",
      "/p:RepositoryProjectGraphReaderRecordsPath=$recordsPath",
      "/p:RepositoryProjectGraphPackageRecordsPath=$packageRecordsPath",
      "/p:RepositoryProjectGraphNuGetRestoreDirectory=$restoreDirectory"
    ) $graphLog))
  }

  $graphReadStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $graph = Get-Content -Raw -LiteralPath $graphPath | ConvertFrom-Json -Depth 100
  $graphReadStopwatch.Stop()
  if ($graph.sourceCommit -ne $sourceCommit) {
    throw "Graph source commit '$($graph.sourceCommit)' does not match '$sourceCommit'."
  }
  if (!$graph.diagnostics.isComplete -or !$graph.diagnostics.configurationGraph.isExact) {
    throw 'Fresh repository graph is incomplete or contains inferred configuration edges.'
  }
  if ($graph.diagnostics.packageClosure.unresolvedRootCount -ne 0) {
    throw 'Fresh repository graph does not have a complete NuGet restore-graph closure.'
  }
  if (!$graph.diagnostics.checkoutRoots.isComplete) {
    throw 'Fresh repository graph checkout-root diagnostics are incomplete.'
  }

  $canonicalValidationStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $canonicalValidation = Test-CanonicalGraphContract `
    $graph $recordsPath $packageRecordsPath $repositoryRoot $sourceCommit
  $canonicalValidationStopwatch.Stop()
  $canonicalValidation | ConvertTo-Json -Depth 100 |
    Set-Content -LiteralPath (Join-Path $sourceDirectory 'canonical-validation.json') -Encoding utf8

  $graphRelationStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $graphRelation = Get-GraphDependencyRelation $graph $packageInfos
  $graphRelationStopwatch.Stop()
  $comparisonStopwatch = [System.Diagnostics.Stopwatch]::StartNew()
  $comparison = Compare-DependencyRelations $oracle.Relation $graphRelation.Relation
  $dependencyProvenance = Read-DependencyProvenance $recordsPath $packageRecordsPath $graphRelation.Model
  $classifications = Get-MismatchClassifications $comparison $graphRelation.Model $dependencyProvenance
  $comparisonStopwatch.Stop()

  $oraclePath = Join-Path $relationDirectory 'msbuild-project-reference-oracle.tsv'
  $graphRelationPath = Join-Path $relationDirectory 'graph.tsv'
  $oracleOnlyPath = Join-Path $relationDirectory 'msbuild-project-reference-oracle-only.tsv'
  $graphOnlyPath = Join-Path $relationDirectory 'graph-only.tsv'
  Write-Utf8Lines $oraclePath $oracle.Relation
  Write-Utf8Lines $graphRelationPath $graphRelation.Relation
  Write-Utf8Lines $oracleOnlyPath $comparison.MSBuildProjectReferenceOracleOnly
  Write-Utf8Lines $graphOnlyPath $comparison.GraphOnly
  Write-Utf8Lines (Join-Path $relationDirectory 'mismatch-classification.tsv') $classifications
  Write-Utf8Lines (Join-Path $relationDirectory 'nuget-only-identities.tsv') $dependencyProvenance.NuGetOnlyIdentities

  # Map both root relations through the production PackageInfo universe. This is the final
  # Language-Settings boundary: unmapped roots are skipped, direct packages are not duplicated,
  # and every emitted indirect object receives IncludedForValidation=true.
  $oraclePackageInfo = Convert-RelationToPackageInfoRelation $oracle.Relation $packageInfos
  $graphPackageInfo = Convert-RelationToPackageInfoRelation $graphRelation.Relation $packageInfos
  Write-Utf8Lines (Join-Path $relationDirectory 'msbuild-project-reference-oracle-package-info.tsv') $oraclePackageInfo.Mapped
  Write-Utf8Lines (Join-Path $relationDirectory 'graph-package-info.tsv') $graphPackageInfo.Mapped
  Write-Utf8Lines (Join-Path $relationDirectory 'msbuild-project-reference-oracle-unmapped-package-roots.tsv') $oraclePackageInfo.Unmapped
  Write-Utf8Lines (Join-Path $relationDirectory 'graph-unmapped-package-roots.tsv') $graphPackageInfo.Unmapped
  $mappedComparison = Compare-DependencyRelations $oraclePackageInfo.Mapped $graphPackageInfo.Mapped
  $unmappedComparison = Compare-DependencyRelations $oraclePackageInfo.Unmapped $graphPackageInfo.Unmapped

  $directExclusionFailures = [System.Collections.Generic.List[string]]::new()
  foreach ($package in $packageInfos) {
    $selected = @(Get-IndirectPackageInfoSelection $graphRelation.Relation $packageInfos @($package.Name))
    if (@($selected | Where-Object { $_.Name -eq $package.Name }).Count -gt 0 -or
        @($selected | Where-Object { !$_.IncludedForValidation }).Count -gt 0) {
      $directExclusionFailures.Add([string] $package.Name)
    }
  }
  $unionMappingChecks = Test-LanguageSettingsUnionSemantics $graphRelation.Relation $packageInfos

  $classificationCounts = [ordered]@{}
  foreach ($classification in $classifications) {
    $kind = $classification.Split("`t")[1]
    if (!$classificationCounts.Contains($kind)) { $classificationCounts[$kind] = 0 }
    $classificationCounts[$kind]++
  }
  $targetFrameworks = @($graph.nodes.targetFrameworks | Sort-Object -Unique)
  $shippingPackages = @($graph.nodes | Where-Object { $_.isShippingLibrary -and $_.packageId })
  $trackedChanges = @(& git -C $repositoryRoot status --porcelain=v1 --untracked-files=all)
  $dotnetInfo = @(& dotnet --info)
  $provenance = [ordered]@{
    validationGoal = 1
    result = if ($comparison.MSBuildProjectReferenceOracleOnly.Count -eq 0 -and $comparison.GraphOnly.Count -eq 0 -and
      $mappedComparison.MSBuildProjectReferenceOracleOnly.Count -eq 0 -and $mappedComparison.GraphOnly.Count -eq 0 -and
      $unmappedComparison.MSBuildProjectReferenceOracleOnly.Count -eq 0 -and $unmappedComparison.GraphOnly.Count -eq 0 -and
      $directExclusionFailures.Count -eq 0) { 'proven' } else { 'mismatch' }
    sourceCommit = $sourceCommit
    repositoryRoot = $repositoryRoot
    trackedWorktreeState = $trackedChanges
    host = [ordered]@{
      osDescription = [System.Runtime.InteropServices.RuntimeInformation]::OSDescription
      osArchitecture = [System.Runtime.InteropServices.RuntimeInformation]::OSArchitecture.ToString()
      processArchitecture = [System.Runtime.InteropServices.RuntimeInformation]::ProcessArchitecture.ToString()
      dotnetSdk = (& dotnet --version).Trim()
      dotnetInfo = $dotnetInfo
    }
    policy = [ordered]@{
      configuration = 'Debug'
      referenceMode = 'package'
      includeSrc = $false
      includeSamples = $false
      includePerf = $false
      includeStress = $false
      runApiCompat = $false
      inheritDocEnabled = $false
      buildProjectReferences = $false
      packageRootOnly = $true
      oracleName = 'MSBuildProjectReferenceOracle'
      oracleIdentity = 'ReferencePath.Filename'
      oracleScope = 'validation-only'
      packageInfoDiscovery = 'eng/common/scripts/Save-Package-Properties.ps1 -> Get-AllPkgProperties -> Get-AllPackageInfoFromRepo -> service.proj:GetPackageInfo'
    }
    counts = [ordered]@{
      graphProjects = [int] $graph.diagnostics.projectCount
      graphConfigurations = [int] $graph.diagnostics.configurationCount
      graphConfigurationEdges = [int] $graph.diagnostics.configurationEdgeCount
      graphRoots = @($graph.roots).Count
      graphCheckoutRoots = [int] $graph.diagnostics.checkoutRoots.rootCount
      graphShippingPackages = $shippingPackages.Count
      productionPackageInfos = $packageInfos.Count
      nugetRoots = [int] $graph.diagnostics.packageClosure.rootCount
      nugetResolvedRoots = [int] $graph.diagnostics.packageClosure.resolvedRootCount
      nugetDerivedEdges = [int] $graph.diagnostics.packageClosure.derivedEdgeCount
      nugetUnresolvedRoots = [int] $graph.diagnostics.packageClosure.unresolvedRootCount
      oracleReferenceRecords = $oracle.RawRecordCount
      oracleProjects = $oracle.ProjectCount
      oracleConfigurations = $oracle.ConfigurationCount
      oracleRelations = $oracle.Relation.Count
      graphRelations = $graphRelation.Relation.Count
      oracleOnly = $comparison.MSBuildProjectReferenceOracleOnly.Count
      graphOnly = $comparison.GraphOnly.Count
      mappedPackageInfoRelations = $oraclePackageInfo.Mapped.Count
      unmappedPackageRootRelations = $oraclePackageInfo.Unmapped.Count
      nugetOnlyIdentities = $dependencyProvenance.NuGetOnlyIdentities.Count
      sourceRecords = $canonicalValidation.sourceRecordCount
      packageRecords = $canonicalValidation.packageRecordCount
      projectReferences = $canonicalValidation.sourceProjectReferenceCount
      nonAssemblyProjectReferences = $canonicalValidation.nonAssemblyProjectReferenceCount
    }
    targetFrameworks = $targetFrameworks
    nugetOnlyIdentities = $dependencyProvenance.NuGetOnlyIdentities
    mismatchClassifications = $classificationCounts
    packageInfoMapping = [ordered]@{
      uniqueDirectoryPaths = $packageInfos.Count
      oracleOnly = $mappedComparison.MSBuildProjectReferenceOracleOnly.Count
      graphOnly = $mappedComparison.GraphOnly.Count
      unmappedOracleOnly = $unmappedComparison.MSBuildProjectReferenceOracleOnly.Count
      unmappedGraphOnly = $unmappedComparison.GraphOnly.Count
      singletonDirectExclusionChecks = $packageInfos.Count
      singletonDirectExclusionFailures = @($directExclusionFailures)
      unionMappingChecks = $unionMappingChecks
      noChangedPackageSelectionCount = @(Get-IndirectPackageInfoSelection $graphRelation.Relation $packageInfos @()).Count
      includedForValidation = $true
    }
    phase1 = $canonicalValidation
    reusedFreshGraph = $ReuseGraph
    graphDiagnostics = $graph.diagnostics
    graphBytes = (Get-Item -LiteralPath $graphPath).Length
    recordsBytes = (Get-Item -LiteralPath $recordsPath).Length
    packageRecordsBytes = (Get-Item -LiteralPath $packageRecordsPath).Length
    commands = @($commands)
    graphGenerationPeakWorkingSetMiB = Get-LoggedPeakWorkingSet $graphLog
    timings = [ordered]@{
      packageInfoReadSeconds = [Math]::Round($packageInfoReadStopwatch.Elapsed.TotalSeconds, 3)
      oracleRelationBuildSeconds = [Math]::Round($oracleRelationStopwatch.Elapsed.TotalSeconds, 3)
      graphReadSeconds = [Math]::Round($graphReadStopwatch.Elapsed.TotalSeconds, 3)
      canonicalValidationSeconds = [Math]::Round($canonicalValidationStopwatch.Elapsed.TotalSeconds, 3)
      graphRelationExportSeconds = [Math]::Round($graphRelationStopwatch.Elapsed.TotalSeconds, 3)
      relationComparisonAndClassificationSeconds = [Math]::Round($comparisonStopwatch.Elapsed.TotalSeconds, 3)
      totalSeconds = 0
    }
    evidenceSha256 = [ordered]@{
      oracle = Get-FileHashValue $oraclePath
      graph = Get-FileHashValue $graphRelationPath
      oracleOnly = Get-FileHashValue $oracleOnlyPath
      graphOnly = Get-FileHashValue $graphOnlyPath
    }
  }
  $validationStopwatch.Stop()
  $provenance.timings.totalSeconds = [Math]::Round($validationStopwatch.Elapsed.TotalSeconds, 3)
  $provenance | ConvertTo-Json -Depth 100 | Set-Content -LiteralPath $provenancePath -Encoding utf8

  Write-Host "Dependency relation validation: packages=$($packageInfos.Count), oracle=$($oracle.Relation.Count), graph=$($graphRelation.Relation.Count), oracleOnly=$($comparison.MSBuildProjectReferenceOracleOnly.Count), graphOnly=$($comparison.GraphOnly.Count)."
  Write-Host "Evidence: $relationDirectory"
  if ($classifications -match "`tunclassified`t") {
    throw "At least one dependency-relation mismatch could not be classified. See '$relationDirectory/mismatch-classification.tsv'."
  }
  if ($provenance.result -ne 'proven') {
    throw "Repository dependency relations differ. See '$oracleOnlyPath' and '$graphOnlyPath'."
  }
  return [pscustomobject] $provenance
}

if ($MyInvocation.InvocationName -ne '.') {
  if (!$DependencyRelation) {
    throw 'Specify -DependencyRelation. Other validation goals are not implemented by this script yet.'
  }
  if (!$RepoRoot) {
    $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot '../..')
  }
  if (!$OutputRoot) {
    $OutputRoot = Join-Path $RepoRoot 'artifacts/validation/RepositoryProjectGraph'
  }
  Invoke-DependencyRelationValidation $RepoRoot $OutputRoot $ReuseFreshGraph | Out-Null
}
