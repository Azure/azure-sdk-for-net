<#
.SYNOPSIS
Bumps up package versions after release

.DESCRIPTION
This script bumps up package versions following conventions defined at https://github.com/Azure/azure-sdk/blob/main/docs/policies/releases.md#incrementing-after-release-net

.PARAMETER RepoRoot
The Root of the repo

.PARAMETER ServiceDirectory
The Name of the Service Directory

.PARAMETER PackageName
The Name of the Package

.PARAMETER NewVersionString
Use this to overide version incement logic and set a version specified by this parameter


.EXAMPLE
Updating package version for Azure.Core
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core

Updating package version for Azure.Core with a specified verion
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core -NewVersionString 2.0.5

Updating package version for Azure.Core with a specified verion and release date
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core -NewVersionString 2.0.5 -ReleaseDate "2020-05-01"

#>

[CmdletBinding()]
Param (
  [ValidateNotNullOrEmpty()]
  [string] $RepoRoot = "${PSScriptRoot}/../..",
  [Parameter(Mandatory=$True)]
  [string] $ServiceDirectory,
  [Parameter(Mandatory=$True)]
  [string] $PackageName,
  [string] $NewVersionString,
  [string] $ReleaseDate,
  [boolean] $ReplaceLatestEntryTitle=$true
)

. (Join-Path $PSScriptRoot ".." common scripts common.ps1)

$pkgProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
$csprojPath = Join-Path $pkgProperties.DirectoryPath src "${PackageName}.csproj"
$csproj = new-object xml
$csproj.PreserveWhitespace = $true
$csproj.Load($csprojPath)
$propertyGroup = ($csproj | Select-Xml "Project/PropertyGroup/Version").Node.ParentNode
$packageVersion = $propertyGroup.Version

if (!$packageVersion) {
  Write-Error "Could not find the <Version> element in your project $csprojPath, be sure it has a Version property and not a VersionPrefix property."
  exit 1
}

$packageSemVer = [AzureEngSemanticVersion]::new($packageVersion)
$packageOldSemVer = [AzureEngSemanticVersion]::new($packageVersion)
Write-Host "Current Version: ${PackageVersion}"

