#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Smoke-tests that the Azure Generator Agent MCP server starts and responds.

.DESCRIPTION
    Launches the Generator Agent over stdio exactly as the cloud agent does
    (see .mcp.json), performs an MCP `initialize` + `tools/list` handshake, and
    asserts that the server identifies itself and exposes its repair tools.

    Exits 0 on success; exits 1 (failing the calling CI step) if the server does
    not start, does not respond within the timeout, or does not advertise the
    expected tools. This guards against regressions that would silently break the
    cloud-agent repair flow.
#>
[CmdletBinding()]
param(
    [int]$TimeoutSeconds = 120
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
$project = 'sdk/tools/Azure.GeneratorAgent/src/Azure.GeneratorAgent.csproj'
$requiredTools = @('build_and_classify', 'classify_errors', 'verify_generated_unchanged')

Write-Host "Repo root: $repoRoot"
Write-Host "Launching Generator Agent MCP server (dotnet run --project $project)..."

$psi = [System.Diagnostics.ProcessStartInfo]::new()
$psi.FileName = 'dotnet'
foreach ($a in @('run', '--project', $project, '--framework', 'net10.0', '--', '--mcp-server')) {
    $psi.ArgumentList.Add($a)
}
$psi.WorkingDirectory = $repoRoot
$psi.RedirectStandardInput = $true
$psi.RedirectStandardOutput = $true
$psi.RedirectStandardError = $true
$psi.UseShellExecute = $false

$proc = [System.Diagnostics.Process]::new()
$proc.StartInfo = $psi

$stdout = [System.Collections.Concurrent.ConcurrentQueue[string]]::new()
$outHandler = {
    if ($null -ne $EventArgs.Data) { $Event.MessageData.Enqueue($EventArgs.Data) }
}
Register-ObjectEvent -InputObject $proc -EventName OutputDataReceived -Action $outHandler -MessageData $stdout | Out-Null

try {
    [void]$proc.Start()
    $proc.BeginOutputReadLine()

    function Send-Message($obj) {
        $json = $obj | ConvertTo-Json -Depth 10 -Compress
        $proc.StandardInput.WriteLine($json)
        $proc.StandardInput.Flush()
    }

    Send-Message @{ jsonrpc = '2.0'; id = 1; method = 'initialize'; params = @{ protocolVersion = '2024-11-05'; capabilities = @{}; clientInfo = @{ name = 'verify'; version = '1.0' } } }
    Start-Sleep -Seconds 2
    Send-Message @{ jsonrpc = '2.0'; method = 'notifications/initialized' }
    Send-Message @{ jsonrpc = '2.0'; id = 2; method = 'tools/list' }

    $sw = [System.Diagnostics.Stopwatch]::StartNew()
    $sawInit = $false
    $toolNames = [System.Collections.Generic.HashSet[string]]::new()

    while ($sw.Elapsed.TotalSeconds -lt $TimeoutSeconds) {
        $line = $null
        if ($stdout.TryDequeue([ref]$line)) {
            try { $msg = $line | ConvertFrom-Json } catch { continue }
            if ($msg.PSObject.Properties.Name -contains 'id' -and $msg.id -eq 1 -and $msg.PSObject.Properties.Name -contains 'result') {
                $name = $msg.result.serverInfo.name
                Write-Host "initialize OK -> serverInfo.name = $name"
                $sawInit = $true
            }
            if ($msg.PSObject.Properties.Name -contains 'id' -and $msg.id -eq 2 -and $msg.PSObject.Properties.Name -contains 'result') {
                foreach ($t in $msg.result.tools) { [void]$toolNames.Add($t.name) }
                Write-Host "tools/list OK -> $($toolNames.Count) tools advertised"
                break
            }
        }
        else {
            if ($proc.HasExited) { break }
            Start-Sleep -Milliseconds 100
        }
    }

    if (-not $sawInit) {
        Write-Error "MCP server did not return an initialize response within $TimeoutSeconds s."
        exit 1
    }

    $missing = $requiredTools | Where-Object { -not $toolNames.Contains($_) }
    if ($missing) {
        Write-Error "MCP server is missing expected tools: $($missing -join ', '). Advertised: $($toolNames -join ', ')"
        exit 1
    }

    Write-Host "SUCCESS: Generator Agent MCP server started and advertised the expected repair tools."
    exit 0
}
finally {
    if ($proc -and -not $proc.HasExited) {
        try { $proc.StandardInput.Close() } catch {}
        Start-Sleep -Milliseconds 500
        if (-not $proc.HasExited) { try { $proc.Kill($true) } catch {} }
    }
    Get-EventSubscriber | Where-Object { $_.SourceObject -eq $proc } | Unregister-Event -ErrorAction SilentlyContinue
}
