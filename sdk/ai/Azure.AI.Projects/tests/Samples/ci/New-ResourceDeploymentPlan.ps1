# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

<#
.SYNOPSIS
Creates an offline infrastructure plan usable by any SDK language.
.DESCRIPTION
Requires explicit target subscription and tenant environment variables. Generates fresh
ownership metadata and discovers non-secret bindings from infra/main.bicep. No test
manifest, SDK package, Python runtime, Azure login, or service call is required.
Admission resolves existing shared identities before a worker can deploy this plan.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $OutputDirectory,
    [Parameter(Mandatory)] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [Parameter(Mandatory)] [AllowEmptyString()] [string] $IdentityResourceGroup,
    [switch] $StandardOnly,
    [ValidatePattern('^[A-Za-z0-9._-]+$')] [string] $ModelName = 'gpt-5.2',
    [ValidatePattern('^[A-Za-z0-9._-]+$')] [string] $ModelVersion = '2025-12-11',
    [ValidateSet('GlobalStandard', 'Standard')] [string] $ModelSku = 'GlobalStandard',
    [ValidateRange(1, 1000)] [int] $ModelCapacity = 10,
    [ValidatePattern('^\d+$')] [string] $DefinitionId = $env:SYSTEM_DEFINITIONID,
    [ValidatePattern('^\d+$')] [string] $BuildId = $env:BUILD_BUILDID,
    [ValidatePattern('^\d+$')] [string] $JobAttempt = $env:SYSTEM_JOBATTEMPT
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'SampleCiHelpers.ps1')
$subscription = Get-SampleSubscriptionId
$tenant = Get-SampleTenantId
$identityGroup = Get-SampleIdentityResourceGroup -Name $IdentityResourceGroup
$ownerToken = [guid]::NewGuid().ToString('N')
$plan = @{
    schemaVersion = 1
    definitionId = $DefinitionId
    buildId = $BuildId
    jobAttempt = $JobAttempt
    queueName = $QueueName
    ownerToken = $ownerToken
    subscriptionId = $subscription
    tenantId = $tenant
    resourceGroup = 'azsdk-samples-{0}-{1}-{2}-{3}-{4}' -f $DefinitionId, $BuildId, $QueueName, $JobAttempt, $ownerToken.Substring(0, 8)
    identityResourceGroup = $identityGroup
    identityResolution = 'Pending'
    sharedIdentities = @{}
    location = ''
    accountPrefix = 'sdk' + $ownerToken.Substring(0, 6)
    agentName = 'sample-' + $ownerToken.Substring(0, 12)
    deploymentTimestamp = [DateTime]::UtcNow.ToString('yyyyMMddHHmmss')
    expiresUtc = [DateTime]::UtcNow.AddDays(1).ToString('o')
    sampleModel = @{ name = $ModelName; version = $ModelVersion; sku = $ModelSku; capacity = $ModelCapacity }
    environmentBindings = @(Get-SampleEnvironmentNames)
}
if ($StandardOnly) {
    $plan.environmentBindings = @(@(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $PSScriptRoot 'infra/standard-with-model.bicep')) +
        @('AZURE_SUBSCRIPTION_ID', 'AZURE_TENANT_ID', 'AZURE_RESOURCE_GROUP') | Sort-Object -Unique)
}
Assert-SampleRunPlan -Plan $plan -QueueName $QueueName
$null = New-Item -ItemType Directory -Path $OutputDirectory -Force
$plan | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath (Join-Path $OutputDirectory 'deployment-plan.json') -Encoding utf8
Write-Host ('DRY RUN: planned a fresh resource group {0}; no Azure resources or grants were changed.' -f $plan.resourceGroup)
