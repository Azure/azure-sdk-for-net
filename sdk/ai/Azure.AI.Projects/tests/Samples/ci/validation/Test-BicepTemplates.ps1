# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding()]
param([ValidateNotNullOrEmpty()] [string] $StandardTemplatePath)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')
$infra = Join-Path $PSScriptRoot '../infra'

function Invoke-BicepCompilation {
    param([Parameter(Mandatory)] [string] $Path, [switch] $Parameters)

    # Compile only: no deployment, authentication, downloader, or service calls.
    # Capture BOTH streams; never print compiled templates, parameter JSON, or raw diagnostics.
    $PSNativeCommandUseErrorActionPreference = $false
    $arguments = @('bicep', $(if ($Parameters) { 'build-params' } else { 'build' }),
        '--file', $Path, '--stdout', '--only-show-errors')
    $captured = $null
    $text = $null
    try {
        try {
            $captured = @(& az @arguments 2>&1)
            $exitCode = $LASTEXITCODE
        } catch {
            throw 'Local Bicep compiler invocation failed; output suppressed.'
        }
        if ($exitCode -ne 0) { throw 'Local Bicep compilation failed; output suppressed.' }
        $text = $captured -join [Environment]::NewLine
        try {
            $parsed = $text | ConvertFrom-Json -AsHashtable -ErrorAction Stop
        } catch {
            throw 'Local Bicep compiler returned invalid protected JSON; output suppressed.'
        }
        if ($parsed -isnot [System.Collections.IDictionary]) {
            throw 'Local Bicep compiler did not return a JSON object; output suppressed.'
        }
        return $parsed
    } finally {
        $captured = $null
        $text = $null
    }
}

function Get-ArmResources {
    param([Parameter(Mandatory)] [System.Collections.IDictionary] $Template, [string] $ParentType = '')

    $resources = $Template['resources']
    if ($null -eq $resources) { return }
    # Support both ordinary ARM resource arrays and languageVersion 2.0 symbolic dictionaries.
    if ($resources -is [System.Collections.IDictionary]) {
        $entries = @($resources.Values)
    } elseif ($resources -is [System.Collections.IList]) {
        $entries = @($resources)
    } else {
        throw 'Cannot inspect the compiled ARM resource collection.'
    }
    foreach ($resource in $entries) {
        if ($resource -isnot [System.Collections.IDictionary] -or [string]::IsNullOrWhiteSpace($resource['type'])) {
            throw 'Cannot inspect a compiled ARM resource.'
        }
        $type = [string] $resource['type']
        if ($ParentType -and $type -notmatch '^[^/]+\.[^/]+/') { $type = $ParentType + '/' + $type }
        [pscustomobject]@{ Type = $type; Definition = $resource }
        if ($resource.Contains('resources')) { Get-ArmResources -Template $resource -ParentType $type }
        if ($type -ieq 'Microsoft.Resources/deployments') {
            if ($resource['properties']['template'] -isnot [System.Collections.IDictionary] -or
                $resource['properties'].Contains('templateLink')) {
                throw 'Worker templates must inline nested deployments so all IAM resources can be inspected.'
            }
            Get-ArmResources -Template $resource['properties']['template']
        }
    }
}

function Assert-NoArmRoleAssignments {
    param([Parameter(Mandatory)] [object[]] $Resources)

    if (@($Resources | Where-Object { $_.Type -imatch '(^|/)Microsoft\.Authorization/roleAssignments$' }).Count -ne 0) {
        throw 'Worker templates must contain zero Microsoft.Authorization/roleAssignments, including nested deployments.'
    }
}

function Assert-SharedIdentity {
    param([Parameter(Mandatory)] [System.Collections.IDictionary] $Resource,
        [Parameter(Mandatory)] [string] $ParameterName)

    $identity = $Resource['identity']
    if ($identity -isnot [System.Collections.IDictionary] -or $identity['type'] -cne 'UserAssigned' -or
        $identity['userAssignedIdentities'] -isnot [System.Collections.IDictionary]) {
        throw 'Foundry account, project, Search, and Function App must use only their existing shared UAMIs.'
    }
    $keys = @($identity['userAssignedIdentities'].Keys)
    $expectedKey = '[parameters(''{0}'')]' -f $ParameterName
    $interpolatedKey = "[format('{0}', parameters('$ParameterName'))]"
    if ($keys.Count -ne 1 -or $keys[0] -cnotin @($expectedKey, $interpolatedKey)) {
        throw 'Each service must attach exactly its designated shared identity resource-ID parameter.'
    }
}

