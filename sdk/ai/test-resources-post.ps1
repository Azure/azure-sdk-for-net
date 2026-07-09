#!/usr/bin/env pwsh
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
Post-deployment bootstrap for sdk/ai live tests.

.DESCRIPTION
Invoked automatically by eng/common/TestResources/New-TestResources.ps1 after the
ARM deployment in test-resources.json completes. Creates the self-provisionable
Foundry data-plane objects that the Azure.AI.Extensions.OpenAI, Azure.AI.Projects,
and Azure.AI.Projects.Agents live tests consume, and exports their ids/names as
environment (and, under CI, pipeline) variables.

Objects created (Wave 1 - core self-provisionable):
  - An uploaded file          -> OPENAI_FILE_ID
  - A vector store            -> OPENAI_VECTOR_STORE_ID
  - A conversation            -> KNOWN_CONVERSATION_ID
  - A declarative agent       -> FOUNDRY_AGENT_NAME / FOUNDRY_AGENT_ID
  - An AI Search index        -> AI_SEARCH_INDEX_NAME (against the ARM-provisioned
                                 search service; AI_SEARCH_CONNECTION_NAME comes
                                 from the ARM deployment output)

The ARM template already exports FOUNDRY_PROJECT_ENDPOINT and the model deployment
names; this script depends on those deployment outputs.

Data-plane object creation is best-effort and guarded: a failure creating any one
object logs a warning and leaves its variable unset so that only the tests which
require that object are skipped, rather than failing the whole deployment.

Out of scope (Wave 1) - these require external/manual resources and are expected
to be supplied out-of-band via the pipeline variable group or a local .env; the
tests that need them read them as optional variables and skip when absent:
  - Grounding/search connections: BING_CONNECTION_(NAME|ID),
    CUSTOM_BING_CONNECTION_(NAME|ID), BING_CUSTOM_SEARCH_INSTANCE_NAME.
  - Data connections: FABRIC_CONNECTION_ID, FABRIC_IQ_CONNECTION_ID,
    SHAREPOINT_CONNECTION_ID, WORKIQ_CONNECTION_ID, PLAYWRIGHT_CONNECTION_ID,
    MCP_PROJECT_CONNECTION_NAME, OPENAPI_PROJECT_CONNECTION_(NAME|ID),
    A2A_CONNECTION_ID / REMOTE_A2A_CONNECTION_ID / A2A_BASE_URI,
    STORAGE_CONNECTION_(NAME|TYPE), AOAI_CONNECTION_NAME.
  - Hosted-agent container infra: AGENT_DOCKER_IMAGE,
    FOUNDRY_AGENT_CONTAINER_IMAGE, CONTAINER_APP_RESOURCE_ID,
    HOSTED_AGENT_NAME / HOSTED_AGENT_VERSION, INGRESS_SUBDOMAIN_SUFFIX,
    PUBLISHED_ENDPOINT.
  - External OpenAI parity: OPENAI_API_KEY, MODEL_ENDPOINT, MODEL_API_KEY.
  - Fine-tuning: FINE_TUNING_* (requires a pre-existing completed job).
  - Telemetry backends: APPLICATIONINSIGHTS_CONNECTION_STRING /
    APPLICATIONINSIGHTS_RESOURCE_ID, STORAGE_QUEUE_URI (candidates for a later
    ARM wave).
