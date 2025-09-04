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

$releasePlanLink = $releasePlan["Custom.ReleasePlanLink"]
$releasePlanSubmittedBy = $releasePlan["Custom.ReleasePlanSubmittedby"]
$ReleasePlanTitle = $releasePlan["System.Title"]
LogDebug "Release plan title: $ReleasePlanTitle"
LogDebug "Release plan link: $releasePlanLink"
Write-Host "Submitted by: $releasePlanSubmittedBy"

# Add a comment in pull request to provide release plan context
$regex = [regex]::new("https://github.com/(?<owner>[^/]+)/(?<repo>[^/]+)/pull/(?<prNumber>\d+)")
if ($PullRequestUrl -and $PullRequestUrl -match $regex)
{
    $owner = $matches['owner']
    $repo = $matches['repo']
    $prNumber = $matches['prNumber']

    # Generate comment to add release plan context
    $comment = "## Release plan details`nTitle: $ReleasePlanTitle`nLink: [$releasePlanLink]($releasePlanLink)`nSubmitted by: $releasePlanSubmittedBy"
    try
    {
        $resp =  Add-GitHubIssueComment -RepoOwner $owner -RepoName $repo -IssueNumber $prNumber -Comment $comment -AuthToken $AuthToken
        LogDebug "Added comment to PR $prNumber in $owner/$repo"
    }
    catch
    {
        LogError "Failed to add comment to PR $prNumber in $owner/$repo. Error: $_"
    }
}