# Compile the three worker templates.
$standard = Invoke-BicepCompilation -Path (Join-Path $infra 'standard-shared-identities.bicep')
$sample = Invoke-BicepCompilation -Path (Join-Path $infra 'sample-resources.bicep')
$group = Invoke-BicepCompilation -Path (Join-Path $infra 'resource-group.bicep')
# Never apply the worker zero-IAM assertion to the official reference.
$standardResources = @(Get-ArmResources -Template $standard)
$sampleResources = @(Get-ArmResources -Template $sample)
Assert-NoArmRoleAssignments -Resources $standardResources
Assert-NoArmRoleAssignments -Resources $sampleResources
Assert-NoArmRoleAssignments -Resources @(Get-ArmResources -Template $group)
if ($standard['parameters']['location'].Contains('defaultValue') -or $standard['parameters']['location'].Contains('allowedValues')) {
    throw 'The worker region must be supplied by the selected MI set, never a Bicep default or fixed region allowlist.'
}
$storageResources = @($standardResources | Where-Object { $_.Type -ieq 'Microsoft.Storage/storageAccounts' })
if ($storageResources.Count -ne 1 -or $storageResources[0].Definition['sku']['name'] -cne 'Standard_ZRS') {
    throw 'The deployed StorageV2 SKU must match the Standard_ZRS regional preflight contract.'
}
$uniqueSuffix = [string] $standard['variables']['uniqueSuffix']
if ($uniqueSuffix -cnotmatch '^\[uniqueString\(' -or $uniqueSuffix -match 'substring\(' -or
    $uniqueSuffix -notmatch 'resourceGroup\(\)\.id' -or $uniqueSuffix -notmatch 'deploymentTimestamp') {
    throw 'Globally unique resource names must retain the full run hash seeded by resource group and deployment timestamp.'
}

foreach ($binding in @(
    @{ Type = 'Microsoft.CognitiveServices/accounts'; Parameter = 'sharedAccountIdentityResourceId' },
    @{ Type = 'Microsoft.CognitiveServices/accounts/projects'; Parameter = 'sharedProjectIdentityResourceId' },
    @{ Type = 'Microsoft.Search/searchServices'; Parameter = 'sharedSearchIdentityResourceId' }
)) {
    $serviceResources = @($standardResources | Where-Object { $_.Type -ieq $binding.Type })
    if ($serviceResources.Count -ne 1) { throw 'The Standard template must create one account, one project, and one Search service.' }
    Assert-SharedIdentity -Resource $serviceResources[0].Definition -ParameterName $binding.Parameter
}
if (@($standardResources | Where-Object { $_.Type -ieq 'Microsoft.ManagedIdentity/userAssignedIdentities' -or
        $_.Type -ieq 'Microsoft.CognitiveServices/accounts/deployments' -or
        $_.Type -ieq 'Microsoft.Insights/components' -or $_.Type -ieq 'Microsoft.OperationalInsights/workspaces' }).Count -ne 0) {
    throw 'The MCP-only Standard template must not create identities, models, or Application Insights resources.'
}
$principalParameter = $standard['parameters']['sharedProjectPrincipalId']
if ($principalParameter['type'] -cne 'string' -or $principalParameter['minLength'] -ne 36 -or
    $principalParameter['maxLength'] -ne 36 -or $principalParameter.Contains('defaultValue')) {
    throw 'The shared project principal must be a required, GUID-length string parameter.'
}
$nativeGrants = @($standardResources | Where-Object { $_.Type -ieq 'Microsoft.DocumentDB/databaseAccounts/sqlRoleAssignments' })
if ($nativeGrants.Count -ne 1) { throw 'The Standard bundle must retain its per-account Cosmos native data grant.' }
$nativeGrant = $nativeGrants[0].Definition
$nativeRoleDefinition = [string] $nativeGrant['properties']['roleDefinitionId']
# The compiler may retain the shared role-definition expression as an ARM variable.
if ($nativeRoleDefinition -ceq '[variables(''cosmosDataContributorRoleDefinitionId'')]') {
    $nativeRoleDefinition = [string] $standard['variables']['cosmosDataContributorRoleDefinitionId']
}
if ($nativeRoleDefinition -notmatch '00000000-0000-0000-0000-000000000002' -or
    [string] $nativeGrant['properties']['scope'] -notmatch '/dbs/enterprise_memory' -or
    $nativeGrant['properties']['principalId'] -cne $standard['outputs']['projectPrincipalId']['value'] -or
    ($nativeGrant['dependsOn'] -join ' ') -notmatch 'projectCapabilityHost|Microsoft\.CognitiveServices/accounts/projects/capabilityHosts') {
    throw 'Cosmos SQL Data Contributor must target enterprise_memory for the shared project principal after its capability host.'
}
$connections = @($standardResources | Where-Object { $_.Type -ieq 'Microsoft.CognitiveServices/accounts/projects/connections' })
$accountHosts = @($standardResources | Where-Object { $_.Type -ieq 'Microsoft.CognitiveServices/accounts/capabilityHosts' })
$projectHosts = @($standardResources | Where-Object { $_.Type -ieq 'Microsoft.CognitiveServices/accounts/projects/capabilityHosts' })
if ($connections.Count -ne 3 -or @($connections | Where-Object { $_.Definition['properties']['authType'] -cne 'AAD' }).Count -ne 0 -or
    $accountHosts.Count -ne 1 -or $projectHosts.Count -ne 1) {
    throw 'The Standard bundle must retain three AAD connections and both capability hosts.'
}

