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

  # check central PR
  # If central PR exist and open, then skip
  $pullRequestNumber = $Matches["PrNumber"]
    
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

  # If no central PR numver retrieved from branch regex, and there are open sync PR(s) associate with branch.
  if (!$pullRequestNumber -and $openPullRequest.Count -gt 0) {
    LogError "PR number not found from $CentralPRRegex. And there are open sync PR(s) associate with branch. Skipping."
    continue
  } 
  if ($pullRequestNumber) {
    try {
      $centralPR = Get-GitHubPullRequest -RepoId $CentralRepoId -PullRequestNumber $pullRequestNumber -AuthToken $AuthToken
      LogDebug "Found closed/merged pull request: $($centralPR.html_url)"
      if ($centralPR.state -ne "closed") {
        continue
      }
    }
    catch 
    {
      if ($openPullRequests.Count -gt 0) {
        LogDebug "PR number [ $pullRequestNumber ] from [ $CentralRepoId ]. And there are open sync PR(s) associate with branch. Skipping."
        continue
      }
    }
  }

  # Two conditions to close sync open PRs.
  # 2. Central repo PR not exist and no open sync PRs
  # 2. Central repo PR exists and closed.
  foreach ($openPullRequest in $openPullRequests) {
    try 
    {
      if ($PSCmdlet.ShouldProcess("[ $($openPullRequest.html_url) ] with branch [ $branchName ] in [ $RepoId ]", "Closing the pull request")) {
        Close-GithubPullRequest -apiurl $openPullRequest.url -AuthToken $AuthToken | Out-Null
        Write-Host "Open pull Request [ $($openPullRequest.html_url) ] has been closed."
      }
    }
    catch
    {
      LogError "Close-GithubPullRequest failed with exception:`n$_"
      exit 1
    }
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
