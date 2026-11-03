# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

<#
.SYNOPSIS
Validates infrastructure plans and provisions Azure resources for any SDK language.

.DESCRIPTION
Admission mode resolves shared identities and checks batch capacity
before provisioning workers start. Provision mode requires -ConfirmProvisioning, creates
a fresh run-owned resource group, and deploys the complete resource bundle: Foundry,
Storage, Cosmos DB, Search, model and MCP resources, and a Function App with its published
queue handler. The sample query selects tests, not resources or prerequisites.

Uses existing shared identities without changing their bootstrap grants. Saves deployment
status, non-secret environment bindings, and resource inventories for subsequent test and
cleanup steps. This script does not execute samples or delete the deployed resources.
#>

[CmdletBinding(DefaultParameterSetName = 'Provision')]
param(
    [Parameter(Mandatory, ParameterSetName = 'Provision')] [string] $PlanPath,
    [Parameter(Mandatory, ParameterSetName = 'Provision')] [string] $StatePath,
    [Parameter(Mandatory, ParameterSetName = 'Provision')] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [Parameter(ParameterSetName = 'Provision')] [switch] $ConfirmProvisioning,
    [Parameter(Mandatory, ParameterSetName = 'Admission')] [string] $BatchPlanDirectory,
    [Parameter(ParameterSetName = 'Admission')] [string] $ResolvedPlanDirectory
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'SampleCiHelpers.ps1')
if ($PSCmdlet.ParameterSetName -eq 'Admission') {
    $files = @(Get-ChildItem -LiteralPath $BatchPlanDirectory -Filter 'deployment-plan.json' -Recurse -File)
    if ($files.Count -lt 1 -or $files.Count -gt 4) { throw 'Expected one to four fresh queue plans.' }
    $plans = @(foreach ($file in $files) {
        $queue = Split-Path -Leaf (Split-Path -Parent $file.FullName)
        $item = Get-Content -LiteralPath $file.FullName -Raw | ConvertFrom-Json -AsHashtable
        Assert-SampleRunPlan -Plan $item -QueueName $queue
        $item
    })
    $null = Set-SampleSubscriptionContext -Plan $plans[0]
    # Resolve each immutable offline name intent before any capacity check/write.
    # No unresolved artifact is ever used by provisioning workers.
    $resolvedPlans = @()
    foreach ($item in $plans) {
        $resolvedPlans += $(if ($item.ContainsKey('identityResolution') -and $item.identityResolution -ceq 'Pending') {
            Resolve-SampleIdentitySelection -Plan $item
        } else { $item })
    }
    $plans = $resolvedPlans
    $null = Get-SampleSharedIdentities -Plan $plans[0]
    Assert-SampleBatchCapacity -Plans $plans
    if ($ResolvedPlanDirectory) {
        # Workers consume these resolved plans, not a second identity lookup that could select different identities.
        if (Test-Path -LiteralPath $ResolvedPlanDirectory) { throw 'Resolved plan output already exists; refusing to overwrite an earlier admission.' }
        foreach ($item in $plans) {
            $directory = Join-Path $ResolvedPlanDirectory $item.queueName
            $null = New-Item -ItemType Directory -Path $directory -Force
            $item | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath (Join-Path $directory 'deployment-plan.json') -Encoding utf8
        }
    }
    return
}
if (-not $ConfirmProvisioning) { throw 'Provisioning is disabled by default. Use -ConfirmProvisioning only for an explicitly requested live run.' }
$plan = Get-Content -LiteralPath $PlanPath -Raw | ConvertFrom-Json -AsHashtable
Assert-SampleRunPlan -Plan $plan -QueueName $QueueName
if ($plan.ContainsKey('identityResolution') -and $plan.identityResolution -cne 'Resolved') { throw 'Only an admitted, resolved identity plan may provision resources.' }
# A retry must get fresh ownership and state; adopting an earlier attempt could make cleanup target its resources.
if (Test-Path -LiteralPath $StatePath) { throw 'Deployment state already exists. Do not adopt or overwrite a previous attempt.' }
Assert-SampleMcpPat

$runnerIdentity = Set-SampleSubscriptionContext -Plan $plan
$subscription = Get-SampleSubscriptionId
$exists = Invoke-SampleAzure -Arguments @('group', 'exists', '--name', $plan.resourceGroup, '--subscription', $subscription)
if ($exists) { throw 'The generated resource group already exists. No existing group will be reused, retagged, or deleted.' }

Assert-SampleRegionAvailability -SubscriptionId $subscription -Location $plan.location
$identities = Get-SampleSharedIdentities -Plan $plan

# Recheck live availability after batch admission because another deployment may have consumed capacity.
$catalog = @(Invoke-SampleAzure -Arguments @('cognitiveservices', 'model', 'list', '--location', $plan.location, '--subscription', $subscription))
$sampleModel = Resolve-SampleModel -Catalog $catalog -Name $plan.sampleModel.name -Version $plan.sampleModel.version `
    -Sku $plan.sampleModel.sku -Capacity $plan.sampleModel.capacity
$usages = @(Invoke-SampleAzure -Arguments @('cognitiveservices', 'usage', 'list', '--location', $plan.location, '--subscription', $subscription))
Assert-SampleAccountQuota -Usages $usages -Location $plan.location
$null = Get-SampleQuotaAvailable -Usages $usages -UsageName $sampleModel.usageName -RequiredCapacity $sampleModel.capacity `
    -Description "model deployment quota for '$($sampleModel.name)'"
Write-Host ('Model preflight: {0} {1}, {2}, capacity {3}.' -f $sampleModel.name, $sampleModel.version, $sampleModel.sku, $sampleModel.capacity)

