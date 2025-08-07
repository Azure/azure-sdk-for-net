[CmdletBinding(SupportsShouldProcess)]
param(
  # Please use the RepoOwner/RepoName format: e.g. Azure/azure-sdk-for-java
  $RepoId,
  # CentralRepoId the original PR to generate sync PR. E.g Azure/azure-sdk-tools for eng/common
  $CentralRepoId,
  # We start from the sync PRs, use the branch name to get the PR number of central repo. E.g. sync-eng/common-(<branchName>)-(<PrNumber>). Have group name on PR number.
  # For sync-eng/common work, we use regex as "^sync-eng/common.*-(?<PrNumber>\d+).*$".
  # For sync-.github/workflows work, we use regex as "^sync-.github/workflows.*-(?<PrNumber>\d+).*$".
  $BranchRegex,
  # Date format: e.g. Tuesday, April 12, 2022 1:36:02 PM. Allow to use other date format.
  [AllowNull()]
  [DateTime]$LastCommitOlderThan,
  [Switch]$DeleteBranchesEvenIfThereIsOpenPR = $false,
  $AuthToken
)
Set-StrictMode -version 3
. (Join-Path $PSScriptRoot common.ps1)

function Get-AllBranchesAndPullRequestInfo($owner, $repo) {
  $query = @'
    query($owner: String!, $repo: String!, $refPrefix: String!$endCursor: String) {
      repository(owner: $owner, name: $repo) {
        refs(first: 100, refPrefix: $refPrefix, after: $endCursor) {
          nodes {
            name
            target {
              commitUrl
              ... on Commit {
                committedDate
              }
            }
            associatedPullRequests(first: 100) {
              nodes {
                url
                closed
              }
            }
          }
          pageInfo {
            hasNextPage
            endCursor
          }
        }
      }
    }
'@

  $all_branches = gh api graphql --paginate -F owner=$owner -F repo=$repo -F refPrefix='refs/heads/' -f query=$query `
    --jq '.data.repository.refs.nodes[] | { name, commitUrl: .target.commitUrl, committedDate: .target.committedDate, pullRequests: .associatedPullRequests.nodes }' | ConvertFrom-Json

  if ($LASTEXITCODE) {
    LogError "Failed to retrieve branches for '$owner' and '$repo' running query '$query'"
    exit $LASTEXITCODE
  }

  return $all_branches
}

LogDebug "Operating on Repo '$RepoId'"

# Setup GH_TOKEN for the gh cli commands
if ($AuthToken) {
  $env:GH_TOKEN = $AuthToken
}

$owner, $repo = $RepoId -split "/"

# These will always be output at the end of the script. Their only purpose is for information gathering
# Total number returned from query
$totalBranchesFromQuery = 0
# reasons why a branch was skipped
$skippedBranchNotMatchRegex = 0
$skippedForCommitDate = 0
$skippedForOpenPRs = 0
$skippedForPRNotInBranch = 0
$skippedForPRNotInRepo = 0
# gh call counters
$ghPRViewCalls = 0
$ghBranchDeleteCalls = 0

try {
  # Output the core rate limit at the start of processing. There's no real need
  # to output this at the end because the GH call counts are being output
  $coreRateLimit = Get-RateLimit core
  Write-RateLimit $coreRateLimit
  # Output the GraphQL rate limit before and after the call
  $graphqlRateLimit = Get-RateLimit graphql
  Write-RateLimit $graphqlRateLimit "Before GraphQL Call"
  $branches = Get-AllBranchesAndPullRequestInfo $owner $repo
  $graphqlRateLimit = Get-RateLimit graphql
  Write-RateLimit $graphqlRateLimit "After GraphQL Call"

  if ($branches) {
    $totalBranchesFromQuery = $branches.Count
  }

  foreach ($branch in $branches)
  {
    $branchName = $branch.Name
    if ($branchName -notmatch $BranchRegex) {
      $skippedBranchNotMatchRegex++
      continue
    }
    $openPullRequests = @($branch.pullRequests | Where-Object { !$_.Closed })

    # If we have a central PR that created this branch still open don't delete the branch
    if ($CentralRepoId)
    {
      $pullRequestNumber = $matches["PrNumber"]
      # If central PR number is not found, then skip
      if (!$pullRequestNumber) {
        LogError "No PR number found in the branch name. Please check the branch name '$branchName'. Skipping..."
        $skippedForPRNotInBranch++
        continue
      }

      $ghPRViewCalls++
      $centralPR = gh pr view --json 'url,closed' --repo $CentralRepoId $pullRequestNumber | ConvertFrom-Json
      if ($LASTEXITCODE) {
        LogError "PR '$pullRequestNumber' not found in repo '$CentralRepoId'. Skipping..."
        $skippedForPRNotInRepo++
        continue
      } else {
        LogDebug "Found central PR $($centralPR.url) and Closed=$($centralPR.closed)"
        if (!$centralPR.Closed) {
          $skippedForOpenPRs++
          # Skipping if there is an open central PR open for the branch.
          LogDebug "Central PR is still open so skipping the deletion of branch '$branchName'. Skipping..."
          continue
        }
      }
    }
    else {
      # Not CentralRepoId - not associated with a central repo PR
      if ($openPullRequests.Count -gt 0 -and !$DeleteBranchesEvenIfThereIsOpenPR) {
        $skippedForOpenPRs++
        LogDebug "Found open PRs associate with branch '$branchName'. Skipping..."
        continue
      }
    }

    # If there is date filter, then check if branch last commit is older than the date.
    if ($LastCommitOlderThan)
    {
      $commitDate = $branch.committedDate
      if ($commitDate -gt $LastCommitOlderThan) {
        $skippedForCommitDate++
        LogDebug "The branch $branch last commit date '$commitDate' is newer than the date '$LastCommitOlderThan'. Skipping..."
        continue
      }
    }

    foreach ($openPullRequest in $openPullRequests) {
      LogDebug "Note: Open pull Request '$($openPullRequest.url)' will be closed after branch deletion, given the central PR is closed."
    }

    $commitUrl = $branch.commitUrl
    if ($PSCmdlet.ShouldProcess("'$branchName' in '$RepoId'", "Deleting branch on cleanup script")) {
      $ghBranchDeleteCalls++
      gh api "repos/${RepoId}/git/refs/heads/${branchName}" -X DELETE
      if ($LASTEXITCODE) {
        LogError "Deletion of branch '$branchName` failed, see command output above"
        exit $LASTEXITCODE
      }
      LogDebug "The branch '$branchName' at commit '$commitUrl' in '$RepoId' has been deleted."
    }
  }
}
finally {


  Write-Host "Number of branches returned from graphql query: $totalBranchesFromQuery"
  # The $BranchRegex seems to be always set
  if ($BranchRegex) {
    Write-Host "Number of branches that didn't match the BranchRegex: $skippedBranchNotMatchRegex"
  }
  Write-Host "Number of branches skipped for newer last commit date: $skippedForCommitDate"
  Write-Host "Number of branches skipped for open PRs: $skippedForOpenPRs"
  Write-Host "Number of gh api calls to delete branches: $ghBranchDeleteCalls"
  # The following are only applicable when $CentralRepoId is passed in
  if ($CentralRepoId) {
    Write-Host "The following are applicable because CentralRepoId was passed in:"
    Write-Host "  Number of gh pr view calls: $ghPRViewCalls"
    Write-Host "  Number of branches skipped due to PR not in the repository: $skippedForPRNotInRepo "
    Write-Host "  Number of branches skipped due to PR not in the branch name: $skippedForPRNotInBranch"
  }
}
