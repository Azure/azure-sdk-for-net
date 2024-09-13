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