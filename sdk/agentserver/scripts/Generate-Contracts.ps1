#!/usr/bin/env pwsh
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
    Regenerates the Azure.AI.AgentServer.Responses generated model code.

.DESCRIPTION
    Runs the full contract generation pipeline:
    1. Syncs upstream TypeSpec sources (eng/common/tsp-client)
    2. Compiles TypeSpec → C# models + OpenAPI spec (npx tsp compile)
    3. Copies generated Models/ and Internal/ into Responses/src/Generated/
    4. Generates C# validators from the OpenAPI spec (python3 generate-validators.py)
    5. Cleans up tsp-output intermediates

    Use -ValidatorsOnly to skip TypeSpec compilation and only regenerate validators.
    Requires a prior full run to have produced the compiled OpenAPI spec.

    Prerequisites:
    - Python 3 + pyyaml (for generate-validators.py)
    - Node.js (for tsp-client sync / tsp compile) — only needed for full regeneration

.PARAMETER ValidatorsOnly
    When specified, skips TypeSpec sync/compile and model copying.
    Only regenerates validators from the previously compiled OpenAPI spec.
    Requires a prior full run to have produced the spec at tsp-output/.

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
$AgentServerRoot = Split-Path -Parent $PSScriptRoot
$PackageRoot = Join-Path $AgentServerRoot "Azure.AI.AgentServer.Responses"

$TspDir = Join-Path $PackageRoot "src" "TypeSpec"
$TspOut = Join-Path $TspDir "tsp-output"
$ContractsGenerated = Join-Path $PackageRoot "src" "Generated"
$ValidatorsDir = Join-Path $PackageRoot "src" "Generated" "Validators"
$OverlayYaml = Join-Path $PackageRoot "src" "Validation" "validation-overlay.yaml"
$ValidatorsNamespace = "Azure.AI.AgentServer.Responses.Validators"
$GenerateValidatorsScript = Join-Path $AgentServerRoot "scripts" "generate-validators.py"

# OpenAPI spec produced by tsp compile (includes client.tsp customizations)
$OpenApiYaml = Join-Path $TspOut "openapi.virtual-public-preview.yaml"

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
        # Step 1: Sync upstream TypeSpec sources via eng/common/tsp-client
        $RepoRoot = Resolve-Path (Join-Path $AgentServerRoot ".." "..")
        $TspClientDir = Join-Path $RepoRoot "eng" "common" "tsp-client"
        if (-not (Test-Path (Join-Path $TspClientDir "package.json"))) {
            throw "tsp-client not found at '$TspClientDir'. Ensure eng/common/tsp-client exists."
        }
        Write-Host "Installing tsp-client dependencies..."
        Push-Location $TspClientDir
        try {
            npm ci --silent
            if ($LASTEXITCODE -ne 0) { throw "npm ci failed in eng/common/tsp-client" }
        } finally {
            Pop-Location
        }

        Write-Host "Syncing upstream TypeSpec sources..."
        npx --prefix $TspClientDir --no -- tsp-client sync --no-prompt --output-dir $PackageRoot
        $TempTypeSpecDir = Join-Path $PackageRoot "TempTypeSpecFiles"
        if ($LASTEXITCODE -ne 0) {
            # Verify sync at least downloaded the source files
            if (-not (Test-Path (Join-Path $TempTypeSpecDir "Foundry"))) {
                throw "tsp-client sync failed: TempTypeSpecFiles/Foundry/ not found"
            }
            Write-Warning "tsp-client sync exited non-zero but source files are present. Continuing..."
        }
        if (-not (Test-Path (Join-Path $TempTypeSpecDir "package.json"))) {
            throw "tsp-client sync did not create TempTypeSpecFiles/package.json. Check emitterPackageJsonPath in tsp-location.yaml."
        }
        Write-Host "TypeSpec sources synced."

        # Step 1b: Install TypeSpec dependencies
        # Dependencies (including @typespec/openapi3) come from the repo-level emitter
        # package specified by emitterPackageJsonPath in tsp-location.yaml.
        Write-Host "Installing TypeSpec dependencies..."
        Push-Location $TempTypeSpecDir
        try {
            npm install --silent
            if ($LASTEXITCODE -ne 0) { throw "npm install failed" }
        } finally {
            Pop-Location
        }
        Write-Host "TypeSpec dependencies installed."

        # Step 2: Compile TypeSpec (produces C# models + OpenAPI spec via client.tsp)
        Write-Host "Compiling TypeSpec -> C# models + OpenAPI spec..."
        $EntrypointTsp = Join-Path $TempTypeSpecDir "sdk-service-agentserver-contracts/client.tsp"
        if (-not (Test-Path $EntrypointTsp)) {
            throw "Entrypoint client.tsp not found at $EntrypointTsp. Check tsp-client sync and tsp-location.yaml."
        }
        Push-Location $TempTypeSpecDir
        try {
            npx tsp compile $EntrypointTsp --output-dir "$TspOut"
            if ($LASTEXITCODE -ne 0) { throw "tsp compile failed" }
        } finally {
            Pop-Location
        }
        Write-Host "TypeSpec compiled."

        # Step 3: Copy generated models into Responses
        Write-Host "Copying generated models into Responses..."
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

    # Step 4: Generate validators from the tsp-compiled OpenAPI spec
    # This spec includes client.tsp customizations (@@copyProperties, @@withoutOmittedProperties,
    # schema filtering). The raw TempTypeSpecFiles spec does NOT include these changes.
    if (-not (Test-Path $OpenApiYaml)) {
        throw "Compiled OpenAPI spec not found at '$OpenApiYaml'. Run without -ValidatorsOnly first to compile TypeSpec."
    }
    Write-Host "Using OpenAPI spec: $OpenApiYaml"

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
    $generatedDirs = @($ContractsGenerated, $ValidatorsDir)
    foreach ($genDir in $generatedDirs) {
        if (Test-Path $genDir) {
            Get-ChildItem -Path $genDir -Filter "*.cs" -Recurse | ForEach-Object {
                $content = Get-Content -Raw $_.FullName
                if ($content -notmatch '^\s*// Copyright \(c\) Microsoft Corporation') {
                    Set-Content -Path $_.FullName -Value ($copyrightHeader + $content) -NoNewline
                }
            }
        }
    }
    Write-Host "Copyright headers added."

    # Step 6: Clean up intermediate artifacts
    if (-not $ValidatorsOnly) {
        Write-Host "Cleaning up intermediate artifacts..."

        # Remove node_modules installed for tsp compile (contains .cs files that
        # would confuse MSBuild if left in place)
        $nodeModules = Join-Path $PackageRoot "TempTypeSpecFiles" "node_modules"
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
    Write-Host "All Responses models generated and cleaned up."
} finally {
    Pop-Location
}
