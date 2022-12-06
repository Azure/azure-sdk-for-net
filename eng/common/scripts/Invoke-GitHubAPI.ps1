. "${PSScriptRoot}\logging.ps1"

$GithubAPIBaseURI = "https://api.github.com/repos"

function Get-GitHubApiHeaders ($token) {
  $headers = @{
    Authorization = "bearer $token"
  }
  return $headers
}

function SplitParameterArray($members) {
    if ($null -ne $members) {
      if ($members -is [array])
      {
        return $members
      }
      else {
        return (@($members.Split(",") | % { $_.Trim() } | ? { return $_ }))
      }
    }
}

function Set-GitHubAPIParameters ($members,  $parameterName, $parameters, $allowEmptyMembers = $false) {
  if ($null -ne $members) {
    [array]$memberAdditions = SplitParameterArray -members $members

    if ($null -eq $memberAdditions -and $allowEmptyMembers){ $memberAdditions = @() }

    if ($memberAdditions.Count -gt 0 -or $allowEmptyMembers) {
      $parameters[$parameterName] = $memberAdditions
    }
  }

  return $parameters
}

function Get-GitHubPullRequests {
  param (
    $RepoOwner,
    $RepoName,
    $RepoId = "$RepoOwner/$RepoName",
    [ValidateSet("open","closed","all")]
    $State = "open",
    $Head,
    $Base,
    [ValidateSet("created","updated","popularity","long-running")]
    $Sort,
    [ValidateSet("asc","desc")]
    $Direction,
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    $AuthToken
  )
  $uri = "$GithubAPIBaseURI/$RepoId/pulls"
  if ($State -or $Head -or $Base -or $Sort -or $Direction) { $uri += '?' }
  if ($State) { $uri += "state=$State&" }
  if ($Head) { $uri += "head=$Head&" }
  if ($Base) { $uri += "base=$Base&" }
  if ($Sort) { $uri += "sort=$Sort&" }
  if ($Direction){ $uri += "direction=$Direction&" }

  return Invoke-RestMethod `
          -Method GET `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

# 
<#
.PARAMETER Ref
Ref to search for
Pass 'heads/<branchame> ,tags/<tag name>, or nothing
#>
function Get-GitHubSourceReferences {
  param (
    $RepoOwner,
    $RepoName,
    $RepoId = "$RepoOwner/$RepoName",
    $Ref,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )
  $uri = "$GithubAPIBaseURI/$RepoId/git/matching-refs/"
  if ($Ref) { $uri += "$Ref" }

  return Invoke-RestMethod `
          -Method GET `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

function Get-GitHubPullRequest {
  param (
    $RepoOwner,
    $RepoName,
    $RepoId = "$RepoOwner/$RepoName",
    [Parameter(Mandatory = $true)]
    $PullRequestNumber,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $uri = "$GithubAPIBaseURI/$RepoId/pulls/$PullRequestNumber"

  return Invoke-RestMethod `
          -Method GET `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

function New-GitHubPullRequest {
  param (
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $Title,
    [Parameter(Mandatory = $true)]
    $Head,
    [Parameter(Mandatory = $true)]
    $Base,
    $Body=$Title,
    [Boolean]$Maintainer_Can_Modify=$false,
    [Boolean]$Draft=$false,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $parameters = @{
    title                 = $Title
    head                  = $Head
    base                  = $Base
    body                  = $Body
    maintainer_can_modify = $Maintainer_Can_Modify
    draft                = $Draft
  }

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/pulls"
  return Invoke-RestMethod `
          -Method POST `
          -Body ($parameters | ConvertTo-Json) `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

function Close-GitHubPullRequest {
  param (
    [Parameter(Mandatory = $true)]
    $apiurl,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $parameters = @{
    state                 = "closed"
  }

  return Invoke-RestMethod `
          -Method PATCH `
          -Uri $apiurl `
          -Body ($parameters | ConvertTo-Json) `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

function New-GitHubIssue {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $Title,
    [Parameter(Mandatory = $true)]
    $Description,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues"

  $parameters = @{
    title = $Title
    body = $Description
  }

  return Invoke-RestMethod `
    -Method POST `
    -Body ($parameters | ConvertTo-Json) `
    -Uri $uri `
    -Headers (Get-GitHubApiHeaders -token $AuthToken) `
    -MaximumRetryCount 3
}

function Get-GitHubIssues {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    $CreatedBy,
    [Parameter(Mandatory = $true)]
    $Labels,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues?labels=$Labels&per_page=100"

  if ($CreatedBy) {
    $uri += "&creator=$CreatedBy"
  }

  return Invoke-RestMethod `
    -Method GET `
    -Uri $uri `
    -Headers (Get-GitHubApiHeaders -token $AuthToken) `
    -MaximumRetryCount 3
}

function Add-GitHubIssueComment {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [Parameter(Mandatory = $true)]
    $Comment,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken

  )
  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/comments"

  $parameters = @{
    body = $Comment
  }

  return Invoke-RestMethod `
          -Method POST `
          -Body ($parameters | ConvertTo-Json) `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

# Will add labels to existing labels on the issue
function Add-GitHubIssueLabels {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $Labels,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  if ($Labels.Trim().Length -eq 0)
  {
    throw " The 'Labels' parameter should not not be whitespace.
    Use the 'Update-Issue' function if you plan to reset the labels"
  }

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/labels"
  $parameters = @{}
  $parameters = Set-GitHubAPIParameters -members $Labels -parameterName "labels" `
  -parameters $parameters

  return Invoke-RestMethod `
          -Method POST `
          -Body ($parameters | ConvertTo-Json) `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

# Will add assignees to existing assignees on the issue
function Add-GitHubIssueAssignees {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $Assignees,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  if ($Assignees.Trim().Length -eq 0)
  {
    throw "The 'Assignees' parameter should not be whitespace.
    You can use the 'Update-Issue' function if you plan to reset the Assignees"
  }

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber/assignees"
  $parameters = @{}
  $parameters = Set-GitHubAPIParameters -members $Assignees -parameterName "assignees" `
  -parameters $parameters

  return Invoke-RestMethod `
          -Method POST `
          -Body ($parameters | ConvertTo-Json) `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

function Add-GitHubPullRequestReviewers {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $PrNumber,
    $Users,
    $Teams,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/pulls/$PrNumber/requested_reviewers"
  $parameters = @{}

  $parameters = Set-GitHubAPIParameters -members $Users -parameterName "reviewers" `
  -parameters $parameters

  $parameters = Set-GitHubAPIParameters -members $Teams -parameterName "team_reviewers" `
  -parameters $parameters

  return Invoke-RestMethod `
          -Method POST `
          -Body ($parameters | ConvertTo-Json) `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

# For labels and assignee pass comma delimited string, to replace existing labels or assignees.
# Or pass white space " " to remove all labels or assignees
function Update-GitHubIssue {
  param (
    [Parameter(Mandatory = $true)]
    $RepoOwner,
    [Parameter(Mandatory = $true)]
    $RepoName,
    [Parameter(Mandatory = $true)]
    $IssueNumber,
    [string]$Title,
    [string]$Body,
    [ValidateSet("open","closed")]
    [string]$State,
    [int]$Milestome,
    $Labels,
    $Assignees,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )

  $uri = "$GithubAPIBaseURI/$RepoOwner/$RepoName/issues/$IssueNumber"
  $parameters = @{}
  if ($Title) { $parameters["title"] = $Title }
  if ($Body) { $parameters["body"] = $Body }
  if ($State) { $parameters["state"] = $State }
  if ($Milestone) { $parameters["milestone"] = $Milestone }

  $parameters = Set-GitHubAPIParameters -members $Labels -parameterName "labels" `
  -parameters $parameters -allowEmptyMembers $true

  $parameters = Set-GitHubAPIParameters -members $Assignees -parameterName "assignees" `
  -parameters $parameters -allowEmptyMembers $true

  return Invoke-RestMethod `
          -Method PATCH `
          -Body ($parameters | ConvertTo-Json) `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}

function Remove-GitHubSourceReferences  {
  param (
    $RepoOwner,
    $RepoName,
    $RepoId = "$RepoOwner/$RepoName",
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $Ref, # Using the format of "refs/heads/<branch>" or "heads/<branch>" for branch, and "tags/<tag>" for tag
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )
  if ($Ref.Trim().Length -eq 0)
  {
    throw "You must supply a valid 'Ref' Parameter to 'Delete-GithubSourceReferences'."
  }
  # Github is using branch in format of "heads/{branch_name}". Trim the "refs/heads/..." to "heads/..."
  $Ref = $Ref -replace "refs/"
  $uri = "$GithubAPIBaseURI/$RepoId/git/refs/$Ref"

  return Invoke-RestMethod `
          -Method DELETE `
          -Uri $uri `
          -Headers (Get-GitHubApiHeaders -token $AuthToken) `
          -MaximumRetryCount 3
}


function Get-GithubReferenceCommitDate($commitUrl, $AuthToken) {
  $commitResponse = ""
  if ($AuthToken) 
  {
    $commitResponse = Invoke-RestMethod $commitUrl `
                        -Headers (Get-GitHubApiHeaders -token $AuthToken) `
                        -MaximumRetryCount 3 
  }
  else 
  {
    $commitResponse = Invoke-RestMethod $commitUrl -MaximumRetryCount 3 
  }
  if (!$commitResponse.committer -or !$commitResponse.committer.date) {
    LogDebug "No date returned from the commit sha. "
    return $null
  }
  return $commitResponse.committer.date
}
