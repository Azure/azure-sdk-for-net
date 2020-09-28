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

$headers = @{
  Authorization = "bearer $AuthToken"
}

$apiUrl = "https://api.github.com/repos/$RepoOwner/$RepoName/issues/$IssueNumber/comments"

$commentPrefixValue = [System.Environment]::GetEnvironmentVariable($CommentPrefix)
$commentValue = [System.Environment]::GetEnvironmentVariable($Comment)
$commentPostFixValue = [System.Environment]::GetEnvironmentVariable($CommentPostFix)

if (!$commentPrefixValue) { $commentPrefixValue = $CommentPrefix }
if (!$commentValue) { $commentValue = $Comment }
if (!$commentPostFixValue) { $commentPostFixValue = $CommentPostFix }

$PRComment = "$commentPrefixValue $commentValue $commentPostFixValue"

$data = @{
  body = $PRComment
}

try {
  $resp = Invoke-RestMethod -Method POST -Headers $headers -Uri $apiUrl -Body ($data | ConvertTo-Json)
}
catch {
  LogError "Invoke-RestMethod [ $apiUrl ] failed with exception:`n$_"
  exit 1
}