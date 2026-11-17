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
$originalOpenApiKey = [Environment]::GetEnvironmentVariable('PROJ_CONN_OPEN_API_KEY')
try {
    $env:MCP_GITHUB_PAT = ''
    $env:PROJ_CONN_OPEN_API_KEY = ''
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
        $compiledParameters['parameters'].Count -ne 2 -or
        -not $compiledParameters['parameters'].Contains('mcpPat') -or
        -not $compiledParameters['parameters'].Contains('openApiKey') -or
        $compiledParameters['parameters']['mcpPat']['value'] -cne '' -or
        $compiledParameters['parameters']['openApiKey']['value'] -cne '') {
        throw 'Bicep parameter compilation must contain only empty PAT and OpenAPI secrets; provisioning metadata must be passed directly.'
    }
} finally {
    [Environment]::SetEnvironmentVariable('MCP_GITHUB_PAT', $originalPat)
    [Environment]::SetEnvironmentVariable('PROJ_CONN_OPEN_API_KEY', $originalOpenApiKey)
    $compiledParameters = $null
}
Write-Host 'Secret-only Bicep parameter file compiled with empty PAT and OpenAPI secrets; no provisioning metadata comes from environment variables.'

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

$searchTemplate = Invoke-BicepCompilation -Path (Join-Path $infra 'ai-search.bicep')
$searchResources = @(Get-ArmResources -Template $searchTemplate)
Assert-NoArmRoleAssignments -Resources $searchResources
$expectedSearchTypes = @('Microsoft.Storage/storageAccounts/blobServices/containers',
    'Microsoft.CognitiveServices/accounts/deployments', 'Microsoft.Resources/deploymentScripts')
foreach ($type in $expectedSearchTypes) {
    if (@($searchResources | Where-Object Type -ceq $type).Count -ne 1) {
        throw "Search indexing must declare exactly one '$type' and reuse the Standard resources."
    }
}
if ($searchResources.Count -ne $expectedSearchTypes.Count) {
    throw 'Search indexing must not create additional accounts, Search services, identities or IAM grants.'
}
$searchScript = @($searchResources | Where-Object Type -ceq 'Microsoft.Resources/deploymentScripts')[0].Definition
Assert-SharedIdentity -Resource $searchScript -ParameterName 'sharedSearchIdentityResourceId'
if ($searchScript['properties']['cleanupPreference'] -cne 'Always' -or
    $searchScript['properties']['timeout'] -cne 'PT30M' -or
    @($searchScript['dependsOn']).Count -ne 2) {
    throw 'Search data-plane deployment must wait for its container and model and clean up supporting resources.'
}
$embedding = @($searchResources | Where-Object Type -ceq 'Microsoft.CognitiveServices/accounts/deployments')[0].Definition
if ($embedding['properties']['model']['name'] -cne 'text-embedding-3-small' -or
    $embedding['properties']['model']['version'] -cne '1' -or
    $embedding['sku']['name'] -cne 'GlobalStandard' -or $embedding['sku']['capacity'] -ne 10 -or
    $searchTemplate['variables']['dimensions'] -ne 1536) {
    throw 'Search index dimensions must match the pinned embedding model deployment.'
}
$service = @($standardResources | Where-Object Type -ceq 'Microsoft.Search/searchServices')[0].Definition
if ($service['properties']['semanticSearch'] -cne 'free') {
    throw 'The Search sample index requires the existing service semantic free tier.'
}
$scriptContent = [IO.File]::ReadAllText((Join-Path $infra 'search-indexing.py'))
$loadedScripts = @($searchTemplate['variables'].GetEnumerator() |
    Where-Object { $_.Value -is [string] -and $_.Value -ceq $scriptContent })
