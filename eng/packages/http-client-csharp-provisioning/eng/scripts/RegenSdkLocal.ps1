#Requires -Version 7.0

<#
.SYNOPSIS
    Regenerates provisioning SDK folders using local generator build.

.DESCRIPTION
    Builds the provisioning generator locally and regenerates SDK folders using TypeSpec.
    Does NOT modify package.json files or create versioned packages.
    By default (when -Services is omitted), regenerates ALL provisioning SDKs.
    Use -Services to regenerate one or more specific libraries by exact
    library folder name (e.g., "Azure.Provisioning.KeyVault").

.PARAMETER Services
    One or more library folder names to regenerate (e.g.,
    "Azure.Provisioning.KeyVault"). Each value must match an SDK folder
    name exactly (case-insensitive). Omit -Services to regenerate ALL
    provisioning SDKs.

    Exact matching avoids the common pitfall where a substring like
    "Container" also picks up ContainerInstance, ContainerService, etc.

.PARAMETER Parallel
    Number of parallel jobs (default: 4, min: 1). Set to 1 for sequential execution.

.PARAMETER LocalSpecRepoPath
    Path to a local azure-rest-api-specs repo. When specified, reads spec files from
    this local directory instead of fetching from GitHub. Useful for fast iteration
    when making spec changes alongside generator changes.

.PARAMETER UseLocalMgmtGenerator
    When specified, builds the local mgmt generator (eng/packages/http-client-csharp-mgmt)
    and overwrites Azure.Generator.Management.{dll,pdb,xml} in the provisioning
    generator's dist/generator output with the freshly built copies. Use this to
    test mgmt-generator changes (e.g., FlattenPropertyVisitor fixes) end-to-end
    without publishing a new Azure.Generator.Management NuGet package.

.PARAMETER UseLocalTypeSpec
    Path to a local microsoft/typespec repo checkout. When specified, overlays the
    locally-built Microsoft.TypeSpec.Generator.* dlls from
    <path>/packages/http-client-csharp/dist/generator into the provisioning generator's
    dist/generator output. Use this to test typespec-base-generator changes end-to-end.
    The local typespec repo must already be built (e.g., via `dotnet build` in
    packages/http-client-csharp/generator).

.PARAMETER SaveInputs
    When specified, passes save-inputs=true to the emitter to preserve tspCodeModel.json for debugging.

.PARAMETER DebugGenerator
    When specified, passes debug=true to the emitter to enable attaching a debugger to the generator process.

.NOTES
    Prerequisites: git, npm, dotnet, and npx must be installed and in PATH.
    The powershell-yaml module will be auto-installed if not present.

.EXAMPLE
    .\RegenSdkLocal.ps1
    # Regenerates ALL provisioning SDKs.

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "Azure.Provisioning.KeyVault"
    # Exact match against the SDK folder name.

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "Azure.Provisioning.KeyVault","Azure.Provisioning.Batch" -Parallel 8

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "Azure.Provisioning.KeyVault" -LocalSpecRepoPath "C:\src\azure-rest-api-specs"
#>

