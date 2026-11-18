# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $OutputDirectory,
    [Parameter(Mandatory)] [string] $IdentityResourceGroup,
    [Parameter(Mandatory)] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [Parameter(Mandatory)] [string] $ModelName,
    [Parameter(Mandatory)] [string] $ModelVersion,
    [Parameter(Mandatory)] [ValidateSet('GlobalStandard', 'Standard')] [string] $ModelSku,
    [Parameter(Mandatory)] [ValidateRange(1, 1000)] [int] $ModelCapacity,
    [switch] $ConfirmProvisioning
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'SampleCiHelpers.ps1')
. (Join-Path $PSScriptRoot 'DotNetSampleCiHelpers.ps1')
if (-not $ConfirmProvisioning) { throw 'Supply -ConfirmProvisioning to create the billable full sample resource bundle.' }
if (Test-Path -LiteralPath $OutputDirectory) { throw 'Provisioning output already exists; refusing to adopt an earlier attempt.' }

& (Join-Path $PSScriptRoot 'New-ResourceDeploymentPlan.ps1') -OutputDirectory $OutputDirectory `
    -IdentityResourceGroup $IdentityResourceGroup -QueueName $QueueName `
    -ModelName $ModelName -ModelVersion $ModelVersion -ModelSku $ModelSku -ModelCapacity $ModelCapacity
$planPath = Join-Path $OutputDirectory 'deployment-plan.json'
$statePath = Join-Path $OutputDirectory 'deployment-state.json'
$plan = Get-Content -LiteralPath $planPath -Raw | ConvertFrom-Json -AsHashtable
$null = Set-SampleSubscriptionContext -Plan $plan
$plan = Resolve-SampleIdentitySelection -Plan $plan
$plan | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $planPath -Encoding utf8

& (Join-Path $PSScriptRoot 'Invoke-ResourceProvisioning.ps1') `
    -PlanPath $planPath -StatePath $statePath -QueueName $QueueName -ConfirmProvisioning
$state = Get-Content -LiteralPath $statePath -Raw | ConvertFrom-Json -AsHashtable
if ($state.status -cne 'Ready') { throw 'The resource bundle is not ready; no test bindings were published.' }
Assert-SampleEnvironment -Environment $state.environment -Names @(Get-SampleEnvironmentNames)

$environment = Get-DotNetSampleEnvironment -Environment $state.environment
foreach ($name in $environment.Keys) {
    $value = $environment[$name].Replace('%', '%AZP25').Replace("`r", '%0D').Replace("`n", '%0A')
    Write-Host "##vso[task.setvariable variable=$name]$value"
}
Write-Host 'The full resource bundle and .NET sample bindings are ready.'
