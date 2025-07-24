#!/bin/env pwsh

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
    [switch]$UpdateVsCodeConfig
)

$ErrorActionPreference = "Stop"
. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

function Get-InstallDirectory {
    if ($IsLinux) {
        $defaultDir = Join-Path $HOME "bin"
        if (-not (Test-Path $defaultDir)) {
            New-Item -ItemType Directory -Path $defaultDir -Force | Out-Null
        }
        return $defaultDir
    }

    if ($IsWindows) {
        $defaultDir = Join-Path $HOME ".azure-sdk"
        if (-not (Test-Path $defaultDir)) {
            New-Item -ItemType Directory -Path $defaultDir -Force | Out-Null
        }

        # Update PATH in current session
        if (-not ($env:PATH -like "*$defaultDir*")) {
            $env:PATH += ";$defaultDir"
        }

        # Update path for future sessions via PowerShell profile
        if (-not (Test-Path $PROFILE)) {
            New-Item -ItemType File -Path $PROFILE -Force | Out-Null
        }
        $markerComment = "  # azsdk install path"
        $pathCommand = 'if (-not ($env:PATH -like "*$HOME\.azure-sdk*")) { $env:PATH += ";$HOME\.azure-sdk" }' + $markerComment
        $profileContent = Get-Content $PROFILE -ErrorAction SilentlyContinue
        if ($profileContent -notcontains $markerComment) {
            Write-Host "Adding install path to PowerShell profile at $PROFILE"
            Add-Content -Path $PROFILE -Value $pathCommand
        }

        return $defaultDir
    }

    if ($IsMacOS) {
        $defaultDir = "/usr/local/bin"
        if (-not (Test-Path $defaultDir)) {
            New-Item -ItemType Directory -Path $defaultDir -Force | Out-Null
        }
        return $defaultDir
    }

    Write-Error "Unsupported platform. Specify an install directory manually with the -InstallDirectory parameter."
    exit 1
}

$InstallDirectory = $InstallDirectory ? $InstallDirectory : (Get-InstallDirectory)

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

Copy-Item -Path $tempExe -Destination $InstallDirectory -Force
$exeName = Split-Path $tempExe -Leaf
$exe = Join-Path $InstallDirectory $exeName
Write-Host "Package $package is installed at $exe"

if ($Run) {
    Start-Process -WorkingDirectory $RunDirectory -FilePath $exe -ArgumentList 'start' -NoNewWindow -Wait
}
