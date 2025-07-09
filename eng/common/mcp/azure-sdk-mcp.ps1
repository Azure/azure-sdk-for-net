#!/bin/env pwsh

param(
    [string]$FileName = 'Azure.Sdk.Tools.Cli',
    [string]$Package = 'azsdk',
    [string]$Version, # Default to latest
    [string]$InstallDirectory = '',
    [string]$Repository = 'Azure/azure-sdk-tools',
    [string]$RunDirectory = (Resolve-Path (Join-Path $PSScriptRoot .. .. ..)),
    [switch]$Run,
    [switch]$UpdateVsCodeConfig,
    [switch]$Clean
)

$ErrorActionPreference = "Stop"

if (-not $InstallDirectory)
{
    $homeDir = if ($env:HOME) { $env:HOME } else { $env:USERPROFILE }
    $InstallDirectory = (Join-Path $homeDir ".azure-sdk-mcp" "azsdk")
}
. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

# If version is not provided, look for the tag <package>_Latest and set the version to the tag's description
if (-not $Version) {
    try {
        $versionTag = "${Package}_Latest"
        $specificReleaseUrl = "https://api.github.com/repos/$Repository/releases/tags/$versionTag"
        $latestRelease = Invoke-RestMethod -Uri $specificReleaseUrl
        $Version = $latestRelease.body
    }
    catch {
        Write-Warning "Could not fetch version from ${Package}_Latest tag. Will run the latest version."
    }
}

if ($Clean) {
    Clear-Directory -Path $InstallDirectory
}

if ($UpdateVsCodeConfig) {
    $vscodeConfigPath = Join-Path $PSScriptRoot ".." ".." ".." ".vscode" "mcp.json"
    if (Test-Path $vscodeConfigPath) {
        $vscodeConfig = Get-Content -Raw $vscodeConfigPath | ConvertFrom-Json -AsHashtable
    }
    else {
        $vscodeConfig = @{}
    }
    $serverKey = "azure-sdk-mcp"
    $serverConfig = @{
        "type"    = "stdio"
        "command" = "$PSCommandPath"
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
    $vscodeConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $vscodeConfigPath -Force
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
