#Requires -Version 7.0

<#
.SYNOPSIS
    Regenerates management SDK folders using local generator build.

.DESCRIPTION
    Builds the mgmt generator locally and regenerates SDK folders using TypeSpec.
    Does NOT modify package.json files or create versioned packages.
    By default, regenerates ALL mgmt SDKs. Use -Services to limit scope.
    
    Pattern matching: The -Services parameter uses substring matching.
    For example, "Key" matches both "KeyVault" and "MyKeyService".
    Use wildcards for more precise matching (e.g., "KeyVault*").

.PARAMETER Services
    One or more service name patterns to regenerate (e.g., "KeyVault", "Compute").
    Supports wildcards. Case-insensitive. Uses substring matching.

.PARAMETER Parallel
    Number of parallel jobs (default: 4, min: 1). Set to 1 for sequential execution.

.PARAMETER SaveInputs
    When specified, passes save-inputs=true to the emitter to preserve tspCodeModel.json for debugging.

.PARAMETER DebugGenerator
    When specified, passes debug=true to the emitter to enable attaching a debugger to the generator process.

.NOTES
    Prerequisites: git, npm, dotnet, and npx must be installed and in PATH.
    The powershell-yaml module will be auto-installed if not present.

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "KeyVault"

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "KeyVault","Compute","Network"

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "Key*" -Parallel 8
#>

param(
    [string[]]$Services,
    [ValidateRange(1, [int]::MaxValue)]
    [int]$Parallel = 4,
    [switch]$SaveInputs,
    [switch]$DebugGenerator
)

$ErrorActionPreference = 'Stop'

# Check prerequisites
function Test-Prerequisite {
    param([string]$Command, [string]$Name)
    if (-not (Get-Command $Command -ErrorAction SilentlyContinue)) {
        throw "$Name is required but not found in PATH. Please install $Name and try again."
    }
}

Test-Prerequisite "git" "Git"
Test-Prerequisite "npm" "npm (Node.js)"
Test-Prerequisite "dotnet" ".NET SDK"

# Resolve paths
$mgmtPackageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
$sdkRepoRoot = Resolve-Path (Join-Path $mgmtPackageRoot '..' '..' '..')
$sdkRoot = Join-Path $sdkRepoRoot "sdk"

# Validate paths
if (-not (Test-Path $sdkRoot)) {
    throw "SDK folder not found: $sdkRoot"
}

Write-Host "=== Local Mgmt SDK Regeneration ==="
Write-Host "Mgmt Generator: $mgmtPackageRoot"
Write-Host "SDK Root: $sdkRepoRoot"

# Step 1: Build generator
Write-Host "`n[1/3] Building Mgmt generator..."
Push-Location $mgmtPackageRoot
try {
    if (-not (Test-Path "node_modules")) {
        Write-Host "  npm install..."
        $output = npm install 2>&1
        if ($LASTEXITCODE -ne 0) {
            Write-Host "  ERROR: npm install failed:" -ForegroundColor Red
            $output | ForEach-Object { Write-Host "    $_" }
            throw "npm install failed with exit code $LASTEXITCODE"
        }
    }
    Write-Host "  npm run build:emitter..."
    $output = npm run build:emitter 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "  ERROR: npm run build:emitter failed:" -ForegroundColor Red
        $output | ForEach-Object { Write-Host "    $_" }
        throw "npm run build:emitter failed with exit code $LASTEXITCODE"
    }
    Write-Host "  dotnet build..."
    $output = dotnet build ./generator/Azure.Generator.Management/src -c Debug --verbosity quiet 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "  ERROR: dotnet build failed:" -ForegroundColor Red
        $output | ForEach-Object { Write-Host "    $_" }
        throw "dotnet build failed with exit code $LASTEXITCODE"
    }
    Write-Host "  Build complete."
}
finally {
    Pop-Location
}

# Step 2: Find mgmt SDK folders
Write-Host "`n[2/3] Scanning for mgmt SDKs..."
$mgmtSdkFolders = @()
$tspFiles = Get-ChildItem -Path $sdkRoot -Recurse -Filter "tsp-location.yaml" -ErrorAction SilentlyContinue

foreach ($tspFile in $tspFiles) {
    $content = Get-Content $tspFile.FullName -Raw -ErrorAction SilentlyContinue
    if ($content -match 'azure-typespec-http-client-csharp-mgmt-emitter-package') {
        $mgmtSdkFolders += @{
            Path = $tspFile.Directory.FullName
            Library = Split-Path $tspFile.Directory.FullName -Leaf
            Service = Split-Path (Split-Path $tspFile.Directory.FullName -Parent) -Leaf
        }
    }
}

