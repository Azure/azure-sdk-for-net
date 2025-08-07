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

  # This script shouldn't need anything other than the $System.AccessToken from
  # from the build pipeline. The retain-run.yml template doesn't run outside
  # of the pipeline it's manipulating the retention leases for.
  [Parameter(Mandatory = $true)]
  [string]$AccessToken = $env:DEVOPS_PAT
)

Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)

$Base64EncodedToken = Get-Base64EncodedToken $AccessToken

LogDebug "Checking for existing leases on run: $RunId"
$existingLeases = Get-RetentionLeases -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -Base64EncodedToken $Base64EncodedToken

if ($existingLeases.count -ne 0) {
    LogDebug "Found $($existingLeases.count) leases, will delete them first."

    foreach ($lease in $existingLeases.value) {
        LogDebug "Deleting lease: $($lease.leaseId)"
        Delete-RetentionLease -Organization $Organization -Project $Project -LeaseId $lease.leaseId -Base64EncodedToken $Base64EncodedToken
    }

}
LogDebug "Creating new lease on run: $RunId"
$lease = Add-RetentionLease -Organization $Organization -Project $Project -DefinitionId $DefinitionId -RunId $RunId -OwnerId $OwnerId -DaysValid $DaysValid -Base64EncodedToken $Base64EncodedToken
LogDebug "Lease ID is: $($lease.value.leaseId)"