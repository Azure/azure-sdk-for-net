# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding(SupportsShouldProcess)]
param(
    [Parameter(Mandatory)] [string] $StatePath,
    [Parameter(Mandatory)] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [switch] $ConfirmCleanup
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'SampleCiHelpers.ps1')
if (-not (Test-Path -LiteralPath $StatePath)) {
    Write-Host 'No deployment attempt was recorded; no cleanup is needed.'
    return
}
$state = Get-Content -LiteralPath $StatePath -Raw | ConvertFrom-Json -AsHashtable
Assert-SampleRunPlan -Plan $state.plan -QueueName $QueueName
$expectedDeployment = 'sample-ci-rg-' + $state.plan.ownerToken
if ($state['resourceGroupDeployment'] -cne $expectedDeployment -or $state['subscriptionId'] -ine $state.plan.subscriptionId -or
    $state['tenantId'] -ine $state.plan.tenantId) {
    throw 'Invalid cleanup state. No resources were deleted.'
}
$null = Set-SampleSubscriptionContext -Plan $state.plan
$exists = Invoke-SampleAzure -Arguments @('group', 'exists', '--name', $state.plan.resourceGroup, '--subscription', $state.subscriptionId)
if ($exists) {
    $group = Invoke-SampleAzure -Arguments @('group', 'show', '--name', $state.plan.resourceGroup, '--subscription', $state.subscriptionId)
    Assert-SampleResourceGroupOwnership -Plan $state.plan -ResourceGroup $group -SubscriptionId $state.subscriptionId
    Write-Host ('Cleanup preview: delete only run-owned resource group {0}, including its temporary resources.' -f $state.plan.resourceGroup)
    if (-not $ConfirmCleanup) { Write-Host 'Dry run only. Supply -ConfirmCleanup to apply this cleanup.'; return }
    if (-not $PSCmdlet.ShouldProcess($state.plan.resourceGroup, 'Delete run-owned temporary resource group')) { return }
    $null = Invoke-SampleAzure -Arguments @('group', 'delete', '--name', $state.plan.resourceGroup, '--subscription', $state.subscriptionId, '--yes')
}
if (-not $ConfirmCleanup) { return }
if (-not $PSCmdlet.ShouldProcess($expectedDeployment, 'Delete the run-owned subscription deployment history')) { return }
$remaining = Invoke-SampleAzure -Arguments @('group', 'exists', '--name', $state.plan.resourceGroup, '--subscription', $state.subscriptionId)
if ($remaining) {
    throw 'The run-owned resource group still exists. Cleanup was not marked complete.'
}
$null = Invoke-SampleAzure -Arguments @('deployment', 'sub', 'delete', '--name', $expectedDeployment, '--subscription', $state.subscriptionId)
$state['status'] = 'CleanedUp'
$state | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $StatePath -Encoding utf8
Write-Host 'Run-owned temporary resource cleanup completed.'