if ($sample['parameters']['mcpPat']['type'] -ine 'secureString') {
    throw 'The MCP PAT must compile to an ARM secureString parameter.'
}
# Planning reads these names from the Bicep text; they must match what the compiled template really outputs.
$compiledNames = @($sample['outputs']['environment']['value'].Keys | Sort-Object)
$planNames = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra 'sample-resources.bicep') | Sort-Object)
if (($compiledNames -join ',') -cne ($planNames -join ',')) {
    throw 'The environment output names read from the Bicep text differ from the compiled template.'
}
if (@($compiledNames | Where-Object { @($_.Split('_') | Where-Object { $_ -in @('PAT', 'SECRET', 'KEY', 'TOKEN', 'PASSWORD', 'CREDENTIAL', 'CREDENTIALS') }).Count -gt 0 }).Count -gt 0) {
    throw 'The environment output must not contain secret-looking names; its values become pytest command-line options.'
}
$models = @($sampleResources | Where-Object { $_.Type -ieq 'Microsoft.CognitiveServices/accounts/deployments' })
if ($models.Count -ne 1 -or $sample['parameters'].Contains('validationModel') -or
    $sample['parameters'].Contains('runnerPrincipalId') -or
    $sample['outputs']['environment']['value'].Contains('LLM_VALIDATION_PROJECT_ENDPOINT') -or
    ($sample['outputs'] | ConvertTo-Json -Depth 100 -Compress) -match 'mcpPat|MCP_GITHUB_PAT') {
    throw 'Sample resources must contain one model, no runner IAM parameter, and no secret or validation endpoint output.'
}
Write-Host 'Three worker templates compiled; shared identities, zero worker ARM IAM, native Cosmos grant, and secure single-model MCP contract verified.'

$originalPat = [Environment]::GetEnvironmentVariable('MCP_GITHUB_PAT')
try {
    $env:MCP_GITHUB_PAT = ''
    $compiledParameters = Invoke-BicepCompilation -Path (Join-Path $infra 'sample-resources.bicepparam') -Parameters
    # CLI versions may return either the parameter object or a parametersJson wrapper.
    if ($compiledParameters.Contains('parametersJson')) {
        try {
            $compiledParameters = $compiledParameters['parametersJson'] | ConvertFrom-Json -AsHashtable -ErrorAction Stop
        } catch {
            throw 'Bicep returned invalid protected parameter JSON; output suppressed.'
        }
    }
    if ($compiledParameters['parameters'] -isnot [System.Collections.IDictionary] -or
        $compiledParameters['parameters'].Count -ne 1 -or
        -not $compiledParameters['parameters'].Contains('mcpPat') -or
        $compiledParameters['parameters']['mcpPat']['value'] -cne '') {
        throw 'Bicep parameter compilation must contain only an empty PAT; provisioning metadata must be passed directly.'
    }
} finally {
    [Environment]::SetEnvironmentVariable('MCP_GITHUB_PAT', $originalPat)
    $compiledParameters = $null
}
Write-Host 'Secret-only Bicep parameter file compiled with an empty PAT; no provisioning metadata comes from environment variables.'

