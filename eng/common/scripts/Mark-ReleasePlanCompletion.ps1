param(    
    [Parameter(Mandatory = $true)]
    [string]$PackageName,

    [Parameter(Mandatory = $true)]
    [string]$PackageVersion,
    
    [Parameter(Mandatory = $false)]
    [int]$MaxCount = 5
)

<#
.SYNOPSIS
    Marks release plan completion by identifying pull requests that changed files in a given path.

.DESCRIPTION
    This script helps to mark release plan completion by finding the active release plans for a package name

.PARAMETER PackageName
    The package name being released (required)

.PARAMETER PackageVersion
    The package version being released (required)

.PARAMETER MaxCount
    Maximum number of recent pull request merges to check (default: 5)

#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)

$AzureDevOpsOrganization = "azure-sdk"
$AzureDevOpsProject = "Release"
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
    $activeReleasePlan = $workItems[0]
    Write-Warning "Multiple active release plans found for package name: $PackageName. Using the first release plan to update release status."    
}
# Update release status
Write-Host "Release plan work item ID: $($activeReleasePlan["id"])"
Write-Host "Marking release completion for package, name: $PackageName version: $PackageVersion"
Update-ReleaseStatusInReleasePlan $activeReleasePlan.id "Released" $PackageVersion
Write-Host "Successfully marked release completion for package, name: $PackageName version: $PackageVersion."
