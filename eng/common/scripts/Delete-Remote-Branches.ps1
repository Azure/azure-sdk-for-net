param(
  $RepoOwner,
  $RepoName,
  $BranchPrefix,
  $WorkingDirectory,
  $AuthToken
)

. "${PSScriptRoot}\common.ps1"

pushd $WorkingDirectory
git clone https://github.com/$RepoOwner/$RepoName.git
pushd $RepoName
$syncBranches = git branch -r --list origin/$BranchPrefix* | % { $_ -replace "origin/", "" }

LogDebug "Operating on Repo [ $RepoName ]"
foreach ($branch in $syncBranches)
{
  try {
    $branchName = $branch.Trim()
    $head = "${RepoOwner}/${RepoName}:${branchName}"
    LogDebug "Operating on branch [ $branchName ]"
    $response = ListPullRequests -RepoOwner $RepoOwner -RepoName $RepoName -head $head
  }
  catch
  {
    LogError "ListPullRequests failed with exception:`n$_"
    exit 1
  }

  if ($response.Count -eq 0)
  {
    LogDebug "Branch [ $branchName ] in repo [ $RepoName ] has no associated Pull Request. Deleting Branch"
    git push origin --delete $branchName
    if ($lastExitCode -ne 0) {
      Write-Host "Failed to delete branch [ $branchName ] in repo [ $RepoName ]"
      exit 1
    }
  }
}

popd
popd
