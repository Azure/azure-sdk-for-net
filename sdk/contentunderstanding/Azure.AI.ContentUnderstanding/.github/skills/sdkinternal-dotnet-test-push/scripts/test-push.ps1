<#
.SYNOPSIS
    Push test recordings to Azure SDK Assets repository.

.DESCRIPTION
    Pushes recordings only, or runs a complete record → push → verify workflow.

.PARAMETER DryRun
    Preview what would be pushed without actually pushing.

.PARAMETER Workflow
    Run full record → push → verify workflow.

.PARAMETER SkipCompile
    Skip compilation step (workflow mode).

.PARAMETER SkipVerify
    Skip playback verification (workflow mode).

.PARAMETER Filter
    Filter tests by name (workflow mode).

.PARAMETER Framework
    Target framework (default: net10.0).
#>

param(
    [switch]$DryRun,
    [switch]$Workflow,
    [switch]$SkipCompile,
    [switch]$SkipVerify,
    [string]$Filter = "",
    [string]$Framework = "net10.0"
)

$ErrorActionPreference = "Stop"

# ── Ensure dotnet is on PATH ──────────────────────────────────────────────────
if (-not (Get-Command "dotnet" -ErrorAction SilentlyContinue)) {
    $dotnetHome = Join-Path $env:HOME ".dotnet"
    $dotnetUser = Join-Path $env:USERPROFILE ".dotnet"
    if (Test-Path (Join-Path $dotnetHome "dotnet")) {
        $env:PATH = "$dotnetHome" + [System.IO.Path]::PathSeparator + $env:PATH
    } elseif (Test-Path (Join-Path $dotnetUser "dotnet.exe")) {
        $env:PATH = "$dotnetUser" + [System.IO.Path]::PathSeparator + $env:PATH
    } else {
        Write-Host "Error: dotnet command not found" -ForegroundColor Red
        Write-Host "Install .NET SDK: https://dot.net/download" -ForegroundColor Yellow
        exit 1
    }
}

# ── Helper: find test-proxy executable ────────────────────────────────────────
function Find-TestProxy {
    if (Get-Command "test-proxy" -ErrorAction SilentlyContinue) {
        return "test-proxy"
    } elseif (Get-Command "Azure.Sdk.Tools.TestProxy" -ErrorAction SilentlyContinue) {
        return "Azure.Sdk.Tools.TestProxy"
    }
    return $null
}

# ── Locate project ───────────────────────────────────────────────────────────
$SdkDir = Get-Location
$AssetsFile = Join-Path $SdkDir "assets.json"
$SkillsDir = Join-Path $SdkDir ".github/skills"

function Write-Step {
    param([int]$Num, [string]$Title)
    Write-Host ""
    Write-Host "════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host "  Step ${Num}: $Title" -ForegroundColor Cyan
    Write-Host "════════════════════════════════════════" -ForegroundColor Cyan
}

# ══════════════════════════════════════════════════════════════════════════════
#  Push Only (no -Workflow)
# ══════════════════════════════════════════════════════════════════════════════
if (-not $Workflow) {
    # Validate assets.json
    if (-not (Test-Path $AssetsFile)) {
        Write-Host "Error: assets.json not found in current directory" -ForegroundColor Red
        Write-Host "Are you in the SDK module directory?" -ForegroundColor Yellow
        exit 1
    }

    Write-Host "═══════════════════════════════════════════════════════════"
    Write-Host "  Azure SDK Test Push"
    Write-Host "═══════════════════════════════════════════════════════════"
    Write-Host ""
    Write-Host "Assets file: $AssetsFile" -ForegroundColor Cyan

    # Dry run (no test-proxy needed)
    if ($DryRun) {
        Write-Host "DRY RUN — No changes will be made" -ForegroundColor Magenta
        Write-Host ""
        Write-Host "Current assets.json:" -ForegroundColor Yellow
        Get-Content $AssetsFile
        Write-Host ""
        Write-Host "Dry run complete. Use without -DryRun to actually push." -ForegroundColor Yellow
        exit 0
    }

    # Push recordings
    $testProxyExe = Find-TestProxy
    if (-not $testProxyExe) {
        Write-Host "Error: test-proxy command not found" -ForegroundColor Red
        Write-Host "Install via repo script: .\eng\common\testproxy\install-test-proxy.ps1" -ForegroundColor Yellow
        Write-Host "Or see: https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation" -ForegroundColor Yellow
        exit 1
    }

    Write-Host "Pushing recordings to Azure SDK Assets repository..." -ForegroundColor Yellow
    Write-Host "Executing: $testProxyExe push -a assets.json" -ForegroundColor Cyan

    & $testProxyExe push -a $AssetsFile
    $exitCode = $LASTEXITCODE

    if ($exitCode -eq 0) {
        Write-Host "`nRecordings pushed successfully!" -ForegroundColor Green
        Write-Host "Don't forget to commit the updated assets.json" -ForegroundColor Yellow
        Write-Host ""
        Write-Host "Updated assets.json:" -ForegroundColor Yellow
        Get-Content $AssetsFile
    } else {
        Write-Host "`nFailed to push recordings (exit code: $exitCode)" -ForegroundColor Red
        Write-Host "Check your git credentials and network connection" -ForegroundColor Yellow
    }

    exit $exitCode
}

