# cSpell:ignore Committish
# cSpell:ignore PULLREQUEST
# cSpell:ignore TARGETBRANCH
# cSpell:ignore SOURCECOMMITID

function RequestGithubGraphQL {
  param (
    [string]$query,
    [object]$variables = @{}
  )

  $payload = @{
    query     = $query
    variables = $variables
  } | ConvertTo-Json -Depth 100

  $response = $payload | gh api graphql --input -
  $data = $response | ConvertFrom-Json

  if ($LASTEXITCODE) {
    LogWarning "Failed graphql operation:"
    LogWarning ($payload -replace '\\n', "`n")
    if ($data.errors) {
      LogWarning ($data.errors.message -join "`n")
    }
    throw "graphql operation failed ($LASTEXITCODE)"
  }

  return $data
}

function Get-ChangedFiles {
  param (
    [string]$SourceCommittish = "${env:SYSTEM_PULLREQUEST_SOURCECOMMITID}",
    [string]$TargetCommittish = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/"),
    [string]$DiffPath,
    [string]$DiffFilterType = "d"
  )
  # If ${env:SYSTEM_PULLREQUEST_TARGETBRANCH} is empty, then return empty.
  if (!$TargetCommittish -or ($TargetCommittish -eq "origin/")) {
    Write-Host "There is no target branch passed in. "
    return ""
  }

  # Add config to disable the quote and encoding on file name.
  # Ref: https://github.com/msysgit/msysgit/wiki/Git-for-Windows-Unicode-Support#disable-quoted-file-names
  # Ref: https://github.com/msysgit/msysgit/wiki/Git-for-Windows-Unicode-Support#disable-commit-message-transcoding
  # Git PR diff: https://docs.github.com/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-comparing-branches-in-pull-requests#three-dot-and-two-dot-git-diff-comparisons
  $command = "git -c core.quotepath=off -c i18n.logoutputencoding=utf-8 diff `"$TargetCommittish...$SourceCommittish`" --name-only --diff-filter=$DiffFilterType"
  if ($DiffPath) {
    $command = $command + " -- `'$DiffPath`'"
  }
  Write-Host $command
  $changedFiles = Invoke-Expression -Command $command
  if (!$changedFiles) {
    Write-Host "No changed files in git diff between $TargetCommittish and $SourceCommittish"
  }
  else {
    Write-Host "Here are the diff files:"
    foreach ($file in $changedFiles) {
      Write-Host "    $file"
    }
  }
  return $changedFiles
}

class ConflictedFile {
  [string]$LeftSource = ""
  [string]$RightSource = ""
  [string]$Content = ""
  [string]$Path = ""
  [boolean]$IsConflicted = $false

  ConflictedFile([string]$File = "") {
    if (!(Test-Path $File)) {
      throw "File $File does not exist, pass a valid file path to the constructor."
    }

    # Normally we would use Resolve-Path $file, but git only can handle relative paths using git show <commitsh>:<path>
    # Therefore, just maintain whatever the path is given to us. Left() and Right() should therefore be called from the same
    # directory as where we defined the relative path to the target file.
    $this.Path = $File
    $this.Content = Get-Content -Raw $File

    $this.ParseContent($this.Content)
  }

  [array] Left() {
    if ($this.IsConflicted) {
      # we are forced to get this line by line and reassemble via join because of how powershell is interacting with
      # git show --textconv commitsh:path
      # powershell ignores the newlines with and without --textconv, which results in a json file without original spacing.
      # by forcefully reading into the array line by line, the whitespace is preserved. we're relying on gits autoconverstion of clrf to lf
      # to ensure that the line endings are consistent.
      $toShow = "$($this.LeftSource):$($this.Path)" -replace "\\", "/"
      Write-Host "git show $toShow"
      $tempContent = git show $toShow
      return $tempContent -split "`r?`n"
    }
    else {
      return $this.Content
    }
  }

  [array] Right() {
    if ($this.IsConflicted) {
      $toShow = "$($this.RightSource):$($this.Path)" -replace "\\", "/"
      Write-Host "git show $toShow"
      $tempContent = git show $toShow
      return $tempContent -split "`r?`n"
    }
    else {
      return $this.Content
    }
  }

  [void] ParseContent([string]$IncomingContent) {
    $lines = $IncomingContent -split "`r?`n"
    $l = @()
    $r = @()

    foreach ($line in $lines) {
      if ($line -match "^<<<<<<<\s*(.+)") {
        $this.IsConflicted = $true
        $this.LeftSource = $matches[1]
        continue
      }
      elseif ($line -match "^>>>>>>>\s*(.+)") {
        $this.IsConflicted = $true
        $this.RightSource = $matches[1]
        continue
      }

      if ($this.LeftSource -and $this.RightSource) {
        break
      }
    }
  }
}

