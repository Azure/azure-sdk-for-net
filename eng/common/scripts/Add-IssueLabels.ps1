<#
.SYNOPSIS
Adds labels to a GitHub issue.

.DESCRIPTION
Supports -WhatIf to preview the action without adding labels.
#>

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

. (Join-Path $PSScriptRoot common.ps1)

try {
  # SupportsShouldProcess exposes -WhatIf but does not guard the helper's REST write.
  # Gate the helper so dry runs and declined confirmations cannot mutate GitHub.
  if ($PSCmdlet.ShouldProcess("$RepoOwner/$RepoName issue #$IssueNumber", "Add issue labels: $Labels")) {
    Add-GithubIssueLabels -RepoOwner $RepoOwner -RepoName $RepoName `
      -IssueNumber $IssueNumber -Labels $Labels -AuthToken $AuthToken
  }
}
catch {
  LogError "Add-GithubIssueLabels failed with exception:`n$_"
  exit 1
}