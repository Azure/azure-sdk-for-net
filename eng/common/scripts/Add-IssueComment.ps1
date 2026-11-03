<#
.SYNOPSIS
Adds a comment to a GitHub issue.

.DESCRIPTION
Supports -WhatIf to preview the action without posting a comment.
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
  [string]$Comment,

  [Parameter(Mandatory = $true)]
  [string]$AuthToken
)

. (Join-Path $PSScriptRoot common.ps1)

try {
  # SupportsShouldProcess exposes -WhatIf but does not guard the helper's REST write.
  # Gate the helper so dry runs and declined confirmations cannot mutate GitHub.
  if ($PSCmdlet.ShouldProcess("$RepoOwner/$RepoName issue #$IssueNumber", "Add issue comment")) {
    Add-GithubIssueComment -RepoOwner $RepoOwner -RepoName $RepoName `
      -IssueNumber $IssueNumber -Comment $Comment -AuthToken $AuthToken
  }
}
catch {
  LogError "Add-GithubIssueComment failed with exception:`n$_"
  exit 1
}