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
  [Parameter(Mandatory=$True)]
  [string] $ArtifactPath,
  [Parameter(Mandatory=$True)]
  [string] $TargetPath
)

. (Join-Path $PSScriptRoot "Helpers" git-helpers.ps1)

function Get-ChangedServices {
    Param (
        [Parameter(Mandatory=$True)]
        [string[]] $ChangedFiles
    )
    
    $changedServices = $ChangedFiles | Foreach-Object { if ($_ -match "sdk/([^/]+)") { $matches[1] } } | Sort-Object -Unique

    return $changedServices
}

if (!(Test-Path $ArtifactPath)) {
    New-Item -ItemType Directory -Path $ArtifactPath | Out-Null
}

$ArtifactPath = Resolve-Path $ArtifactPath
$ArtifactName = Join-Path $ArtifactPath "diff.json"

$changedFiles = Get-ChangedFiles -DiffPath $TargetPath
$changedServices = Get-ChangedServices -ChangedFiles $changedFiles

$result = [PSCustomObject]@{
    "ChangedFiles" = $changedFiles
    "ChangedServices" = $changedServices
    "PRNumber" = $env:SYSTEM_PULLREQUEST_PULLREQUESTNUMBER
}

$result | ConvertTo-Json | Out-File $ArtifactName
