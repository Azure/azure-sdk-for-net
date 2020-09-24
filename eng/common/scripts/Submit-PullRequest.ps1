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
  [string]$PRLabels
)

$headers = @{
  Authorization = "bearer $AuthToken"
}

$query = "state=open&head=${PROwner}:${PRBranch}&base=${BaseBranch}"

function AddLabels([int] $prNumber, [string] $prLabelString)
{
  # Adding labels to the pr.
  if (-not $prLabelString) {
    Write-Verbose "There are no labels added to the PR."
    return
  }

  # Parse the labels from string to array
  $prLabelArray = @($prLabelString.Split(",") | % { $_.Trim() } | ? { return $_ })
  $prLabelUri = "https://api.github.com/repos/$RepoOwner/$RepoName/issues/$prNumber"
  $labelRequestData = @{
    labels = $prLabelArray
  }
  try {
    $resp = Invoke-RestMethod -Method PATCH -Headers $headers $prLabelUri -Body ($labelRequestData | ConvertTo-Json)
  }
  catch {
    Write-Error "Invoke-RestMethod $prLabelUri failed with exception:`n$_"
  }

  $resp | Write-Verbose
  Write-Host -f green "Label(s) [$prLabelArray] added to pull request: https://github.com/$RepoOwner/$RepoName/pull/$prNumber"
}

try {
  $resp = Invoke-RestMethod -Headers $headers "https://api.github.com/repos/$RepoOwner/$RepoName/pulls?$query"
}
catch { 
  Write-Error "Invoke-RestMethod [https://api.github.com/repos/$RepoOwner/$RepoName/pulls?$query] failed with exception:`n$_"
  exit 1
}
$resp | Write-Verbose

if ($resp.Count -gt 0) {
    Write-Host -f green "Pull request already exists $($resp[0].html_url)"

    # setting variable to reference the pull request by number
    Write-Host "##vso[task.setvariable variable=Submitted.PullRequest.Number]$($resp[0].number)"
    AddLabels $resp[0].number $PRLabels
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
  }
  catch {
    Write-Error "Invoke-RestMethod [https://api.github.com/repos/$RepoOwner/$RepoName/pulls] failed with exception:`n$_"
    exit 1
  }

  $resp | Write-Verbose
  Write-Host -f green "Pull request created https://github.com/$RepoOwner/$RepoName/pull/$($resp.number)"

  # setting variable to reference the pull request by number
  Write-Host "##vso[task.setvariable variable=Submitted.PullRequest.Number]$($resp.number)"

  AddLabels $resp.number $PRLabels
}
