#!/usr/bin/env pwsh

<#
.SYNOPSIS
Computes the minimal set of sparse-checkout paths a PR test job needs.

.DESCRIPTION
PR test jobs currently sparse-checkout the entire repository ('/*'). Because the
shared checkout step clones with '--filter=tree:0', materializing the full working
tree forces an on-demand fetch of every tree and blob. Checkout cost is dominated by
file count, and 'sdk/**/Generated' alone accounts for the large majority of tracked
files, nearly all of which belong to services the job never builds.

A PR test job only builds the test projects of the packages in its batch plus the
transitive project closure of those tests. This script computes that closure so the
job can check out just the service directories it needs.

The closure must be exact. When UseProjectReferenceToAzureClients=true,
eng/Directory.Build.Common.targets globs '$(RepoRoot)/sdk/**/src/*.csproj' and
converts every PackageReference whose name matches one of those projects into a
ProjectReference. VerifyProjectReferencesReferences then fails the build if any
'Azure.*' reference did not become a ProjectReference. A src project that is missing
from the working tree would therefore turn into a hard build error rather than a
silent fallback, so this script mirrors that glob and that matching rule exactly:

  * ProjectReference entries are literal relative paths and are followed as-is.
  * PackageReference entries are followed whenever the package name matches the file
    name of a project found by the same 'sdk/**/src/*.csproj' glob.

Closure is reported at service-directory granularity ('sdk/<service>') rather than
package granularity so that service-level Directory.Build.props, assets.json files,
and shared test collateral are always present.

.PARAMETER BuildMap
Build the artifact -> service-directory map. Requires a full checkout, so this runs
during matrix generation and the resulting map is published for the test jobs.

.PARAMETER RepoRoot
Repository root to scan. Defaults to the repository containing this script.

.PARAMETER OutputPath
Where to write the map when -BuildMap is specified.

.PARAMETER MapPath
Map produced by an earlier -BuildMap run, used to resolve checkout paths.

.PARAMETER ArtifactNames
Comma-separated artifact (package) names for the batch being resolved. This matches
the 'ProjectNames' variable that Create-PrJobMatrix.ps1 sets on each PR test job.

.EXAMPLE
./Get-TestCheckoutPaths.ps1 -BuildMap -OutputPath ./checkout-map.json

