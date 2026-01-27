param(    
    [Parameter(Mandatory = $true)]
    [string]$PackageInfoFilePath,
    [Parameter(Mandatory = $true)]
    [string]$AzsdkExePath
)

<#
.SYNOPSIS
    Marks release plan completion by identifying pull requests that changed files in a given path.

.DESCRIPTION
    This script helps to mark release plan completion by finding the active release plans for a package name

.PARAMETER PackageInfoFilePath
    The path to the package information file (required) or path to the directory containing package information files.

.PARAMETER AzsdkExePath
    The path to the azsdk executable used to mark the release completion.
#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)

#Get package properties
if (-Not (Test-Path $PackageInfoFilePath))
{
    Write-Host "Package information file path $($PackageInfoFilePath) is invalid."
    exit 0
}

function Process-Package([string]$packageInfoPath)
{
    # Get package info from json file created before updating version to daily dev
    $pkgInfo = Get-Content $packageInfoPath | ConvertFrom-Json
    $PackageName = $pkgInfo.Name
    if (!$PackageName)
    {
        Write-Host "Package name is not available in the package information file. Skipping the release plan status update for the package."
        return
    } 

    Write-Host "Marking release completion for package, name: $PackageName"
    $releaseInfo = &$AzsdkExePath release-plan update-release-status -p $PackageName -l $LanguageDisplayName -s "Released"
    Write-Host "Details: $releaseInfo"
}

Write-Host "Finding all package info files in the path: $PackageInfoFilePath"
# Get all package info file under the directory given in input param and process
Get-ChildItem -Path $PackageInfoFilePath -Filter "*.json" | ForEach-Object {
    Write-Host "Processing package info file: $_"
    Process-Package $_.FullName
}