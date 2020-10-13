param(
  $RepoOwner,
  $RepoName,
  $BranchPrefix,
  $AuthToken
)

. "${PSScriptRoot}\common.ps1"

LogDebug "Operating on Repo [ $RepoName ]"
try{
  $branches = (List-References -RepoOwner $RepoOwner -RepoName $RepoName -Ref "heads/$BranchPrefix").ref
}
catch {
  LogError "List-References failed with exception:`n$_"
  exit 1
}

foreach ($branch in $branches)
{
  try {
    $branchName = $branch.Replace("refs/heads/","")
    $head = "${RepoOwner}/${RepoName}:${branchName}"
    LogDebug "Operating on branch [ $branchName ]"
    $pullRequests = List-PullRequests -RepoOwner $RepoOwner -RepoName $RepoName -head $head
  }
  catch
  {
    LogError "List-PullRequests failed with exception:`n$_"
    exit 1
  }

  "bvranch $branch"
  "PR COunt $($pullRequests.Count)"


  if ($pullRequests.Count -eq 0)
  {
    LogDebug "Branch [ $branchName ] in repo [ $RepoName ] has no associated Pull Request. Deleting Branch"
    try{
      Delete-References -RepoOwner $RepoOwner -RepoName $RepoName -Ref ($branch.Remove(0,5))
    }
    catch {
      LogError "Delete-References failed with exception:`n$_"
      exit 1
    }
  }
}