# Run Azure SDK tests in RECORD mode
# Usage: .\test-record.ps1 [-Filter "TestName"] [-Framework net462]

param(
    [string]$Filter = "",
    [string]$Framework = "net462"
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

# Set test mode to Record
$env:AZURE_TEST_MODE = "Record"

# Find test project
$sdkDir = Get-Location
$testsProject = Get-ChildItem -Path (Join-Path $sdkDir "tests") -Filter "*.csproj" | Select-Object -First 1

if (-not $testsProject) {
    Write-ColorOutput "Error: No test project found in tests/ directory" "Red"
    exit 1
}

Write-ColorOutput "Running tests in RECORD mode..." "Yellow"
Write-ColorOutput "Test Project: $($testsProject.Name)" "Cyan"
Write-ColorOutput "Framework: $Framework" "Cyan"
Write-ColorOutput "AZURE_TEST_MODE: $env:AZURE_TEST_MODE" "Cyan"

# Build command
$testArgs = @(
    "test"
    $testsProject.FullName
    "-f", $Framework
    "-v", "n"
)

if ($Filter) {
    $testArgs += "--filter"
    $testArgs += "FullyQualifiedName~$Filter"
    Write-ColorOutput "Filter: $Filter" "Cyan"
}

Write-ColorOutput "`nStarting test execution..." "Yellow"

# Run tests
& dotnet @testArgs

$exitCode = $LASTEXITCODE

if ($exitCode -eq 0) {
    Write-ColorOutput "`nTests completed successfully in RECORD mode!" "Green"
    Write-ColorOutput "Next step: Push recordings with 'test-proxy push -a assets.json'" "Yellow"
} else {
    Write-ColorOutput "`nTests failed with exit code: $exitCode" "Red"
}

exit $exitCode
