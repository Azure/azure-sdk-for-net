# Run a single Azure SDK sample
# Usage: .\run-sample.ps1 -SampleName "Sample01_AnalyzeBinary" [-Live] [-List]

param(
    [string]$SampleName = "",
    [switch]$Live,
    [switch]$List,
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

# List available samples
if ($List) {
    Write-ColorOutput "Available sample methods:" "Yellow"
    Write-ColorOutput "(Use these names with -SampleName)" "Gray"
    
    # List test methods from sample files
    Get-ChildItem -Path $samplesDir -Filter "Sample*.cs" | ForEach-Object {
        $fileName = $_.BaseName
        $content = Get-Content $_.FullName -Raw
        
        # Extract method names with [RecordedTest] or [Test] attribute
        $methodMatches = [regex]::Matches($content, '\[(RecordedTest|Test)\][^\{]*public\s+async\s+Task\s+(\w+)\s*\(')
        foreach ($m in $methodMatches) {
            $methodName = $m.Groups[2].Value
            Write-Host "  $methodName" -ForegroundColor Cyan -NoNewline
            Write-Host " ($fileName)" -ForegroundColor DarkGray
        }
    }
    exit 0
}

# Validate sample name
if ([string]::IsNullOrEmpty($SampleName)) {
    Write-ColorOutput "Error: Sample name is required" "Red"
    Write-ColorOutput "Usage: .\run-sample.ps1 -SampleName `"Sample01_AnalyzeBinary`"" "Yellow"
    Write-ColorOutput "Use -List to see available samples" "Yellow"
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

Write-ColorOutput "Running sample: $SampleName" "Yellow"
Write-ColorOutput "Framework: $Framework" "Cyan"

# Build filter - match class name or method containing the sample name
$filter = "FullyQualifiedName~$SampleName"

# Run the sample
$testArgs = @(
    "test"
    $testsProject.FullName
    "-f", $Framework
    "-v", "n"
    "--filter", $filter
)

Write-ColorOutput "`nExecuting sample..." "Yellow"
& dotnet @testArgs

$exitCode = $LASTEXITCODE

if ($exitCode -eq 0) {
    Write-ColorOutput "`nSample executed successfully!" "Green"
} else {
    Write-ColorOutput "`nSample failed with exit code: $exitCode" "Red"
}

exit $exitCode
