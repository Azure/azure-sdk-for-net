# Shared auto-release operations used by language repos to resolve the pull request and
# changed-file set that drive post-merge auto-release. Generic GitHub API calls live in
# Invoke-GitHubAPI.ps1; this file holds the auto-release policy and diff-shaping logic.

. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\Invoke-GitHubAPI.ps1"

# Resolves the auto-release pull request for a commit SHA.
#
# Applies the shared auto-release selection policy:
#   1. Look up the pull requests associated with the commit.
#   2. Re-fetch each distinct PR to read its authoritative merge state, commit, target branch and labels.
#   3. Keep only PRs merged into the target branch at the exact build commit.
#   4. Require exactly one exact match; ambiguous results are not eligible.
#   5. Require the auto-release label on that PR; labels never break an identity tie.
#
# Returns a result object:
#   PullRequest    : the selected PR object, or $null
#   PullRequestNumber : the selected PR number, or $null
#   IsEligible     : $true only when a merged, labeled PR was found
#   SkipReason     : a human readable reason when IsEligible is $false
function Get-GitHubAutoReleasePullRequestForCommit {
  param (
    $RepoOwner,
    $RepoName,
    $RepoId = "$RepoOwner/$RepoName",
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    $CommitSha,
    $TargetBranch = "main",
    $RequiredLabel = "auto-release",
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $result = [PSCustomObject]@{
    PullRequest       = $null
    PullRequestNumber = $null
    IsEligible        = $false
    SkipReason        = ""
  }

  # Invoke-RestMethod can emit a JSON array as one pipeline object; enumerate its records first.
  $associatedPullRequests = @(
    Get-GitHubPullRequestsForCommit -RepoId $RepoId -CommitSha $CommitSha -AuthToken $AuthToken |
      ForEach-Object { $_ }
  )

  # A commit can be contained in several PRs without being the merge commit of all of them.
  # The association payload can also lag, so only canonical PR records decide the match.
  $exactMatches = @()
  $unverifiedNumbers = @()
  foreach ($number in @($associatedPullRequests | Select-Object -ExpandProperty number -Unique)) {
    $pullRequest = Get-GitHubPullRequest -RepoId $RepoId -PullRequestNumber $number -AuthToken $AuthToken
    if ($null -eq $pullRequest) {
      $unverifiedNumbers += $number
      continue
    }
    if ($pullRequest.merged_at -and $pullRequest.base.ref -eq $TargetBranch -and $pullRequest.merge_commit_sha -eq $CommitSha) {
      $exactMatches += $pullRequest
    }
  }

  # Search all candidates, but an unreadable candidate could still be a second exact match.
  if ($unverifiedNumbers.Count -gt 0) {
    $result.SkipReason = "Could not verify associated pull requests: $($unverifiedNumbers -join ', '). No pull request was selected."
    return $result
  }

  if ($exactMatches.Count -eq 0) {
    $result.SkipReason = "No merged pull request targeting '$TargetBranch' matches the build's merge commit '$CommitSha'."
    return $result
  }

  if ($exactMatches.Count -ne 1) {
    $result.SkipReason = "Multiple merged pull requests match the build's merge commit '$CommitSha': $($exactMatches.number -join ', '). No pull request was selected."
    return $result
  }

  $pullRequest = $exactMatches[0]
  $result.PullRequest = $pullRequest
  $result.PullRequestNumber = $pullRequest.number

  $labels = @($pullRequest.labels | ForEach-Object { $_.name })
  if ($RequiredLabel -notin $labels) {
    $result.SkipReason = "Pull request #$($pullRequest.number) does not have the required label '$RequiredLabel'."
    return $result
  }

  $result.IsEligible = $true
  return $result
}

# Converts GitHub pull request file entries into the Azure SDK PR diff object shape
# consumed by package-detection tooling (compatible with Generate-PR-Diff.ps1 output).
#
# Parameters:
#   PullRequestNumber : the PR number recorded in the diff object.
#   PullRequestFiles  : the file entries returned by Get-GitHubPullRequestFiles.
#   ExcludePaths      : optional paths to record on the diff object.
#   ExcludeServiceRootFiles : excludes files directly under sdk/<service> so they do not resolve every
#                             package in that service.
#
# Returns a PSCustomObject with ChangedFiles, ChangedServices, ExcludePaths, DeletedFiles, PRNumber.
function New-GitHubPullRequestDiffObject {
  param (
    [Parameter(Mandatory = $true)]
    $PullRequestNumber,
    [Parameter(Mandatory = $true)]
    [AllowEmptyCollection()]
    [array] $PullRequestFiles,
    [AllowEmptyCollection()]
    [array] $ExcludePaths = @(),
    [switch] $ExcludeServiceRootFiles
  )

  $changedFiles = @()
  $deletedFiles = @()

  foreach ($file in $PullRequestFiles) {
    $filename = "$($file.filename)" -replace '\\', '/'

    if ($file.status -eq 'removed') {
      $deletedFiles += $filename
    }
    else {
      $changedFiles += $filename
    }

    # For renames, include the previous path as deleted so package detection sees both sides of the move.
    if ($file.status -eq 'renamed' -and $file.previous_filename) {
      $deletedFiles += ("$($file.previous_filename)" -replace '\\', '/')
    }
  }

  if ($ExcludeServiceRootFiles) {
    $serviceRootFilePattern = '^sdk/[^/]+/[^/]+$'
    $changedFiles = @($changedFiles | Where-Object { $_ -notmatch $serviceRootFilePattern })
    $deletedFiles = @($deletedFiles | Where-Object { $_ -notmatch $serviceRootFilePattern })
  }

  $changedFiles = @($changedFiles | Where-Object { $_ } | Sort-Object -Unique)
  $deletedFiles = @($deletedFiles | Where-Object { $_ } | Sort-Object -Unique)

  $changedServices = @(
    $changedFiles + $deletedFiles |
      ForEach-Object { if ($_ -match "^sdk/([^/]+)/") { $Matches[1] } } |
      Sort-Object -Unique
  )

  if (-not $ExcludePaths) {
    $ExcludePaths = @()
  }

  return [PSCustomObject]@{
    ChangedFiles    = $changedFiles
    ChangedServices = $changedServices
    ExcludePaths    = @($ExcludePaths)
    DeletedFiles    = $deletedFiles
    PRNumber        = "$PullRequestNumber"
  }
}