Write-Host "Found $($mgmtSdkFolders.Count) mgmt SDK folders"

# Apply services filter
if ($Services -and $Services.Count -gt 0) {
    $mgmtSdkFolders = @($mgmtSdkFolders | Where-Object { 
        $folder = $_
        $Services | Where-Object { $folder.Library -like "*$_*" -or $folder.Service -like "*$_*" }
    })
    Write-Host "Filtered to $($mgmtSdkFolders.Count) matching: $($Services -join ', ')"
}

if ($mgmtSdkFolders.Count -eq 0) {
    Write-Host "No matching SDK folders found."
    exit 0
}

# If no filter specified, regenerate all by default
$selectedFolders = $mgmtSdkFolders
Write-Host "Selected $($selectedFolders.Count) SDKs for regeneration"

# Step 3: Regenerate
Write-Host "`n[3/3] Regenerating ($Parallel parallel jobs)..."
$totalStart = Get-Date
$workerScript = Join-Path $PSScriptRoot "Invoke-SdkRegeneration.ps1"

# Run regeneration (parallel or sequential)
if ($Parallel -gt 1 -and $selectedFolders.Count -gt 1) {
    $results = $selectedFolders | ForEach-Object -ThrottleLimit $Parallel -Parallel {
        $folder = $_
        $mgmtPkgRoot = $using:mgmtPackageRoot
        $sdkRepo = $using:sdkRepoRoot
        $worker = $using:workerScript
        $saveInputsFlag = $using:SaveInputs
        $debugFlag = $using:DebugGenerator
        
        $result = @{ Library = $folder.Library; Success = $false; Error = ""; Elapsed = 0 }
        $start = Get-Date
        
        try {
            $output = & $worker -ProjectPath $folder.Path -MgmtPackageRoot $mgmtPkgRoot -SdkRepoRoot $sdkRepo -SaveInputs:$saveInputsFlag -DebugGenerator:$debugFlag 2>&1
            $jsonLine = $output | Where-Object { $_ -match '^\{.*\}$' } | Select-Object -Last 1
            if ($jsonLine) {
                $workerResult = $jsonLine | ConvertFrom-Json
                $result.Success = $workerResult.Success
                $result.Error = $workerResult.Error
            } else {
                throw "Worker script did not return valid result"
            }
        }
        catch {
            $result.Error = $_.ToString()
        }
        
        $result.Elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
        
        # Output progress
        if ($result.Success) {
            Write-Host "  $($result.Library): OK ($($result.Elapsed)s)"
        } else {
            Write-Host "  $($result.Library): FAILED - $($result.Error)"
        }
        
        $result
    }
} else {
    $results = @()
    foreach ($folder in $selectedFolders) {
        Write-Host "`n  $($folder.Library)..."
        
        $result = @{ Library = $folder.Library; Success = $false; Error = ""; Elapsed = 0 }
        $start = Get-Date
        
        try {
            $output = & $workerScript -ProjectPath $folder.Path -MgmtPackageRoot $mgmtPackageRoot -SdkRepoRoot $sdkRepoRoot -SaveInputs:$SaveInputs -DebugGenerator:$DebugGenerator 2>&1
            $jsonLine = $output | Where-Object { $_ -match '^\{.*\}$' } | Select-Object -Last 1
            if ($jsonLine) {
                $workerResult = $jsonLine | ConvertFrom-Json
                $result.Success = $workerResult.Success
                $result.Error = $workerResult.Error
            } else {
                throw "Worker script did not return valid result"
            }
        }
        catch {
            $result.Error = $_.ToString()
        }
        
        $result.Elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
        
        if ($result.Success) {
            Write-Host "    OK ($($result.Elapsed)s)"
        } else {
            Write-Host "    FAILED: $($result.Error)"
        }
        $results += $result
    }
}

# Summary
$totalElapsed = [math]::Round(((Get-Date) - $totalStart).TotalSeconds, 1)
$passed = @($results | Where-Object { $_.Success -eq $true }).Count
$failed = @($results | Where-Object { $_.Success -ne $true }).Count
Write-Host "`n=== Summary: $passed passed, $failed failed (${totalElapsed}s total) ==="

if ($failed -gt 0) { exit 1 }
