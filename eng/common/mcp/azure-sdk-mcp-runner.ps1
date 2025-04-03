#/usr/bin/env pwsh

param(
    [string]$Config = "$PSScriptRoot/mcp-servers.json",
    [switch]$Run,
    [string]$CreateVSCodeConfig,
    [switch]$Clean
)

$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = 'Stop'

$McpDirectory = "$HOME/.azure-sdk-mcp"
$registryConfig = Join-Path -Path $McpDirectory -ChildPath "mcp-servers.json"

if ($Clean) {
    Write-Warning "Cleaning $McpDirectory"
    Remove-Item $McpDirectory -Force -Recurse
    exit 0
}

function Get-Feed([string]$feedName, [string]$packageType) {
    if ($feedName -eq 'public') {
        if ($packageType -eq 'node') {
            return "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-mcp/npm/registry/"
        }
        if ($packageType -eq 'python') {
            return "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-mcp/pypi/simple/"
        }
        if ($packageType -eq 'static') {
            return @{
                Org     = "https://dev.azure.com/azure-sdk/"
                Project = "29ec6040-b234-4e31-b139-33dc4287b756"
                Feed    = "azure-sdk-mcp"
            }
        }
        throw "Unsupported package type '$packageType' for feed"
    }
    if ($feedName -eq 'internal') {
        if ($packageType -eq 'node') {
            return "https://pkgs.dev.azure.com/azure-sdk/internal/_packaging/azure-sdk-mcp-private/npm/registry/"
        }
        if ($packageType -eq 'python') {
            return "https://pkgs.dev.azure.com/azure-sdk/internal/_packaging/azure-sdk-mcp-private/pypi/simple/"
        }
        if ($packageType -eq 'static') {
            return @{
                Org     = "https://dev.azure.com/azure-sdk/"
                Project = "590cfd2a-581c-4dcb-a12e-6568ce786175"
                Feed    = "azure-sdk-mcp-private"
            }
        }
        throw "Unsupported package type '$packageType' for feed"
    }
    throw "Unsupported feed '$feedName'"
}

function Get-Registry() {
    if (-not (Test-Path -Path $McpDirectory)) {
        New-Item -ItemType Directory -Path $McpDirectory -Force | Out-Null
    }
    if (-not (Test-Path -Path $registryConfig)) {
        '{}' | Out-File $registryConfig
    }

    $artifactRegistry = Get-Content -Path $registryConfig | ConvertFrom-Json -AsHashtable
    return $artifactRegistry
}

function Set-Registry([string]$packageName, [string]$packageVersion, [string]$packageDirectory, [object]$artifactRegistry) {
    $artifactRegistry[$packageName] = @{}
    $artifactRegistry[$packageName].Version = $packageVersion
    $artifactRegistry[$packageName].Directory = $packageDirectory
    $artifactRegistry | ConvertTo-Json -Depth 10 | Set-Content -Path $registryConfig
}

function Get-LogPath([string]$packageName) {
    $logFile = "$packageName_{0}.log" -f (Get-Date -Format "yyyyMMdd_HHmmss")
    $log = Join-Path (Get-Location) "$logFile.txt"
    $errorLog = Join-Path (Get-Location) "$logFile.error.txt"
    New-Item -ItemType File -Path $log -Force | Out-Null
    return $log, $errorLog
}

function Start-Server-Process([string]$packageName, [string]$filePath, [string]$argumentList, [object]$environment, [string]$log) {
    $log, $errorLog = Get-LogPath $packageName
    $process = Start-Process `
        -FilePath $filePath `
        -ArgumentList $argumentList `
        -RedirectStandardOutput $log -RedirectStandardError $errorLog `
        -Environment $environment `
        -NoNewWindow `
        -PassThru
    return $process, $log, $errorLog
}

function Start-Node-Server([string]$packageName, [int]$port, [string]$feed) {
    if (!(Test-Path .npmrc)) {
        $feedUrl = Get-Feed $feed 'node'
        "registry=https://registry.npmjs.org/" | Out-File .npmrc
        "${packageName}:registry=$feedUrl" | Out-File -Append .npmrc
    }
    if (!(Get-Command npx)) {
        throw "npx must be installed along with node to run js/ts mcp servers: https://nodejs.org/en/download"
    }
    return Start-Server-Process -packageName $packageName -filePath npx -argumentList "-y $packageName" -environment @{ MCP_SSE_PORT = $port } -log $log
}

function Start-Python-Server([string]$packageName, [int]$port, [string]$feed) {
    if (!(Get-Command uvx)) {
        throw "uv/uvx must be installed along with python to run python mcp servers: https://github.com/astral-sh/uv?tab=readme-ov-file#installation"
    }
    $feedUrl = Get-Feed $feed 'python'
    return Start-Server-Process -packageName $packageName -filePath uvx -argumentList "--index $feedUrl $packageName" -environment @{ MCP_SSE_PORT = $port } -log $log
}

