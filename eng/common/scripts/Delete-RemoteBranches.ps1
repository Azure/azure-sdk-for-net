param(
  [Parameter(Mandatory = $true)]
  $RepoOwner,
  # Use this if a pull request might have been opened from one repo against another.
  # E.g Pull request opened from azure-sdk/azure-sdk prBranch --> Azure/azure-sdk baseBranch
  $ForkRepoOwner,
  [Parameter(Mandatory = $true)]
  $RepoName,
  [Parameter(Mandatory = $true)]
  $BranchPrefix,
  [Parameter(Mandatory = $true)]
  $AuthToken
)

. (Join-Path $PSScriptRoot common.ps1)

LogDebug "Operating on Repo [ $RepoName ]"
try{
  $branches = (Get-GitHubSourceReferences -RepoOwner $RepoOwner -RepoName $RepoName -Ref "heads/$BranchPrefix" -AuthToken $AuthToken).ref 
}
catch {
  LogError "Get-GitHubSourceReferences failed with exception:`n$_"
  exit 1
}

foreach ($branch in $branches)
{
  try {
    $branchName = $branch.Replace("refs/heads/","")
    $head = "${RepoOwner}/${RepoName}:${branchName}"
    LogDebug "Operating on branch [ $branchName ]"
    $pullRequests = Get-GitHubPullRequests -RepoOwner $RepoOwner -RepoName $RepoName -State "all" -Head $head -AuthToken $AuthToken

    if ($ForkRepoOwner)
    {
      $pullRequests += Get-GitHubPullRequests -RepoOwner $ForkRepoOwner -RepoName $RepoName -State "all" -Head $head -AuthToken $AuthToken
    }
  }
  catch
  {
    LogError "Get-GitHubPullRequests failed with exception:`n$_"
    exit 1
  }

  $openPullRequests = $pullRequests | ? { $_.State -eq "open" }
  if ($openPullRequests.Count -gt 0)
  {
    LogDebug "Branch [ $branchName ] in repo [ $RepoName ] has open pull Requests. Skipping"
    LogDebug $openPullRequests.url
    continue
  }

  LogDebug "Branch [ $branchName ] in repo [ $RepoName ] has no associated open Pull Request. Deleting Branch"
  try{
    Remove-GitHubSourceReferences -RepoOwner $RepoOwner -RepoName $RepoName -Ref ($branch.Remove(0,5)) -AuthToken $AuthToken
  }
  catch {
    LogError "Remove-GitHubSourceReferences failed with exception:`n$_"
    exit 1
  }
}