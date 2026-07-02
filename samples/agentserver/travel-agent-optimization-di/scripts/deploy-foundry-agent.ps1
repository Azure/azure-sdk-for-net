# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
#
# Deploys the TravelAgent sample to an existing Foundry hosted agent.
#
# Invoked by `azd up` / `azd deploy` via the hooks declared in ../azure.yaml.
# Steps:
#   1. dotnet publish (Release) -> ../publish
#   2. az acr build              -> push image to ACR
#   3. Resolve the pushed image digest
#   4. GET the current agent to preserve env vars / cpu / memory
#   5. POST a new agent version pointing at the new digest
#
# Required environment variables (set via `azd env set <name> <value>`):
#   AZURE_ACR_NAME, FOUNDRY_ENDPOINT, FOUNDRY_PROJECT, FOUNDRY_AGENT

[CmdletBinding()]
param(
    [string]$AcrName         = $env:AZURE_ACR_NAME,
    [string]$ImageName       = $(if ($env:AZURE_IMAGE_NAME)    { $env:AZURE_IMAGE_NAME }    else { 'travel-agent' }),
    [string]$ImageTag        = $(if ($env:AZURE_IMAGE_TAG)     { $env:AZURE_IMAGE_TAG }     else { 'latest' }),
    [string]$FoundryEndpoint = $env:FOUNDRY_ENDPOINT,
    [string]$FoundryProject  = $env:FOUNDRY_PROJECT,
    [string]$FoundryAgent    = $env:FOUNDRY_AGENT,
    [string]$ApiVersion      = '2025-11-15-preview',
    [string]$Description     = $(if ($env:VERSION_DESCRIPTION) { $env:VERSION_DESCRIPTION } else { "azd deploy at $(Get-Date -Format 'yyyy-MM-ddTHH:mm:ssZ')" })
)

$ErrorActionPreference = 'Stop'
$ProjectRoot = Split-Path -Parent $PSScriptRoot   # ./samples/TravelAgent/
$AzCli = (Get-Command az -ErrorAction SilentlyContinue).Source
if (-not $AzCli) { $AzCli = 'az' }

function Assert-Var($value, $name) {
    if (-not $value) { throw "Required environment variable $name is not set. Run: azd env set $name <value>" }
}
Assert-Var $AcrName         'AZURE_ACR_NAME'
Assert-Var $FoundryEndpoint 'FOUNDRY_ENDPOINT'
Assert-Var $FoundryProject  'FOUNDRY_PROJECT'
Assert-Var $FoundryAgent    'FOUNDRY_AGENT'

function Write-Step($msg) { Write-Host "`n=== $msg ===" -ForegroundColor Cyan }

Write-Step "1/5 dotnet publish"
Push-Location $ProjectRoot
try {
    # Sample is multi-targeted (net8.0 + net10.0); the Dockerfile uses the
    # net10.0 runtime image, so publish for net10.0 explicitly.
    dotnet publish -c Release -f net10.0 -o (Join-Path $ProjectRoot 'publish') --nologo
    if ($LASTEXITCODE -ne 0) { throw "dotnet publish failed" }
} finally { Pop-Location }

# Ensure agent_configs is alongside the published binaries (Dockerfile copies it
# from the build context, not from publish/, but the local-run path expects it
# next to the assembly too).
if (Test-Path (Join-Path $ProjectRoot '.agent_configs')) {
    Copy-Item -Recurse (Join-Path $ProjectRoot '.agent_configs') (Join-Path $ProjectRoot 'publish/.agent_configs') -Force
}

Write-Step "2/5 az acr build"
Push-Location $ProjectRoot
try {
    & $AzCli acr build --registry $AcrName --image "$($ImageName):$($ImageTag)" --file Dockerfile . --output none
    if ($LASTEXITCODE -ne 0) { throw "az acr build failed" }
} finally { Pop-Location }

Write-Step "3/5 Resolve image digest"
$manifestJson = & $AzCli acr repository show --name $AcrName --image "$($ImageName):$($ImageTag)" --output json
if ($LASTEXITCODE -ne 0) { throw "az acr repository show failed: $manifestJson" }
$digest = ($manifestJson | ConvertFrom-Json).digest
if (-not $digest) { throw "Could not resolve digest for $($ImageName):$($ImageTag)" }
$loginServer = (& $AzCli acr show --name $AcrName --query loginServer --output tsv).Trim()
$imageRef = "$loginServer/$ImageName@$digest"
Write-Host "Image: $imageRef" -ForegroundColor Green

Write-Step "4/5 GET current agent version (preserve env / cpu / memory)"
$tokenJson = & $AzCli account get-access-token --resource 'https://ai.azure.com' --output json
$accessToken = ($tokenJson | ConvertFrom-Json).accessToken
$headers = @{ Authorization = "Bearer $accessToken"; 'Content-Type' = 'application/json' }
$getUri = "$FoundryEndpoint/api/projects/$FoundryProject/agents/$($FoundryAgent)?api-version=$ApiVersion"
$current = Invoke-RestMethod -Method Get -Uri $getUri -Headers $headers
$prevDef = $current.versions.latest.definition
Write-Host "Previous version: $($current.versions.latest.version) ($($current.versions.latest.id))"
Write-Host "Previous image:   $($prevDef.image)"

Write-Step "5/5 POST new version"
$newDef = @{
    kind = 'hosted'
    image = $imageRef
    container_protocol_versions = $prevDef.container_protocol_versions
    cpu = $prevDef.cpu
    memory = $prevDef.memory
}
if ($prevDef.environment_variables) {
    $envHash = @{}
    foreach ($prop in $prevDef.environment_variables.PSObject.Properties) {
        $envHash[$prop.Name] = $prop.Value
    }
    $newDef.environment_variables = $envHash
}
$body = @{ description = $Description; definition = $newDef } | ConvertTo-Json -Depth 32 -Compress
$postUri = "$FoundryEndpoint/api/projects/$FoundryProject/agents/$FoundryAgent/versions?api-version=$ApiVersion"
$resp = Invoke-RestMethod -Method Post -Uri $postUri -Headers $headers -Body $body
Write-Host "`n=== Deployed ===" -ForegroundColor Green
Write-Host "New version: $($resp.version) (id=$($resp.id))"
Write-Host "Status:      $($resp.status)"
Write-Host "Endpoint:    $FoundryEndpoint/api/projects/$FoundryProject/agents/$FoundryAgent/endpoint/protocols/openai/responses"
