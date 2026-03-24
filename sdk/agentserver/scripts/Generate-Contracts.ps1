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

    Use -ValidatorsOnly to skip TypeSpec compilation and only regenerate validators
    from the existing OpenAPI spec.

    Prerequisites:
    - Python 3 + pyyaml (for generate-validators.py)
    - Node.js (for npx tsp-client / tsp compile) — only needed for full regeneration

.PARAMETER ValidatorsOnly
    When specified, skips TypeSpec sync/compile and model copying.
    Only regenerates validators from the existing OpenAPI spec.

.EXAMPLE
    # Full regeneration
    ./scripts/Generate-Contracts.ps1

    # Validators only
    ./scripts/Generate-Contracts.ps1 -ValidatorsOnly
#>

param(
    [switch]$ValidatorsOnly
)

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
$ContractsGenerated = Join-Path $AgentServerRoot "Azure.AI.AgentServer.Responses.Contracts" "src" "Generated"
$ValidatorsDir = Join-Path $ContractsGenerated "Validators"
$OverlayYaml = Join-Path $AgentServerRoot "Azure.AI.AgentServer.Responses.Contracts" "src" "Validation" "validation-overlay.yaml"
$ValidatorsNamespace = "Azure.AI.AgentServer.Responses.Validators"
$GenerateValidatorsScript = Join-Path $AgentServerRoot "scripts" "generate-validators.py"

# OpenAPI spec: prefer tsp-output (from tsp compile), fall back to synced TempTypeSpecFiles
$OpenApiYaml = Join-Path $TspOut "openapi.virtual-public-preview.yaml"
$FallbackOpenApiYaml = Join-Path $TspDir "TempTypeSpecFiles" "Foundry" "openapi3" "virtual-public-preview" "microsoft-foundry-openapi3.yaml"

# Ensure pyyaml is available
Write-Host "Checking Python dependencies..."
$pyCheck = python3 -c "import yaml" 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Host "Installing pyyaml (required by generate-validators.py)..."
    python3 -m pip install --quiet pyyaml
}

Push-Location $AgentServerRoot
try {
    if (-not $ValidatorsOnly) {
        # Step 1: Sync upstream TypeSpec sources
        Write-Host "Syncing upstream TypeSpec sources..."
        npx tsp-client sync --output-dir (Join-Path "Azure.AI.AgentServer.Responses.Contracts" "src" "TypeSpec")
        if ($LASTEXITCODE -ne 0) { throw "tsp-client sync failed" }
        Write-Host "TypeSpec sources synced."

        # Step 1b: Install TypeSpec dependencies (including @typespec/openapi3 for OpenAPI generation)
        $TempTypeSpecDir = Join-Path $TspDir "TempTypeSpecFiles"
        Write-Host "Installing TypeSpec dependencies..."
        Push-Location $TempTypeSpecDir
        try {
            npm install --silent
            if ($LASTEXITCODE -ne 0) { throw "npm install failed" }
            # Ensure @typespec/openapi3 emitter is installed (required by tspconfig.yaml)
            $openapi3Installed = npm ls @typespec/openapi3 2>&1
            if ($LASTEXITCODE -ne 0) {
                $compilerVer = (npm ls @typespec/compiler --json 2>$null | ConvertFrom-Json).dependencies.'@typespec/compiler'.version
                Write-Host "Installing @typespec/openapi3@$compilerVer..."
                npm install "@typespec/openapi3@$compilerVer" --silent
                if ($LASTEXITCODE -ne 0) { throw "Failed to install @typespec/openapi3" }
            }
        } finally {
            Pop-Location
        }
        Write-Host "TypeSpec dependencies installed."

        # Step 2: Compile TypeSpec (produces C# models + OpenAPI spec via client.tsp)
        Write-Host "Compiling TypeSpec -> C# models + OpenAPI spec..."
        Push-Location $TspDir
        try {
            npx --prefix TempTypeSpecFiles tsp compile .
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
    } else {
        Write-Host "Skipping TypeSpec sync/compile (validators-only mode)."
    }

    # Step 4: Generate validators from OpenAPI spec
    # IMPORTANT: Use the tsp-compiled OpenAPI spec (includes client.tsp customizations)
    # The raw TempTypeSpecFiles spec does NOT include client.tsp changes (@@copyProperties,
    # @@withoutOmittedProperties, schema filtering). Only fall back for bootstrapping.
    $specPath = $OpenApiYaml
    if (-not (Test-Path $specPath)) {
        if ($ValidatorsOnly) {
            Write-Warning "Compiled OpenAPI spec not found at '$OpenApiYaml'. Falling back to raw synced spec."
            Write-Warning "Run without -ValidatorsOnly to compile TypeSpec with client.tsp customizations."
        }
        $specPath = $FallbackOpenApiYaml
    }
    if (-not (Test-Path $specPath)) {
        throw "OpenAPI spec not found at '$OpenApiYaml' or '$FallbackOpenApiYaml'. Run without -ValidatorsOnly first, or ensure TempTypeSpecFiles are synced."
    }
    Write-Host "Using OpenAPI spec: $specPath"

    Write-Host "Generating C# validators from OpenAPI spec..."
    python3 $GenerateValidatorsScript `
        --input $specPath `
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

    # Step 6: Clean up intermediate artifacts
    if (-not $ValidatorsOnly) {
        Write-Host "Cleaning up intermediate artifacts..."

        # Remove node_modules installed for tsp compile (contains .cs files that
        # would confuse MSBuild if left in place)
        $nodeModules = Join-Path $TspDir "TempTypeSpecFiles" "node_modules"
        if (Test-Path $nodeModules) {
            Remove-Item -Recurse -Force $nodeModules
            Write-Host "  Removed TempTypeSpecFiles/node_modules"
        }

        # Clean tsp-output: keep the compiled OpenAPI spec (for -ValidatorsOnly)
        # and Custom stubs, remove everything else (Generated/, *.cs client code)
        $tspOutSrc = Join-Path $TspOut "src"
        if (Test-Path $tspOutSrc) {
            Get-ChildItem -Path $tspOutSrc -Exclude "Custom" | Remove-Item -Recurse -Force
        }
        # Remove non-yaml/non-src items (e.g. .tsp intermediates)
        Get-ChildItem -Path $TspOut -Exclude "src", "*.yaml" | Remove-Item -Recurse -Force
        Write-Host "  Preserved tsp-output/openapi.*.yaml and src/Custom/"
    }
    Write-Host "All Responses contracts generated and cleaned up."
} finally {
    Pop-Location
}
