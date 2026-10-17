#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
$previous = $env:AZURE_MCP_UPDATE_GENERATED
Push-Location $packageRoot
try {
    npm run build
    if ($LASTEXITCODE -ne 0) {
        throw 'Building the MCP emitter and generator failed.'
    }

    $env:AZURE_MCP_UPDATE_GENERATED = '1'
    npm run test:storage
    if ($LASTEXITCODE -ne 0) {
        throw 'Generating and validating the Storage output failed.'
    }
}
finally {
    $env:AZURE_MCP_UPDATE_GENERATED = $previous
    Pop-Location
}
