param(
  $AuthToken
)

$GithubAPIBaseURI = "https://api.github.com/repos"
function InvokePost($apiURI, $body) {
    $resp = Invoke-RestMethod `
        -Method POST `
        -Body ($body | ConvertTo-Json) `
        -Uri $apiURI `
        -Authentication Bearer `
        -Token $AuthToken
        -MaximumRetryCount 3
    ($body | Format-List | Write-Output)
    $resp | Write-Verbose
}

function InvokeGet($apiURI) {
  $resp = Invoke-RestMethod `
      -Method GET `
      -Uri $apiURI `
      -Authentication Bearer `
      -Token $AuthToken
      -MaximumRetryCount 3
  ($body | Format-List | Write-Output)
  $resp | Write-Verbose
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
    [ValidateSet("asc","desc",)]
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
    $IssueNumber,
    $CommentPrefix,
    [Parameter(Mandatory = $true)]
    $Comment,
    $CommentSuffix,
  )
  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/comments"
  $PRComment = "$CommentPrefix $Comment $CommentSuffix"

  $data = @{
    body = $PRComment
  }
  return InvokePost -apiURI $uri -body $data
}