param(
    [string[]]$Services,
    [ValidateRange(1, [int]::MaxValue)]
    [int]$Parallel = 4,
    [string]$LocalSpecRepoPath,
    [switch]$UseLocalMgmtGenerator,
    [string]$UseLocalTypeSpec,
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

# Validate LocalSpecRepoPath upfront
if ($LocalSpecRepoPath) {
    if (-not (Test-Path $LocalSpecRepoPath)) {
        throw "LocalSpecRepoPath not found: $LocalSpecRepoPath"
    }
    $LocalSpecRepoPath = (Resolve-Path $LocalSpecRepoPath).Path
}

# Resolve paths
$provisioningPackageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
$sdkRepoRoot = Resolve-Path (Join-Path $provisioningPackageRoot '..' '..' '..')
$sdkRoot = Join-Path $sdkRepoRoot "sdk"
$mgmtPackageRoot = Resolve-Path (Join-Path $provisioningPackageRoot '..' 'http-client-csharp-mgmt')

# Validate paths
if (-not (Test-Path $sdkRoot)) {
    throw "SDK folder not found: $sdkRoot"
}

Write-Host "=== Local Provisioning SDK Regeneration ==="
Write-Host "Provisioning Generator: $provisioningPackageRoot"
Write-Host "SDK Root: $sdkRepoRoot"
if ($UseLocalMgmtGenerator) {
    Write-Host "Mgmt Generator (override): $mgmtPackageRoot"
}

# Step 0 (optional): Build local mgmt generator
if ($UseLocalMgmtGenerator) {
    Write-Host "`n[0/3] Building local Mgmt generator (override)..."
    if (-not (Test-Path $mgmtPackageRoot)) {
        throw "Mgmt generator package root not found: $mgmtPackageRoot"
    }
    Push-Location $mgmtPackageRoot
    try {
        Write-Host "  dotnet build (Azure.Generator.Management)..."
        $output = dotnet build ./generator/Azure.Generator.Management/src -c Debug --verbosity quiet 2>&1
        if ($LASTEXITCODE -ne 0) {
            Write-Host "  ERROR: mgmt dotnet build failed:" -ForegroundColor Red
            $output | ForEach-Object { Write-Host "    $_" }
            throw "mgmt dotnet build failed with exit code $LASTEXITCODE"
        }
        Write-Host "  Mgmt build complete."
    }
    finally {
        Pop-Location
    }
}

# Step 1: Build generator
Write-Host "`n[1/3] Building Provisioning generator..."
Push-Location $provisioningPackageRoot
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
    $output = dotnet build ./generator/Azure.Generator.Provisioning/src -c Debug --no-dependencies --verbosity quiet 2>&1
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

# Step 1b (optional): overlay locally-built mgmt generator dll into provisioning dist/
if ($UseLocalMgmtGenerator) {
    Write-Host "`n  Overlaying local Azure.Generator.Management binaries..."
    $mgmtDistDir = Join-Path $mgmtPackageRoot 'dist' 'generator'
    $provDistDir = Join-Path $provisioningPackageRoot 'dist' 'generator'
    if (-not (Test-Path $mgmtDistDir)) {
        throw "Mgmt dist/generator not found after build: $mgmtDistDir"
    }
    if (-not (Test-Path $provDistDir)) {
        throw "Provisioning dist/generator not found after build: $provDistDir"
    }
    # Overlay all files from mgmt dist EXCEPT provisioning-specific ones, so that
    # transitive deps (Microsoft.TypeSpec.Generator.*, Microsoft.CodeAnalysis.*, Humanizer, etc.)
    # match the version Azure.Generator.Management.dll was just built against. Otherwise MEF
    # DirectoryCatalog scanning fails with ReflectionTypeLoadException due to missing methods.
    $excludePatterns = @(
        'Azure.Generator.Provisioning.*',
        'Azure.Provisioning.dll'
    )
    $copied = 0
    foreach ($file in Get-ChildItem -Path $mgmtDistDir -File) {
        $skip = $false
        foreach ($pat in $excludePatterns) { if ($file.Name -like $pat) { $skip = $true; break } }
        if ($skip) { continue }
        Copy-Item -Path $file.FullName -Destination $provDistDir -Force
        $copied++
    }
    Write-Host "    Overlaid $copied files from mgmt dist."
    if ($copied -eq 0) {
        throw "No files overlaid from $mgmtDistDir"
    }
}

# Step 1c (optional): overlay locally-built TypeSpec generator dlls
if ($UseLocalTypeSpec) {
    Write-Host "`n  Overlaying local Microsoft.TypeSpec.Generator binaries..."
    if (-not (Test-Path $UseLocalTypeSpec)) {
        throw "UseLocalTypeSpec path not found: $UseLocalTypeSpec"
    }
    $tspDistDir = Join-Path (Resolve-Path $UseLocalTypeSpec).Path 'packages' 'http-client-csharp' 'dist' 'generator'
    if (-not (Test-Path $tspDistDir)) {
        throw "Local typespec dist/generator not found: $tspDistDir. Build typespec first (dotnet build packages/http-client-csharp/generator)."
    }
    $provDistDir = Join-Path $provisioningPackageRoot 'dist' 'generator'
    $tspCopied = 0
    foreach ($file in Get-ChildItem -Path $tspDistDir -File -Filter 'Microsoft.TypeSpec.Generator*') {
        Copy-Item -Path $file.FullName -Destination $provDistDir -Force
        $tspCopied++
    }
    Write-Host "    Overlaid $tspCopied Microsoft.TypeSpec.Generator.* files from $tspDistDir."
    if ($tspCopied -eq 0) {
        throw "No Microsoft.TypeSpec.Generator.* files overlaid from $tspDistDir"
    }
}

# Step 2: Find provisioning SDK folders
Write-Host "`n[2/3] Scanning for provisioning SDKs..."
$provisioningSdkFolders = @()
$tspFiles = Get-ChildItem -Path $sdkRoot -Recurse -Filter "tsp-location.yaml" -ErrorAction SilentlyContinue

foreach ($tspFile in $tspFiles) {
    $content = Get-Content $tspFile.FullName -Raw -ErrorAction SilentlyContinue
    if ($content -match 'azure-typespec-http-client-csharp-provisioning-emitter-package') {
        $provisioningSdkFolders += @{
            Path = $tspFile.Directory.FullName
            Library = Split-Path $tspFile.Directory.FullName -Leaf
            Service = Split-Path (Split-Path $tspFile.Directory.FullName -Parent) -Leaf
        }
    }
}

Write-Host "Found $($provisioningSdkFolders.Count) provisioning SDK folders"

# Apply services filter: each value must match an SDK folder name exactly
# (case-insensitive). Throws if any value matches no folder.
if ($Services -and $Services.Count -gt 0) {
    $unmatched = @($Services | Where-Object {
        $name = $_
        -not ($provisioningSdkFolders | Where-Object { $_.Library -ieq $name })
    })
    if ($unmatched.Count -gt 0) {
        throw "No provisioning SDK folder matched: $($unmatched -join ', '). Pass the exact library folder name, e.g., 'Azure.Provisioning.KeyVault'."
    }
    $provisioningSdkFolders = @($provisioningSdkFolders | Where-Object {
        $folder = $_
        $null -ne ($Services | Where-Object { $folder.Library -ieq $_ })
    })
    Write-Host "Filtered to $($provisioningSdkFolders.Count) matching: $($Services -join ', ')"
}

if ($provisioningSdkFolders.Count -eq 0) {
    Write-Host "No matching SDK folders found."
    exit 0
}

# If no filter specified, regenerate all by default
$selectedFolders = $provisioningSdkFolders
Write-Host "Selected $($selectedFolders.Count) SDKs for regeneration"

# Step 3: Regenerate
Write-Host "`n[3/3] Regenerating ($Parallel parallel jobs)..."
$totalStart = Get-Date
$workerScript = Join-Path $PSScriptRoot "Invoke-SdkRegeneration.ps1"

# Run regeneration (parallel or sequential)
if ($Parallel -gt 1 -and $selectedFolders.Count -gt 1) {
    $results = $selectedFolders | ForEach-Object -ThrottleLimit $Parallel -Parallel {
        $folder = $_
        $provPkgRoot = $using:provisioningPackageRoot
        $sdkRepo = $using:sdkRepoRoot
        $worker = $using:workerScript
        $localSpecRepo = $using:LocalSpecRepoPath
        $saveInputsFlag = $using:SaveInputs
        $debugFlag = $using:DebugGenerator

        $result = @{ Library = $folder.Library; Success = $false; Error = ""; Elapsed = 0 }
        $start = Get-Date

        try {
            $workerArgs = @{
                ProjectPath = $folder.Path
                ProvisioningPackageRoot = $provPkgRoot
                SdkRepoRoot = $sdkRepo
                SaveInputs = $saveInputsFlag
                DebugGenerator = $debugFlag
            }
            if ($localSpecRepo) { $workerArgs['LocalSpecRepoPath'] = $localSpecRepo }
            $output = & $worker @workerArgs 2>&1
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
            $workerArgs = @{
                ProjectPath = $folder.Path
                ProvisioningPackageRoot = $provisioningPackageRoot
                SdkRepoRoot = $sdkRepoRoot
                SaveInputs = $SaveInputs
                DebugGenerator = $DebugGenerator
            }
            if ($LocalSpecRepoPath) { $workerArgs['LocalSpecRepoPath'] = $LocalSpecRepoPath }
            $output = & $workerScript @workerArgs 2>&1
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
