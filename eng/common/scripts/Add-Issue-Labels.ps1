[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$RepoOwner,

  [Parameter(Mandatory = $true)]
  [string]$RepoName,

  [Parameter(Mandatory = $true)]
  [string]$IssueNumber,

  [Parameter(Mandatory = $true)]
  [string]$Labels,

  [Parameter(Mandatory = $true)]
  [string]$AuthToken
)

. "${PSScriptRoot}\common.ps1"

try {
  AddIssueLabels -RepoOwner $RepoOwner -RepoName $RepoName `
  -IssueNumber $IssueNumber -Labels $Labels -AuthToken $AuthToken
}
catch {
  LogError "AddIssueLabels failed with exception:`n$_"
  exit 1
}