.EXAMPLE
./Get-TestCheckoutPaths.ps1 -MapPath ./checkout-map.json -ArtifactNames 'Azure.Core,Azure.Identity'
#>
[CmdletBinding(DefaultParameterSetName = 'Resolve')]
param(
  [Parameter(ParameterSetName = 'BuildMap', Mandatory = $true)]
  [switch] $BuildMap,

  [Parameter(ParameterSetName = 'BuildMap')]
  [string] $RepoRoot,

  [Parameter(ParameterSetName = 'BuildMap', Mandatory = $true)]
  [string] $OutputPath,

  [Parameter(ParameterSetName = 'Resolve', Mandatory = $true)]
  [string] $MapPath,

  [Parameter(ParameterSetName = 'Resolve', Mandatory = $true)]
  [AllowEmptyString()]
  [string] $ArtifactNames
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

# Paths the shared sparse-checkout step already establishes before our list is added.
# Repeating them here keeps the emitted list self-describing and independent of the
# order in which sparse-checkout patterns are applied.
$script:BasePaths = @('/*', '!/*/', '/eng', '/.config')

# Every top level directory other than sdk/. Together these are roughly 5,200 of the
# repository's ~139,000 tracked files, so including all of them unconditionally costs
# almost nothing and removes an entire class of failure. In particular the shared
# management test sources referenced as '..\..\..\..\common\ManagementTestShared'
# resolve to the repository-root 'common' directory, which the base sparse-checkout
# patterns above exclude.
$script:AlwaysIncludedRootDirectories = @(
  '/.devcontainer'
  '/.github'
  '/.vscode'
  '/common'
  '/doc'
  '/samples'
)

# Service directories that projects reach without ever naming them in a .csproj:
#   core            - Azure.Core, and $(TestFrameworkSupportFiles) which points at
#                     sdk/core/Azure.Core.TestFramework/src/Shared/*.cs
#   resourcemanager - eng/Directory.Build.Common.props injects an implicit
#                     PackageReference to Azure.ResourceManager for every management
#                     sub-library, so it never appears in the project file
#   identity        - commonly pulled in by test setup rather than by a reference
#   template        - the template package participates in repository-wide builds
# These five services total about 2.1% of the files under sdk/.
$script:AlwaysIncludedServices = @('core', 'common', 'identity', 'resourcemanager', 'template')

function Get-ProjectReferenceIndex {
  param([string] $Root)

  # Mirrors the AzureProjects glob in eng/Directory.Build.Common.targets. Only these
  # projects participate in PackageReference -> ProjectReference conversion.
  $index = @{}
  $srcRoot = Join-Path $Root 'sdk'
  if (-not (Test-Path $srcRoot)) {
    return $index
  }

  foreach ($project in Get-ChildItem -Path $srcRoot -Filter '*.csproj' -Recurse -File) {
    if ($project.Directory.Name -ne 'src') {
      continue
    }
    $name = [System.IO.Path]::GetFileNameWithoutExtension($project.Name)
    if (-not $index.ContainsKey($name)) {
      $index[$name] = $project.FullName
    }
  }

  return $index
}

function Get-ProjectReferences {
  param(
    [string] $ProjectPath,
    [hashtable] $Index
  )

  $content = Get-Content -LiteralPath $ProjectPath -Raw -ErrorAction SilentlyContinue
  if (-not $content) {
    return @()
  }

  $results = [System.Collections.Generic.HashSet[string]]::new()
  $projectDir = Split-Path -Parent $ProjectPath

  foreach ($match in [regex]::Matches($content, '<ProjectReference[^>]*Include\s*=\s*"([^"]+)"', 'IgnoreCase')) {
    $relative = $match.Groups[1].Value -replace '\\', [System.IO.Path]::DirectorySeparatorChar
    $resolved = [System.IO.Path]::GetFullPath((Join-Path $projectDir $relative))
    $null = $results.Add($resolved)
  }

  # PackageReference entries only matter when they name a project that the
  # UseProjectReferenceToAzureClients conversion would swap in.
  foreach ($match in [regex]::Matches($content, '<PackageReference[^>]*(?:Include|Update)\s*=\s*"([^"]+)"', 'IgnoreCase')) {
    $name = $match.Groups[1].Value
    if ($Index.ContainsKey($name)) {
      $null = $results.Add($Index[$name])
    }
  }

  return @($results)
}

function Get-ServiceClosure {
  param(
    [string] $PackageRoot,
    [hashtable] $Index,
    [hashtable] $ReferenceCache
  )

  $visited = [System.Collections.Generic.HashSet[string]]::new()
  $pending = [System.Collections.Generic.Stack[string]]::new()

  foreach ($project in Get-ChildItem -Path $PackageRoot -Filter '*.csproj' -Recurse -File -ErrorAction SilentlyContinue) {
    $pending.Push($project.FullName)
  }

  while ($pending.Count -gt 0) {
    $current = $pending.Pop()
    if (-not $visited.Add($current)) {
      continue
    }

    if (-not $ReferenceCache.ContainsKey($current)) {
      $ReferenceCache[$current] = Get-ProjectReferences -ProjectPath $current -Index $Index
    }

    foreach ($reference in $ReferenceCache[$current]) {
      if (-not $visited.Contains($reference)) {
        $pending.Push($reference)
      }
    }
  }

  return $visited
}

function Get-LinkedSourceServices {
  param(
    [string] $ProjectPath,
    [string] $Root
  )

  # Projects also pull in shared sources via Compile/None globs that escape the
  # package directory, for example the management test helpers referenced as
  # '..\..\..\..\common\ManagementTestShared\Temp\*.cs'. Those never appear as
  # references, so resolve them separately.
  $content = Get-Content -LiteralPath $ProjectPath -Raw -ErrorAction SilentlyContinue
  if (-not $content) {
    return @()
  }

  $services = [System.Collections.Generic.HashSet[string]]::new()
  $projectDir = Split-Path -Parent $ProjectPath

  foreach ($match in [regex]::Matches($content, '<(?:Compile|None|EmbeddedResource|Content)[^>]*Include\s*=\s*"([^"]+)"', 'IgnoreCase')) {
    $include = $match.Groups[1].Value
    if ($include -notmatch '\.\.') {
      continue
    }

    # Strip the globbed tail so GetFullPath sees a plain directory path.
    $directory = $include -replace '[\\/][^\\/]*[*?][^\\/]*$', ''
    $directory = $directory -replace '\\', [System.IO.Path]::DirectorySeparatorChar
    if ($directory -match '\$\(') {
      continue
    }

    $resolved = [System.IO.Path]::GetFullPath((Join-Path $projectDir $directory))
    $service = Get-ServiceDirectoryName -ProjectPath $resolved -Root $Root
    if ($service) {
      $null = $services.Add($service)
    }
  }

  return @($services)
}

function Get-ServiceDirectoryName {
  param(
    [string] $ProjectPath,
    [string] $Root
  )

  $relative = [System.IO.Path]::GetRelativePath($Root, $ProjectPath)
  $segments = $relative -split '[\\/]'
  if ($segments.Length -lt 3 -or $segments[0] -ne 'sdk') {
    return $null
  }

  return $segments[1]
}

function New-CheckoutMap {
  param([string] $Root)

  $index = Get-ProjectReferenceIndex -Root $Root
  $referenceCache = @{}
  $map = [ordered]@{}

  foreach ($artifact in ($index.Keys | Sort-Object)) {
    # sdk/<service>/<package>/src/<artifact>.csproj -> sdk/<service>/<package>
    $packageRoot = Split-Path -Parent (Split-Path -Parent $index[$artifact])

    $services = [System.Collections.Generic.SortedSet[string]]::new()
    foreach ($project in (Get-ServiceClosure -PackageRoot $packageRoot -Index $index -ReferenceCache $referenceCache)) {
      $service = Get-ServiceDirectoryName -ProjectPath $project -Root $Root
      if ($service) {
        $null = $services.Add($service)
      }

      foreach ($linked in (Get-LinkedSourceServices -ProjectPath $project -Root $Root)) {
        $null = $services.Add($linked)
      }
    }

    $map[$artifact] = @($services)
  }

  return $map
}

function Resolve-CheckoutPaths {
  param(
    [hashtable] $Map,
    [string[]] $Artifacts
  )

  $services = [System.Collections.Generic.SortedSet[string]]::new()
  foreach ($service in $script:AlwaysIncludedServices) {
    $null = $services.Add($service)
  }

  $contributed = 0
  foreach ($artifact in $Artifacts) {
    if (-not $Map.ContainsKey($artifact)) {
      # An unknown artifact means the map is stale relative to the packages being
      # tested. Narrowing on incomplete data risks a build break, so signal the
      # caller to fall back to a full checkout.
      Write-Warning "No checkout map entry for '$artifact'; falling back to a full checkout."
      return $null
    }

    foreach ($service in $Map[$artifact]) {
      $null = $services.Add($service)
      $contributed++
    }
  }

  if ($contributed -eq 0) {
    # Every requested artifact mapped to an empty closure, which means the map is not
    # usable. Fall back rather than checking out only the always-included services.
    return $null
  }

  $paths = [System.Collections.Generic.List[string]]::new()
  foreach ($path in $script:BasePaths) {
    $paths.Add($path)
  }
  foreach ($path in $script:AlwaysIncludedRootDirectories) {
    $paths.Add($path)
  }
  foreach ($service in $services) {
    $paths.Add("/sdk/$service/*")
  }

  return @($paths)
}

if ($BuildMap) {
  if (-not $RepoRoot) {
    $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..')).Path
  }
  $RepoRoot = (Resolve-Path $RepoRoot).Path

  $map = New-CheckoutMap -Root $RepoRoot

  $outputDirectory = Split-Path -Parent $OutputPath
  if ($outputDirectory -and -not (Test-Path $outputDirectory)) {
    $null = New-Item -ItemType Directory -Path $outputDirectory -Force
  }

  $map | ConvertTo-Json -Depth 5 -Compress | Set-Content -LiteralPath $OutputPath -NoNewline
  Write-Host "Wrote checkout map for $($map.Keys.Count) artifacts to $OutputPath"
  return
}

$artifacts = @($ArtifactNames -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_ })
if ($artifacts.Count -eq 0) {
  Write-Warning 'No artifact names supplied; falling back to a full checkout.'
  return $null
}

if (-not (Test-Path $MapPath)) {
  Write-Warning "Checkout map '$MapPath' not found; falling back to a full checkout."
  return $null
}

$map = @{}
foreach ($property in (Get-Content -LiteralPath $MapPath -Raw | ConvertFrom-Json).PSObject.Properties) {
  $map[$property.Name] = @($property.Value)
}

return Resolve-CheckoutPaths -Map $map -Artifacts $artifacts