if ($loadedScripts.Count -ne 1 -or
    -not ([string] $searchScript['properties']['scriptContent']).Contains("variables('$($loadedScripts[0].Key)')") -or
    $scriptContent -notmatch '2026-04-01' -or $scriptContent -notmatch 'wait_for_indexer' -or
    $scriptContent -match '\baz\s+role\s+assignment|\blistKeys\b|\blistAdminKeys\b') {
    throw 'Search data-plane execution must wait for indexers and use tokens rather than IAM writes or keys.'
}
$searchOutputNames = @($searchTemplate['outputs']['environment']['value'].Keys | Sort-Object)
$expectedSearchNames = @('AZURE_AI_SEARCH_ENDPOINT', 'AI_SEARCH_PROJECT_CONNECTION_ID', 'AI_SEARCH_INDEX_NAME',
    'AZURE_AI_EMBED_DEPLOYMENT_NAME', 'AZURE_AI_EMBED_DIMENSIONS', 'AZURE_BLOB_CONTAINER_NAME',
    'AI_SEARCH_USER_INPUT' | Sort-Object)
$searchPlanNames = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra 'ai-search.bicep') | Sort-Object)
if (($searchOutputNames -join ',') -cne ($expectedSearchNames -join ',') -or
    ($searchOutputNames -join ',') -cne ($searchPlanNames -join ',')) {
    throw 'Search must expose only its discoverable, non-secret sample bindings.'
}

# The permanent identities and grants remain owned by the Python bootstrap.
Write-Host 'Search module compiled; keyless execution, embedding dimensions and non-secret outputs verified.'

$browserTemplate = Invoke-BicepCompilation -Path (Join-Path $infra 'browser-automation.bicep')
$browserResources = @(Get-ArmResources -Template $browserTemplate)
Assert-NoArmRoleAssignments -Resources $browserResources
$workspaces = @($browserResources | Where-Object Type -ceq 'Microsoft.LoadTestService/playwrightWorkspaces')
$browserConnections = @($browserResources | Where-Object Type -ceq 'Microsoft.CognitiveServices/accounts/projects/connections')
if ($browserResources.Count -ne 2 -or $workspaces.Count -ne 1 -or $browserConnections.Count -ne 1) {
    throw 'Browser automation must create only a native workspace and project connection, with no identities or scripts.'
}
$workspace = $workspaces[0].Definition
if ($workspace['apiVersion'] -cne '2025-09-01' -or
    $workspace['location'] -cne "[parameters('location')]" -or
    $workspace['properties']['localAuth'] -cne 'Disabled' -or
    $workspace['properties']['regionalAffinity'] -cne 'Enabled' -or
    $browserTemplate['parameters']['workspaceName']['minLength'] -ne 3 -or
    $browserTemplate['parameters']['workspaceName']['maxLength'] -ne 24) {
    throw 'Browser workspace must use the admitted region, valid name bounds, regional affinity and no local authentication.'
}
$browserConnection = $browserConnections[0].Definition
$browserProperties = $browserConnection['properties']
$workspaceId = "[resourceId('Microsoft.LoadTestService/playwrightWorkspaces', parameters('workspaceName'))]"
$expectedTarget = "[format('{0}/mcp', replace(reference($($workspaceId.Trim('[', ']')), '2025-09-01').dataplaneUri, '.api.playwright.microsoft.com', '.mcp.playwright.microsoft.com'))]"
if ($browserConnection['apiVersion'] -cne '2025-04-01-preview' -or
    $browserProperties['category'] -cne 'PlaywrightWorkspace' -or
    $browserProperties['authType'] -cne 'ProjectManagedIdentity' -or
    $browserProperties['audience'] -cne 'https://mcp.playwright.microsoft.com' -or
    $browserProperties['isSharedToAll'] -ne $true -or
    -not $browserProperties.Contains('credentials') -or $null -ne $browserProperties['credentials'] -or
    $browserProperties['metadata']['resourceId'] -cne $workspaceId -or
    $browserProperties['target'] -cne $expectedTarget -or
    @($browserConnection['dependsOn']).Count -ne 1 -or
    @($browserConnection['dependsOn'])[0] -cne $workspaceId) {
    throw 'Browser connection must wait for its workspace, derive its MCP target and use only project managed-identity authentication.'
}
$browserOutputNames = @($browserTemplate['outputs']['environment']['value'].Keys | Sort-Object)
$expectedBrowserNames = @('BROWSER_AUTOMATION_PROJECT_CONNECTION_ID',
    'BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME', 'PLAYWRIGHT_SERVICE_RESOURCE_ID' | Sort-Object)
