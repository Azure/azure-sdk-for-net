param(
  $AuthToken
)

$Token = ConvertTo-SecureString -String $AuthToken -AsPlainText -Force
$GithubAPIBaseURI = "https://api.github.com/repos"
function InvokePost($apiURI, $body) {
    $resp = Invoke-RestMethod `
        -Method POST `
        -Body ($body | ConvertTo-Json) `
        -Uri $apiURI `
        -Authentication Bearer `
        -Token $Token `
        -MaximumRetryCount 3

    return $resp
}

function InvokePatch($apiURI, $body) {
  $resp = Invoke-RestMethod `
      -Method PATCH `
      -Body ($body | ConvertTo-Json) `
      -Uri $apiURI `
      -Authentication Bearer `
      -Token $Token `
      -MaximumRetryCount 3

  return $resp
}

function InvokeGet($apiURI) {
  $resp = Invoke-RestMethod `
      -Method GET `
      -Uri $apiURI `
      -Authentication Bearer `
      -Token $Token `
      -MaximumRetryCount 3
      
  return $resp
}

function SplitMembers ($membersString)
{
  if (!$membersString) { return $null }
  return @($membersString.Split(",") | % { $_.Trim() } | ? { return $_ })
}

function ListPullRequests {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [ValidateSet("open","closed","all")]
    $state = "open",
    $head,
    $base,
    [ValidateSet("created","updated","popularity","long-running")]
    $sort,
    [ValidateSet("asc","desc")]
    $direction
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/pulls"
  if ($state -or $head -or $base -or $sort -or $direction) { $uri += '?'}
  if ($state){ $uri += "state=$state&" }
  if ($head){ $uri += "head=$head&" }
  if ($base){ $uri += "base=$base&" }
  if ($sort){ $uri += "sort=$sort&" }
  if ($direction){ $uri += "direction=$direction&" }

  return InvokeGet -apiURI $uri
}

function AddIssueComment {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    $CommentPrefix,
    [Parameter(Mandatory = $true)]
    $Comment,
    $CommentSuffix
  )
  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/comments"
  $PRComment = "$CommentPrefix $Comment $CommentSuffix"

  $parameters = @{
    body = $PRComment
  }
  return InvokePost -apiURI $uri -body $parameters
}

# Will add labels to existing labels on the issue
function AddIssueLabels {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $labels
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/labels"
  $labelAdditions = SplitMembers -membersString $labels
  $parameters = @{
    labels = @($labelAdditions)
  }

  return InvokePost -apiURI $uri -body $parameters
}

# Will add assignees to existing assignees on the issue
function AddIssueAssignees {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $assignees
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/assignees"
  $assigneesAdditions = SplitMembers -membersString $assignees
  $parameters = @{
    assignees = @($assigneesAdditions)
  }

  return InvokePost -apiURI $uri -body $parameters
}

# For labels and assignee pass comma delimited string, to replace existing labels or assignees.
# Or pass white space " " to remove all labels or assignees
function UpdateIssue {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [string]$title,
    [string]$body,
    [string]$state,
    [int]$milestome,
    [ValidateNotNullOrEmpty()]
    [string]$labels,
    [ValidateNotNullOrEmpty()]
    [string]$assignees
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber"
  $parameters = @{}
  if ($title) { $parameters["title"] = $title }
  if ($body) { $parameters["body"] = $body }
  if ($state) { $parameters["state"] = $state }
  if ($milestone) { $parameters["milestone"] = $milestone }
  if ($labels) { 
    $labelAdditions = SplitMembers -membersString $labels
    $parameters["labels"] = @($labelAdditions) 
  }
  if ($assignees) { 
    $assigneesAdditions = SplitMembers -membersString $assignees
    $parameters["assignees"] = @($assigneesAdditions) 
  }

  return InvokePatch -apiURI $uri -body $parameters
}