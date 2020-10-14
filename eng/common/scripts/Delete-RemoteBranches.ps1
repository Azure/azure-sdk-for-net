param(
  $RepoOwner,
  $RepoName,
  $BranchPrefix,
  $AuthToken
)

. "${PSScriptRoot}\common.ps1"

LogDebug "Operating on Repo [ $RepoName ]"
try{
  $branches = (List-GithubSourceReferences -RepoOwner $RepoOwner -RepoName $RepoName -Ref "heads/$BranchPrefix").ref
}
catch {
  LogError "List-GithubSourceReferences failed with exception:`n$_"
  exit 1
}

foreach ($branch in $branches)
{
  try {
    $branchName = $branch.Replace("refs/heads/","")
    $head = "${RepoOwner}/${RepoName}:${branchName}"
    LogDebug "Operating on branch [ $branchName ]"
    $pullRequests = List-GithubPullRequests -RepoOwner $RepoOwner -RepoName $RepoName -head $head
  }
  catch
  {
    LogError "List-GithubPullRequests failed with exception:`n$_"
    exit 1
  }

  if ($pullRequests.Count -eq 0)
  {
    LogDebug "Branch [ $branchName ] in repo [ $RepoName ] has no associated Pull Request. Deleting Branch"
    try{
      Delete-GithubSourceReferences -RepoOwner $RepoOwner -RepoName $RepoName -Ref ($branch.Remove(0,5)) -AuthToken $AuthToken
    }
    catch {
      LogError "Delete-GithubSourceReferences failed with exception:`n$_"
      exit 1
    }
  }
}