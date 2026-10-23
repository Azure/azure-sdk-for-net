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
    [string]$SdkPullRequest = '',
    [string]$PipelineUrl = ''
)

<#
.SYNOPSIS
    Updates release status using an explicit release-plan ID or SDK PR when supplied, otherwise the legacy package lookup.

.DESCRIPTION
    Uses the requester-supplied release-plan ID for manual releases, or the triggering SDK PR
    for automatic releases. azsdk resolves the existing ADO plan and validates the language/package.
    When neither is supplied, the current run URL can identify the plan recorded by auto-release preparation.
    TRANSITIONAL: without a recorded association, azsdk falls back to the package-name lookup.

.PARAMETER PackageInfoFilePath
    The path to the package information file (required) or path to the directory containing package information files.

.PARAMETER AzsdkExePath
    The path to the azsdk executable used to mark the release completion.

.PARAMETER ReleasePlanId
    The release-plan ID explicitly supplied for this manual release. Zero means no manual association.

.PARAMETER SdkPullRequest
    The unambiguous SDK PR that triggered the automatic release. Not a spec PR or a previous package PR.

.PARAMETER PipelineUrl
    The current release pipeline URL, recorded for manual and automatic releases. When omitted in Azure Pipelines,
    derive it from the current run so direct script callers retain the preparation-stage association.
#>

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'
[int]$suppliedPlanId = [int]::Parse($ReleasePlanId, [System.Globalization.CultureInfo]::InvariantCulture)
if ([string]::IsNullOrWhiteSpace($PipelineUrl) -and $env:TF_BUILD -eq 'True' -and
    -not [string]::IsNullOrWhiteSpace($env:SYSTEM_COLLECTIONURI) -and
    -not [string]::IsNullOrWhiteSpace($env:SYSTEM_TEAMPROJECT) -and $env:BUILD_BUILDID -match '^[1-9][0-9]*$')
{
    $PipelineUrl = "$env:SYSTEM_COLLECTIONURI$env:SYSTEM_TEAMPROJECT/_build/results?buildId=$env:BUILD_BUILDID"
}
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

    $isLegacyLookup = ($suppliedPlanId -eq 0 -and [string]::IsNullOrWhiteSpace($SdkPullRequest) -and [string]::IsNullOrWhiteSpace($PipelineUrl))
    if ($isLegacyLookup)
    {
        Write-Host "LEGACY_RELEASE_PLAN_LOOKUP: Package '$PackageName' has no release-plan ID or triggering SDK PR; using the legacy package lookup. Forward ReleasePlanId or SdkPullRequest from the release pipeline."
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
    if (-not [string]::IsNullOrWhiteSpace($PipelineUrl))
    {
        $releaseArgs += @("--release-pipeline", $PipelineUrl)
    }
    $PackageVersion = $pkgInfo['Version']
    $version = $null
    if ($PackageVersion -is [string] -and -not [string]::IsNullOrWhiteSpace($PackageVersion))
    {
        $version = [AzureEngSemanticVersion]::ParseVersionString($PackageVersion)
    }
    if ($version)
    {
        $sdkReleaseType = if ($version.IsPrerelease) { 'beta' } else { 'stable' }
        $releaseArgs += @("--package-version", $PackageVersion, "--sdk-release-type", $sdkReleaseType)
    }
    else
    {
        Write-Host "Package version is missing or invalid for '$PackageName'. Updating release status without version metadata."
    }
    $releaseInfo = & $AzsdkExePath @releaseArgs
    if ($LASTEXITCODE -ne 0)
    {
        ## Not all releases have a release plan. So we should not fail the script even if a release plan is missing.
        Write-Host "Release plan status was not updated for package '$PackageName'. Exit code: $LASTEXITCODE. Not all packages have a release plan."
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

# Status reporting must not change the outcome of an already completed package release.
exit 0
