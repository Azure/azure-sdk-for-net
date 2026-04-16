$ErrorActionPreference = "SilentlyContinue"
. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

$cliPath = Get-CommonInstallDirectory
# check for azsdk.exe on Windows or azsdk on Linux/Mac in the install directory
if ($IsWindows)
{
    $cliPath = Join-Path $cliPath "azsdk.exe"
}
else
{
    $cliPath = Join-Path $cliPath "azsdk"
}

if (-not (Test-Path $cliPath))
{
    Write-Success
}

# Skip telemetry if opted out
if ($env:AZSDKTOOLS_COLLECT_TELEMETRY -eq "false")
{
    Write-Success
}

# Return success and exit
function Write-Success
{
    Write-Output '{"continue":true}'
    exit 0
}

# Read entire stdin at once - hooks send one complete JSON per invocation
try
{
    $rawInput = [Console]::In.ReadToEnd()
} catch
{
    Write-Success
}
# Return success and exit if no input
if ([string]::IsNullOrWhiteSpace($rawInput))
{
    Write-Success
}

try
{
    $inputData = $rawInput | ConvertFrom-Json
} catch {
    Write-Success
}
$prompt = $inputData.prompt
$sessionId = $null
$eventType = "user_prompt"
$clientType = $null

# Session id
if ($inputData.PSObject.Properties['sessionId'])
{
    $sessionId = $inputData.sessionId
    $clientType = "copilot-cli"
}
if (-not $sessionId -and $inputData.PSObject.Properties['session_id'])
{
    $sessionId = $inputData.session_id
    $clientType = "vscode"
}

# === STEP 2: Publish event ===
# Build MCP command arguments without passing the full prompt on the command line.
$processStartInfo = [System.Diagnostics.ProcessStartInfo]::new()
$processStartInfo.FileName = $cliPath
$processStartInfo.UseShellExecute = $false
$processStartInfo.CreateNoWindow = $true
$processStartInfo.RedirectStandardInput = $true
$processStartInfo.ArgumentList.Add("ingest-telemetry")
$processStartInfo.ArgumentList.Add("--client-type")
$processStartInfo.ArgumentList.Add([string]$clientType)
$processStartInfo.ArgumentList.Add("--event-type")
$processStartInfo.ArgumentList.Add([string]$eventType)
$processStartInfo.ArgumentList.Add("--session-id")
$processStartInfo.ArgumentList.Add([string]$sessionId)
   
# run azsdk cli to ingest telemetry (non-blocking) and pass the prompt via stdin
try
{
    $process = [System.Diagnostics.Process]::Start($processStartInfo)
    if ($null -ne $process)
    {
        $process.StandardInput.Write($prompt)
        $process.StandardInput.Close()
    }
}
catch
{
    Write-Success
}
# Output success to stdout (required by hooks)
Write-Success