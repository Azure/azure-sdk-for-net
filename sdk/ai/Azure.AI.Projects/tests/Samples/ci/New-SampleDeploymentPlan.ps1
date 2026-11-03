# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $SelectionManifest,
    [Parameter(Mandatory)] [string] $OutputDirectory,
    [Parameter(Mandatory)] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [Parameter(Mandatory)] [AllowEmptyString()] [string] $IdentityResourceGroup,
    [ValidatePattern('^[A-Za-z0-9._-]+$')] [string] $ModelName = 'gpt-5.2',
    [ValidatePattern('^[A-Za-z0-9._-]+$')] [string] $ModelVersion = '2025-12-11',
    [ValidateSet('GlobalStandard', 'Standard')] [string] $ModelSku = 'GlobalStandard',
    [ValidateRange(1, 1000)] [int] $ModelCapacity = 10,
    [ValidatePattern('^\d+$')] [string] $DefinitionId = $env:SYSTEM_DEFINITIONID,
    [ValidatePattern('^\d+$')] [string] $BuildId = $env:BUILD_BUILDID,
    [ValidatePattern('^\d+$')] [string] $JobAttempt = $env:SYSTEM_JOBATTEMPT,
    [string] $PackageRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'SampleCiHelpers.ps1')
. (Join-Path $PSScriptRoot 'PythonSampleCiHelpers.ps1')
$manifest = Read-SampleManifest -Path $SelectionManifest -PackageRoot $PackageRoot
$scanner = Join-Path $PackageRoot '.github/skills/azure-ai-projects-record-sample/scripts/GetSampleRequiredEnvironmentVariables.ps1'
$required = @()
$runnable = @()
$rejected = @()
# Bicep outputs plus values the provisioning script adds; the validation endpoint is a pipeline variable and never enters state.
$stateBindings = @(Get-SampleEnvironmentNames)
$provided = @($stateBindings + 'LLM_VALIDATION_PROJECT_ENDPOINT')
# Validate test compatibility only; selection never changes the resource bundle or its bindings.
foreach ($test in @($manifest.tests)) {
    $names = @(& $scanner -SamplePath @($test.sample_path) -PackageRoot $PackageRoot)
    $unsupported = @($names | Where-Object { $_ -notin $provided })
    if ($unsupported.Count -gt 0) {
        $rejected += @{ node_id = $test.node_id; sample_path = $test.sample_path; unsupported = $unsupported }
    } else {
        $runnable += $test
        $required += $names
    }
}
$required = @($required | Sort-Object -Unique)

$null = New-Item -ItemType Directory -Path $OutputDirectory -Force
if ($rejected.Count -gt 0) {
    # Only these samples fail; the rest of the selection still runs.
    ConvertTo-Json -InputObject $rejected -Depth 5 | Set-Content -LiteralPath (Join-Path $OutputDirectory 'rejected-tests.json') -Encoding utf8
    foreach ($item in $rejected) {
        Write-Host ('REJECTED {0}: requires unsupported environment variable(s) {1}. No Azure changes were made.' -f $item.node_id, ($item.unsupported -join ', '))
    }
}
if ($runnable.Count -eq 0) {
    Write-Host ('Queue {0} has no runnable sample; no plan was written.' -f $QueueName)
    return
}

# The Python adapter adds test metadata; the shared planner has no knowledge of pytest or sample paths.
& (Join-Path $PSScriptRoot 'New-ResourceDeploymentPlan.ps1') -OutputDirectory $OutputDirectory -QueueName $QueueName `
    -IdentityResourceGroup $IdentityResourceGroup -ModelName $ModelName -ModelVersion $ModelVersion `
    -ModelSku $ModelSku -ModelCapacity $ModelCapacity -DefinitionId $DefinitionId -BuildId $BuildId -JobAttempt $JobAttempt
$plan = Get-Content -LiteralPath (Join-Path $OutputDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
$plan['requiredEnvironment'] = $required
$plan['selectedTests'] = @($runnable)
Assert-SampleRunPlan -Plan $plan -QueueName $QueueName
$plan | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath (Join-Path $OutputDirectory 'deployment-plan.json') -Encoding utf8

Write-Host 'DRY RUN: no Azure resources, role assignments, or project connections were changed.'
Write-Host ('Target subscription from AZURE_SUBSCRIPTION_ID: {0}.' -f $plan.subscriptionId)
Write-Host ('Target tenant from AZURE_TENANT_ID: {0}.' -f $plan.tenantId)
Write-Host ('Shared identity resource group: {0}. Managed identities are looked up there by their -project-/-account-/-search-/-function- names before provisioning.' -f $plan.identityResourceGroup)
Write-Host ('New resource group: {0}; identity resource IDs and region will be resolved by read-only admission.' -f $plan.resourceGroup)
Write-Host ('Test queue: {0}. Local shared-identity Standard variant: new account/project, Storage, Cosmos DB, Search and capability hosts.' -f $QueueName)
Write-Host 'Shared UAMIs and Azure service-role grants must already exist. Only native Cosmos data roles are created per run.'
Write-Host ('Sample model: {0} ({1}).' -f $ModelName, $ModelVersion)
Write-Host 'Output validation uses an existing project supplied by the LLM_VALIDATION_PROJECT_ENDPOINT environment variable; no validator is provisioned.'
Write-Host 'GitHub MCP connection: always provisioned; the PAT is never stored in this plan.'
Write-Host 'Function App, hosting plan, queues and handler code: always provisioned for every active queue.'
Write-Host 'Public networking. Resources incur charges until cleanup completes.'
Write-Host 'This offline preview is not ARM what-if. A live run checks identity, regional dependency eligibility and model/account quota before provisioning.'
