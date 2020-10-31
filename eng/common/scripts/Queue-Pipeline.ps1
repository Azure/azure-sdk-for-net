[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$Organization,

  [Parameter(Mandatory = $true)]
  [string]$Project,

  [Parameter(Mandatory = $true)]
  [string]$SourceBranch,

  [Parameter(Mandatory = $true)]
  [int]$DefinitionId,

  [boolean]$CancelPreviousBuilds=$false,

  [Parameter(Mandatory = $false)]
  [string]$VsoQueuedPipelines,

  [Parameter(Mandatory = $true)]
  [string]$AuthToken
)

. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\Invoke-DevOpsAPI.ps1"

if ($CancelPreviousBuilds)
{
  try {
    $queuedBuilds = Get-DevOpsBuilds -BranchName "refs/heads/$SourceBranch" -Definitions $DefinitionId `
    -StatusFilter "inProgress, notStarted" -AuthToken $AuthToken

    foreach ($build in $queuedBuilds.Value) {
      $buildID = $build.id
      LogDebug "Canceling build [ $($build._links.web) ]"
      Update-DevOpsBuild -BuildId $buildID -Status "canceling" -AuthToken $AuthToken
    }
  }
  catch {
    LogError "Call to DevOps API failed with exception:`n$_"
    exit 1
  }
}

try {
  $resp = Start-DevOpsBuild -SourceBranch $SourceBranch -DefinitionId $DefinitionId -AuthToken $AuthToken
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
  $QueuedPipelineLinks
  Write-Host "##vso[task.setvariable variable=$VsoQueuedPipelines]$QueuedPipelineLinks"
}