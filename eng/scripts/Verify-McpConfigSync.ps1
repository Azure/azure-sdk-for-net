#requires -version 7

<#
.SYNOPSIS
    Verifies that .mcp.json (Copilot CLI / Anthropic format) and .vscode/mcp.json
    (VS Code format) declare the same MCP servers.

.DESCRIPTION
    Copilot CLI reads .mcp.json at the workspace root and expects the top-level
    key "mcpServers". VS Code reads .vscode/mcp.json and expects the top-level
    key "servers". Beyond that, the per-server config schema (type, command,
    args, env) is identical, so both files must declare the same servers with
    the same definitions.

    This script:
      1. Loads both files
      2. Normalizes them (treats "mcpServers" and "servers" as equivalent)
      3. Compares them deeply
      4. Fails (exit 1) with a clear diff if they drift

    Run locally: pwsh eng/scripts/Verify-McpConfigSync.ps1
#>

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
$cliConfigPath = Join-Path $repoRoot '.mcp.json'
$vsCodeConfigPath = Join-Path $repoRoot '.vscode' 'mcp.json'

function Read-ServerConfig {
    param(
        [string] $Path,
        [string] $TopLevelKey
    )

    if (-not (Test-Path $Path)) {
        throw "Expected MCP config file not found: $Path"
    }

    $raw = Get-Content -Raw -Path $Path
    $obj = $raw | ConvertFrom-Json -AsHashtable

    if (-not $obj.ContainsKey($TopLevelKey)) {
        throw "File '$Path' is missing required top-level key '$TopLevelKey'."
    }

    return $obj[$TopLevelKey]
}

function ConvertTo-Canonical {
    param([Parameter(ValueFromPipeline)] $InputObject)

    process {
        if ($null -eq $InputObject) { return $null }

        if ($InputObject -is [System.Collections.IDictionary]) {
            $sorted = [ordered]@{}
            foreach ($key in ($InputObject.Keys | Where-Object { -not $_.StartsWith('_') } | Sort-Object)) {
                $sorted[$key] = $InputObject[$key] | ConvertTo-Canonical
            }
            return $sorted
        }

        if ($InputObject -is [System.Collections.IEnumerable] -and $InputObject -isnot [string]) {
            return @($InputObject | ForEach-Object { $_ | ConvertTo-Canonical })
        }

        return $InputObject
    }
}

$cliServers = Read-ServerConfig -Path $cliConfigPath -TopLevelKey 'mcpServers'
$vsCodeServers = Read-ServerConfig -Path $vsCodeConfigPath -TopLevelKey 'servers'

$cliCanonical = ($cliServers | ConvertTo-Canonical) | ConvertTo-Json -Depth 20
$vsCodeCanonical = ($vsCodeServers | ConvertTo-Canonical) | ConvertTo-Json -Depth 20

if ($cliCanonical -ne $vsCodeCanonical) {
    Write-Host "::error::MCP server configurations have drifted between .mcp.json and .vscode/mcp.json"
    Write-Host ""
    Write-Host "--- .mcp.json (mcpServers, used by Copilot CLI) ---"
    Write-Host $cliCanonical
    Write-Host ""
    Write-Host "--- .vscode/mcp.json (servers, used by VS Code) ---"
    Write-Host $vsCodeCanonical
    Write-Host ""
    Write-Host "Update both files so the server definitions match."
    exit 1
}

Write-Host ".mcp.json and .vscode/mcp.json declare matching MCP servers."
