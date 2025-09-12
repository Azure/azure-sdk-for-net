param(    
    [Parameter(Mandatory = $true)]
    [string]$PackageInfoFilePath
)

<#
.SYNOPSIS
    Marks release plan completion by identifying pull requests that changed files in a given path.

.DESCRIPTION
    This script helps to mark release plan completion by finding the active release plans for a package name

.PARAMETER PackageInfoFilePath
    The path to the package information file (required) or path to the directory containing package information files.
#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)


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
    $PackageVersion = $pkgInfo.Version
    $PackageName = $pkgInfo.Name
    if (!$PackageName -or !$PackageVersion)
    {
        Write-Host "Package name or version is not available in the package information file. Skipping the release plan status update for the package."
        return
    }

    # Check Azure DevOps Release Plan work items
    Write-Host "Checking active release plan work items for package: $PackageName"
    $workItems = Get-ReleasePlanForPackage $PackageName
    if(!$workItems)
    {
        Write-Host "No active release plans found for package name: $PackageName."
        return
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
}

Write-Host "Finding all package info files in the path: $PackageInfoFilePath"
# Get all package info file under the directory given in input param and process
Get-ChildItem -Path $PackageInfoFilePath -Filter "*.json" | ForEach-Object {
    Write-Host "Processing package info file: $_"
    Process-Package $_.FullName
}