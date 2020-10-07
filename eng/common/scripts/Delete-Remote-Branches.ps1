param(
  $RepoOwner = "Azure",
  $RepoName,
  $BranchPrefix = "sync-eng/common",
  $AuthToken
)

. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\Invoke-GitHub-API.ps1"

git clone "https://github.com/$RepoOwner/$RepoName"
pushd $RepoName
$syncBranches = (git branch --remote).where{$_ -like "*origin/$BranchPrefix*"}

Write-Host "Repo Name $RepoName"
foreach ($branch in $syncBranches)
{
  try {
    $branchName = $branch.Trim()
    $head = "${RepoOwner}/${RepoName}:${branchName}"
    $response = ListPullRequests -RepoOwner $RepoOwner -RepoName $RepoName -head $head
  }
  catch
  {
    LogError "ListPullRequests failed with exception:`n$_"
    exit 1
  }
  Write-Host "Response Count $($Response.Count)"
  if ($Response.Count -eq 0)
  {
    # Delete branch here
    #git push origin --delete "sync-${{ parameters.DirectoryToSync }}-$(System.PullRequest.SourceBranch)-$(System.PullRequest.PullRequestNumber)"
    #if ($lastExitCode -ne 0) {
    #  Write-Host "Failed to delete [sync-${{ parameters.DirectoryToSync }}-$(System.PullRequest.SourceBranch)-$(System.PullRequest.PullRequestNumber)] branch in ${{ repo }}"
    #  exit 1
    #}
  }
}
