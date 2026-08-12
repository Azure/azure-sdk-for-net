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

#Validate azsdk executable path
if (-Not (Test-Path $AzsdkExePath))
{
    Write-Error "The azsdk executable was not found at path '$AzsdkExePath'. Please ensure the executable exists and the path is correct."
    exit 1
}

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
        return $true
    } 

    Write-Host "Marking release completion for package, name: $PackageName"
    $PackageVersion = $pkgInfo.Version
    $version = [AzureEngSemanticVersion]::ParseVersionString($PackageVersion)
    if (!$version)
    {
        Write-Host "Failed to parse version string '$($PackageVersion)' for package '$PackageName'. Skipping the release plan status update."
        return $true
    }

    $sdkReleaseType = ""
    if ($version.IsPrerelease)
    {
        $sdkReleaseType = "beta"
    }
    else
    {
        $sdkReleaseType = "stable"
    }

    $releaseArgs = @("release-plan", "update-release-status", "--package-name", $PackageName, "--language", $LanguageDisplayName, "--status", "Released", "--sdk-release-type", $sdkReleaseType)
    if ($PackageVersion)
    {
        $releaseArgs += @("--package-version", $PackageVersion)
    }
    $releaseInfo = & $AzsdkExePath @releaseArgs
    $releaseExitCode = $LASTEXITCODE
    Write-Host "Details: $releaseInfo"
    if ($releaseExitCode -ne 0)
    {
        Write-Warning "Failed to mark release completion for package '$PackageName' using azsdk. Exit code: $releaseExitCode"
        return $false
    }
    return $true
}

Write-Host "Finding all package info files in the path: $PackageInfoFilePath"
$hasFailures = $false
# Get all package info file under the directory given in input param and process
Get-ChildItem -Path $PackageInfoFilePath -Filter "*.json" | ForEach-Object {
    Write-Host "Processing package info file: $_"
    if (!(Process-Package $_.FullName))
    {
        $hasFailures = $true
    }
}

if ($hasFailures)
{
    exit 1
}