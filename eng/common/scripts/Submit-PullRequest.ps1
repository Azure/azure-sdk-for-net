 #!/usr/bin/env pwsh -c

<#
.DESCRIPTION
Creates a GitHub pull request for a given branch if it doesn't already exist
.PARAMETER RepoOwner
The GitHub repository owner to create the pull request against.
.PARAMETER RepoName
The GitHub repository name to create the pull request against.
.PARAMETER BaseBranch
The base or target branch we want the pull request to be against.
.PARAMETER PROwner
The owner of the branch we want to create a pull request for.
.PARAMETER PRBranch
The branch which we want to create a pull request for.
.PARAMETER AuthToken
A personal access token
.PARAMETER PRTitle
The title of the pull request.
.PARAMETER PRBody
The body message for the pull request. 
.PARAMETER PRLabels
The labels added to the PRs. Multple labels seperated by comma, e.g "bug, service"
#>
[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$RepoOwner,

  [Parameter(Mandatory = $true)]
  [string]$RepoName,

  [Parameter(Mandatory = $true)]
  [string]$BaseBranch,

  [Parameter(Mandatory = $true)]
  [string]$PROwner,

  [Parameter(Mandatory = $true)]
  [string]$PRBranch,

  [Parameter(Mandatory = $true)]
  [string]$AuthToken,

  [Parameter(Mandatory = $true)]
  [string]$PRTitle,

  [Parameter(Mandatory = $false)]
  [string]$PRBody = $PRTitle,

  [Parameter(Mandatory = $false)]
  [string]$PRLabels,

  [Parameter(Mandatory = $false)]
  [string]$UserReviewers,

  [Parameter(Mandatory = $false)]
  [string]$TeamReviewers,

  [Parameter(Mandatory = $false)]
  [string]$Assignees
)

$headers = @{
  Authorization = "bearer $AuthToken"
}
$baseURI = "https://api.github.com/repos"
function SplitMembers ($membersString)
{
  return @($membersString.Split(",") | % { $_.Trim() } | ? { return $_ })
}

function InvokeGitHubAPI($apiURI, $method, $body) {
  $resp = Invoke-RestMethod -Method $method -Headers $headers -Body ($body | ConvertTo-Json) -Uri $apiURI -MaximumRetryCount 3
  Write-Host -f green "These members have been added to: https://github.com/$RepoOwner/$RepoName/pull/$prNumber"
  ($body | Format-List | Write-Output)
  $resp | Write-Verbose
}

function AddReviewers ($prNumber, $users, $teams) {
  $uri = "$baseURI/$RepoOwner/$RepoName/pulls/$prNumber/requested_reviewers"
  $userAdditions = SplitMembers -membersString $users
  $teamAdditions = SplitMembers -membersString $teams
  $postResp = @{}
  if ($userAdditions) {
    $postResp["reviewers"] = @($userAdditions)
  }
  if ($teamAdditions) {
    $postResp["team_reviewers"] = @($teamAdditions)
  }
  return InvokeGitHubAPI -apiURI $uri -method 'Post' -body $postResp
}

function AddLabelsAndOrAssignees ($prNumber, $labels, $assignees) {
  $uri = "$baseURI/$RepoOwner/$RepoName/issues/$prNumber"
  $labelAdditions = SplitMembers -membersString $labels
  $assigneeAdditions = SplitMembers -membersString $assignees
  $postResp = @{}
  if ($assigneeAdditions) {
    $postResp["assignees"] = @($assigneeAdditions)
  }
  if ($labelAdditions) {
    $postResp["labels"] = @($labelAdditions)
  }
  return InvokeGitHubAPI -apiURI $uri -method 'Post' -body $postResp
}

$query = "state=open&head=${PROwner}:${PRBranch}&base=${BaseBranch}"

try {
  $resp = Invoke-RestMethod -Headers $headers "https://api.github.com/repos/$RepoOwner/$RepoName/pulls?$query"
}
catch { 
  Write-Error "Invoke-RestMethod [https://api.github.com/repos/$RepoOwner/$RepoName/pulls?$query] failed with exception:`n$_"
  exit 1
}
$resp | Write-Verbose

if ($resp.Count -gt 0) {
  try {
    Write-Host -f green "Pull request already exists $($resp[0].html_url)"

    # setting variable to reference the pull request by number
    Write-Host "##vso[task.setvariable variable=Submitted.PullRequest.Number]$($resp[0].number)"
    AddReviewers -prNumber $resp[0].number -users $UserReviewers -teams $TeamReviewers
    AddLabelsAndOrAssignees -prNumber $resp[0].number -labels $PRLabels -assignees $Assignees
  }
  catch {
    Write-Error "Call to GitHub API failed with exception:`n$_"
    exit 1
  }
}
else {
  $data = @{
    title                 = $PRTitle
    head                  = "${PROwner}:${PRBranch}"
    base                  = $BaseBranch
    body                  = $PRBody
    maintainer_can_modify = $true
  }

  try {
    $resp = Invoke-RestMethod -Method POST -Headers $headers `
                              "https://api.github.com/repos/$RepoOwner/$RepoName/pulls" `
                              -Body ($data | ConvertTo-Json)

    $resp | Write-Verbose
    Write-Host -f green "Pull request created https://github.com/$RepoOwner/$RepoName/pull/$($resp.number)"
  
    # setting variable to reference the pull request by number
    Write-Host "##vso[task.setvariable variable=Submitted.PullRequest.Number]$($resp.number)"
    AddReviewers -prNumber $resp.number -users $UserReviewers -teams $TeamReviewers
    AddLabelsAndOrAssignees -prNumber $resp.number -labels $PRLabels -assignees $Assignees
  }
  catch {
    Write-Error "Call to GitHub API failed with exception:`n$_"
    exit 1
  }
}