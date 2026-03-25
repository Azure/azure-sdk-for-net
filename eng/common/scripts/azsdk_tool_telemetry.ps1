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
    Write-Output '{"continue":true}'
    exit 0
}

$toolsToIgnore = @( "run_in_terminal", "apply_patch")

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

$toolName = $inputData.toolName
if (-not $toolName)
{
    $toolName = $inputData.tool_name
}

# Skip if no tool name found in either format
if (-not $toolName)
{
    Write-Success
}

# Check if tool name is in ignore list
if ($toolsToIgnore -contains $toolName)
{
    Write-Success
}

$sessionId = $inputData.sessionId
if (-not $sessionId) {
    $sessionId = $inputData.session_id
}

# Get tool input arguments
$toolInput = $inputData.toolArgs
if (-not $toolInput)
{
    $toolInput = $inputData.tool_input
}

$timestamp = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")

# Helper to extract path from tool input (handles 'path', 'filePath', 'file_path')
function Get-ToolInputPath
{
    if ($toolInput.path) { return $toolInput.path }
    if ($toolInput.filePath) { return $toolInput.filePath }
    if ($toolInput.file_path) { return $toolInput.file_path }
    return $null
}

# === STEP 2: Determine what to track ===

$shouldTrack = $false
$eventType = $null
$skillName = $null
$clientType = $null

# check if hook is triggered from vscode or copilot-cli. Azure sdk tools hook is not considering claude at this point.
if ($inputData.PSObject.Properties['tool_use_id'] -and $inputData.tool_use_id -match ".*_vscode-.*")
{
    $clientType = "vscode"
}
else
{
    $clientType = "copilot-cli"
}

# Process skill invocations (looking for "azsdk" prefix in skill name)
if ($toolName -eq "skill")
{
    $skillName = $toolInput.skill
    if ($skillName -and $skillName.StartsWith("azsdk"))
    {
        $eventType = "skill_invocation"
        $shouldTrack = $true
    }
}

# Check for skill invocation (reading SKILL.md files)
if ($toolName -eq "view" -or $toolName -eq "read_file")
{
    $pathToCheck = Get-ToolInputPath
    if ($pathToCheck)
    {
        # replace backslashes and squeeze consecutive slashes
        $pathNormalized = $pathToCheck -replace '\\', '/' -replace '/+', '/'
        if ($pathNormalized -match "/skills/([^/]+)/SKILL\.md$")
        {
                $skillName = $Matches[1]
                $eventType = "skill_invocation"
                $shouldTrack = $true
        }
    }
}

# Find property from tool input or output
function Get-Property
{
    param (
        [object]$Object,
        [string]$PropertyName
    )

    if ($Object -and $Object.PSObject.Properties[$PropertyName])
    {
        return $Object.PSObject.Properties[$PropertyName].Value
    }
    return $null
}

# Check for Azure SDK Tools MCP invocation
# Skip mcp tool telemetry since it's already tracked by MCP server
if ($toolName.StartsWith("mcp_azure-sdk") -or $toolName.StartsWith("azure-sdk-mcp"))
{
    Write-Success
}

# === STEP 3: Publish event ===

if ($shouldTrack)
{
    # Build MCP command arguments
    $cliArgs = @(
        "ingest-telemetry",
        "--timestamp", $timestamp,
        "--client-type", $clientType
    )

    if ($eventType) { $cliArgs += "--event-type"; $cliArgs += $eventType }
    if ($sessionId) { $cliArgs += "--session-id"; $cliArgs += $sessionId }
    if ($skillName) { $cliArgs += "--skill-name"; $cliArgs += $skillName }
    
    # run azsdk cli to ingest telemetry (non-blocking)
    try
    {
        Start-Process -FilePath $cliPath -ArgumentList $cliArgs -NoNewWindow
    }
    catch {
        Write-Success
    }
}
# Output success to stdout (required by hooks)
Write-Success