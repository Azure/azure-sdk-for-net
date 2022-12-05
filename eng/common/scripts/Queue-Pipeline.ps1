<#
.SYNOPSIS
Queues an Azure DevOps Pipeline run optionally canceling similar runs

.PARAMETER Organization
Azure DevOps organization name

.PARAMETER Project
Azure DevOps project name

.PARAMETER SourceBranch
Source branch use when executing the DevOps pipeline. Specifying an empty string
will result in queuing of the run with the default branch configured for the
pipeline.

.PARAMETER DefinitionId
Pipline definition ID

.PARAMETER CancelPreviousBuilds
Requires a value for SourceBranch. Cancel previous builds before queuing the new 
build.

.PARAMETER VsoQueuedPipelines
Variable name to set in DevOps for the queued pipeline links

.PARAMETER Base64EncodedAuthToken
Auth token for Azure DevOps API

.PARAMETER BuildParametersJson
Additional build parameters to provide to the pipeline execution.

Of the format:

```json
{
  "variable1": "value1",
  "variable2": "value2"
}
```

#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$Organization,

  [Parameter(Mandatory = $true)]
  [string]$Project,

  [string]$SourceBranch,

  [Parameter(Mandatory = $true)]
  [int]$DefinitionId,

  [boolean]$CancelPreviousBuilds=$false,

  [Parameter(Mandatory = $false)]
  [string]$VsoQueuedPipelines,

  [Parameter(Mandatory = $true)]
  [string]$Base64EncodedAuthToken,

  [Parameter(Mandatory = $false)]
  [string]$BuildParametersJson
)

. (Join-Path $PSScriptRoot common.ps1)

# Skip if SourceBranch is empty because it we cannot generate a target branch
# name from an empty string.
if ($CancelPreviousBuilds -and $SourceBranch)
{
  try {
    $queuedBuilds = Get-DevOpsBuilds -BranchName "refs/heads/$SourceBranch" -Definitions $DefinitionId `
    -StatusFilter "inProgress, notStarted" -Base64EncodedAuthToken $Base64EncodedAuthToken

    if ($queuedBuilds.count -eq 0) {
      LogDebug "There is no previous build still inprogress or about to start."
    }

    foreach ($build in $queuedBuilds.Value) {
      $buildID = $build.id
      LogDebug "Canceling build [ $($build._links.web.href) ]"
      Update-DevOpsBuild -BuildId $buildID -Status "cancelling" -Base64EncodedAuthToken $Base64EncodedAuthToken
    }
  }
  catch {
    LogError "Call to DevOps API failed with exception:`n$_"
    exit 1
  }
}

try {
  $resp = Start-DevOpsBuild `
    -Organization $Organization `
    -Project $Project `
    -SourceBranch $SourceBranch `
    -DefinitionId $DefinitionId `
    -Base64EncodedAuthToken $Base64EncodedAuthToken `
    -BuildParametersJson $BuildParametersJson
}
catch {
  LogError "Start-DevOpsBuild failed with exception:`n$_"
  exit 1
}

LogDebug "Pipeline [ $($resp.definition.name) ] queued at [ $($resp._links.web.href) ]"

if ($VsoQueuedPipelines) {
  $enVarValue = [System.Environment]::GetEnvironmentVariable($VsoQueuedPipelines)
  $QueuedPipelineLinks = if ($enVarValue) { 
    "$enVarValue<br>[$($resp.definition.name)]($($resp._links.web.href))"
  }else {
    "[$($resp.definition.name)]($($resp._links.web.href))"
  }
  LogDebug "Here are the queued pipeline links: "
  LogDebug $QueuedPipelineLinks
  Write-Host "##vso[task.setvariable variable=$VsoQueuedPipelines]$QueuedPipelineLinks"
}