# The rate limit comes back in the following format:
# The top level "rate" object is deprecated and the resources->core object should be used
# in its place.
# {
#   "resources": {
#     "core": {
#       "limit": 5000,
#       "used": 1087,
#       "remaining": 3913,
#       "reset": 1722876411
#     },
#     "search": {
#       "limit": 30,
#       "used": 0,
#       "remaining": 30,
#       "reset": 1722875519
#     },
#     "graphql": {
#       "limit": 5000,
#       "used": 0,
#       "remaining": 5000,
#       "reset": 1722879059
#     },
#     "integration_manifest": {
#       "limit": 5000,
#       "used": 0,
#       "remaining": 5000,
#       "reset": 1722879059
#     },
#     "source_import": {
#       "limit": 100,
#       "used": 0,
#       "remaining": 100,
#       "reset": 1722875519
#     },
#     "code_scanning_upload": {
#       "limit": 1000,
#       "used": 0,
#       "remaining": 1000,
#       "reset": 1722879059
#     },
#     "actions_runner_registration": {
#       "limit": 10000,
#       "used": 0,
#       "remaining": 10000,
#       "reset": 1722879059
#     },
#     "scim": {
#       "limit": 15000,
#       "used": 0,
#       "remaining": 15000,
#       "reset": 1722879059
#     },
#     "dependency_snapshots": {
#       "limit": 100,
#       "used": 0,
#       "remaining": 100,
#       "reset": 1722875519
#     },
#     "audit_log": {
#       "limit": 1750,
#       "used": 0,
#       "remaining": 1750,
#       "reset": 1722879059
#     },
#     "audit_log_streaming": {
#       "limit": 15,
#       "used": 0,
#       "remaining": 15,
#       "reset": 1722879059
#     },
#     "code_search": {
#       "limit": 10,
#       "used": 0,
#       "remaining": 10,
#       "reset": 1722875519
#     }
#   },
#   "rate": {
#     "limit": 5000,
#     "used": 1087,
#     "remaining": 3913,
#     "reset": 1722876411
#   }
# }

# These are the rate limit types we care about. If others needed in the future they
# can be defined here. The reason these need to be defined is because Get-RateLimit
# call needs to select the particular property to return the right limit. This ensures
# that rate limit type being passed to the function will exist.
enum RateLimitTypes {
  core
  search
  graphql
}

# Fetch the rate limit for the given RateLimitType
function Get-RateLimit([RateLimitTypes]$RateLimitType) {
  $returnValue = gh api rate_limit
  if ($LASTEXITCODE) {
    LogError "Get-RateLimit::unable to get rate limit"
    exit $LASTEXITCODE
  }
  # All rate limits have the following fields: limit, used, remaning, reset.
  # Returning -AsHashtable allows easier access, eg. $rate_limit.remaining
  $rate_limit = $returnValue | ConvertFrom-Json -AsHashtable | Select-Object -ExpandProperty resources | Select-Object -ExpandProperty $RateLimitType
  # Add the limit type for convenance
  $rate_limit["type"] = $RateLimitType
  return $rate_limit
}

# Get the number of minutes until RateLimit reset rounded up to the nearest minute
# for the passed in RateLimit. This is more applicable to the core and graphql rate
# limits than search because the search rate limit resets every minute
function Get-MinutesUntilRateLimitReset($RateLimit) {
  $TimeSpan = [System.DateTimeOffset]::FromUnixTimeSeconds($rate.reset).UtcDateTime.Subtract([System.DateTime]::UtcNow)
  $MinutesRoundedUp = [Math]::Ceiling($TimeSpan.TotalMinutes)
  return $MinutesRoundedUp
}

# Output the rate limit
function Write-RateLimit {
  param (
    $RateLimit,
    [string]$PreMsg = $null
  )

  if ($PreMsg) {
    Write-Host $PreMsg
  }
  Write-Host "Limit Type=$($RateLimit.type)"
  Write-Host "    limit=$($RateLimit.limit)"
  Write-Host "    used=$($RateLimit.used)"
  Write-Host "    remaining=$($RateLimit.remaining)"
  Write-Host "    reset=$($RateLimit.reset)"
  Write-Host ""
}

function GetUnresolvedAIReviewThreads {
  param(
    [string]$repoOwner,
    [string]$repoName,
    [string]$prNumber,
    [array]$reviewers
  )

  $reviewers ??= @('copilot-pull-request-reviewer')

  $reviewThreadsQuery = @'
query ReviewThreads($owner: String!, $name: String!, $number: Int!) {
  repository(owner: $owner, name: $name) {
    pullRequest(number: $number) {
      reviewThreads(first: 100) {
        nodes {
          id
          isResolved
          comments(first: 100) {
            nodes {
              body
              author {
                login
              }
            }
          }
        }
      }
    }
  }
}
'@

  $variables = @{ owner = $repoOwner; name = $repoName; number = [int]$prNumber }
  $response = RequestGithubGraphQL -query $reviewThreadsQuery -variables $variables
  $reviews = $response.data.repository.pullRequest.reviewThreads.nodes

  $threadIds = @()
  # There should be only one threadId for copilot, but make it an array in case there
  # are more, or if we want to resolve threads from multiple ai authors in the future.
  # Don't mark threads from humans as resolved, as those may be real questions/blockers.
  foreach ($thread in $reviews) {
    if ($thread.comments.nodes | Where-Object { $_.author.login -in $reviewers }) {
      if (!$thread.isResolved) {
        $threadIds += $thread.id
      }
      continue
    }
  }

  return $threadIds
}

function TryResolveAIReviewThreads {
  param(
    [string]$repoOwner,
    [string]$repoName,
    [string]$prNumber,
    [array]$reviewers
  )

  $resolveThreadMutation = @'
mutation ResolveThread($id: ID!) {
  resolveReviewThread(input: { threadId: $id }) {
    thread {
      isResolved
    }
  }
}
'@

  $threadIds = GetUnresolvedAIReviewThreads -repoOwner $repoOwner -repoName $repoName -prNumber $prNumber -reviewers $reviewers

  if (!$threadIds) {
    return $false
  }

  foreach ($threadId in $threadIds) {
    LogInfo "Resolving review thread '$threadId' for '$repoName' PR '$prNumber'"
    RequestGithubGraphQL -query $resolveThreadMutation -variables @{ id = $threadId }
  }

  return $true
}
