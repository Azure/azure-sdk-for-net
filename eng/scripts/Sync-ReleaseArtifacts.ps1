<#
.SYNOPSIS
Syncs release artifacts (csproj + changelog) between the current working tree
and a target branch (typically main).

.DESCRIPTION
When the release pipeline runs from a release/* branch the sparse checkout
lands on the release commit.  This script:
  1. Syncs the csproj version — takes the higher of main vs release so that
     hotfix releases (where main has already advanced) do not downgrade.
  2. Merges changelog entries from main into the release changelog so that
     entries from both branches are preserved in the correct version order.

When the pipeline runs on main the versions and changelog entries will
typically match, making this effectively a no-op.  If main has advanced
since the build started, the script still produces the correct result by
taking the higher version and merging changelog entries from both sides.

.PARAMETER PackageName
The name of the package (e.g. Azure.Core).

.PARAMETER ServiceDirectory
The service directory name under sdk/ (e.g. core).

.PARAMETER MainRef
A git ref pointing to main (e.g. origin/main or FETCH_HEAD) used to read
main's csproj and changelog via git show.

.EXAMPLE
eng/scripts/Sync-ReleaseArtifacts.ps1 -PackageName Azure.Core -ServiceDirectory core -MainRef origin/main
#>

[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string]$PackageName,

  [Parameter(Mandatory = $true)]
  [string]$ServiceDirectory,

  [Parameter(Mandatory = $true)]
  [string]$MainRef
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
  elseif ($mainSemVer.CompareTo($releaseSemVer) -gt 0) {
    Write-Host "  Main version $MainVersion > release version $ReleaseVersion — using main"
    return $MainVersion
  }
  else {
    Write-Host "  Versions equal ($MainVersion) — no change needed"
    return $MainVersion
  }
}

# --- Main ---

$pkgProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
$changelogPath = $pkgProperties.ChangeLogPath
$csprojPath = Join-Path $pkgProperties.DirectoryPath "src" "$PackageName.csproj"

# Sync csproj — take the higher version between main and release
$csprojGitPath = (Resolve-Path -Relative $csprojPath) -replace '\\', '/'

# Read the release csproj from the working tree (we are on the release branch)
$releaseCsproj = [xml](Get-Content -LiteralPath $csprojPath -Raw)
$releaseVersion = ($releaseCsproj | Select-Xml "Project/PropertyGroup/Version").Node.InnerText

# Read main's csproj via git show
$mainCsprojContent = (git show "${MainRef}:${csprojGitPath}") -join "`n"
if ($LASTEXITCODE -ne 0) {
  Write-Error "Failed to read csproj from $MainRef"
  exit 1
}
$mainCsproj = [xml]$mainCsprojContent
$mainVersion = ($mainCsproj | Select-Xml "Project/PropertyGroup/Version").Node.InnerText

$resolvedVersion = Resolve-CsprojVersion -MainVersion $mainVersion -ReleaseVersion $releaseVersion

if ($resolvedVersion -ne $releaseVersion) {
  # Main version is higher (hotfix scenario) — overwrite working tree with main's csproj
  [System.IO.File]::WriteAllText($csprojPath, $mainCsprojContent + "`n", [System.Text.Encoding]::UTF8)
  Write-Host "Synced $csprojGitPath from $MainRef (version $mainVersion)"
}
else {
  Write-Host "Kept release csproj at $csprojGitPath (version $releaseVersion)"
}

# Merge changelog — read release from working tree, main from git show
$releaseEntries = Get-ChangeLogEntries -ChangeLogLocation $changelogPath
$changelogGitPath = (Resolve-Path -Relative $changelogPath) -replace '\\', '/'
$mainChangelogContent = git show "${MainRef}:${changelogGitPath}"
if ($LASTEXITCODE -ne 0) {
  Write-Error "Failed to read changelog from $MainRef"
  exit 1
}
$mainEntries = Get-ChangeLogEntriesFromContent $mainChangelogContent

$mergedEntries = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

Set-ChangeLogContent -ChangeLogLocation $changelogPath -ChangeLogEntries $mergedEntries
Write-Host "Merged changelog at $changelogGitPath"
