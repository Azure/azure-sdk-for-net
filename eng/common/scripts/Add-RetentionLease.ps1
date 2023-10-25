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
  [int]$DaysValid,

  [Parameter(Mandatory = $false)]
  [string]$OwnerId = "azure-sdk-pipeline-automation",

  [Parameter(Mandatory = $false)]
  [string]$AccessToken = $env:DEVOPS_PAT
)

Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)

$encodedAuthToken = Get-Base64EncodedToken $AccessToken

LogDebug "Checking for existing leases on run: $RunId"
$existingLeases = Get-RetentionLeases -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -Base64EncodedAuthToken $encodedAuthToken

if ($existingLeases.count -ne 0) {
    LogDebug "Found $($existingLeases.count) leases, will delete them first."

    foreach ($lease in $existingLeases.value) {
        LogDebug "Deleting lease: $($lease.leaseId)"
        Delete-RetentionLease -Organization $Organization -Project $Project -LeaseId $lease.leaseId -Base64EncodedAuthToken $encodedAuthToken
    }

}

LogDebug "Creating new lease on run: $RunId"
$lease = Add-RetentionLease -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -DaysValid $DaysValid -Base64EncodedAuthToken $encodedAuthToken
LogDebug "Lease ID is: $($lease.value.leaseId)"