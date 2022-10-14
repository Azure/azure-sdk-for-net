<#
  .SYNOPSIS
  Fetch the namespaces from dotnet nupkg and checkin to docs/metadata

  .DESCRIPTION
  The scripts is used for docs.ms to fetch namespace list for particular nupkg artifact.

  .PARAMETER DotnetNupkgLocation
  Specifies the fo nupkg location.

  .PARAMETER DocRepoLocation
  Specifies Location of the root of the docs.microsoft.com reference doc location. 

  .PARAMETER ArtifactName
  The artifact name. E.g. Azure.Template
#>
[CmdletBinding()]
param (
  [string] $DotnetNupkgLocation,
  [string] $DocRepoLocation,
  [string] $ArtifactName
)
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot ../common/scripts/common.ps1)

Write-Host "DotnetNupkgLocation: $DotnetNupkgLocation/$ArtifactName"
Write-Host "DocRepoLocation: $DocRepoLocation"

$nupkgFile = Get-dotnet-Package-Artifacts -Location "$DotnetNupkgLocation/$ArtifactName"
$version = $nupkgFile.Name -replace "$([Regex]::Escape($ArtifactName))\.(.*\d)\.nupkg", '$1'
Write-Host "The full version: $version"
$originalVersion = [AzureEngSemanticVersion]::ParseVersionString($version)
Write-Host "The origin version: $originalVersion"
$metadataMoniker = 'latest'
if ($originalVersion -and $originalVersion.IsPrerelease) {
  $metadataMoniker = 'preview'
}
$packageNameLocation = "$DocRepoLocation/metadata/$metadataMoniker"
New-Item -ItemType Directory -Path $packageNameLocation -Force
Write-Host "The moniker $packageNameLocation"

Fetch-NamespacesFromNupkg $nupkgFile.FullName "$packageNameLocation/$ArtifactName.txt"
