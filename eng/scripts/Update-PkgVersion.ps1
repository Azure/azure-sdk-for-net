<#
.SYNOPSIS
Bumps up package versions after release

.DESCRIPTION
This script bumps up package versions following conventions defined at https://github.com/Azure/azure-sdk/blob/master/docs/policies/releases.md#incrementing-after-release-net

.PARAMETER RepoRoot
The Root of the repo

.PARAMETER ServiceDirectory
The Name of the Service Directory

.PARAMETER PackageName
The Name of the Package

.PARAMETER PackageDirName
Used in the case where the package directory name is different from the package name. e.g in cognitiveservice packages

.PARAMETER NewVersionString
Use this to overide version incement logic and set a version specified by this parameter


.EXAMPLE
Updating package version for Azure.Core
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core

Updating package version for Azure.Core with a specified verion
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core -NewVersionString 2.0.5

Updating package version for Azure.Core with a specified verion and release date
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core -NewVersionString 2.0.5 -ReleaseDate "2020-05-01"

Updating package version for Microsoft.Azure.CognitiveServices.AnomalyDetector
Update-PkgVersion.ps1 -ServiceDirectory cognitiveservices -PackageName Microsoft.Azure.CognitiveServices.AnomalyDetector -PackageDirName AnomalyDetector

#>

[CmdletBinding()]
Param (
  [ValidateNotNullOrEmpty()]
  [string] $RepoRoot = "${PSScriptRoot}/../..",
  [Parameter(Mandatory=$True)]
  [string] $ServiceDirectory,
  [Parameter(Mandatory=$True)]
  [string] $PackageName,
  [string] $PackageDirName,
  [string] $NewVersionString,
  [string] $ReleaseDate
)

. ${PSScriptRoot}\..\common\scripts\SemVer.ps1
# Obtain Current Package Version
if ([System.String]::IsNullOrEmpty($PackageDirName)) { $PackageDirName = $PackageName }
$changelogPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $PackageDirName "CHANGELOG.md"
$csprojPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $PackageDirName "src" "${PackageName}.csproj"
$csproj = new-object xml
$csproj.PreserveWhitespace = $true
$csproj.Load($csprojPath)
$propertyGroup = ($csproj | Select-Xml "Project/PropertyGroup/Version").Node.ParentNode
$packageVersion = $propertyGroup.Version

$packageSemVer = [AzureEngSemanticVersion]::new($packageVersion)
$packageOldSemVer = [AzureEngSemanticVersion]::new($packageVersion)
Write-Host "Current Version: ${PackageVersion}"

if ([System.String]::IsNullOrEmpty($NewVersionString)) {
  $packageSemVer.IncrementAndSetToPrerelease()

  & "${PSScriptRoot}/../common/scripts/Update-ChangeLog.ps1" -Version $packageSemVer.ToString() `
  -ServiceDirectory $ServiceDirectory -PackageName $PackageName -Unreleased $True
}
else {
  $packageSemVer = [AzureEngSemanticVersion]::new($NewVersionString)

  & "${PSScriptRoot}/../common/scripts/Update-ChangeLog.ps1" -Version $packageSemVer.ToString() `
  -ServiceDirectory $ServiceDirectory -PackageName $PackageName -Unreleased $False `
  -ReplaceLatestEntryTitle $True -ReleaseDate $ReleaseDate
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
  if (!$propertyGroup.ApiCompatVersion) {
    $propertyGroup.InsertAfter($csproj.CreateElement("ApiCompatVersion"), $propertyGroup["Version"]) | Out-Null
    $whitespace = $propertyGroup["Version"].PreviousSibling
    $propertyGroup.InsertAfter($whitespace.Clone(), $propertyGroup["Version"]) | Out-Null
  }
  $propertyGroup.ApiCompatVersion = $packageOldSemVer.ToString()
}

$propertyGroup.Version = $packageSemVer.ToString()
$csproj.Save($csprojPath)