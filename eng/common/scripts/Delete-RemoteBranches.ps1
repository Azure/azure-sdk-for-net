[CmdletBinding(SupportsShouldProcess)]
param(
  # The repo owner: e.g. Azure
  $RepoOwner,
  # The repo name. E.g. azure-sdk-for-java
  $RepoName,
  # Please use the RepoOwner/RepoName format: e.g. Azure/azure-sdk-for-java
  $RepoId="$RepoOwner/$RepoName",
  # CentralRepoId the original PR to generate sync PR. E.g Azure/azure-sdk-tools for eng/common
  $CentralRepoId,
  # We start from the sync PRs, use the branch name to get the PR number of central repo. E.g. sync-eng/common-(<branchName>)-(<PrNumber>). Have group name on PR number.
  # For sync-eng/common work, we use regex as "^sync-eng/common.*-(?<PrNumber>\d+).*$".
  $BranchRegex,
  # Date format: e.g. Tuesday, April 12, 2022 1:36:02 PM. Allow to use other date format.
  [AllowNull()]
  [DateTime]$LastCommitOlderThan,
  [Parameter(Mandatory = $true)]
  $AuthToken
)

. (Join-Path $PSScriptRoot common.ps1)

LogDebug "Operating on Repo [ $RepoId ]"

try{
  # pull all branches.
  $responses = Get-GitHubSourceReferences -RepoId $RepoId -Ref "heads" -AuthToken $AuthToken
}
catch {
  LogError "Get-GitHubSourceReferences failed with exception:`n$_"
  exit 1
}

foreach ($res in $responses)
{
  if (!$res -or !$res.ref) {
    LogDebug "No branch returned from the branch prefix $BranchRegex on $Repo. Skipping..."
    continue
  }
  $branch = $res.ref
  $branchName = $branch.Replace("refs/heads/","")
  if (!($branchName -match $BranchRegex)) {
    continue
  }

  # Get all open sync PRs associate with branch.
  try {
    $head = "${RepoId}:${branchName}"
    LogDebug "Operating on branch [ $branchName ]"
    $pullRequests = Get-GitHubPullRequests -RepoId $RepoId -State "all" -Head $head -AuthToken $AuthToken
  }
  catch
  {
    LogError "Get-GitHubPullRequests failed with exception:`n$_"
    exit 1
  }
  $openPullRequests = $pullRequests | ? { $_.State -eq "open" }

  if (!$CentralRepoId -and $openPullRequests.Count -gt 0) {
    LogDebug "CentralRepoId is not configured and found open PRs associate with branch [ $branchName ]. Skipping..."
    continue
  }

  # check central PR
  if ($CentralRepoId) {
    $pullRequestNumber = $Matches["PrNumber"]
    # If central PR number found, then skip
    if (!$pullRequestNumber) {
      LogError "No PR number found in the branch name. Please check the branch name [ $branchName ]. Skipping..."
      continue
    }
      
    try {
      $centralPR = Get-GitHubPullRequest -RepoId $CentralRepoId -PullRequestNumber $pullRequestNumber -AuthToken $AuthToken
      LogDebug "Found central PR pull request: $($centralPR.html_url)"
      if ($centralPR.state -ne "closed") {
        # Skipping if there open central PR number for the branch.
        continue
      }
    }
    catch 
    {
      # If there is no central PR for the PR number, log error and skip.
      LogError "Get-GitHubPullRequests failed with exception:`n$_"
      LogError "Not found PR number [ $pullRequestNumber ] from [ $CentralRepoId ]. Skipping..."
      continue
    }
  }

  foreach ($openPullRequest in $openPullRequests) {
    Write-Host "Open pull Request [ $($openPullRequest.html_url) ] will be closed after branch deletion."
  }

  # If there is date filter, then check if branch last commit older than the date.
  if ($LastCommitOlderThan) {
    if (!$res.object -or !$res.object.url) {
      LogWarning "No commit url returned from response. Skipping... "
      continue
    }
    try {
      $commitDate = Get-GithubReferenceCommitDate -commitUrl $res.object.url -AuthToken $AuthToken
      if (!$commitDate) {
        LogDebug "No last commit date found. Skipping."
        continue
      }
      if ($commitDate -gt $LastCommitOlderThan) {
        LogDebug "The branch $branch last commit date [ $commitDate ] is newer than the date $LastCommitOlderThan. Skipping."
        continue
      }
      
      LogDebug "Branch [ $branchName ] in repo [ $RepoId ] has a last commit date [ $commitDate ] that is older than $LastCommitOlderThan. "
    }
    catch {
      LogError "Get-GithubReferenceCommitDate failed with exception:`n$_"
      exit 1
    }
  } 
  
  try {
    if ($PSCmdlet.ShouldProcess("[ $branchName ] in [ $RepoId ]", "Deleting branches on cleanup script")) {
      Remove-GitHubSourceReferences -RepoId $RepoId -Ref $branch -AuthToken $AuthToken
      Write-Host "The branch [ $branchName ] with sha [$($res.object.sha)] in [ $RepoId ] has been deleted."
    }
  }
  catch {
    LogError "Remove-GitHubSourceReferences failed with exception:`n$_"
    exit 1
  }
}
