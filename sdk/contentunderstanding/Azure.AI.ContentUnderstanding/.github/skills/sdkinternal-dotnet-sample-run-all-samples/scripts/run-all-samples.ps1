# Run all Azure SDK samples
# Usage: .\run-all-samples.ps1 [-Live] [-ContinueOnError]

param(
    [switch]$Live,
    [switch]$ContinueOnError,
    [string]$Framework = "net462"
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

# Find SDK directory and samples
$sdkDir = Get-Location
$samplesDir = Join-Path $sdkDir "tests" "samples"
$testsProject = Get-ChildItem -Path (Join-Path $sdkDir "tests") -Filter "*.csproj" | Select-Object -First 1

if (-not (Test-Path $samplesDir)) {
    Write-ColorOutput "Error: Samples directory not found at tests/samples/" "Red"
    exit 1
}

if (-not $testsProject) {
    Write-ColorOutput "Error: No test project found in tests/ directory" "Red"
    exit 1
}

# Set test mode
if ($Live) {
    $env:AZURE_TEST_MODE = "Live"
    Write-ColorOutput "Running in LIVE mode (requires Azure credentials)" "Magenta"
} else {
    $env:AZURE_TEST_MODE = "Playback"
    Write-ColorOutput "Running in PLAYBACK mode" "Cyan"
}

# Get sample files
$sampleFiles = Get-ChildItem -Path $samplesDir -Filter "Sample*.cs" | Sort-Object Name
$sampleCount = $sampleFiles.Count

Write-ColorOutput "Found $sampleCount sample files" "Yellow"
Write-ColorOutput "Framework: $Framework" "Cyan"
Write-ColorOutput "Test Project: $($testsProject.Name)" "Cyan"

# Run all samples using test filter
Write-ColorOutput "`nRunning all samples..." "Yellow"

$filter = "FullyQualifiedName~Samples"

$testArgs = @(
    "test"
    $testsProject.FullName
    "-f", $Framework
    "-v", "n"
    "--filter", $filter
)

& dotnet @testArgs

$exitCode = $LASTEXITCODE

if ($exitCode -eq 0) {
    Write-ColorOutput "`nAll samples executed successfully!" "Green"
} else {
    Write-ColorOutput "`nSome samples failed (exit code: $exitCode)" "Red"
    if (-not $ContinueOnError) {
        exit $exitCode
    }
}

exit $exitCode
