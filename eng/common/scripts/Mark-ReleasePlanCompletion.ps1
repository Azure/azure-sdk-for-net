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
    Updates release status using an explicit release-plan ID or SDK PR when supplied, otherwise the plan that recorded this release run, otherwise the legacy package lookup.

.DESCRIPTION
    Uses the requester-supplied release-plan ID for manual releases, or the triggering SDK PR
    for automatic releases. azsdk resolves the existing ADO plan and validates the language/package.
    When neither is supplied, azsdk updates the one plan that already recorded this release run URL for the package
    (the auto-release preparation stage records it), so callers need no stage-to-stage output mapping.
    Several matching plans stop the update. TRANSITIONAL: when no plan recorded this run, the original package-name lookup
    is used so pipelines that do not yet forward the association keep working.

.PARAMETER PackageInfoFilePath
    The path to the package information file (required) or path to the directory containing package information files.

.PARAMETER AzsdkExePath
    The path to the azsdk executable used to mark the release completion.

.PARAMETER ReleasePlanId
    The release-plan ID explicitly supplied for this manual release. Zero means no manual association.

.PARAMETER SdkPullRequest
    The unambiguous SDK PR that triggered the automatic release. Not a spec PR or a previous package PR.

.PARAMETER PipelineUrl
    The current release pipeline URL, recorded for manual and automatic releases. When omitted, it is built from the
    standard Azure Pipelines variables (SYSTEM_COLLECTIONURI, SYSTEM_TEAMPROJECT, BUILD_BUILDID) if all are set.
#>

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'
[int]$suppliedPlanId = [int]::Parse($ReleasePlanId, [System.Globalization.CultureInfo]::InvariantCulture)
. (Join-Path $PSScriptRoot common.ps1)

# Same format the auto-release preparation stage records on the release plan.
if ([string]::IsNullOrWhiteSpace($PipelineUrl))
{
    $collectionUri = [Environment]::GetEnvironmentVariable('SYSTEM_COLLECTIONURI')
    $teamProject = [Environment]::GetEnvironmentVariable('SYSTEM_TEAMPROJECT')
    $buildId = [Environment]::GetEnvironmentVariable('BUILD_BUILDID')
    if ($collectionUri -and $teamProject -and $buildId)
    {
        $PipelineUrl = "$($collectionUri.TrimEnd('/'))/$teamProject/_build/results?buildId=$buildId"
    }
}

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

    $isLegacyLookup = ($suppliedPlanId -eq 0 -and [string]::IsNullOrWhiteSpace($SdkPullRequest))
    if ($isLegacyLookup)
    {
        Write-Host "LEGACY_RELEASE_PLAN_LOOKUP: Package '$PackageName' has no release-plan ID or triggering SDK PR. azsdk uses the plan that recorded this release run when exactly one did; otherwise it uses the legacy package lookup."
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
