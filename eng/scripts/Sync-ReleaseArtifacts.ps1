<#
.SYNOPSIS
Syncs release artifacts (csproj + changelog) from a release commit into the
current working tree which is expected to be on main.

.DESCRIPTION
When the release pipeline runs from a release/* branch the sparse checkout
lands on main.  This script:
  1. Replaces the csproj with the version from the release commit so
     Update-PkgVersion sees the released version.
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
  }

  return $MainEntries
}

# --- Main ---

$pkgProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
$changelogPath = $pkgProperties.ChangeLogPath
$csprojPath = Join-Path $pkgProperties.DirectoryPath "src" "$PackageName.csproj"

# Sync csproj (simple replacement)
$csprojGitPath = (Resolve-Path -Relative $csprojPath) -replace '\\', '/'
git checkout $SourceCommit -- $csprojGitPath
if ($LASTEXITCODE -ne 0) {
  Write-Error "Failed to checkout csproj from $SourceCommit"
  exit 1
}
Write-Host "Synced $csprojGitPath from $SourceCommit"

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