$browserPlanNames = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra 'browser-automation.bicep') | Sort-Object)
if (($browserOutputNames -join ',') -cne ($expectedBrowserNames -join ',') -or
    ($browserOutputNames -join ',') -cne ($browserPlanNames -join ',') -or
    ($browserTemplate | ConvertTo-Json -Depth 100 -Compress) -match 'listKeys|listAccessTokens|apiKey|sessionId|liveView') {
    throw 'Browser outputs must contain only discoverable ARM IDs and the connection name, never keys or session data.'
}
Write-Host 'Browser module compiled; native keyless workspace, project connection and non-secret outputs verified.'

$connectionModules = @(
    @{ File = 'bing-search.bicep'; Module = 'bing-search'; Connection = 'bing'; Category = 'GroundingWithBingSearch'
        Kind = 'Bing.Grounding'; Sku = 'G1'; MetadataType = 'bing_grounding'
        Names = @('BING_PROJECT_CONNECTION_ID', 'BING_PROJECT_CONNECTION_NAME') },
    @{ File = 'bing-custom-search.bicep'; Module = 'bing-custom-search'; Connection = 'bing-custom'; Category = 'GroundingWithCustomSearch'
        Kind = 'Bing.GroundingCustomSearch'; Sku = 'G2'; MetadataType = 'bing_custom_search'
        Names = @('BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID', 'BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME',
            'BING_CUSTOM_SEARCH_INSTANCE_NAME', 'BING_CUSTOM_USER_INPUT') },
    @{ File = 'openapi.bicep'; Module = 'openapi'; Connection = 'openapi'; Category = 'CustomKeys'
        Names = @('OPENAPI_PROJECT_CONNECTION_ID', 'OPENAPI_PROJECT_CONNECTION_NAME', 'TRIPADVISOR_PROJECT_CONNECTION_ID') }
)
foreach ($contract in $connectionModules) {
    $template = Invoke-BicepCompilation -Path (Join-Path $infra $contract.File)
    $resources = @(Get-ArmResources -Template $template)
    Assert-NoArmRoleAssignments -Resources $resources
    $connections = @($resources | Where-Object Type -ceq 'Microsoft.CognitiveServices/accounts/projects/connections')
    if ($connections.Count -ne 1) { throw 'Each Bing/OpenAPI module must create exactly one project connection.' }
    $connection = $connections[0].Definition
    $properties = $connection['properties']
    if ($connection['apiVersion'] -cne '2025-10-01-preview' -or
        $connection['name'] -cne "[format('{0}/{1}/{2}', parameters('accountName'), parameters('projectName'), '$($contract.Connection)')]" -or
        $properties['category'] -cne $contract.Category -or $properties['isSharedToAll'] -ne $false) {
        throw 'Bing/OpenAPI connection API, name, category and sharing must match the pool scripts.'
    }
    $environment = $template['outputs']['environment']['value']
    $declared = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra $contract.File) | Sort-Object)
    if ((@($environment.Keys | Sort-Object) -join ',') -cne (@($contract.Names | Sort-Object) -join ',') -or
        ($declared -join ',') -cne (@($contract.Names | Sort-Object) -join ',') -or
        ($environment | ConvertTo-Json -Depth 100 -Compress) -match 'listKeys|openApiKey|credentials') {
        throw 'Bing/OpenAPI outputs must contain only their declared non-secret, discoverable sample bindings.'
    }
    if ($contract.Module -eq 'openapi') {
        if ($resources.Count -ne 1 -or $template['parameters']['openApiKey']['type'] -ine 'secureString' -or
            $template['parameters']['openApiKey']['minLength'] -ne 1 -or
            $template['parameters']['openApiKey'].Contains('defaultValue') -or
            $properties['authType'] -cne 'CustomKeys' -or $properties['target'] -cne '_' -or
            $properties['credentials']['keys']['key'] -cne "[parameters('openApiKey')]" -or
            $properties['metadata']['type'] -cne 'openapi' -or
            $environment['TRIPADVISOR_PROJECT_CONNECTION_ID'] -cne $environment['OPENAPI_PROJECT_CONNECTION_ID']) {
            throw 'OpenAPI must require a secure external key, store it only in CustomKeys credentials and preserve its alias.'
        }
        continue
    }
    $accounts = @($resources | Where-Object Type -ceq 'Microsoft.Bing/accounts')
    $custom = @($resources | Where-Object Type -ceq 'Microsoft.Bing/accounts/customSearchConfigurations')
    $isCustom = $contract.Module -eq 'bing-custom-search'
    if ($accounts.Count -ne 1 -or $custom.Count -ne [int] $isCustom -or $resources.Count -ne (2 + [int] $isCustom)) {
        throw 'Bing modules must declare only one account, one connection and the custom configuration when required.'
    }
    $account = $accounts[0].Definition
    $bingId = "resourceId('Microsoft.Bing/accounts', parameters('bingAccountName'))"
    if ($account['apiVersion'] -cne '2020-06-10' -or $account['location'] -cne 'global' -or
        $account['kind'] -cne $contract.Kind -or $account['sku']['name'] -cne $contract.Sku -or
        $account['properties']['statisticsEnabled'] -ne $false -or
        $properties['target'] -cne "[reference($bingId, '2020-06-10').endpoint]" -or
        $properties['authType'] -cne 'ApiKey' -or
        $properties['credentials']['key'] -cne "[listKeys($bingId, '2020-06-10').key1]" -or
        $properties['metadata']['ApiType'] -cne 'Azure' -or
        $properties['metadata']['ResourceId'] -cne "[$bingId]" -or
        $properties['metadata']['type'] -cne $contract.MetadataType -or
        "[$bingId]" -cnotin @($connection['dependsOn'])) {
        throw 'Bing connections must use the provisioned account endpoint and ARM-only key lookup with the pool SKU and metadata.'
    }
    if ($isCustom) {
        $configuration = $custom[0].Definition
        $expectedPages = @(
            'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/overview',
            'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/overview',
            'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/bing-grounding',
            'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/bing-custom-search'
        )
        $domains = @($configuration['properties']['allowedDomains'])
        if ($configuration['apiVersion'] -cne '2025-05-01-preview' -or
            $configuration['name'] -cne "[format('{0}/{1}', parameters('bingAccountName'), 'agentdoc')]" -or
            $domains.Count -ne 4 -or ($domains.domain -join ',') -cne ($expectedPages -join ',') -or
            @($domains | Where-Object { $_.includeSubPages -ne $false -or $_.boostLevel -cne 'Default' }).Count -ne 0 -or
            @($configuration['properties']['blockedDomains']).Count -ne 0 -or
            @($configuration['properties']['pinnedDomains']).Count -ne 0 -or
            $environment['BING_CUSTOM_SEARCH_INSTANCE_NAME'] -cne 'agentdoc' -or
            [string]::IsNullOrWhiteSpace($environment['BING_CUSTOM_USER_INPUT'])) {
            throw 'Custom Search must pin exactly the four approved pages without subpages, blocked/pinned domains or interactive input.'
        }
    }
}
Write-Host 'Bing and OpenAPI modules compiled; pool resource shapes, pinned custom pages and secret-only credentials verified.'

