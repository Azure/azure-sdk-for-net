param(    
    [Parameter(Mandatory = $true)]
    $ReleasePlanWorkItemId,
    [Parameter(Mandatory = $true)]
    $PullRequestUrl,
    [Parameter(Mandatory = $true)]
    $Status,
    [Parameter(Mandatory = $true)]
    $LanguageName
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

#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)


LogDebug "Updating pull request in release plan"
Update-PullRequestInReleasePlan $ReleasePlanWorkItemId $PullRequestUrl $Status $LanguageName
LogDebug "Updated pull request in release plan"