$groupDeploymentName = 'sample-ci-rg-' + $plan.ownerToken
$groupArguments = @('--name', $groupDeploymentName, '--location', $plan.location, '--subscription', $subscription,
    '--template-file', (Join-Path $PSScriptRoot 'infra/resource-group.bicep'), '--parameters',
    "location=$($plan.location)", "resourceGroupName=$($plan.resourceGroup)",
    ('runId={0}-{1}-{2}-{3}' -f $plan.definitionId, $plan.buildId, $plan.queueName, $plan.jobAttempt),
    "queueName=$($plan.queueName)",
    "ownerToken=$($plan.ownerToken)", "expiresUtc=$($plan.expiresUtc)")
Write-Host 'Validating Bicep resource-group deployment before any resource changes.'
$null = Invoke-SampleAzure -Arguments (@('deployment', 'sub', 'validate') + $groupArguments)

$bundleTemplatePath = Join-Path $PSScriptRoot 'infra/main.bicep'
# Persist ownership and the initial step before any resource creation so partial failures remain discoverable for cleanup.
$state = @{
    schemaVersion = 1
    plan = $plan
    subscriptionId = $subscription
    tenantId = $runnerIdentity.tenantId
    resourceGroupDeployment = $groupDeploymentName
    status = 'Provisioning'
    provisioningStep = 'ResourceGroup'
}
$stateDirectory = Split-Path -Parent $StatePath
$null = New-Item -ItemType Directory -Path $stateDirectory -Force
$state | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $StatePath -Encoding utf8
'[]' | Set-Content -LiteralPath (Join-Path $stateDirectory 'inventory-before.json') -Encoding utf8

try {
    $null = Invoke-SampleAzure -Arguments (@('deployment', 'sub', 'create') + $groupArguments)
    $group = Invoke-SampleAzure -Arguments @('group', 'show', '--name', $plan.resourceGroup, '--subscription', $subscription)
    Assert-SampleResourceGroupOwnership -Plan $plan -ResourceGroup $group -SubscriptionId $subscription

    # Bicep owns resource ordering and module wiring; new resources belong in the root template, not this script.
    $state['provisioningStep'] = 'ResourceBundle'
    Write-Host 'Deploying the complete shared-identity resource bundle (capability hosts can take 10-20 minutes).'
    $modelParameters = @{ name = $sampleModel.name; version = $sampleModel.version; sku = $sampleModel.sku; capacity = $sampleModel.capacity }
    $bundleArguments = @('deployment', 'group', 'create', '--name', 'resource-bundle',
        '--resource-group', $plan.resourceGroup, '--subscription', $subscription,
        '--template-file', $bundleTemplatePath,
        '--parameters', (Join-Path $PSScriptRoot 'infra/sample-resources.bicepparam'),
        "location=$($plan.location)", "accountPrefix=$($plan.accountPrefix)",
        "deploymentTimestamp=$($plan.deploymentTimestamp)", "ownerToken=$($plan.ownerToken)",
        "agentName=$($plan.agentName)", ('sampleModel=' + ($modelParameters | ConvertTo-Json -Compress)),
        "sharedProjectIdentityResourceId=$($identities.project.resourceId)",
        "sharedAccountIdentityResourceId=$($identities.account.resourceId)",
        "sharedSearchIdentityResourceId=$($identities.search.resourceId)",
        "sharedFunctionIdentityResourceId=$($identities.function.resourceId)",
        "sharedProjectPrincipalId=$($identities.project.principalId)")
    $bundle = Invoke-SampleAzure -Arguments $bundleArguments -Sensitive
    if ($bundle.properties.provisioningState -ne 'Succeeded') { throw 'Resource bundle Bicep deployment did not succeed.' }
    $state['environment'] = $bundle.properties.outputs.environment.value
    Assert-SampleEnvironment -Environment $state.environment -Names @(Get-SampleBicepEnvironmentNames -BicepPath $bundleTemplatePath)

    # Publishing code is an imperative action, separate from adding declarative infrastructure.
    # It remains unconditional and uses the same Function host for all SDK languages.
    $state['provisioningStep'] = 'FunctionCode'
    Publish-SampleFunctionApp -Plan $plan -FunctionAppName ([string] $state.environment.FUNCTION_APP_NAME)
    Write-Host 'Function code published and queue_trigger indexed successfully.'
    $state.environment['AZURE_SUBSCRIPTION_ID'] = $subscription
    $state.environment['AZURE_TENANT_ID'] = $runnerIdentity.tenantId
    $state.environment['AZURE_RESOURCE_GROUP'] = $plan.resourceGroup
    Assert-SampleEnvironment -Environment $state.environment -Names @($plan.environmentBindings)
    # Do not expose a Ready state until publication and trigger indexing have both succeeded.
    $state['status'] = 'Ready'
    $state['provisioningStep'] = 'Complete'
} catch {
    $state['status'] = 'Failed'
    Write-Host ('Provisioning failed during step: {0}.' -f $state.provisioningStep)
    throw
} finally {
    # Preserve failure state and partial inventory too; downstream cleanup must not depend on a successful deployment.
    $state | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $StatePath -Encoding utf8
    try {
        Save-SampleInventory -State $state -OutputPath (Join-Path $stateDirectory 'inventory-after.json')
    } catch {
        Write-Warning 'Resource inventory could not be captured; cleanup must still verify the exact ownership tags.'
    }
}
Write-Host 'Bicep provisioning completed. Only non-secret endpoints and resource IDs were saved for the test step.'
