<#
.SYNOPSIS
Removes obsolete ApiCompat baseline suppressions and opt-out entries for a project after a GA release.

.DESCRIPTION
After a GA (non-preview) release, Update-PkgVersion.ps1 bumps the project's <ApiCompatVersion> to the
just-released version. Any ApiCompat baseline suppressions or version opt-out entries recorded against the
previous baseline are then obsolete, so this removes them for the released project:
  * the project-specific baseline file eng/apicompatbaselines/<PackageName>.txt, and
  * any line naming the project in the common list files (e.g. ApiCompatVersionOptOut.txt), which contain
    one project name per line.

Returns the number of files that were deleted or modified.

.PARAMETER RepoRoot
The root of the repo.

.PARAMETER PackageName
The name of the package (matches the MSBuild project name and baseline file name).
#>
function Remove-ObsoleteApiCompatBaselines {
  param (
    [Parameter(Mandatory = $true)] [string] $RepoRoot,
    [Parameter(Mandatory = $true)] [string] $PackageName
  )

  $removedCount = 0
  $baselineDir = Join-Path $RepoRoot "eng" "apicompatbaselines"
  if (-not (Test-Path -LiteralPath $baselineDir -PathType Container)) {
    return $removedCount
  }

  # Remove the project-specific baseline file (eng/apicompatbaselines/<PackageName>.txt).
  $projectBaselineFile = Join-Path $baselineDir "${PackageName}.txt"
  if (Test-Path -LiteralPath $projectBaselineFile -PathType Leaf) {
    Remove-Item -LiteralPath $projectBaselineFile -Force
    Write-Host "Removed ApiCompat baseline file '$projectBaselineFile' after GA release of $PackageName"
    $removedCount++
  }

  # Common list files are named ApiCompat*.txt (e.g. ApiCompatVersionOptOut.txt) and contain one project
  # name per line ('#' comments allowed). Only these are scanned - per-package baseline suppression files
  # (named <Project>.txt) are deliberately excluded so a suppression line that happens to equal a package
  # name is never touched. Remove a line only when it is the project name and nothing else (surrounding
  # whitespace is ignored); any line with additional content is left untouched. Files under
  # eng/apicompatbaselines are LF-only (enforced by .gitattributes eol=lf), so always normalize to LF
  # while preserving each file's trailing-newline state, keeping the diff minimal.
  $commonFiles = Get-ChildItem -LiteralPath $baselineDir -File -Filter "ApiCompat*.txt" |
    Where-Object { $_.Name -ne "${PackageName}.txt" }
  foreach ($file in $commonFiles) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    if ([string]::IsNullOrEmpty($content)) { continue }

    $normalized = $content -replace "`r`n", "`n"
    $hadTrailingNewline = $normalized.EndsWith("`n")
    $body = if ($hadTrailingNewline) { $normalized.Substring(0, $normalized.Length - 1) } else { $normalized }
    $lines = if ($body.Length -eq 0) { @() } else { $body -split "`n" }

    $filtered = @($lines | Where-Object { $_.Trim() -ne $PackageName })
    if ($filtered.Count -eq $lines.Count) { continue }

    $newContent = $filtered -join "`n"
    if ($hadTrailingNewline -and $newContent.Length -gt 0) { $newContent += "`n" }

    [System.IO.File]::WriteAllText($file.FullName, $newContent, (New-Object System.Text.UTF8Encoding($false)))
    Write-Host "Removed '$PackageName' entry from '$($file.FullName)' after GA release"
    $removedCount++
  }

  return $removedCount
}

<#
.SYNOPSIS
Returns true when a post-release version bump advances <ApiCompatVersion> (and therefore should trigger
ApiCompat baseline cleanup).

.DESCRIPTION
Baseline cleanup must run on exactly the same condition that advances <ApiCompatVersion>: the version
currently in the project (the version just released) is a GA (non-preview) version AND the version is
actually changing. Gating on this prevents deleting baselines when the bump is a no-op (for example when
-NewVersionString equals the current version), which would advance nothing.

.PARAMETER CurrentVersion
The version currently in the project's .csproj (i.e. the version that was just released).

.PARAMETER NewVersionString
The optional explicit target version passed to Update-PkgVersion.ps1. Empty in the normal
auto-increment path.
#>
function Test-ApiCompatVersionBumped {
  param (
    [Parameter(Mandatory = $true)] [string] $CurrentVersion,
    [string] $NewVersionString
  )
  $current = [AzureEngSemanticVersion]::new($CurrentVersion)
  return (-not $current.IsPrerelease) -and ($CurrentVersion -ne $NewVersionString)
}
