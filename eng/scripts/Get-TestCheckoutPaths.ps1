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
#   tools           - eng/Directory.Build.Common.targets injects ProjectReferences to
#                     $(RepoRoot)/sdk/tools/Azure.SdkAnalyzers[.CodeFixes] into every
#                     project when EnableClientSdkAnalyzers is true. These are analyzer
#                     references, so a missing project degrades to an MSB9008 *warning*
#                     rather than an error, and the build then fails later with
#                     confusing analyzer diagnostics (e.g. AAIP001) because the
#                     analyzers that carry the suppressions never loaded. 138 files.
# These six services total about 2.1% of the files under sdk/.
$script:AlwaysIncludedServices = @('core', 'common', 'identity', 'resourcemanager', 'template', 'tools')

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
    [hashtable] $Index,
    [string] $Root,
    [System.Collections.Generic.HashSet[string]] $UnresolvedProperties
  )

  $content = Get-Content -LiteralPath $ProjectPath -Raw -ErrorAction SilentlyContinue
  if (-not $content) {
    return @()
  }

  $results = [System.Collections.Generic.HashSet[string]]::new()
  $projectDir = Split-Path -Parent $ProjectPath

  foreach ($match in [regex]::Matches($content, '<ProjectReference[^>]*Include\s*=\s*"([^"]+)"', 'IgnoreCase')) {
    $include = $match.Groups[1].Value

    # $(MSBuildThisFileDirectory) is the directory of the project file itself, so it can
    # be expanded exactly. About 90 references in the repository use it, several of them
    # crossing service directories (for example the perf projects reaching the
    # repository-root common/Perf/Azure.Test.Perf).
    $include = $include -replace '(?i)\$\(MSBuildThisFileDirectory\)[\\/]*', ''

    # Any property left over cannot be expanded without evaluating MSBuild. Rather than
    # silently dropping the edge - which would narrow the checkout too far and break the
    # build - record the property name so the caller can fall back to a full checkout.
    $remaining = [regex]::Matches($include, '\$\(([^)]+)\)')
    if ($remaining.Count -gt 0) {
      $property = $remaining[0].Groups[1].Value
      if ($script:KnownProjectReferenceProperties.ContainsKey($property)) {
        $null = $results.Add([System.IO.Path]::GetFullPath(
          (Join-Path $Root $script:KnownProjectReferenceProperties[$property])))
        continue
      }

      if ($property -notmatch $script:ProjectLocalPropertyPattern -and $UnresolvedProperties) {
        $null = $UnresolvedProperties.Add($property)
      }
      continue
    }

    $relative = $include -replace '\\', [System.IO.Path]::DirectorySeparatorChar
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
    [string] $Root,
    [hashtable] $ReferenceCache,
    [System.Collections.Generic.HashSet[string]] $UnresolvedProperties
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
      # The cache is shared across artifacts, so the unresolved properties found while
      # first visiting a project have to be cached with it. Otherwise only the artifact
      # that happened to visit it first would learn about them.
      $found = [System.Collections.Generic.HashSet[string]]::new()
      $ReferenceCache[$current] = [pscustomobject]@{
        References = Get-ProjectReferences -ProjectPath $current -Index $Index -Root $Root -UnresolvedProperties $found
        Unresolved = @($found)
      }
    }

    if ($UnresolvedProperties) {
      foreach ($property in $ReferenceCache[$current].Unresolved) {
        $null = $UnresolvedProperties.Add($property)
      }
    }

    foreach ($reference in $ReferenceCache[$current].References) {
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
    [string] $Root,
    [System.Collections.Generic.HashSet[string]] $UnresolvedProperties
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

  # <Import Project="..."> is resolved the same way. A cross-service import that lands
  # outside the narrowed checkout is a hard MSBuild error, not a warning, so it has to
  # participate in the closure just like a ProjectReference.
  $patterns = @(
    '<(?:Compile|None|EmbeddedResource|Content)[^>]*Include\s*=\s*"([^"]+)"'
    '<Import[^>]*Project\s*=\s*"([^"]+)"'
  )

  foreach ($pattern in $patterns) {
    foreach ($match in [regex]::Matches($content, $pattern, 'IgnoreCase')) {
      $include = $match.Groups[1].Value

      # The project's own directory, so this expands exactly.
      $include = $include -replace '(?i)\$\(MSBuildThisFileDirectory\)[\\/]*', ''

      # Strip the globbed tail so GetFullPath sees a plain directory path.
      $directory = $include -replace '[\\/][^\\/]*[*?][^\\/]*$', ''
      $directory = $directory -replace '\\', [System.IO.Path]::DirectorySeparatorChar

      $remaining = [regex]::Matches($directory, '\$\(([^)]+)\)')
      if ($remaining.Count -eq 0 -and $include -notmatch '\.\.') {
        # A plain relative path inside the package directory contributes nothing.
        continue
      }

      if ($remaining.Count -gt 0) {
        $property = $remaining[0].Groups[1].Value
        if ($script:KnownProjectReferenceProperties.ContainsKey($property)) {
          $known = [System.IO.Path]::GetFullPath(
            (Join-Path $Root $script:KnownProjectReferenceProperties[$property]))
          $service = Get-ServiceDirectoryName -ProjectPath $known -Root $Root
          if ($service) {
            $null = $services.Add($service)
          }
          continue
        }

        # Same rule as ProjectReference: an unexpandable property may point anywhere, so
        # make the package unmappable rather than narrow past it.
        if ($property -notmatch $script:ProjectLocalPropertyPattern -and $UnresolvedProperties) {
          $null = $UnresolvedProperties.Add($property)
        }
        continue
      }

      $resolved = [System.IO.Path]::GetFullPath((Join-Path $projectDir $directory))
      $service = Get-ServiceDirectoryName -ProjectPath $resolved -Root $Root
      if ($service) {
        $null = $services.Add($service)
      }
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

function Get-AlwaysIncludedPaths {
  # The complete set of paths that every narrowed checkout needs regardless of which
  # packages are in the batch. This is written into the map so that consumers - notably
  # the resolver inlined into eng/pipelines/templates/jobs/ci.tests.yml, which cannot
  # dot-source this script because it runs before the repository is on disk - never
  # have to repeat the list. Duplicating it once already caused a build break.
  $paths = [System.Collections.Generic.List[string]]::new()
  foreach ($path in $script:BasePaths) { $paths.Add($path) }
  foreach ($path in $script:AlwaysIncludedRootDirectories) { $paths.Add($path) }
  foreach ($service in $script:AlwaysIncludedServices) { $paths.Add("/sdk/$service/*") }
  return @($paths)
}

# Reserved map key holding the output of Get-AlwaysIncludedPaths. Package artifact
# names can never collide with it because they are always valid assembly names.
$script:AlwaysIncludedPathsKey = '$alwaysIncludedPaths'

# ProjectReference Include values that are written as a bare MSBuild property. Each of
# these is known to resolve inside a service that is always included, so the edge can be
# dropped without narrowing the checkout too far:
# Each maps to the repository-relative project it expands to, taken from the property
# definition, so the edge is followed exactly rather than guessed at or dropped.
# A property that is NOT listed here forces a full checkout for the affected package,
# so adding a new one degrades performance rather than correctness.
$script:KnownProjectReferenceProperties = @{
  'AzureCoreTestFramework'  = 'sdk/core/Azure.Core.TestFramework/src/Azure.Core.TestFramework.csproj'
  'ExternalAzureCoreSource' = 'sdk/core/Azure.Core/src/Azure.Core.csproj'
  'ExternalOpenAISource'    = 'sdk/openai/external/OpenAI/src/OpenAI.csproj'

  # Shared-source directories linked in through Compile/None globs. All are defined in
  # eng/ or service level .props files, so they never appear as a literal path.
  'AzureCoreSharedSources'                       = 'sdk/core/Azure.Core/src/Shared'
  'AzureCoreSharedCodeDirectory'                 = 'sdk/core/Azure.Core/src/Shared'
  'AzureCoreAmqpSharedSources'                   = 'sdk/core/Azure.Core.Amqp/src/Shared'
  'TestFrameworkSupportFiles'                    = 'sdk/core/Azure.Core.TestFramework/src/Shared'
  'AzureStorageSharedSources'                    = 'sdk/storage/Azure.Storage.Common/src/Shared'
  'AzureStorageSharedTestSources'                = 'sdk/storage/Azure.Storage.Common/tests/Shared'
  'AzureStorageStressTestSharedSources'          = 'sdk/storage/Azure.Storage.Common/src/stress/Shared'
  'AzureStorageBlobsSharedSources'               = 'sdk/storage/Azure.Storage.Blobs/src/Shared'
  'AzureStorageDataMovementSharedSources'        = 'sdk/storage/Azure.Storage.DataMovement/src/Shared'
  'AzureStorageDataMovementTestSharedSources'    = 'sdk/storage/Azure.Storage.DataMovement/tests/Shared'
  'AzureStorageWebjobsExtensionSharedSources'    = 'sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Common/src/Shared'
  'AzureStorageWebjobsExtensionSharedTestSources' = 'sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Common/tests/Shared'
  'MicrosoftAzureWebJobsExtensionsClientsSources' = 'sdk/extensions/Microsoft.Azure.WebJobs.Extensions.Clients/src/Shared'
  'AzureEventGridSharedSources'                  = 'sdk/eventgrid/Azure.Messaging.EventGrid/src/Shared'
  'RepoEngPath'                                  = 'eng'
}

# Properties that cannot move a path into a different service directory, so leaving them
# unexpanded is safe and must not force a full checkout. They are relative to the
# referencing project itself - they name its own bin/ output or are plain tokens. The
# analyzer project injected into every package packs its build output this way, so
# treating these as unresolvable would make more than half the repository unmappable for
# no correctness gain.
#
# Deliberately anchored with ^...$ so only these exact property names match:
# $(AzureCoreOutputPath) must still force a fallback.
#
# This list intentionally does not exempt [MSBuild]::GetDirectoryNameOfFileAbove or
# similar function calls. Those would be safe in principle (they walk *up* to an ancestor,
# which is always in the checkout), but no .csproj in the repo uses one - all occurrences
# are in .props/.targets files, which this script never parses. Exempting an arbitrary
# function whose arguments are never evaluated is the widest part of the blast radius, and
# it currently buys nothing, so it stays out until something actually needs it.
$script:ProjectLocalPropertyPattern =
  '(?i)^(?:OutputPath|BaseOutputPath|IntermediateOutputPath|Configuration|Platform|' +
  'AssemblyName|TargetFramework|MSBuildProjectName)$'

function New-CheckoutMap {
  param([string] $Root)

  $index = Get-ProjectReferenceIndex -Root $Root
  $referenceCache = @{}
  $map = [ordered]@{}

  foreach ($artifact in ($index.Keys | Sort-Object)) {
    # sdk/<service>/<package>/src/<artifact>.csproj -> sdk/<service>/<package>
    $packageRoot = Split-Path -Parent (Split-Path -Parent $index[$artifact])

    $services = [System.Collections.Generic.SortedSet[string]]::new()
    $unresolved = [System.Collections.Generic.HashSet[string]]::new()
    foreach ($project in (Get-ServiceClosure -PackageRoot $packageRoot -Index $index -Root $Root -ReferenceCache $referenceCache -UnresolvedProperties $unresolved)) {
      $service = Get-ServiceDirectoryName -ProjectPath $project -Root $Root
      if ($service) {
        $null = $services.Add($service)
      }

      foreach ($linked in (Get-LinkedSourceServices -ProjectPath $project -Root $Root -UnresolvedProperties $unresolved)) {
        $null = $services.Add($linked)
      }
    }

    if ($unresolved.Count -gt 0) {
      # An MSBuild property we cannot expand may point anywhere, so the closure for this
      # package is not trustworthy. Record it as unmappable; Resolve-CheckoutPaths turns
      # an empty entry into a full checkout, which is slow but always correct.
      Write-Warning ("Package '$artifact' references projects through unexpanded MSBuild " +
        "properties ($($unresolved -join ', ')); it will use a full checkout. Add them to " +
        '$script:KnownProjectReferenceProperties to restore narrowing.')
      $map[$artifact] = @()
    }
    else {
      $map[$artifact] = @($services)
    }
  }

  $map[$script:AlwaysIncludedPathsKey] = Get-AlwaysIncludedPaths

  return $map
}

function Resolve-CheckoutPaths {
  param(
    [hashtable] $Map,
    [string[]] $Artifacts
  )

  $services = [System.Collections.Generic.SortedSet[string]]::new()

  $contributed = 0
  foreach ($artifact in $Artifacts) {
    if ($artifact -eq $script:AlwaysIncludedPathsKey -or -not $Map.ContainsKey($artifact)) {
      # An unknown artifact means the map is stale relative to the packages being
      # tested. Narrowing on incomplete data risks a build break, so signal the
      # caller to fall back to a full checkout.
      Write-Warning "No checkout map entry for '$artifact'; falling back to a full checkout."
      return $null
    }

    if (@($Map[$artifact]).Count -eq 0) {
      # New-CheckoutMap records an empty closure for a package it could not analyse
      # exactly. Narrowing on it would drop services the build needs.
      Write-Warning "Checkout map entry for '$artifact' is empty; falling back to a full checkout."
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

  # Prefer the always-included paths recorded in the map so that a map built by an
  # older revision of this script still resolves exactly the way it was built.
  $paths = [System.Collections.Generic.List[string]]::new()
  if ($Map.ContainsKey($script:AlwaysIncludedPathsKey)) {
    foreach ($path in $Map[$script:AlwaysIncludedPathsKey]) { $paths.Add($path) }
  }
  else {
    foreach ($path in (Get-AlwaysIncludedPaths)) { $paths.Add($path) }
  }

  foreach ($service in $services) {
    $candidate = "/sdk/$service/*"
    if (-not $paths.Contains($candidate)) {
      $paths.Add($candidate)
    }
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
  Write-Host "Wrote checkout map for $($map.Keys.Count - 1) artifacts to $OutputPath"
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

# A truncated or empty map must degrade to a full checkout rather than throw: the
# artifact download that produces it is deliberately non-fatal.
$map = @{}
try {
  $raw = Get-Content -LiteralPath $MapPath -Raw
  if (-not $raw) {
    throw 'the file is empty'
  }
  foreach ($property in ($raw | ConvertFrom-Json).PSObject.Properties) {
    $map[$property.Name] = @($property.Value)
  }
}
catch {
  Write-Warning "Checkout map '$MapPath' could not be read ($_); falling back to a full checkout."
  return $null
}

return Resolve-CheckoutPaths -Map $map -Artifacts $artifacts