if ([System.String]::IsNullOrEmpty($NewVersionString)) {
  $packageSemVer.IncrementAndSetToPrerelease()

  & "${PSScriptRoot}/../common/scripts/Update-ChangeLog.ps1" -Version $packageSemVer.ToString() `
  -ChangelogPath $pkgProperties.ChangeLogPath -Unreleased $True
}
else {
  $packageSemVer = [AzureEngSemanticVersion]::new($NewVersionString)

  & "${PSScriptRoot}/../common/scripts/Update-ChangeLog.ps1" -Version $packageSemVer.ToString() `
  -ChangelogPath $pkgProperties.ChangeLogPath -Unreleased $False `
  -ReplaceLatestEntryTitle $ReplaceLatestEntryTitle -ReleaseDate $ReleaseDate
}

Write-Host "New Version: ${packageSemVer}"

# Allow the prerelease label to also be preview until all those ship as GA
if ($packageSemVer.PrereleaseLabel -eq "preview") {
  $packageSemVer.DefaultPrereleaseLabel = "preview"
}

if ($packageSemVer.HasValidPrereleaseLabel() -ne $true){
  Write-Error "Invalid prerelease label"
  exit 1
}

if (!$packageOldSemVer.IsPrerelease -and ($packageVersion -ne $NewVersionString)) {
  $whitespace = $propertyGroup["Version"].PreviousSibling
  if (!$propertyGroup.ApiCompatVersion) {
    $propertyGroup.InsertAfter($csproj.CreateElement("ApiCompatVersion"), $propertyGroup["Version"]) | Out-Null
    $propertyGroup.InsertAfter($whitespace.Clone(), $propertyGroup["Version"]) | Out-Null
  }
  $ApiCompatVersionComment = "The ApiCompatVersion is managed automatically and should not generally be modified manually."
  if (!($propertyGroup.InnerXml -Match $ApiCompatVersionComment)){
    $comment = $csproj.CreateComment($ApiCompatVersionComment);
    $propertyGroup.InsertAfter($comment, $propertyGroup["Version"]) | Out-Null
    $propertyGroup.InsertAfter($whitespace.Clone(), $propertyGroup["Version"]) | Out-Null
  }
  $propertyGroup.ApiCompatVersion = $packageOldSemVer.ToString()
}

$propertyGroup.Version = $packageSemVer.ToString()
$csproj.Save($csprojPath)

# Update Central Package Management files with the released version so
# other packages that depend on this one pick up the latest release.
# Wrapped in its own try/catch so a CPM failure never blocks the version bump PR.
try {
  $releasedVersion = $packageOldSemVer.ToString()
  $escapedName = [regex]::Escape($PackageName)
  # Match PackageVersion (Include|Update) and PackageReference (Update) entries with literal versions.
  # The version must start with a digit to skip MSBuild property references like $(SomeVersion).
  $versionPattern = '(<Package(?:Version|Reference)\s+(?:Include|Update)="' + $escapedName + '"\s+Version=")(\d[^"]*?)(")'
  $totalUpdates = 0

  # New CPM structure (post CPM migration): eng/centralpackagemanagement/*.Packages.props
  # Update all occurrences in files directly in this directory — NOT in overrides/ subdirectory.
  $cpmDir = Join-Path $RepoRoot "eng" "centralpackagemanagement"
  if (Test-Path -LiteralPath $cpmDir -PathType Container) {
    $cpmFiles = Get-ChildItem -LiteralPath $cpmDir -File -Filter '*.Packages.props'
    foreach ($file in $cpmFiles) {
      $content = Get-Content -LiteralPath $file.FullName -Raw
      if (-not $content) { continue }
      $newContent = [regex]::Replace($content, $versionPattern, '${1}' + $releasedVersion + '${3}')

      if ($newContent -ne $content) {
        Set-Content -LiteralPath $file.FullName -Value $newContent -NoNewline
        Write-Host "Updated package '$PackageName' version to '$releasedVersion' in '$($file.FullName)'"
        $totalUpdates++
      }
    }
  }

  # Old format (pre CPM migration): eng/Packages.Data.props
  # Only update entries inside the three central ItemGroups (approved dependencies,
  # build-time packages, and test/support packages). Per-package override ItemGroups
  # that use MSBuildProjectName conditions must NOT be touched.
  $oldFile = Join-Path $RepoRoot "eng" "Packages.Data.props"
  if (Test-Path -LiteralPath $oldFile -PathType Leaf) {
    [xml]$propsXml = Get-Content -LiteralPath $oldFile -Raw

    # Build a set of line numbers that are safe to update by walking the XML DOM.
    # Safe ItemGroups: those without conditions referencing MSBuildProjectName,
    # TargetFramework, or legacy library filters.
    $safeLineNumbers = @{}
    foreach ($itemGroup in $propsXml.SelectNodes('//ItemGroup')) {
      $condition = $itemGroup.GetAttribute('Condition')
      if ($condition -match 'MSBuildProjectName') { continue }
      if ($condition -match 'TargetFramework') { continue }
      if ($condition -match "'`\$\(IsClientLibrary\)'\s*!=\s*'true'") { continue }

      foreach ($node in $itemGroup.ChildNodes) {
        if ($node.NodeType -ne 'Element') { continue }
        if ($node.LocalName -ne 'PackageReference' -and $node.LocalName -ne 'PackageVersion') { continue }
        $nameAttr = $node.GetAttribute('Update')
        if (-not $nameAttr) { $nameAttr = $node.GetAttribute('Include') }
        if ($nameAttr -eq $PackageName) {
          $versionAttr = $node.GetAttribute('Version')
          if ($versionAttr -and $versionAttr -notmatch '^\$' -and $versionAttr -notmatch '^\[') {
            # XmlReader-based line info isn't available after loading, so we match by
            # the unique combination of element+name+version to build a targeted regex.
            $safeLineNumbers[$versionAttr] = $true
          }
        }
      }
    }

    if ($safeLineNumbers.Count -gt 0) {
      $content = Get-Content -LiteralPath $oldFile -Raw
      # For each safe version found, build a targeted pattern that only matches
      # the exact package with that exact old version (to avoid touching overrides).
      $newContent = $content
      foreach ($oldVersion in $safeLineNumbers.Keys) {
        $escapedOldVersion = [regex]::Escape($oldVersion)
        $targetedPattern = '(<Package(?:Version|Reference)\s+(?:Include|Update)="' + $escapedName + '"\s+Version=")' + $escapedOldVersion + '(")'
        $newContent = [regex]::Replace($newContent, $targetedPattern, '${1}' + $releasedVersion + '${2}')
      }

      if ($newContent -ne $content) {
        Set-Content -LiteralPath $oldFile -Value $newContent -NoNewline
        Write-Host "Updated package '$PackageName' version to '$releasedVersion' in '$oldFile'"
        $totalUpdates++
      }
    }
  }

  Write-Host "Updated $totalUpdates central package management file(s)"
}
catch {
  Write-Warning "CPM update failed — central package management will need to be updated manually: $($_.Exception.Message)"
  Write-Host "##vso[task.logissue type=warning]CPM update failed for package version bump. Central package management files will need a manual update."
}