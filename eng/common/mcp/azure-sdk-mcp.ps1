#!/usr/bin/env pwsh

#Requires -Version 7.0
#Requires -PSEdition Core

param(
    [string]$FileName = 'Azure.Sdk.Tools.Cli',
    [string]$Package = 'azsdk',
    [string]$Version, # Default to latest
    [string]$InstallDirectory = '',
    [string]$Repository = 'Azure/azure-sdk-tools',
    [string]$RunDirectory = (Resolve-Path (Join-Path $PSScriptRoot .. .. ..)),
    [switch]$Run,
    [switch]$UpdateVsCodeConfig,
    [switch]$UpdatePathInProfile
)

$ErrorActionPreference = "Stop"
. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

$toolInstallDirectory = $InstallDirectory ? $InstallDirectory : (Get-CommonInstallDirectory)

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

# Install to a temp directory first so we don't dump out all the other
# release zip contents to one of the users bin directories.
$tmp = $env:TEMP ? $env:TEMP : [System.IO.Path]::GetTempPath()
$guid = [System.Guid]::NewGuid()
$tempInstallDirectory = Join-Path $tmp "azsdk-install-$($guid)"
$tempExe = Install-Standalone-Tool `
    -Version $Version `
    -FileName $FileName `
    -Package $Package `
    -Directory $tempInstallDirectory `
    -Repository $Repository

if (-not (Test-Path $toolInstallDirectory)) {
    New-Item -ItemType Directory -Path $toolInstallDirectory -Force | Out-Null
}
$exeName = Split-Path $tempExe -Leaf
$exeDestination = Join-Path $toolInstallDirectory $exeName
Copy-Item -Path $tempExe -Destination $exeDestination -Force

Write-Host "Package $package is installed at $exeDestination"
if (!$UpdatePathInProfile) {
    Write-Warning "To add the tool to PATH for new shell sessions, re-run with -UpdatePathInProfile to modify the shell profile file."
} else {
    Add-InstallDirectoryToPathInProfile -InstallDirectory $toolInstallDirectory
    Write-Warning "'$exeName' will be available in PATH for new shell sessions."
}

if ($Run) {
    Start-Process -WorkingDirectory $RunDirectory -FilePath $exeDestination -ArgumentList 'start' -NoNewWindow -Wait
}
