[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageInfoFilePath,
    [Parameter(Mandatory = $true)]
    [string]$AzsdkExePath
)

<#
.SYNOPSIS
    Updates release status only for packages with explicit release-plan correlation metadata.

.DESCRIPTION
    Reads ReleasePlanId and a single ApiVersion from each package-info artifact and validates them
    through azsdk before updating a plan. These values must describe this specific package build;
    they must not be inferred from the latest plan or inherited by unrelated SDK-only releases.
    Packages without correlation metadata are skipped without affecting package publication.

.PARAMETER PackageInfoFilePath
    The path to the package information file (required) or path to the directory containing package information files.

.PARAMETER AzsdkExePath
    The path to the azsdk executable used to mark the release completion.
#>

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'
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
    $pkgInfo = Get-Content -LiteralPath $packageInfoPath -Raw | ConvertFrom-Json -AsHashtable
    if ($pkgInfo -isnot [System.Collections.IDictionary])
    {
        Write-Warning "Package information must be a JSON object: $packageInfoPath. No release plan was updated."
        return
    }
    $PackageName = $pkgInfo['Name']
    if ($PackageName -isnot [string] -or [string]::IsNullOrWhiteSpace($PackageName))
    {
        Write-Host "Package name is not available in the package information file. Skipping the release plan status update for the package."
        return
    }

    $planIdValue = $pkgInfo['ReleasePlanId']
    if ($null -eq $planIdValue -or [string]::IsNullOrWhiteSpace([string]$planIdValue) -or "$planIdValue" -eq '0')
    {
        Write-Host "Package '$PackageName' has no release-plan ID. No release plan was updated."
        return
    }
    $releasePlanId = 0
    if (-not [int]::TryParse([string]$planIdValue, [ref]$releasePlanId) -or $releasePlanId -le 0)
    {
        Write-Warning "Package '$PackageName' has an invalid release-plan ID. No release plan was updated."
        return
    }

    $apiVersion = $pkgInfo['ApiVersion']
    if ($apiVersion -isnot [string] -or [string]::IsNullOrWhiteSpace($apiVersion))
    {
        Write-Warning "Package '$PackageName' must have one explicit ApiVersion for release plan $releasePlanId. No release plan was updated."
        return
    }

    Write-Host "Validating release plan $releasePlanId for package '$PackageName', language '$LanguageDisplayName', API version '$apiVersion'."
    $releaseArgs = @("release-plan", "update-release-status", "--package-name", $PackageName, "--language", $LanguageDisplayName, "--status", "Released", "--release-plan-id", "$releasePlanId", "--api-version", $apiVersion)
    $PackageVersion = $pkgInfo['Version']
    if ($null -ne $PackageVersion -and -not [string]::IsNullOrWhiteSpace([string]$PackageVersion))
    {
        if ($PackageVersion -isnot [string])
        {
            Write-Warning "Package '$PackageName' has invalid package-version metadata. No release plan was updated."
            return
        }
        $version = [AzureEngSemanticVersion]::ParseVersionString($PackageVersion)
        if (!$version)
        {
            Write-Warning "Failed to parse version '$PackageVersion' for package '$PackageName'. No release plan was updated."
            return
        }
        $sdkReleaseType = if ($version.IsPrerelease) { 'beta' } else { 'stable' }
        $releaseArgs += @("--package-version", $PackageVersion, "--sdk-release-type", $sdkReleaseType)
    }
    $releaseInfo = & $AzsdkExePath @releaseArgs
    if ($LASTEXITCODE -ne 0)
    {
        ## Not all releases have a release plan. So we should not fail the script even if a release plan is missing.
        Write-Host "Failed to mark release completion for package '$PackageName' using azsdk. Exit code: $LASTEXITCODE"
    }
    Write-Host "Details: $releaseInfo"
    return
}

Write-Host "Finding all package info files in the path: $PackageInfoFilePath"
# Get all package info file under the directory given in input param and process
foreach ($packageInfoFile in Get-ChildItem -Path $PackageInfoFilePath -Filter "*.json" -File)
{
    try
    {
        Write-Host "Processing package info file: $packageInfoFile"
        Process-Package $packageInfoFile.FullName
    }
    catch
    {
        Write-Warning "Failed to update release status for '$packageInfoFile': $($_.Exception.Message)"
    }
}
