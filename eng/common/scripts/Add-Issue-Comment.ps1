[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$RepoOwner,

  [Parameter(Mandatory = $true)]
  [string]$RepoName,

  [Parameter(Mandatory = $true)]
  [string]$IssueNumber,

  [Parameter(Mandatory = $false)]
  [string]$CommentPrefix,

  [Parameter(Mandatory = $true)]
  [string]$Comment,

  [Parameter(Mandatory = $false)]
  [string]$CommentPostFix,

  [Parameter(Mandatory = $true)]
  [string]$AuthToken
)

. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\Invoke-GitHub-API.ps1" -AuthToken $AuthToken

$commentPrefixValue = [System.Environment]::GetEnvironmentVariable($CommentPrefix)
$commentValue = [System.Environment]::GetEnvironmentVariable($Comment)
$commentPostFixValue = [System.Environment]::GetEnvironmentVariable($CommentPostFix)

if (!$commentPrefixValue) { $commentPrefixValue = $CommentPrefix }
if (!$commentValue) { $commentValue = $Comment }
if (!$commentPostFixValue) { $commentPostFixValue = $CommentPostFix }

try {
  $resp = AddIssueComment -RepoOwner $RepoOwner -RepoName $RepoName `
          -IssueNumber $IssueNumber -CommentPrefix $commentPrefixValue `
          -Comment $commentValue -CommentSuffix $commentPostFixValue
}
catch {
  LogError "AddIssueComment failed with exception:`n$_"
  exit 1
}