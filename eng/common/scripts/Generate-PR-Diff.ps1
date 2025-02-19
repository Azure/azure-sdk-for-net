<#
.SYNOPSIS
Script used to generate the diff.json file for a PR. Explicitly intended to work in a PR context.

.DESCRIPTION
Combines the result of git diff, some parsed details from the diff, and the PR number into a single JSON file. This JSON file is intended for use further along the pipeline.

.PARAMETER ArtifactPath
The folder in which the result will be written.

.PARAMETER TargetPath
The path under which changes will be detected.
#>
[CmdletBinding()]
Param (
  [Parameter(Mandatory = $True)]
  [string] $ArtifactPath,
  [Parameter(Mandatory = $True)]
  [string] $TargetPath,
  [Parameter(Mandatory=$false)]
  [AllowEmptyCollection()]
  [array] $ExcludePaths
)

. (Join-Path $PSScriptRoot "Helpers" "git-helpers.ps1")

function Get-ChangedServices
{
  Param (
    [Parameter(Mandatory = $True)]
    [string[]] $ChangedFiles
  )

  [string[]] $changedServices = $ChangedFiles | Foreach-Object { if ($_ -match "sdk/([^/]+)") { $matches[1] } } | Sort-Object -Unique

  return , $changedServices
}

if (!(Test-Path $ArtifactPath))
{
  New-Item -ItemType Directory -Path $ArtifactPath | Out-Null
}

$ArtifactPath = Resolve-Path $ArtifactPath
$ArtifactName = Join-Path $ArtifactPath "diff.json"

$changedFiles = @()
$changedServices = @()

$changedFiles = Get-ChangedFiles -DiffPath $TargetPath
$deletedFiles = Get-ChangedFiles -DiffPath $TargetPath -DiffFilterType "D"

if ($changedFiles) {
  $changedServices = Get-ChangedServices -ChangedFiles $changedFiles
}
else {
  # ensure we default this to an empty array if not set
  $changedFiles = @()
}

# ExcludePaths is an object array with the default of [] which evaluates to null.
# If the value is null, set it to empty list to ensure that the empty list is
# stored in the json
if (-not $ExcludePaths) {
  $ExcludePaths = @()
}
if (-not $deletedFiles) {
  $deletedFiles = @()
}
if (-not $changedServices) {
  $changedServices = @()
}
$result = [PSCustomObject]@{
  "ChangedFiles"    = $changedFiles
  "ChangedServices" = $changedServices
  "ExcludePaths"    = $ExcludePaths
  "DeletedFiles"    = $deletedFiles
  "PRNumber"        = if ($env:SYSTEM_PULLREQUEST_PULLREQUESTNUMBER) { $env:SYSTEM_PULLREQUEST_PULLREQUESTNUMBER } else { "-1" }
}

$json = $result | ConvertTo-Json
$json | Out-File $ArtifactName

Write-Host "`nGenerated diff.json file at $ArtifactName"
Write-Host "  $($json -replace "`n", "`n  ")"
