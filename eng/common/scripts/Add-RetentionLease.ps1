[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$Organization,

  [Parameter(Mandatory = $true)]
  [string]$Project,

  [Parameter(Mandatory = $true)]
  [int]$DefinitionId,

  [Parameter(Mandatory = $true)]
  [int]$RunId,

  [Parameter(Mandatory = $true)]
  [string]$OwnerId,

  [Parameter(Mandatory = $true)]
  [int]$DaysValid,

  [Parameter(Mandatory = $true)]
  [string]$Base64EncodedAuthToken
)

. (Join-Path $PSScriptRoot common.ps1)

LogDebug "Checking for existing leases on run: $RunId"
$existingLeases = Get-RetentionLeases -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -Base64EncodedAuthToken $Base64EncodedAuthToken

if ($existingLeases.count -ne 0) {
    LogDebug "Found $($existingLeases.count) leases, will delete them first."

    foreach ($lease in $existingLeases.value) {
        LogDebug "Deleting lease: $($lease.leaseId)"
        Delete-RetentionLease -Organization $Organization -Project $Project -LeaseId $lease.leaseId -Base64EncodedAuthToken $Base64EncodedAuthToken
    }

}

LogDebug "Creating new lease on run: $RunId"
$lease = Add-RetentionLease -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -DaysValid $DaysValid -Base64EncodedAuthToken $Base64EncodedAuthToken
LogDebug "Lease ID is: $($lease.value.leaseId)"

#Add-RetentionLease -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -DaysValid $DaysValid -Base64AuthToken $Base64AuthToken

# if ($CancelPreviousBuilds)
# {
#   try {
#     $queuedBuilds = Get-DevOpsBuilds -BranchName "refs/heads/$SourceBranch" -Definitions $DefinitionId `
#     -StatusFilter "inProgress, notStarted" -Base64EncodedAuthToken $Base64EncodedAuthToken

#     if ($queuedBuilds.count -eq 0) {
#       LogDebug "There is no previous build still inprogress or about to start."
#     }

#     foreach ($build in $queuedBuilds.Value) {
#       $buildID = $build.id
#       LogDebug "Canceling build [ $($build._links.web.href) ]"
#       Update-DevOpsBuild -BuildId $buildID -Status "cancelling" -Base64EncodedAuthToken $Base64EncodedAuthToken
#     }
#   }
#   catch {
#     LogError "Call to DevOps API failed with exception:`n$_"
#     exit 1
#   }
# }

# try {
#   $resp = Start-DevOpsBuild -SourceBranch $SourceBranch -DefinitionId $DefinitionId -Base64EncodedAuthToken $Base64EncodedAuthToken
# }
# catch {
#   LogError "Start-DevOpsBuild failed with exception:`n$_"
#   exit 1
# }

# LogDebug "Pipeline [ $($resp.definition.name) ] queued at [ $($resp._links.web.href) ]"

# if ($VsoQueuedPipelines) {
#   $enVarValue = [System.Environment]::GetEnvironmentVariable($VsoQueuedPipelines)
#   $QueuedPipelineLinks = if ($enVarValue) { 
#     "$enVarValue<br>[$($resp.definition.name)]($($resp._links.web.href))"
#   }else {
#     "[$($resp.definition.name)]($($resp._links.web.href))"
#   }
#   $QueuedPipelineLinks
#   Write-Host "##vso[task.setvariable variable=$VsoQueuedPipelines]$QueuedPipelineLinks"
# }