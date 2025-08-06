param(
    [Parameter(Mandatory = $true)]
    [string]$Path,
    
    [Parameter(Mandatory = $true)]
    [string]$PackageName,

    [Parameter(Mandatory = $true)]
    [string]$PackageVersion,
    
    [Parameter(Mandatory = $true)]
    [string]$GitHubRepoUrl,
    
    [Parameter(Mandatory = $false)]
    [int]$MaxCount = 5
)

<#
.SYNOPSIS
    Marks release plan completion by identifying pull requests that changed files in a given path.

.DESCRIPTION
    This script helps mark release plan completion by searching through git commit history to find 
    "Merge pull request" commits that affected files in the specified path. It extracts pull request 
    numbers and generates GitHub links to track what changes were included in the release.

.PARAMETER Path
    The file or directory path to check for changes (required)

.PARAMETER PackageName
    The package name being released (required)

.PARAMETER PackageVersion
    The package version being released (required)

.PARAMETER GitHubRepoUrl
    The GitHub repository URL.

.PARAMETER MaxCount
    Maximum number of recent pull request merges to check (default: 5)

#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)

$AzureDevOpsOrganization = "azure-sdk"
$AzureDevOpsProject = "Release"


function Get-MergedPullRequests()
{
    Write-Host "Searching for merged pull requests..."
    $gitArgs = @(
        "log"
        "--grep=Merge pull request"
        "--oneline"
        "--max-count=$MaxCount"
        "--"
        $Path
    )

    Write-Host "Executing: git $($gitArgs -join ' ')"
    $commits = & git @gitArgs 2>$null    
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Git command failed with exit code $LASTEXITCODE"
        exit 1
    }

    if (-not $commits) {
        Write-Host "No merge pull request commits found for the specified path."
        exit 0
    }

    $pullRequests = @()
    foreach ($commit in $commits) {
        # Parse commit hash and message
        if ($commit -match "Merge pull request #(\d+)") {
            $prNumber = $matches[1]
            if ($prNumber)
            {  
                $prLink = "$GitHubRepoUrl/pull/$prNumber"
                $pullRequests += $prLink
                Write-Host "Merged pull request: $prLink"
            }
        }
        break
    }
    return $pullRequests
}


# Verify the path exists
if (-not (Test-Path $Path)) {
    Write-Warning "Path '$Path' does not exist in the current repository"
}

# Main execution
Write-Host "Finding most recent merged pull requests for path: $Path"

$pullRequests = Get-MergedPullRequests
if (!$pullRequests)
{
    Write-Host "No valid pull request commits found."
    exit 0
}
# Check Azure DevOps Release Plan work items if LanguageShort is available
Write-Host "Checking Azure DevOps Release Plan work items for language: $LanguageShort"
$workItems = @()
foreach ($prLink in $pullRequests)
{
    Write-Host "Searching for work items related to pull request: $prLink"
    $workItems += Get-ReleasePlanForPullRequest $prLink
    if ($LASTEXITCODE -ne 0)
    {
        Write-Error "Failed to search Azure DevOps work items." -ForegroundColor Red
        exit 1
    }
}

if(!$workItems)
{
    Write-Host "No active release plans found for the merged pull requests." -ForegroundColor Yellow
    exit 0
}

# Update release status
Write-Host "Marking release completion for package, name: $PackageName version: $PackageVersion"
foreach ($workItem in $workItems)
{
    Update-ReleaseStatusInReleasePlan $workItem.id "Released" $PackageVersion
    if ($LASTEXITCODE -ne 0)
    {
        Write-Error "Failed to update release status for work item ID $($workItem.id)." -ForegroundColor Red
        exit 1
    }
}
Write-Host "Successfully marked release completion for package, name: $PackageName version: $PackageVersion."