# ══════════════════════════════════════════════════════════════════════════════
#  Full Workflow: Record → Push → Verify
# ══════════════════════════════════════════════════════════════════════════════
$startTime = Get-Date

Write-Host "═══════════════════════════════════════════════════════════"
Write-Host "  Azure SDK Workflow: Record and Push"
Write-Host "═══════════════════════════════════════════════════════════"
Write-Host "Started at: $(Get-Date)" -ForegroundColor DarkGray

# ── Step 1: Setup Environment ────────────────────────────────────────────────
Write-Step 1 "Setup Environment"
$envScript = Join-Path $SkillsDir "sdkinternal-dotnet-env-setup/scripts/load-env.ps1"
if (Test-Path $envScript) {
    . $envScript
} else {
    Write-Host "Warning: load-env.ps1 not found, skipping environment setup" -ForegroundColor Yellow
}

# ── Step 2: Compile SDK ──────────────────────────────────────────────────────
if (-not $SkipCompile) {
    Write-Step 2 "Compile SDK"
    $compileScript = Join-Path $SkillsDir "sdkinternal-dotnet-sdk-compile/scripts/compile.ps1"
    if (Test-Path $compileScript) {
        & $compileScript
        if ($LASTEXITCODE -ne 0) {
            Write-Host "Compilation failed. Aborting workflow." -ForegroundColor Red
            exit 1
        }
    } else {
        dotnet build
        if ($LASTEXITCODE -ne 0) {
            Write-Host "Compilation failed. Aborting workflow." -ForegroundColor Red
            exit 1
        }
    }
} else {
    Write-Host "Skipping compilation (-SkipCompile)" -ForegroundColor Yellow
}

# ── Step 3: Record Tests ─────────────────────────────────────────────────────
Write-Step 3 "Record Tests"
$env:AZURE_TEST_MODE = "Record"
$TestsDir = Join-Path $SdkDir "tests"
$TestsProject = Get-ChildItem -Path "$TestsDir/*.csproj" -ErrorAction SilentlyContinue | Select-Object -First 1

if (-not $TestsProject) {
    Write-Host "Error: No test project found in tests/ directory" -ForegroundColor Red
    exit 1
}

$testArgs = @("test", $TestsProject.FullName, "-f", $Framework, "-v", "n")
if ($Filter) {
    $testArgs += @("--filter", "FullyQualifiedName~$Filter")
    Write-Host "Filter: $Filter" -ForegroundColor Cyan
}

dotnet @testArgs
if ($LASTEXITCODE -ne 0) {
    Write-Host "Recording failed. Aborting workflow." -ForegroundColor Red
    exit 1
}

# ── Step 4: Push Recordings ──────────────────────────────────────────────────
Write-Step 4 "Push Recordings"
if (Test-Path $AssetsFile) {
    $testProxyExe = Find-TestProxy
    if (-not $testProxyExe) {
        Write-Host "Error: test-proxy command not found" -ForegroundColor Red
        Write-Host "Install via repo script: .\eng\common\testproxy\install-test-proxy.ps1" -ForegroundColor Yellow
        exit 1
    }

    & $testProxyExe push -a $AssetsFile
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Push failed. Aborting workflow." -ForegroundColor Red
        exit 1
    }
} else {
    Write-Host "Warning: assets.json not found, skipping push" -ForegroundColor Yellow
}

# ── Step 5: Verify Playback ──────────────────────────────────────────────────
if (-not $SkipVerify) {
    Write-Step 5 "Verify Playback"
    $env:AZURE_TEST_MODE = "Playback"

    dotnet @testArgs
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Playback verification failed!" -ForegroundColor Red
        exit 1
    }
} else {
    Write-Host "Skipping playback verification (-SkipVerify)" -ForegroundColor Yellow
}

# ── Summary ───────────────────────────────────────────────────────────────────
$duration = (Get-Date) - $startTime
$minutes = [math]::Floor($duration.TotalMinutes)
$seconds = $duration.Seconds

Write-Host ""
Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Green
Write-Host "  Workflow Completed Successfully!" -ForegroundColor Green
Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Green
Write-Host "Duration: ${minutes}m ${seconds}s" -ForegroundColor DarkGray
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "  1. Review the updated assets.json"
Write-Host "  2. Commit your changes"
Write-Host "  3. Create a pull request"
