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
    $content = Get-Content -LiteralPath $oldFile -Raw

    # Walk each ItemGroup block individually. Check the Condition attribute to decide
    # whether this block is safe to update, then only replace within that block's body.
    $itemGroupPattern = '<ItemGroup(?<attrs>[^>]*)>(?<body>.*?)</ItemGroup>'
    $regexOptions = [System.Text.RegularExpressions.RegexOptions]::Singleline
    $packagePattern = '(<Package(?:Version|Reference)\s+(?:Include|Update)="' + $escapedName + '"\s+Version=")(\d[^"]*?)(")'

    $builder = New-Object System.Text.StringBuilder
    $lastIndex = 0
    $oldFileUpdated = $false

    foreach ($match in [regex]::Matches($content, $itemGroupPattern, $regexOptions)) {
      # Append content before this ItemGroup unchanged.
      if ($match.Index -gt $lastIndex) {
        [void]$builder.Append($content.Substring($lastIndex, $match.Index - $lastIndex))
      }

      $attrs = $match.Groups['attrs'].Value
      $body = $match.Groups['body'].Value

      # Determine if this ItemGroup is safe to update.
      $isUnsafe = ($attrs -match 'MSBuildProjectName') -or
                  ($attrs -match 'TargetFramework') -or
                  ($attrs -match "IsClientLibrary\)'\s*!=\s*'true'")

      $newBody = $body
      if (-not $isUnsafe) {
        $newBody = [regex]::Replace($body, $packagePattern, '${1}' + $releasedVersion + '${3}')
        if ($newBody -ne $body) { $oldFileUpdated = $true }
      }

      [void]$builder.Append('<ItemGroup' + $attrs + '>' + $newBody + '</ItemGroup>')
      $lastIndex = $match.Index + $match.Length
    }

    if ($lastIndex -lt $content.Length) {
      [void]$builder.Append($content.Substring($lastIndex))
    }

    if ($oldFileUpdated) {
      Set-Content -LiteralPath $oldFile -Value $builder.ToString() -NoNewline
      Write-Host "Updated package '$PackageName' version to '$releasedVersion' in '$oldFile'"
      $totalUpdates++
    }
  }

  Write-Host "Updated $totalUpdates central package management file(s)"
}
catch {
  Write-Warning "CPM update failed — central package management will need to be updated manually: $($_.Exception.Message)"
  Write-Host "##vso[task.logissue type=warning]CPM update failed for package version bump. Central package management files will need a manual update."
}