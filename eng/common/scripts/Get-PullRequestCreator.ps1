param (
    [Parameter(Mandatory = $true)]
    [string]$RepoOwner,

    [Parameter(Mandatory = $true)]
    [string]$RepoName,

    [Parameter(Mandatory = $true)]
    $PullRequestNumber,

    [Parameter(Mandatory = $true)]
    [string]$AuthToken
)

. (Join-Path $PSScriptRoot common.ps1)

try
{
    $pullRequest = Get-GithubPullRequest -RepoOwner $RepoOwner -RepoName $RepoName `
    -PullRequestNumber $PullRequestNumber -AuthToken $AuthToken

    $prCreator = $pullRequest.user.login

    # Set the prCreator variable to empty if the PR creator is dependabot or copilot
    if ($prCreator -ilike "dependabot*" -or $prCreator -ilike "copilot*")
    {
        $prCreator = ""
    }
    Write-Host "##vso[task.setvariable variable=System.PullRequest.Creator;]$($prCreator)"
}
catch
{
    Write-Error "Get-PullRequest failed with exception:`n$_"
    exit 1
}

