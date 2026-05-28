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

$mcpMode = $Run

# Log to console or MCP client json-rpc
function log([object]$message, [switch]$warn, [switch]$err) {
    [string]$messageString = $message

    # Assume we are in an MCP client context when `-Run` is specified
    # otherwise print to console normally
    if (!$mcpMode) {
        if ($err) {
            Write-Error $messageString -ErrorAction Continue
        }
        elseif ($warn) {
            Write-Warning $messageString
        }
        else {
            Write-Host $messageString
        }
        return;
    }

    $level = switch ($message) {
        { $_ -is [System.Management.Automation.ErrorRecord] } { 'error' }
        { $_ -is [System.Management.Automation.WarningRecord] } { 'warning' }
        default { 'notice' }
    }

    # If message stringifies as a valid error message we want to print it
    # otherwise print stack for calls to external binaries
    if ($messageString -eq 'System.Management.Automation.RemoteException') {
        $messageString = $message.ScriptStackTrace
    }

    # Log json-rpc messages so the MCP client doesn't print
    # '[warning] Failed to parse message:'
    $messageObject = @{
        jsonrpc = "2.0"
        method  = "notifications/message"
        params  = @{
            level  = $level
            logger = "installer"
            data   = $messageString
        }
    }

    Write-Host ($messageObject | ConvertTo-Json -Depth 100 -Compress)
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
    log "Updating vscode mcp config at $vscodeConfigPath"
    $vscodeConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $vscodeConfigPath -Force
}

# Install to a temp directory first so we don't dump out all the other
# release zip contents to one of the users bin directories.
$tmp = $env:TEMP ? $env:TEMP : [System.IO.Path]::GetTempPath()
$guid = [System.Guid]::NewGuid()
$tempInstallDirectory = Join-Path $tmp "azsdk-install-$($guid)"

if ($mcpMode) {
    try {
        # Swallow all output and re-log so we can wrap any
        # output from the inner function as json-rpc
        $tempExe = Install-Standalone-Tool `
            -Version $Version `
            -FileName $FileName `
            -Package $Package `
            -Directory $tempInstallDirectory `
            -Repository $Repository `
            *>&1
        | Tee-Object -Variable _
        | ForEach-Object { log $_; $_ }
        | Select-Object -Last 1
    }
    catch {
        log -err $_
        exit 1
    }
}
else {
    $tempExe = Install-Standalone-Tool `
        -Version $Version `
        -FileName $FileName `
        -Package $Package `
        -Directory $tempInstallDirectory `
        -Repository $Repository `

}

if (-not (Test-Path $toolInstallDirectory)) {
    New-Item -ItemType Directory -Path $toolInstallDirectory -Force | Out-Null
}
$exeName = Split-Path $tempExe -Leaf
$exeDestination = Join-Path $toolInstallDirectory $exeName
Copy-Item -Path $tempExe -Destination $exeDestination -Force

log "Package $package is installed at $exeDestination"
if (!$UpdatePathInProfile) {
    log -warn "To add the tool to PATH for new shell sessions, re-run with -UpdatePathInProfile to modify the shell profile file."
}
else {
    Add-InstallDirectoryToPathInProfile -InstallDirectory $toolInstallDirectory
    log -warn "'$exeName' will be available in PATH for new shell sessions."
}

if ($Run) {
    Start-Process -WorkingDirectory $RunDirectory -FilePath $exeDestination -ArgumentList 'start' -NoNewWindow -Wait
}