# The root is the extensibility boundary: modules and bindings must stay in sync.
$bundle = Invoke-BicepCompilation -Path (Join-Path $infra 'main.bicep')
$bundleResources = @(Get-ArmResources -Template $bundle)
Assert-NoArmRoleAssignments -Resources $bundleResources
$declaredNames = @(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $infra 'main.bicep') | Sort-Object)
$compiledNames = @($bundle['outputs']['environment']['value'].Keys | Sort-Object)
if ($bundle['parameters']['openApiKey']['type'] -ine 'secureString' -or
    $bundle['parameters']['openApiKey']['minLength'] -ne 1 -or
    $bundle['parameters']['openApiKey'].Contains('defaultValue')) {
    throw 'The root OpenAPI key must remain a required secureString without a default.'
}
if (($declaredNames -join ',') -cne ($compiledNames -join ',')) {
    throw 'The root environment contract must use explicit keys discoverable by offline planning.'
}
foreach ($resource in $bundleResources) {
    if ($resource.Type -ieq 'Microsoft.Resources/deployments' -and $resource.Definition.Contains('condition')) {
        throw 'Resource bundle modules must be unconditional; test selection never chooses infrastructure.'
    }
}
$searchModules = @($bundleResources | Where-Object {
    $_.Type -ieq 'Microsoft.Resources/deployments' -and $_.Definition['name'] -ceq 'ai-search'
})
if ($searchModules.Count -ne 1 -or
    "[resourceId('Microsoft.Resources/deployments', 'sample-resources')]" -cnotin
        @($searchModules[0].Definition['dependsOn'])) {
    throw 'Search embedding deployment must wait for the chat-model module to avoid concurrent Foundry account operations.'
}
$browserModules = @($bundleResources | Where-Object {
    $_.Type -ieq 'Microsoft.Resources/deployments' -and $_.Definition['name'] -ceq 'browser-automation'
})
if ($browserModules.Count -ne 1 -or
    @($browserModules[0].Definition['dependsOn']).Count -ne 1 -or
    @($browserModules[0].Definition['dependsOn'])[0] -cne
        "[resourceId('Microsoft.Resources/deployments', 'standard-setup')]" -or
    $browserModules[0].Definition['properties']['parameters']['workspaceName']['value'] -cne
        "[format('pw-{0}', uniqueString(resourceGroup().id, parameters('ownerToken')))]") {
    throw 'Browser provisioning must depend only on Standard setup and retain the full run-unique workspace-name hash.'
}
foreach ($name in $expectedBrowserNames) {
    if ($name -cnotin $compiledNames -or
        -not ([string] $bundle['outputs']['environment']['value'][$name]).Contains("'browser-automation'")) {
        throw 'Every browser environment binding must be exposed by the root from the browser module.'
    }
}
foreach ($contract in $connectionModules) {
    $modules = @($bundleResources | Where-Object {
        $_.Type -ceq 'Microsoft.Resources/deployments' -and $_.Definition['name'] -ceq $contract.Module
    })
    if ($modules.Count -ne 1 -or @($modules[0].Definition['dependsOn']).Count -ne 1 -or
        @($modules[0].Definition['dependsOn'])[0] -cne "[resourceId('Microsoft.Resources/deployments', 'standard-setup')]") {
        throw 'Bing and OpenAPI provisioning must depend only on Standard setup, not on model deployments or indexing.'
    }
    foreach ($name in $contract.Names) {
        if ($name -cnotin $compiledNames -or
            -not ([string] $bundle['outputs']['environment']['value'][$name]).Contains("'$($contract.Module)'")) {
            throw 'Every Bing/OpenAPI sample binding must be exposed by the root from its own module.'
        }
    }
    if ($contract.Module -eq 'openapi') {
        if ($modules[0].Definition['properties']['parameters']['openApiKey']['value'] -cne "[parameters('openApiKey')]") {
            throw 'The OpenAPI module must receive only the root secure parameter, not a literal key.'
        }
    } else {
        $prefix = $(if ($contract.Module -eq 'bing-search') { 'bing' } else { 'bing-custom' })
        if ($modules[0].Definition['properties']['parameters']['bingAccountName']['value'] -cne
            "[format('$prefix-{0}', uniqueString(resourceGroup().id, parameters('ownerToken')))]") {
            throw 'Bing accounts must retain their full run-unique name hash.'
        }
    }
}
Write-Host 'Complete resource bundle compiled; serialized models, independent connections, unconditional modules, environment contract and zero worker IAM verified.'

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