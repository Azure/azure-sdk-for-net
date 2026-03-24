$ErrorActionPreference = "SilentlyContinue"
. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

$cliPath = Get-CommonInstallDirectory

# check for azsdk.exe on Windows or azsdk on Linux/Mac in the install directory, then check for dotnet CLI as fallback since it's required to run the tool
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

$toolsToIgnore = @( "run_in_terminal", "view", "apply_patch")

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
$azsdkToolName = $null
$packageName = $null
$language = $null
$typeSpecProject = $null
$status = $null
$package_type = $null
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
# Copilot CLI: "mcp_azure-sdk*" or "azure-*" prefixes
if ($toolName.StartsWith("mcp_azure-sdk") -or $toolName.StartsWith("azure-sdk-mcp"))
{
    $azsdkToolName = $toolName
    $eventType = "tool_invocation"
    $shouldTrack = $true

    # Parser tool_input and tool output : @{packageName=azure-template; language=python; checkReady=True}
    if ($toolInput)
    {
        # Check if it contains a packageName property and append it to the tool name for more granular telemetry (e.g., "mcp_azure-sdk_template" for the azure-template package)
        $packageName = Get-Property -Object $toolInput -PropertyName "packageName"
        $language = Get-Property -Object $toolInput -PropertyName "language"
        $typeSpecProject = Get-Property -Object $toolInput -PropertyName "typeSpecProject"
    }

    # Get tool output arguments
    $toolOutput = $null
    try
    {
        if ($inputData.PSObject.Properties['toolResult'])
        {
            # toolResult exists
            $toolOutput = $inputData.toolResult | ConvertFrom-Json
        }
        elseif ($inputData.PSObject.Properties['tool_response'])
        {
            # tool_response exists
            $toolOutput = $inputData.tool_response | ConvertFrom-Json
        }

        if ($toolOutput -and $toolOutput.PSObject.Properties['textResultForLlm'])
        {
            $toolOutput = $toolOutput.textResultForLlm | ConvertFrom-Json
        }
    }
    catch
    {
        Write-Success
    }       
    
    # Process tool output for mcp tool calls
    if ($toolOutput)
    {
        # Some tools may return the packageName in the output instead of input, so also check there
        if (-not $packageName)
        {
            $packageName = Get-Property -Object $toolOutput -PropertyName "packageName"
        }
        if (-not $language)
        {
            $language = Get-Property -Object $toolOutput -PropertyName "language"
        }
        if (-not $typeSpecProject)
        {
            $typeSpecProject = Get-Property -Object $toolOutput -PropertyName "typeSpecProject"
        }
        $status = Get-Property -Object $toolOutput -PropertyName "operation_status"
        $package_type = Get-Property -Object $toolOutput -PropertyName "package_type"
    }
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
    if ($azsdkToolName) { $cliArgs += "--tool-name"; $cliArgs += $azsdkToolName }
    if ($packageName) { $cliArgs += "--package-name"; $cliArgs += $packageName }
    if ($language) { $cliArgs += "--language"; $cliArgs += $language }
    if ($typeSpecProject) { $cliArgs += "--type-spec-project"; $cliArgs += $typeSpecProject }
    if ($status) { $cliArgs += "--operation-status"; $cliArgs += $status }
    if ($package_type) { $cliArgs += "--package-type"; $cliArgs += $package_type }
    
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