function Start-Static-Server([string]$packageName, [string]$packageVersion, [int]$port, [string]$feed) {
    if (!(Test-Path start.ps1)) {
        $feedData = Get-Feed $feed 'static'
        Write-Host "az artifacts universal download --organization $($feedData.Org) --project $($feedData.Project) --scope project --feed $($feedData.Feed) --name $packageName --version $packageVersion --path ."
        $out = az artifacts universal download --organization $feedData.Org --project $feedData.Project --scope project --feed $feedData.Feed --name $packageName --version $packageVersion --path . 2>&1
        Write-Host $out
        chmod +x ./*
    }
    if (!(Test-Path start.ps1)) {
        throw "Static server artifact must contain start.ps1 script"
    }
    return Start-Server-Process -packageName $packageName -filePath pwsh -argumentList "./start.ps1" -environment @{ MCP_SSE_PORT = $port } -log $log
}

function Start-Server([string]$serverType, [string]$packageName, [object]$artifactRegistry, [int]$port, [string]$feed) {
    if (!$artifactRegistry[$packageName]) {
        throw "Package $packageName not found in registry"
    }

    $serverDirectory = $artifactRegistry[$packageName]["Directory"]
    Push-Location -Path $serverDirectory

    try {
        if ($serverType -eq 'node') {
            return Start-Node-Server $packageName $port $feed
        }
        if ($serverType -eq 'python') {
            return Start-Python-Server $packageName $port $feed
        }
        if ($serverType -eq 'static') {
            return Start-Static-Server $packageName $artifactRegistry[$packageName]['Version'] $port $feed
        }
        else {
            throw "MCP server type '$serverType' not supported"
        }
    }
    finally { Pop-Location }
}

function Start-FromConfig([object]$serverConfig) {
    $artifactRegistry = Get-Registry
    foreach ($mcp in $serverConfig) {
        $packageDirectory = "$McpDirectory" + "/" + ($mcp.Package -replace "[^A-Za-z0-9_]", "_") + "_$($mcp.Version)"
        if ((!$artifactRegistry[$mcp.Package] -or $artifactRegistry[$mcp.Package]['Version'] -ne $mcp.Version) -or !(Test-Path -Path $packageDirectory)) {
            New-Item -ItemType Directory -Path $packageDirectory -Force | Out-Null
            Set-Registry $mcp.Package $mcp.Version $packageDirectory $artifactRegistry
        }
    }
    $servers = @()
    foreach ($mcp in $serverConfig) {
        $process, $log, $errorLog = Start-Server $mcp.Type $mcp.Package $artifactRegistry $mcp.Port $mcp.Feed
        $servers += @{ Process = $process; Log = $log; ErrorLog = $errorLog; Package = $mcp.Package }
    }
    return $servers
}

function Main([string]$config) {
    $error.Clear()
    $colors = @("White", "Blue", "Green", "Cyan", "Red", "Magenta", "Yellow", "Gray", "DarkGray", "DarkBlue", "DarkGreen", "DarkCyan", "DarkMagenta", "DarkYellow")
    $serverConfig = Get-Content -Raw $Config | ConvertFrom-Json -AsHashtable

    if ($CreateVSCodeConfig) {
        $mcpConfig = @{ servers = @{} }
        foreach ($mcp in $serverConfig) {
            $mcpConfig.servers[$mcp.Package] = @{
                type = "sse"
                url  = "http://localhost:$($mcp.Port)/sse"
            }
        }

        Write-Host "Creating VSCode config at [$CreateVSCodeConfig]"
        $mcpConfig | ConvertTo-Json -Depth 100 | Set-Content -Path $CreateVSCodeConfig
    }

    if (!$Run) {
        Write-Host "Use -Run to start $($serverConfig.Length) MCP servers"
        return
    }

    try {
        Write-Host "Starting servers..."
        $servers = @(Start-FromConfig $serverConfig)
        $colorIdx = 0
        foreach ($server in $servers) {
            $server['LogColor'] = $colors[$colorIdx]
            $colorIdx++
        }
        $toTail = @()
        foreach ($server in $servers) {
            $toTail += @{ Name = $server.Package; File = $server.Log; Color = $server.LogColor }
            $toTail += @{ Name = $server.Package; File = $server.ErrorLog; Color = "Red" }
        }
        $toTail | ForEach-Object -Parallel {
            $tail = $_
            Write-Host "Tailing logs for [$($tail.Name)] at [$($tail.File)]"
            Get-Content $tail.File -Tail 1 -Wait `
            | ForEach-Object {
                Write-Host -ForegroundColor $tail.Color "[$($tail.Name)] $_"
            }
        }
    }
    finally {
        $error | ForEach-Object {
            $_
        }

        foreach ($servers in $servers) {
            Write-Host "Stopping [$($servers.Package)]"
            $servers.Process | Stop-Process -Force
        }
    }
}

Main $Config
