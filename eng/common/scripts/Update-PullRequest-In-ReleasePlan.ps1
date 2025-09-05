param(    
    [Parameter(Mandatory = $true)]
    $ReleasePlanWorkItemId,
    [Parameter(Mandatory = $true)]
    $PullRequestUrl,
    [Parameter(Mandatory = $true)]
    $Status,
    [Parameter(Mandatory = $true)]
    $LanguageName,
    [Parameter(Mandatory = $true)]
    $AuthToken
)

<#
.SYNOPSIS
Updates the pull request URL and status in the specified release plan work item for a given programming language.

.PARAMETER ReleasePlanWorkItemId
The ID of the release plan work item to update.

.PARAMETER PullRequestUrl
The URL of the pull request to set in the release plan.

.PARAMETER Status
The status of the pull request.

.PARAMETER LanguageName
The programming language associated with the pull request.

.PARAMETER AuthToken
The authentication token for GitHub API.

#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)

$releasePlan = Get-ReleasePlan-Link $ReleasePlanWorkItemId
if (!$releasePlan)
{
    LogError "Release plan with ID $ReleasePlanWorkItemId not found."
}

LogDebug "Updating pull request in release plan"
Update-PullRequestInReleasePlan $ReleasePlanWorkItemId $PullRequestUrl $Status $LanguageName
LogDebug "Updated pull request in release plan"