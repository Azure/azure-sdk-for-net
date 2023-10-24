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
    LogError "Failed to retireve branches for '$owner' and '$repo' running query '$query'"
    exit 1
  }

  return $all_branches
}

LogDebug "Operating on Repo '$RepoId'"

# Setup GH_TOKEN for the gh cli commands
if ($AuthToken) {
  $env:GH_TOKEN = $AuthToken
}

$owner, $repo = $RepoId -split "/"
$branches = Get-AllBranchesAndPullRequestInfo $owner $repo

foreach ($branch in $branches)
{
  $branchName = $branch.Name
  if ($branchName -notmatch $BranchRegex) {
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
      continue
    }

    $centralPR = gh pr view --json 'url,closed' --repo $CentralRepoId $pullRequestNumber | ConvertFrom-Json
    if ($LASTEXITCODE) {
      LogError "PR '$pullRequestNumber' not found in repo '$CentralRepoId'. Skipping..."
      continue;
    } else {
      LogDebug "Found central PR $($centralPR.url) and Closed=$($centralPR.closed)"
      if (!$centralPR.Closed) {
        # Skipping if there is an open central PR open for the branch.
        LogDebug "Central PR is still open so skipping the deletion of branch '$branchName'. Skipping..."
        continue;
      }
    }
  }
  else {
    # Not CentralRepoId - not associated with a central repo PR
    if ($openPullRequests.Count -gt 0 -and !$DeleteBranchesEvenIfThereIsOpenPR) {
      LogDebug "Found open PRs associate with branch '$branchName'. Skipping..."
      continue
    }
  }

  # If there is date filter, then check if branch last commit is older than the date.
  if ($LastCommitOlderThan)
  {
    $commitDate = $branch.committedDate
    if ($commitDate -gt $LastCommitOlderThan) {
      LogDebug "The branch $branch last commit date '$commitDate' is newer than the date '$LastCommitOlderThan'. Skipping..."
      continue
    }
  }

  foreach ($openPullRequest in $openPullRequests) {
    Write-Host "Note: Open pull Request '$($openPullRequest.url)' will be closed after branch deletion, given the central PR is closed."
  }

  $commitUrl = $branch.commitUrl
  if ($PSCmdlet.ShouldProcess("'$branchName' in '$RepoId'", "Deleting branch on cleanup script")) {
    gh api "repos/${RepoId}/git/refs/heads/${branchName}" -X DELETE
    if ($LASTEXITCODE) {
      LogError "Delection of branch '$branchName` failed"
    }
    Write-Host "The branch '$branchName' at commit '$commitUrl' in '$RepoId' has been deleted."
  }
}
