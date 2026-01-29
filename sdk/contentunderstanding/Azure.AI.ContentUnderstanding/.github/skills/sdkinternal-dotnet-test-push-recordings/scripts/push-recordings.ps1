# Push test session recordings to Azure SDK Assets repository
# Usage: .\push-recordings.ps1 [-DryRun]

param(
    [switch]$DryRun
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

# Find assets.json
$sdkDir = Get-Location
$assetsFile = Join-Path $sdkDir "assets.json"

if (-not (Test-Path $assetsFile)) {
    Write-ColorOutput "Error: assets.json not found in current directory" "Red"
    Write-ColorOutput "Are you in the SDK module directory?" "Yellow"
    exit 1
}

# Check if test-proxy is available
$testProxy = Get-Command "test-proxy" -ErrorAction SilentlyContinue
if (-not $testProxy) {
    Write-ColorOutput "Error: test-proxy command not found" "Red"
    Write-ColorOutput "Install test-proxy: dotnet tool install -g Azure.Sdk.Tools.TestProxy" "Yellow"
    exit 1
}

Write-ColorOutput "Pushing recordings to Azure SDK Assets repository..." "Yellow"
Write-ColorOutput "Assets file: $assetsFile" "Cyan"

if ($DryRun) {
    Write-ColorOutput "DRY RUN - No changes will be made" "Magenta"
    
    # Show current assets.json content
    Write-ColorOutput "`nCurrent assets.json:" "Yellow"
    Get-Content $assetsFile | Write-Host
    
    Write-ColorOutput "`nDry run complete. Use without -DryRun to actually push." "Yellow"
    exit 0
}

# Push recordings
Write-ColorOutput "`nExecuting: test-proxy push -a assets.json" "Cyan"
test-proxy push -a $assetsFile

$exitCode = $LASTEXITCODE

if ($exitCode -eq 0) {
    Write-ColorOutput "`nRecordings pushed successfully!" "Green"
    Write-ColorOutput "Don't forget to commit the updated assets.json" "Yellow"
    
    # Show updated assets.json
    Write-ColorOutput "`nUpdated assets.json:" "Yellow"
    Get-Content $assetsFile | Write-Host
} else {
    Write-ColorOutput "`nFailed to push recordings (exit code: $exitCode)" "Red"
    Write-ColorOutput "Check your git credentials and network connection" "Yellow"
}

exit $exitCode