$functionTemplate = Invoke-BicepCompilation -Path (Join-Path $infra 'function-app.bicep')
$functionResources = @(Get-ArmResources -Template $functionTemplate)
Assert-NoArmRoleAssignments -Resources $functionResources
$functionResourceTypes = @('Microsoft.Web/serverfarms', 'Microsoft.Web/sites', 'Microsoft.Web/sites/config',
    'Microsoft.Storage/storageAccounts/queueServices/queues')
if (@($functionResources | Where-Object { $_.Type -cnotin $functionResourceTypes }).Count -ne 0) {
    throw 'Function infrastructure must reuse existing storage and identities, and create only its plan, app, settings, and queues.'
}
foreach ($resourceType in $functionResourceTypes) {
    if (@($functionResources | Where-Object { $_.Type -ceq $resourceType }).Count -ne 1) {
        throw "Function infrastructure must contain exactly one '$resourceType' resource declaration."
    }
}
if ($functionTemplate['parameters']['planSku']['defaultValue'] -cne 'EP1' -or
    $functionTemplate['parameters']['runtimeVersion']['defaultValue'] -cne '3.11' -or
    $functionTemplate['parameters']['inputQueueName']['defaultValue'] -cne 'weather-input-queue' -or
    $functionTemplate['parameters']['outputQueueName']['defaultValue'] -cne 'weather-output-queue' -or
    $functionTemplate['parameters']['location'].Contains('defaultValue') -or
    $functionTemplate['parameters']['storageAccountName'].Contains('defaultValue') -or
    $functionTemplate['parameters']['sharedFunctionIdentityResourceId'].Contains('defaultValue')) {
    throw 'Function infrastructure must preserve reference defaults and require explicit region, storage, and shared identity inputs.'
}
$functionSite = @($functionResources | Where-Object { $_.Type -ceq 'Microsoft.Web/sites' })[0].Definition
Assert-SharedIdentity -Resource $functionSite -ParameterName 'sharedFunctionIdentityResourceId'
if ($functionSite['properties']['httpsOnly'] -ne $true -or
    $functionSite['properties']['siteConfig']['linuxFxVersion'] -notmatch 'Python\|' -or
    $functionSite['properties']['siteConfig']['minTlsVersion'] -cne '1.2' -or
    $functionSite['properties']['siteConfig']['ftpsState'] -cne 'Disabled') {
    throw 'The Function App must use its single existing UAMI, Linux Python runtime, HTTPS, and disabled FTP.'
}
$functionSettings = @($functionResources | Where-Object { $_.Type -ceq 'Microsoft.Web/sites/config' })[0].Definition
if ($functionSettings['properties'] -isnot [System.Collections.IDictionary]) {
    throw 'Fresh Function App settings must be declared directly, without reading the appsettings resource being deployed.'
}
$settingsJson = $functionSettings['properties'] | ConvertTo-Json -Depth 20 -Compress
foreach ($setting in @('AzureWebJobsStorage__accountName', 'AzureWebJobsStorage__credential',
        'AzureWebJobsStorage__clientId', 'FUNCTIONS_EXTENSION_VERSION', 'FUNCTIONS_WORKER_RUNTIME',
    'SCM_DO_BUILD_DURING_DEPLOYMENT', 'ENABLE_ORYX_BUILD', 'STORAGE_INPUT_QUEUE_NAME', 'STORAGE_OUTPUT_QUEUE_NAME',
        'STORAGE_CONNECTION__queueServiceUri', 'STORAGE_CONNECTION__credential', 'STORAGE_CONNECTION__clientId')) {
    if ($settingsJson -notmatch [regex]::Escape($setting)) { throw "Missing Function App setting '$setting'." }
}
if ($settingsJson -notmatch 'managedidentity' -or $settingsJson -notmatch '~4' -or
    $settingsJson -match '(?i)\blist\w*\s*\(') {
    throw 'Function settings must use managed identity and host v4 without a circular appsettings list operation.'
}
$functionNames = @($functionTemplate['outputs']['environment']['value'].Keys | Sort-Object)
$expectedFunctionNames = @('FUNCTION_APP_NAME', 'FUNCTION_APP_URL', 'STORAGE_INPUT_QUEUE_NAME',
    'STORAGE_OUTPUT_QUEUE_NAME', 'STORAGE_QUEUE_SERVICE_ENDPOINT' | Sort-Object)
