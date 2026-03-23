<#
.SYNOPSIS
Syncs release artifacts (csproj + changelog) from a release commit into the
current working tree which is expected to be on main.

.DESCRIPTION
When the release pipeline runs from a release/* branch the sparse checkout
lands on main.  This script:
  1. Syncs the csproj version — takes the higher of main vs release so that
     hotfix releases (where main has already advanced) do not downgrade.
  2. Merges changelog entries from the release commit into main's changelog
     so new release entries are inserted in the correct version order without
     losing entries that only exist on main.

When the pipeline runs on main both operations are no-ops because the release
commit IS the current checkout.

.PARAMETER PackageName
The name of the package (e.g. Azure.Core).

.PARAMETER ServiceDirectory
The service directory name under sdk/ (e.g. core).

.PARAMETER SourceCommit
The git commit SHA to sync from (typically $(Build.SourceVersion)).

.EXAMPLE
eng/scripts/Sync-ReleaseArtifacts.ps1 -PackageName Azure.Core -ServiceDirectory core -SourceCommit abc123
#>

[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string]$PackageName,

  [Parameter(Mandatory = $true)]
  [string]$ServiceDirectory,

  [Parameter(Mandatory = $true)]
  [string]$SourceCommit
)

. (Join-Path $PSScriptRoot ".." "common" "scripts" "common.ps1")
. (Join-Path $PSScriptRoot ".." "common" "scripts" "ChangeLog-Operations.ps1")

function Merge-ChangeLogEntries {
  <#
  .SYNOPSIS
  Merges release changelog entries into main changelog entries.

  .DESCRIPTION
  For each entry in the release changelog:
    - If the version does not exist in main, add it.
    - If main has the version as (Unreleased) but release has a date, replace it.
    - If both have a dated entry for the same version, release wins (it has
      the latest content from prepare-release).
    - Otherwise keep main's entry.
  Returns the merged entries (unordered — Set-ChangeLogContent handles sorting).
  #>
  param(
    [Parameter(Mandatory = $true)]
    $MainEntries,

    [Parameter(Mandatory = $true)]
    $ReleaseEntries
  )

  foreach ($version in $ReleaseEntries.Keys) {
    $releaseEntry = $ReleaseEntries[$version]
    if (-not $MainEntries.Contains($version)) {
      $MainEntries[$version] = $releaseEntry
      Write-Host "  Added changelog entry for $version from release"
    }
    elseif ($MainEntries[$version].ReleaseStatus -eq $CHANGELOG_UNRELEASED_STATUS -and
            $releaseEntry.ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS) {
      $MainEntries[$version] = $releaseEntry
      Write-Host "  Updated changelog entry for $version with release date"
    }
    elseif ($releaseEntry.ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS -and
            $MainEntries[$version].ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS) {
      $MainEntries[$version] = $releaseEntry
      Write-Host "  Replaced changelog entry for $version with release content"
    }
  }

  return $MainEntries
}

function Resolve-CsprojVersion {
  <#
  .SYNOPSIS
  Returns the higher of two version strings using semver comparison.

  .DESCRIPTION
  Compares main and release csproj versions and returns the higher one.
  In a hotfix scenario where main has advanced (e.g. 1.3.0-beta.1) past
  the release version (e.g. 1.1.1), the main version wins so the
  version-bump PR does not downgrade.
  #>
  param(
    [Parameter(Mandatory = $true)]
    [string]$MainVersion,

    [Parameter(Mandatory = $true)]
    [string]$ReleaseVersion
  )

  $mainSemVer = [AzureEngSemanticVersion]::new($MainVersion)
  $releaseSemVer = [AzureEngSemanticVersion]::new($ReleaseVersion)

  if ($releaseSemVer.CompareTo($mainSemVer) -gt 0) {
    Write-Host "  Release version $ReleaseVersion > main version $MainVersion — using release"
    return $ReleaseVersion
  }
  else {
    Write-Host "  Main version $MainVersion >= release version $ReleaseVersion — keeping main"
    return $MainVersion
  }
}

# --- Main ---

$pkgProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
$changelogPath = $pkgProperties.ChangeLogPath
$csprojPath = Join-Path $pkgProperties.DirectoryPath "src" "$PackageName.csproj"

# Sync csproj — take the higher version between main and release
$csprojGitPath = (Resolve-Path -Relative $csprojPath) -replace '\\', '/'

$mainCsproj = [xml](Get-Content -LiteralPath $csprojPath -Raw)
$mainVersion = ($mainCsproj | Select-Xml "Project/PropertyGroup/Version").Node.InnerText

$releaseCsprojContent = (git show "${SourceCommit}:${csprojGitPath}") -join "`n"
if ($LASTEXITCODE -ne 0) {
  Write-Error "Failed to read csproj from $SourceCommit"
  exit 1
}
$releaseCsproj = [xml]$releaseCsprojContent
$releaseVersion = ($releaseCsproj | Select-Xml "Project/PropertyGroup/Version").Node.InnerText

$resolvedVersion = Resolve-CsprojVersion -MainVersion $mainVersion -ReleaseVersion $releaseVersion

if ($resolvedVersion -ne $mainVersion) {
  git checkout $SourceCommit -- $csprojGitPath
  if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to checkout csproj from $SourceCommit"
    exit 1
  }
  Write-Host "Synced $csprojGitPath from $SourceCommit"
}
else {
  Write-Host "Kept main csproj at $csprojGitPath (version $mainVersion)"
}

# Merge changelog
$mainEntries = Get-ChangeLogEntries -ChangeLogLocation $changelogPath
$changelogGitPath = (Resolve-Path -Relative $changelogPath) -replace '\\', '/'
$releaseContent = git show "${SourceCommit}:${changelogGitPath}"
if ($LASTEXITCODE -ne 0) {
  Write-Error "Failed to read changelog from $SourceCommit"
  exit 1
}
$releaseEntries = Get-ChangeLogEntriesFromContent $releaseContent

$mergedEntries = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

Set-ChangeLogContent -ChangeLogLocation $changelogPath -ChangeLogEntries $mergedEntries
Write-Host "Merged changelog at $changelogGitPath"