#>
param(
    [Parameter()]
    [hashtable] $DeploymentOutputs,

    [Parameter()]
    [string] $ResourceGroupName,

    [Parameter()]
    [switch] $CI,

    # Swallow any additional named/positional arguments splatted from
    # New-TestResources.ps1 (@PSBoundParameters) that this script does not use.
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

$ErrorActionPreference = 'Stop'

# The scope used by the Foundry data-plane clients (see AIProjectClient _flows).
$AiScope = 'https://ai.azure.com'

# The api-version used by the Foundry control-plane (agent) routes.
$AgentApiVersion = 'v1'

# Fixed, stable name so repeated deployments reuse the same logical agent.
$AgentName = 'sdk-test-agent'

function Get-DeploymentOutput {
    param([string] $Name)
    if ($null -eq $DeploymentOutputs) { return $null }
    if ($DeploymentOutputs.ContainsKey($Name)) {
        $value = $DeploymentOutputs[$Name]
        # Deployment outputs may be raw strings or objects with a 'value' member.
        if ($value -is [hashtable] -and $value.ContainsKey('value')) { return $value['value'] }
        if ($value.PSObject -and $value.PSObject.Properties['value']) { return $value.value }
        return $value
    }
    return $null
}

function Set-BootstrapVariable {
    param(
        [string] $Name,
        [string] $Value,
        [bool] $IsSecret = $false
    )
    if ([string]::IsNullOrEmpty($Value)) { return }

    # Make the value available to any subsequent step in this process/session.
    Set-Item -Path "env:$Name" -Value $Value

    if ($CI) {
        $secretFlag = if ($IsSecret) { 'true' } else { 'false' }
        Write-Host "##vso[task.setvariable variable=$Name;issecret=$secretFlag;]$Value"
    }
    else {
        Write-Host "Set bootstrap variable '$Name'"
    }
}

function Get-AiAccessToken {
    $token = Get-AzAccessToken -ResourceUrl $AiScope
    # Az 12+ returns Token as a SecureString; earlier versions return a plaintext string.
    if ($token.Token -is [System.Security.SecureString]) {
        return [System.Net.NetworkCredential]::new('', $token.Token).Password
    }
    return $token.Token
}

$projectEndpoint = Get-DeploymentOutput -Name 'FOUNDRY_PROJECT_ENDPOINT'
$modelName = Get-DeploymentOutput -Name 'FOUNDRY_MODEL_NAME'

if ([string]::IsNullOrEmpty($projectEndpoint)) {
    Write-Warning "FOUNDRY_PROJECT_ENDPOINT deployment output is missing; skipping data-plane bootstrap."
    return
}

$baseUri = $projectEndpoint.TrimEnd('/')
$openAiUri = "$baseUri/openai/v1"

$accessToken = Get-AiAccessToken
$authHeader = @{ Authorization = "Bearer $accessToken" }

Write-Host "Bootstrapping Foundry data-plane objects against '$projectEndpoint'"

# --- Uploaded file -> OPENAI_FILE_ID -----------------------------------------
$fileId = $null
try {
    # Use a supported text extension (.txt): the files/vector-store surface rejects
    # unknown extensions such as the .tmp produced by New-TemporaryFile with a 400.
    $fixture = Join-Path ([System.IO.Path]::GetTempPath()) ("sdk-test-fixture-{0}.txt" -f ([guid]::NewGuid().ToString('N')))
    @(
        'Contoso product catalog (test fixture).',
        'Widget A: a small blue widget used for SDK live testing.',
        'Widget B: a large red widget used for SDK live testing.'
    ) | Set-Content -Path $fixture -Encoding utf8

    # Do not set a per-part Content-Type for the file: doing so can cause vector
    # store indexing to fail for some formats (see AddAzureFinetuningParityPolicy).
    $fileResponse = Invoke-RestMethod -Method Post -Uri "$openAiUri/files" `
        -Headers $authHeader `
        -Form @{ purpose = 'assistants'; file = Get-Item -Path $fixture }
    $fileId = $fileResponse.id
    Set-BootstrapVariable -Name 'OPENAI_FILE_ID' -Value $fileId
}
catch {
    Write-Warning "Failed to upload bootstrap file: $($_.Exception.Message)"
}
finally {
    if ($fixture -and (Test-Path $fixture)) { Remove-Item -Path $fixture -Force -ErrorAction SilentlyContinue }
}

# --- Vector store -> OPENAI_VECTOR_STORE_ID ----------------------------------
try {
    $vectorStoreBody = @{ name = 'sdk-test-vector-store' }
    if ($fileId) { $vectorStoreBody['file_ids'] = @($fileId) }

    $vectorStoreResponse = Invoke-RestMethod -Method Post -Uri "$openAiUri/vector_stores" `
        -Headers $authHeader `
        -ContentType 'application/json' `
        -Body ($vectorStoreBody | ConvertTo-Json -Depth 5)
    Set-BootstrapVariable -Name 'OPENAI_VECTOR_STORE_ID' -Value $vectorStoreResponse.id
}
catch {
    Write-Warning "Failed to create bootstrap vector store: $($_.Exception.Message)"
}

# --- Conversation -> KNOWN_CONVERSATION_ID -----------------------------------
try {
    $conversationResponse = Invoke-RestMethod -Method Post -Uri "$openAiUri/conversations" `
        -Headers $authHeader `
        -ContentType 'application/json' `
        -Body '{}'
    Set-BootstrapVariable -Name 'KNOWN_CONVERSATION_ID' -Value $conversationResponse.id
}
catch {
    Write-Warning "Failed to create bootstrap conversation: $($_.Exception.Message)"
}

# --- Declarative agent -> FOUNDRY_AGENT_NAME / FOUNDRY_AGENT_ID ---------------
if ([string]::IsNullOrEmpty($modelName)) {
    Write-Warning "FOUNDRY_MODEL_NAME deployment output is missing; skipping agent bootstrap."
}
else {
    try {
        $agentBody = @{
            definition = @{
                kind         = 'prompt'
                model        = $modelName
                instructions = 'You are a helpful assistant used for Azure SDK live testing.'
            }
        }
        $agentResponse = Invoke-RestMethod -Method Post `
            -Uri "$baseUri/agents/$AgentName/versions?api-version=$AgentApiVersion" `
            -Headers ($authHeader + @{ 'Foundry-Features' = 'MemoryStores=V1Preview,ContainerAgents=V1Preview,WorkflowAgents=V1Preview,Evaluations=V1Preview,Schedules=V1Preview,RedTeams=V1Preview,AgentEndpoints=V1Preview,Skills=V1Preview,Insights=V1Preview,DataGenerationJobs=V1Preview,Models=V1Preview,AgentsOptimization=V1Preview,Routines=V1Preview,ExternalAgents=V1Preview' }) `
            -ContentType 'application/json' `
            -Body ($agentBody | ConvertTo-Json -Depth 6)

        $agentId = if ($agentResponse.id) { $agentResponse.id } else { $AgentName }
        Set-BootstrapVariable -Name 'FOUNDRY_AGENT_NAME' -Value $AgentName
        Set-BootstrapVariable -Name 'FOUNDRY_AGENT_ID' -Value $agentId
    }
    catch {
        Write-Warning "Failed to create bootstrap agent: $($_.Exception.Message)"
    }
}

# --- AI Search index -> AI_SEARCH_INDEX_NAME ---------------------------------
$searchServiceName = Get-DeploymentOutput -Name 'AI_SEARCH_SERVICE_NAME'
$searchIndexName = 'sample_index'
if ([string]::IsNullOrEmpty($searchServiceName)) {
    Write-Warning "AI_SEARCH_SERVICE_NAME deployment output is missing; skipping AI Search bootstrap."
}
else {
    try {
        $mgmtToken = (Get-AzAccessToken -ResourceUrl 'https://management.azure.com').Token
        if ($mgmtToken -is [System.Security.SecureString]) {
            $mgmtToken = [System.Net.NetworkCredential]::new('', $mgmtToken).Password
        }
        $subId = (Get-AzContext).Subscription.Id
        $keysUri = "https://management.azure.com/subscriptions/$subId/resourceGroups/$ResourceGroupName" +
                   "/providers/Microsoft.Search/searchServices/$searchServiceName/listAdminKeys?api-version=2024-06-01-preview"
        $adminKey = (Invoke-RestMethod -Method Post -Uri $keysUri -Headers @{ Authorization = "Bearer $mgmtToken" }).primaryKey

        $searchBase = "https://$searchServiceName.search.windows.net"
        $searchHeaders = @{ 'api-key' = $adminKey }
        $searchApi = '2024-07-01'

        # Index schema (QueryType.Simple: keyword only, no vectors required).
        $indexSchema = @{
            name   = $searchIndexName
            fields = @(
                @{ name = 'id'; type = 'Edm.String'; key = $true; filterable = $true },
                @{ name = 'content'; type = 'Edm.String'; searchable = $true },
                @{ name = 'title'; type = 'Edm.String'; searchable = $true; retrievable = $true },
                @{ name = 'url'; type = 'Edm.String'; retrievable = $true },
                @{ name = 'category'; type = 'Edm.String'; filterable = $true; facetable = $true }
            )
        }
        Invoke-RestMethod -Method Put -Uri "$searchBase/indexes/$searchIndexName`?api-version=$searchApi" `
            -Headers $searchHeaders -ContentType 'application/json' `
            -Body ($indexSchema | ConvertTo-Json -Depth 6) | Out-Null

        # Documents that satisfy the sample query + "category eq 'sleeping bag'" filter.
        $docs = @{ value = @(
            @{ '@search.action' = 'mergeOrUpload'; id = '1'; category = 'sleeping bag';
               title = 'CozyNights Sleeping Bag';
               url = 'https://example.com/products/cozynights-sleeping-bag';
               content = 'The CozyNights sleeping bag is a lightweight 3-season bag rated for a temperature of 15 degrees Fahrenheit (-9 Celsius). It weighs 2.5 pounds and packs down small for backpacking.' },
            @{ '@search.action' = 'mergeOrUpload'; id = '2'; category = 'sleeping bag';
               title = 'MountainDream Sleeping Bag';
               url = 'https://example.com/products/mountaindream-sleeping-bag';
               content = 'The MountainDream sleeping bag is a winter bag rated to 0 degrees Fahrenheit (-18 Celsius).' },
            @{ '@search.action' = 'mergeOrUpload'; id = '3'; category = 'tent';
               title = 'TrailBlaze 2-Person Tent';
               url = 'https://example.com/products/trailblaze-tent';
               content = 'The TrailBlaze tent is a two-person, three-season backpacking tent.' }
        ) }
        Invoke-RestMethod -Method Post -Uri "$searchBase/indexes/$searchIndexName/docs/index`?api-version=$searchApi" `
            -Headers $searchHeaders -ContentType 'application/json' `
            -Body ($docs | ConvertTo-Json -Depth 6) | Out-Null

        Set-BootstrapVariable -Name 'AI_SEARCH_INDEX_NAME' -Value $searchIndexName
    }
    catch {
        Write-Warning "Failed to bootstrap AI Search index: $($_.Exception.Message)"
    }
}

Write-Host "Foundry data-plane bootstrap complete."
