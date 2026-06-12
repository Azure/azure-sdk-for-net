<#
.SYNOPSIS
    Builds the Azure.AI.Extensions.OpenAI code generation plugin and runs code generation.

.DESCRIPTION
    This script builds the local Extensions.Plugin project and then invokes the standard
    TypeSpec-based code generation pipeline ('dotnet build /t:GenerateCode') for the
    Azure.AI.Extensions.OpenAI library.

    The plugin adds custom visitors (e.g., ExperimentalAttributeVisitor) that modify the
    generated code, mirroring the pattern used by the upstream OpenAI library's codegen plugin.

.PARAMETER SkipSync
    When specified, skips syncing the TypeSpec specification and only regenerates code
    from previously saved inputs. Requires a prior run with -SaveInputs.

.PARAMETER SaveInputs
    When specified, saves the intermediate TypeSpec inputs for later use with -SkipSync.
#>
[CmdletBinding()]
param(
    [switch]$SkipSync,
    [switch]$SaveInputs
)

$ErrorActionPreference = 'Stop'

$scriptDir = $PSScriptRoot
$projectRoot = Join-Path $scriptDir .. -Resolve
$pluginProjectPath = Join-Path $projectRoot "codegen" "generator" "src" "Extensions.Plugin.csproj"
$srcDir = Join-Path $projectRoot "src"

# Step 1: Build the local codegen plugin
Write-Host "Building Extensions.Plugin..." -ForegroundColor Cyan
dotnet build $pluginProjectPath
if ($LASTEXITCODE -ne 0) {
    throw "Failed to build Extensions.Plugin (exit code: $LASTEXITCODE)."
}
Write-Host "Extensions.Plugin built successfully." -ForegroundColor Green
Write-Host ""

# Step 2: Run the standard code generation from the src directory
Write-Host "Running code generation..." -ForegroundColor Cyan
$generateArgs = @("/t:GenerateCode")
if ($SkipSync) {
    $generateArgs += "/p:SkipSync=true"
}
if ($SaveInputs) {
    $generateArgs += "/p:SaveInputs=true"
}

Push-Location $srcDir
try {
    dotnet build @generateArgs
    if ($LASTEXITCODE -ne 0) {
        throw "Code generation failed (exit code: $LASTEXITCODE)."
    }
    Write-Host "Code generation completed successfully." -ForegroundColor Green
}
finally {
    Pop-Location
}
