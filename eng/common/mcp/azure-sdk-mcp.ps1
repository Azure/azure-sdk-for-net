#!/bin/env pwsh

param(
    [string]$FileName = 'Azure.Sdk.Tools.Cli',
    [string]$Package = 'azsdk',
    [string]$Version, # Default to latest
    [string]$InstallDirectory = (Join-Path $HOME ".azure-sdk-mcp" "azsdk"),
    [string]$Repository = 'Azure/azure-sdk-tools',
    [string]$RunDirectory = (Resolve-Path (Join-Path $PSScriptRoot .. .. ..)),
    [switch]$Run,
    [switch]$UpdateVsCodeConfig,
    [switch]$Clean
)

$ErrorActionPreference = "Stop"

. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

if ($Clean) {
    Clear-Directory -Path $InstallDirectory
}

if ($UpdateVsCodeConfig) {
    $vscodeConfigPath = $PSScriptRoot + "../../../.vscode/mcp.json"
    if (Test-Path $vscodeConfigPath) {
        $vscodeConfig = Get-Content -Raw $vscodeConfig | ConvertFrom-Json -AsHashtable
    }
    else {
        $vscodeConfig = @{}
    }
    $serverKey = "azure-sdk-mcp"
    $serverConfig = @{
        "type"    = "stdio"
        "command" = "/home/ben/azs/azure-sdk-tools/eng/common/mcp/azure-sdk-mcp.ps1"
    }
    $orderedServers = [ordered]@{
        $serverKey = $serverConfig
    }
    if (-not $vscodeConfig.ContainsKey('servers')) {
        $vscodeConfig['servers'] = @{}
    }
    foreach ($key in $vscodeConfig.servers.Keys) {
        if ($key -ne $serverKey) {
            $orderedServers[$key] = $vscodeConfig.servers[$key]
        }
    }
    $vscodeConfig.servers = $orderedServers
    Write-Host "Updating vscode mcp config at $vscodeConfigPath"
    $vscodeConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $vscodeConfig -Force
}

$exe = Install-Standalone-Tool `
    -Version $Version `
    -FileName $FileName `
    -Package $Package `
    -Directory $InstallDirectory `
    -Repository $Repository

if ($Run) {
    Start-Process -WorkingDirectory $RunDirectory -FilePath $exe -ArgumentList 'start' -NoNewWindow -Wait
}