$functionPlanNames = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra 'function-app.bicep') | Sort-Object)
if (($functionNames -join ',') -cne ($expectedFunctionNames -join ',') -or
    ($functionNames -join ',') -cne ($functionPlanNames -join ',') -or
    ($functionTemplate | ConvertTo-Json -Depth 100 -Compress) -match 'listKeys|FUNCTION_APP_KEY|connectionString') {
    throw 'Function outputs must contain only the five non-secret sample bindings, without storage keys or function keys.'
}
Write-Host 'Standalone Function App template compiled; reference defaults, shared identity, keyless settings, and non-secret outputs verified.'

# The root is the extensibility boundary: modules and bindings must stay in sync.
$bundle = Invoke-BicepCompilation -Path (Join-Path $infra 'main.bicep')
$bundleResources = @(Get-ArmResources -Template $bundle)
Assert-NoArmRoleAssignments -Resources $bundleResources
$declaredNames = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra 'main.bicep') | Sort-Object)
$compiledNames = @($bundle['outputs']['environment']['value'].Keys | Sort-Object)
if (($declaredNames -join ',') -cne ($compiledNames -join ',')) {
    throw 'The root environment contract must use explicit keys discoverable by offline planning.'
}
foreach ($resource in $bundleResources) {
    if ($resource.Type -ieq 'Microsoft.Resources/deployments' -and $resource.Definition.Contains('condition')) {
        throw 'Resource bundle modules must be unconditional; test selection never chooses infrastructure.'
    }
}
Write-Host 'Complete resource bundle compiled; unconditional modules, environment contract and zero worker IAM verified.'

# Optional, separate provenance check. The parent downloader remains responsible
# for fetching the original 14 pinned files; this checker never downloads or patches them.
if (-not [string]::IsNullOrWhiteSpace($StandardTemplatePath)) {
    if ((Split-Path -Leaf $StandardTemplatePath) -cne 'main.bicep') { throw 'The official reference must be the pinned main.bicep.' }
    $sourceLock = Get-Content -LiteralPath (Join-Path $infra 'standard-setup.lock.json') -Raw | ConvertFrom-Json -AsHashtable
    if ($sourceLock['repository'] -cne 'microsoft-foundry/foundry-samples' -or
        $sourceLock['commit'] -cne 'fbbe89b701c758e871922adaceea0ac0e4dae40f' -or $sourceLock['files'].Count -ne 14) {
        throw 'Unexpected official Standard source pin.'
    }
    $officialRoot = Split-Path -Parent ([IO.Path]::GetFullPath($StandardTemplatePath))
    foreach ($entry in $sourceLock['files'].GetEnumerator()) {
        if ($entry.Key -notmatch '^(main\.bicep|modules-standard/[a-z-]+\.bicep)$' -or $entry.Value -notmatch '^[a-f0-9]{64}$') {
            throw 'Invalid official Bicep source path or hash.'
        }
        $bytes = [IO.File]::ReadAllBytes((Join-Path $officialRoot $entry.Key))
        $hash = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($bytes)).ToLowerInvariant()
        if ($hash -cne $entry.Value) { throw 'Official Bicep source hash mismatch; no source was changed.' }
    }
    $null = Invoke-BicepCompilation -Path $StandardTemplatePath
    Write-Host 'All 14 unchanged pinned official sources verified and compiled separately; bootstrap IAM remains allowed only outside worker templates.'
}