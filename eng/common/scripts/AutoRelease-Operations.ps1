# Shared auto-release operations used by language repos to resolve the pull request and
# changed-file set that drive post-merge auto-release. Generic GitHub API calls live in
# Invoke-GitHubAPI.ps1; this file holds the auto-release policy and diff-shaping logic.

. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\Invoke-GitHubAPI.ps1"

# Resolves the auto-release pull request for a commit SHA.
#
# Applies the shared auto-release selection policy:
#   1. Look up the pull requests associated with the commit.
#   2. Keep only pull requests merged into the target branch.
#   3. Select the most recently merged one.
#   4. Re-fetch that pull request by number to read its authoritative merge state and labels.
#   5. Require it to be merged into the target branch and to carry the auto-release label.
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

  $associatedPullRequests = @(Get-GitHubPullRequestsForCommit -RepoId $RepoId -CommitSha $CommitSha -AuthToken $AuthToken)

  $mergedToTarget = @(
    $associatedPullRequests |
      Where-Object { $_.merged_at -and $_.base.ref -eq $TargetBranch }
  )

  if ($mergedToTarget.Count -eq 0) {
    $result.SkipReason = "No merged pull request targeting '$TargetBranch' was associated with commit '$CommitSha'."
    return $result
  }

  $selectedPullRequest = $mergedToTarget |
    Sort-Object { [datetime]$_.merged_at } -Descending |
    Select-Object -First 1

  $result.PullRequestNumber = $selectedPullRequest.number

  # Re-fetch the pull request by number to read its authoritative state. The commit -> pulls payload is
  # a secondary representation whose labels and merge state can lag the canonical pull request, so
  # eligibility (merge target + required label) is decided against this authoritative payload.
  $pullRequest = Get-GitHubPullRequest -RepoId $RepoId -PullRequestNumber $selectedPullRequest.number -AuthToken $AuthToken
  $result.PullRequest = $pullRequest

  if (-not $pullRequest.merged_at -or $pullRequest.base.ref -ne $TargetBranch) {
    $result.SkipReason = "Pull request #$($pullRequest.number) is not merged into '$TargetBranch'."
    return $result
  }

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
    [array] $ExcludePaths = @()
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
