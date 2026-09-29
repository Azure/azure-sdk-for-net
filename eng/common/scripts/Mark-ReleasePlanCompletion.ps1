[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageInfoFilePath,
    [Parameter(Mandatory = $true)]
    [string]$AzsdkExePath,
    [ValidateScript({
        $id = 0
        if (-not [int]::TryParse($_, [System.Globalization.NumberStyles]::None, [System.Globalization.CultureInfo]::InvariantCulture, [ref]$id))
        {
            throw 'Release plan ID must be a nonnegative 32-bit integer, without fractions or whitespace.'
        }
        return $true
    })]
    [string]$ReleasePlanId = '0',
    [string]$SdkPullRequest = ''
)

<#
.SYNOPSIS
    Updates release status only for packages with explicit release-plan correlation metadata.

.DESCRIPTION
    Uses the requester-supplied release-plan ID for manual releases, or the triggering SDK PR
    for automatic releases. azsdk resolves the existing ADO plan and validates the language/package.
    No API version or package-name-to-plan mapping is used. Missing correlation skips the update.

.PARAMETER PackageInfoFilePath
    The path to the package information file (required) or path to the directory containing package information files.

.PARAMETER AzsdkExePath
    The path to the azsdk executable used to mark the release completion.

.PARAMETER ReleasePlanId
    The release-plan ID explicitly supplied for this manual release. Zero means no manual association.

.PARAMETER SdkPullRequest
    The unambiguous SDK PR that triggered the automatic release. Not a spec PR or a previous package PR.
#>

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'
[int]$suppliedPlanId = [int]::Parse($ReleasePlanId, [System.Globalization.CultureInfo]::InvariantCulture)
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

    if ($suppliedPlanId -eq 0 -and [string]::IsNullOrWhiteSpace($SdkPullRequest))
    {
        Write-Host "Package '$PackageName' has no supplied release-plan ID or triggering SDK PR. No release plan was updated."
        return
    }

    # Do not inherit plan IDs from package metadata; unrelated bug-fix builds can reuse those files.
    Write-Host "Correlating release status for package '$PackageName', language '$LanguageDisplayName'."
    $releaseArgs = @("release-plan", "update-release-status", "--package-name", $PackageName, "--language", $LanguageDisplayName, "--status", "Released")
    if ($suppliedPlanId -gt 0)
    {
        $releaseArgs += @("--release-plan-id", "$suppliedPlanId")
    }
    if (-not [string]::IsNullOrWhiteSpace($SdkPullRequest))
    {
        $releaseArgs += @("--sdk-pull-request", $SdkPullRequest)
    }
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
        Write-Warning "Failed to mark release completion for package '$PackageName' using azsdk. Exit code: $LASTEXITCODE. Investigate the correlation error; do not republish the package."
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
