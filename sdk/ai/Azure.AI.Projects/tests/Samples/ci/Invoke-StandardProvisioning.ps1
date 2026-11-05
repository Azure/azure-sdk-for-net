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
if (-not $ConfirmProvisioning) { throw 'Supply -ConfirmProvisioning to create billable Standard Foundry resources.' }
$statePath = Join-Path $OutputDirectory 'deployment-state.json'
if (Test-Path -LiteralPath $OutputDirectory) { throw 'Provisioning output already exists; refusing to adopt an earlier attempt.' }

& (Join-Path $PSScriptRoot 'New-ResourceDeploymentPlan.ps1') -OutputDirectory $OutputDirectory `
    -IdentityResourceGroup $IdentityResourceGroup -QueueName $QueueName -StandardOnly `
    -ModelName $ModelName -ModelVersion $ModelVersion -ModelSku $ModelSku -ModelCapacity $ModelCapacity
$planPath = Join-Path $OutputDirectory 'deployment-plan.json'
$plan = Get-Content -LiteralPath $planPath -Raw | ConvertFrom-Json -AsHashtable
$runnerIdentity = Set-SampleSubscriptionContext -Plan $plan
$plan = Resolve-SampleIdentitySelection -Plan $plan
$identities = Get-SampleSharedIdentities -Plan $plan
$plan | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $planPath -Encoding utf8

$subscription = $plan.subscriptionId
if (Invoke-SampleAzure -Arguments @('group', 'exists', '--name', $plan.resourceGroup, '--subscription', $subscription)) {
    throw 'The generated resource group already exists; no resources were changed.'
}
Assert-SampleRegionAvailability -SubscriptionId $subscription -Location $plan.location
$catalog = @(Invoke-SampleAzure -Arguments @('cognitiveservices', 'model', 'list', '--location', $plan.location, '--subscription', $subscription))
$model = Resolve-SampleModel -Catalog $catalog -Name $ModelName -Version $ModelVersion -Sku $ModelSku -Capacity $ModelCapacity
$usages = @(Invoke-SampleAzure -Arguments @('cognitiveservices', 'usage', 'list', '--location', $plan.location, '--subscription', $subscription))
Assert-SampleAccountQuota -Usages $usages -Location $plan.location
$null = Get-SampleQuotaAvailable -Usages $usages -UsageName $model.usageName -RequiredCapacity $model.capacity -Description 'sample model quota'

$deploymentName = 'sample-ci-rg-' + $plan.ownerToken
$groupArguments = @('--name', $deploymentName, '--location', $plan.location, '--subscription', $subscription,
    '--template-file', (Join-Path $PSScriptRoot 'infra/resource-group.bicep'), '--parameters',
    "location=$($plan.location)", "resourceGroupName=$($plan.resourceGroup)",
    ('runId={0}-{1}-{2}-{3}' -f $plan.definitionId, $plan.buildId, $plan.queueName, $plan.jobAttempt),
    "queueName=$QueueName", "ownerToken=$($plan.ownerToken)", "expiresUtc=$($plan.expiresUtc)")
$null = Invoke-SampleAzure -Arguments (@('deployment', 'sub', 'validate') + $groupArguments)
$state = @{
    schemaVersion = 1
    plan = $plan
    subscriptionId = $subscription
    tenantId = $runnerIdentity.tenantId
    resourceGroupDeployment = $deploymentName
    status = 'Provisioning'
    provisioningStep = 'ResourceGroup'
}
$state | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $statePath -Encoding utf8
try {
    $null = Invoke-SampleAzure -Arguments (@('deployment', 'sub', 'create') + $groupArguments)
    $group = Invoke-SampleAzure -Arguments @('group', 'show', '--name', $plan.resourceGroup, '--subscription', $subscription)
    Assert-SampleResourceGroupOwnership -Plan $plan -ResourceGroup $group -SubscriptionId $subscription
    $state.provisioningStep = 'StandardFoundry'
    $templatePath = Join-Path $PSScriptRoot 'infra/standard-with-model.bicep'
    $modelParameters = @{ name = $model.name; version = $model.version; sku = $model.sku; capacity = $model.capacity }
    $deployment = Invoke-SampleAzure -Arguments @('deployment', 'group', 'create', '--name', 'standard-foundry',
        '--resource-group', $plan.resourceGroup, '--subscription', $subscription, '--template-file', $templatePath,
        '--parameters', "location=$($plan.location)", "accountPrefix=$($plan.accountPrefix)",
        "deploymentTimestamp=$($plan.deploymentTimestamp)", "agentName=$($plan.agentName)",
        ('sampleModel=' + ($modelParameters | ConvertTo-Json -Compress)),
        "sharedProjectIdentityResourceId=$($identities.project.resourceId)",
        "sharedAccountIdentityResourceId=$($identities.account.resourceId)",
        "sharedSearchIdentityResourceId=$($identities.search.resourceId)",
        "sharedProjectPrincipalId=$($identities.project.principalId)")
    if ($deployment.properties.provisioningState -ne 'Succeeded') { throw 'Standard Foundry deployment did not succeed.' }
    $state['environment'] = $deployment.properties.outputs.environment.value
    $state.environment['AZURE_SUBSCRIPTION_ID'] = $subscription
    $state.environment['AZURE_TENANT_ID'] = $runnerIdentity.tenantId
    $state.environment['AZURE_RESOURCE_GROUP'] = $plan.resourceGroup
    Assert-SampleEnvironment -Environment $state.environment -Names $plan.environmentBindings
    $state.status = 'Ready'
    $state.provisioningStep = 'Complete'
} catch {
    $state.status = 'Failed'
    Write-Host "Standard Foundry provisioning failed during $($state.provisioningStep)."
    throw
} finally {
    $state | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $statePath -Encoding utf8
}
foreach ($name in $state.environment.Keys) {
    Write-Host "##vso[task.setvariable variable=$name]$($state.environment[$name])"
}
Write-Host 'Standard Foundry and model are ready. No MCP connection or Function App was provisioned.'
