param(    
    [Parameter(Mandatory = $true)]
    [string]$PackageArtifactName,

    [Parameter(Mandatory = $true)]
    [string]$PackageConfigPath
)

<#
.SYNOPSIS
    Marks release plan completion by identifying pull requests that changed files in a given path.

.DESCRIPTION
    This script helps to mark release plan completion by finding the active release plans for a package name

.PARAMETER PackageArtifactName
    The package artifact name being released (required)

.PARAMETER PackageConfigPath
    The path to the package configuration file (required)
#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)


#Get package properties
$pkgPropPath = Join-Path -Path $PackageConfigPath "$PackageArtifactName.json"
if (-Not (Test-Path $pkgPropPath))
{
    Write-Host "Package property file path $($pkgPropPath) is invalid."
    exit 0
}
# Get package info from json file created before updating version to daily dev
$pkgInfo = Get-Content $pkgPropPath | ConvertFrom-Json
$PackageVersion = $pkgInfo.Version
$PackageName = $pkgInfo.Name
if (!$PackageName -or !$PackageVersion)
{
    Write-Host "Package name or version is not available in the package property file. Skipping the release plan status update for the package."
    exit 0
}

# Check Azure DevOps Release Plan work items if LanguageShort is available
Write-Host "Checking active release plan work items for package: $PackageName"
$workItems = Get-ReleasePlanForPackage $PackageName
if(!$workItems)
{
    Write-Host "No active release plans found for package name: $PackageName."
    exit 0
}

$activeReleasePlan = $workItems
if($workItems.Count -gt 1 -and ($workItems -is [System.Array]))
{    
    $concatenatedIds = ($workItems | Select-Object -ExpandProperty id) -join ','
    Write-Host "Multiple release plans found for package name: $PackageName with work item IDs: $concatenatedIds. Using the first release plan to update release status."
    $activeReleasePlan = $workItems[0]
}
# Update release status
Write-Host "Release plan work item ID: $($activeReleasePlan["id"])"
Write-Host "Marking release completion for package, name: $PackageName version: $PackageVersion"
Update-ReleaseStatusInReleasePlan $activeReleasePlan.id "Released" $PackageVersion
Write-Host "Successfully marked release completion for package, name: $PackageName version: $PackageVersion."
