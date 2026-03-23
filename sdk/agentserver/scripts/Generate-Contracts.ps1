#!/usr/bin/env pwsh
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
    Regenerates the Azure.AI.AgentServer.Responses.Contracts generated code.

.DESCRIPTION
    Runs the full contract generation pipeline:
    1. Syncs upstream TypeSpec sources (npx tsp-client sync)
    2. Compiles TypeSpec → C# models + OpenAPI spec (npx tsp compile)
    3. Copies generated Models/ and Internal/ into Contracts/src/Generated/
    4. Generates C# validators from the OpenAPI spec (python3 generate-validators.py)
    5. Cleans up tsp-output intermediates

    Prerequisites:
    - Node.js (for npx tsp-client / tsp compile)
    - Python 3 + pyyaml (for generate-validators.py)
    - npm install must have been run in the sdk/agentserver/ directory

.EXAMPLE
    ./scripts/Generate-Contracts.ps1
#>

param()

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

# Resolve paths relative to the agentserver root (parent of scripts/)
$AgentServerRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
if (-not (Test-Path (Join-Path $AgentServerRoot "scripts" "Generate-Contracts.ps1"))) {
    # Fallback: script is at sdk/agentserver/scripts/Generate-Contracts.ps1
    $AgentServerRoot = Split-Path -Parent $PSScriptRoot
}

$TspDir = Join-Path $AgentServerRoot "Azure.AI.AgentServer.Responses.Contracts" "src" "TypeSpec"
$TspOut = Join-Path $TspDir "tsp-output"
$OpenApiYaml = Join-Path $TspOut "openapi.virtual-public-preview.yaml"
$ContractsGenerated = Join-Path $AgentServerRoot "Azure.AI.AgentServer.Responses.Contracts" "src" "Generated"
$ValidatorsDir = Join-Path $ContractsGenerated "Validators"
$OverlayYaml = Join-Path $AgentServerRoot "Azure.AI.AgentServer.Responses.Contracts" "src" "Validation" "validation-overlay.yaml"
$ValidatorsNamespace = "Azure.AI.AgentServer.Responses"
$GenerateValidatorsScript = Join-Path $AgentServerRoot "scripts" "generate-validators.py"

# Ensure pyyaml is available
Write-Host "Checking Python dependencies..."
$pyCheck = python3 -c "import yaml" 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Host "Installing pyyaml (required by generate-validators.py)..."
    python3 -m pip install --quiet pyyaml
}

Push-Location $AgentServerRoot
try {
    # Step 1: Sync upstream TypeSpec sources
    Write-Host "Syncing upstream TypeSpec sources..."
    npx tsp-client sync --output-dir (Join-Path "Azure.AI.AgentServer.Responses.Contracts" "src" "TypeSpec")
    if ($LASTEXITCODE -ne 0) { throw "tsp-client sync failed" }
    Write-Host "TypeSpec sources synced."

    # Step 2: Compile TypeSpec
    Write-Host "Compiling TypeSpec -> C# models + OpenAPI spec..."
    Push-Location $TspDir
    try {
        npx tsp compile .
        if ($LASTEXITCODE -ne 0) { throw "tsp compile failed" }
    } finally {
        Pop-Location
    }
    Write-Host "TypeSpec compiled."

    # Step 3: Copy generated models into Contracts
    Write-Host "Copying generated models into Contracts..."
    $modelsDir = Join-Path $ContractsGenerated "Models"
    $internalDir = Join-Path $ContractsGenerated "Internal"

    if (Test-Path $modelsDir) { Remove-Item -Recurse -Force $modelsDir }
    if (Test-Path $internalDir) { Remove-Item -Recurse -Force $internalDir }

    New-Item -ItemType Directory -Force -Path $modelsDir | Out-Null
    New-Item -ItemType Directory -Force -Path $internalDir | Out-Null

    $tspGenerated = Join-Path $TspOut "src" "Generated"
    $tspModels = Join-Path $tspGenerated "Models"
    $tspInternal = Join-Path $tspGenerated "Internal"
    $tspFactory = Join-Path $tspGenerated "AzureAIAgentServerResponsesModelFactory.cs"

    if (Test-Path $tspModels) {
        Copy-Item -Recurse -Force (Join-Path $tspModels "*") $modelsDir
    }
    if (Test-Path $tspFactory) {
        Copy-Item -Force $tspFactory $modelsDir
    }
    if (Test-Path $tspInternal) {
        Copy-Item -Force (Join-Path $tspInternal "*.cs") $internalDir
    }
    Write-Host "Models generated."

    # Step 4: Generate validators from OpenAPI spec
    Write-Host "Generating C# validators from OpenAPI spec..."
    python3 $GenerateValidatorsScript `
        --input $OpenApiYaml `
        --output $ValidatorsDir `
        --overlay $OverlayYaml `
        --namespace $ValidatorsNamespace `
        --root-schemas "OpenAI.Response"
    if ($LASTEXITCODE -ne 0) { throw "generate-validators.py failed" }
    Write-Host "Validators generated."

    # Step 5: Add copyright headers to all generated .cs files
    Write-Host "Adding copyright headers to generated files..."
    $copyrightHeader = @"
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

"@
    Get-ChildItem -Path $ContractsGenerated -Filter "*.cs" -Recurse | ForEach-Object {
        $content = Get-Content -Raw $_.FullName
        if ($content -notmatch '^\s*// Copyright \(c\) Microsoft Corporation') {
            Set-Content -Path $_.FullName -Value ($copyrightHeader + $content) -NoNewline
        }
    }
    Write-Host "Copyright headers added."

    # Step 6: Clean up tsp-output intermediates (preserve Custom stubs only)
    Write-Host "Cleaning up tsp-output intermediates..."
    Get-ChildItem -Path $TspOut -Exclude "src" | Remove-Item -Recurse -Force
    $tspOutSrc = Join-Path $TspOut "src"
    if (Test-Path $tspOutSrc) {
        Get-ChildItem -Path $tspOutSrc -Exclude "Custom" | Remove-Item -Recurse -Force
    }
    Write-Host "All Responses contracts generated and cleaned up."
} finally {
    Pop-Location
}
