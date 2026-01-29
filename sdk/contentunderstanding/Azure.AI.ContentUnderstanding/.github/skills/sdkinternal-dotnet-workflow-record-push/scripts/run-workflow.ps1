# Complete workflow: Record tests and push recordings
# Usage: .\run-workflow.ps1 [-SkipCompile] [-SkipVerify] [-Filter "TestName"]

param(
    [switch]$SkipCompile,
    [switch]$SkipVerify,
    [string]$Filter = "",
    [string]$Framework = "net462"
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

function Write-Step {
    param([int]$Step, [string]$Title)
    Write-ColorOutput "`n========================================" "Cyan"
    Write-ColorOutput "Step $Step`: $Title" "Cyan"
    Write-ColorOutput "========================================" "Cyan"
}

$sdkDir = Get-Location
$skillsDir = Join-Path $sdkDir ".github" "skills"
$startTime = Get-Date

Write-ColorOutput "Azure SDK Workflow: Record and Push" "Yellow"
Write-ColorOutput "Started at: $startTime" "Gray"

# Step 1: Setup Environment
Write-Step 1 "Setup Environment"
$envScript = Join-Path $skillsDir "sdkinternal-dotnet-env-setup" "scripts" "load-env.ps1"
if (Test-Path $envScript) {
    . $envScript
} else {
    Write-ColorOutput "Warning: load-env.ps1 not found, skipping environment setup" "Yellow"
}

# Step 2: Compile SDK
if (-not $SkipCompile) {
    Write-Step 2 "Compile SDK"
    $compileScript = Join-Path $skillsDir "sdkinternal-dotnet-sdk-compile" "scripts" "compile.ps1"
    if (Test-Path $compileScript) {
        & $compileScript
        if ($LASTEXITCODE -ne 0) {
            Write-ColorOutput "Compilation failed. Aborting workflow." "Red"
            exit $LASTEXITCODE
        }
    } else {
        dotnet build
        if ($LASTEXITCODE -ne 0) {
            Write-ColorOutput "Compilation failed. Aborting workflow." "Red"
            exit $LASTEXITCODE
        }
    }
} else {
    Write-ColorOutput "Skipping compilation (--skip-compile)" "Yellow"
}

# Step 3: Record Tests
Write-Step 3 "Record Tests"
$env:AZURE_TEST_MODE = "Record"
$testsProject = Get-ChildItem -Path (Join-Path $sdkDir "tests") -Filter "*.csproj" | Select-Object -First 1

$testArgs = @("test", $testsProject.FullName, "-f", $Framework, "-v", "n")
if ($Filter) {
    $testArgs += "--filter"
    $testArgs += "FullyQualifiedName~$Filter"
}

& dotnet @testArgs
if ($LASTEXITCODE -ne 0) {
    Write-ColorOutput "Recording failed. Aborting workflow." "Red"
    exit $LASTEXITCODE
}

# Step 4: Push Recordings
Write-Step 4 "Push Recordings"
$assetsFile = Join-Path $sdkDir "assets.json"
if (Test-Path $assetsFile) {
    test-proxy push -a $assetsFile
    if ($LASTEXITCODE -ne 0) {
        Write-ColorOutput "Push failed. Aborting workflow." "Red"
        exit $LASTEXITCODE
    }
} else {
    Write-ColorOutput "Warning: assets.json not found, skipping push" "Yellow"
}

# Step 5: Verify Playback
if (-not $SkipVerify) {
    Write-Step 5 "Verify Playback"
    $env:AZURE_TEST_MODE = "Playback"
    
    & dotnet @testArgs
    if ($LASTEXITCODE -ne 0) {
        Write-ColorOutput "Playback verification failed!" "Red"
        exit $LASTEXITCODE
    }
} else {
    Write-ColorOutput "Skipping playback verification (--skip-verify)" "Yellow"
}

# Summary
$endTime = Get-Date
$duration = $endTime - $startTime

Write-ColorOutput "`n========================================" "Green"
Write-ColorOutput "Workflow Completed Successfully!" "Green"
Write-ColorOutput "========================================" "Green"
Write-ColorOutput "Duration: $($duration.TotalMinutes.ToString('F1')) minutes" "Gray"
Write-ColorOutput "`nNext steps:" "Yellow"
Write-ColorOutput "  1. Review the updated assets.json" "White"
Write-ColorOutput "  2. Commit your changes" "White"
Write-ColorOutput "  3. Create a pull request" "White"
