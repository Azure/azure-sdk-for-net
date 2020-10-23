param(
  $RepoOwner,
  $RepoName,
  $BranchPrefix,
  $AuthToken
)

. "${PSScriptRoot}\common.ps1"

LogDebug "Operating on Repo [ $RepoName ]"
try{
  $branches = (Get-GitHubSourceReferences -RepoOwner $RepoOwner -RepoName $RepoName -Ref "heads/$BranchPrefix").ref
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
    $pullRequests = Get-GitHubPullRequests -RepoOwner $RepoOwner -RepoName $RepoName -head $head
  }
  catch
  {
    LogError "Get-GitHubPullRequests failed with exception:`n$_"
    exit 1
  }

  if ($pullRequests.Count -eq 0)
  {
    LogDebug "Branch [ $branchName ] in repo [ $RepoName ] has no associated Pull Request. Deleting Branch"
    try{
      Remove-GitHubSourceReferences -RepoOwner $RepoOwner -RepoName $RepoName -Ref ($branch.Remove(0,5)) -AuthToken $AuthToken
    }
    catch {
      LogError "Remove-GitHubSourceReferences failed with exception:`n$_"
      exit 1
    }
  }
}