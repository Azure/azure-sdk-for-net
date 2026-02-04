#Requires -Version 7.0

<#
.SYNOPSIS
    Regenerates management SDK folders using local generator build.

.DESCRIPTION
    Builds the mgmt generator locally and regenerates SDK folders using TypeSpec.
    Does NOT modify package.json files or create versioned packages.
    By default, regenerates ALL mgmt SDKs. Use -Filter or -Services to limit scope.

.PARAMETER Filter
    Filter SDK folders by name pattern (e.g., "KeyVault").

.PARAMETER Services
    Array of service names to regenerate (e.g., "KeyVault", "Compute").

.PARAMETER Parallel
    Number of parallel jobs (default: 4). Set to 1 for sequential execution.

.EXAMPLE
    .\RegenSdkLocal.ps1 -Filter "KeyVault"

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "KeyVault","Compute","Network"

.EXAMPLE
    .\RegenSdkLocal.ps1 -Parallel 8
#>

param(
    [string]$Filter,
    [string[]]$Services,
    [int]$Parallel = 4
)

$ErrorActionPreference = 'Stop'

# Resolve paths
$mgmtPackageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
$sdkRepoRoot = Resolve-Path (Join-Path $mgmtPackageRoot '..' '..' '..')
$sdkRoot = Join-Path $sdkRepoRoot "sdk"

# Validate paths
if (-not (Test-Path $sdkRoot)) {
    throw "SDK folder not found: $sdkRoot"
}

Write-Output "=== Local Mgmt SDK Regeneration ==="
Write-Output "Mgmt Generator: $mgmtPackageRoot"
Write-Output "SDK Root: $sdkRepoRoot"

# Step 1: Build generator
Write-Output "`n[1/3] Building Mgmt generator..."
Push-Location $mgmtPackageRoot
try {
    if (-not (Test-Path "node_modules")) {
        Write-Output "  npm install..."
        npm install 2>&1 | Out-Null
    }
    Write-Output "  npm run build:emitter..."
    npm run build:emitter 2>&1 | Out-Null
    Write-Output "  dotnet build..."
    dotnet build ./generator/Azure.Generator.Management/src -c Debug --verbosity quiet 2>&1 | Out-Null
    Write-Output "  Build complete."
}
finally {
    Pop-Location
}

# Step 2: Find mgmt SDK folders
Write-Output "`n[2/3] Scanning for mgmt SDKs..."
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

Write-Output "Found $($mgmtSdkFolders.Count) mgmt SDK folders"

# Apply filter or services list
if ($Services -and $Services.Count -gt 0) {
    $mgmtSdkFolders = @($mgmtSdkFolders | Where-Object { 
        $folder = $_
        $Services | Where-Object { $folder.Library -like "*$_*" -or $folder.Service -like "*$_*" }
    })
    Write-Output "Selected $($mgmtSdkFolders.Count) matching: $($Services -join ', ')"
}
elseif ($Filter) {
    $mgmtSdkFolders = @($mgmtSdkFolders | Where-Object { $_.Library -like "*$Filter*" -or $_.Service -like "*$Filter*" })
    Write-Output "Filtered to $($mgmtSdkFolders.Count) matching '$Filter'"
}

if ($mgmtSdkFolders.Count -eq 0) {
    Write-Output "No matching SDK folders found."
    exit 0
}

# If no filter/services specified, regenerate all by default
$selectedFolders = $mgmtSdkFolders
Write-Output "Selected $($selectedFolders.Count) SDKs for regeneration"

# Step 3: Regenerate
Write-Output "`n[3/3] Regenerating ($Parallel parallel jobs)..."

# Run regeneration (parallel or sequential)
if ($Parallel -gt 1 -and $selectedFolders.Count -gt 1) {
    $results = $selectedFolders | ForEach-Object -ThrottleLimit $Parallel -Parallel {
        $folder = $_
        $mgmtPkgRoot = $using:mgmtPackageRoot
        $sdkRepo = $using:sdkRepoRoot
        
        $result = @{ Library = $folder.Library; Success = $false; Error = ""; Elapsed = 0 }
        $start = Get-Date
        
        try {
            # Sync TypeSpec files
            $syncScript = Join-Path $sdkRepo "eng" "common" "scripts" "TypeSpec-Project-Sync.ps1"
            & $syncScript -ProjectDirectory $folder.Path 2>&1 | Out-Null
            
            # Get spec directory from tsp-location.yaml
            if (-not (Get-Module -ListAvailable -Name powershell-yaml -ErrorAction SilentlyContinue)) {
                Install-Module -Name powershell-yaml -Force -Scope CurrentUser 2>&1 | Out-Null
            }
            Import-Module powershell-yaml -ErrorAction SilentlyContinue
            $tspConfig = Get-Content (Join-Path $folder.Path "tsp-location.yaml") -Raw | ConvertFrom-Yaml
            $specDir = Split-Path $tspConfig["directory"] -Leaf
            
            $workDir = Join-Path $folder.Path "TempTypeSpecFiles" $specDir
            if (-not (Test-Path $workDir)) { throw "TypeSpec files not found: $workDir" }
            
            # Find main tsp file
            $mainTsp = if (Test-Path "$workDir/client.tsp") { "$workDir/client.tsp" } else { "$workDir/main.tsp" }
            
            # Remove any interfering package.json from work dir
            Remove-Item "$workDir/package.json" -Force -ErrorAction SilentlyContinue
            Remove-Item "$workDir/node_modules" -Recurse -Force -ErrorAction SilentlyContinue
            
            # Temporarily rename SDK's node_modules to avoid TypeSpec version conflicts
            $sdkNodeModules = Join-Path $folder.Path "node_modules"
            $sdkNodeModulesBackup = $null
            if (Test-Path $sdkNodeModules) {
                $sdkNodeModulesBackup = "$sdkNodeModules.bak"
                Rename-Item $sdkNodeModules $sdkNodeModulesBackup -Force
            }
            
            # Create junction from TempTypeSpecFiles/node_modules to mgmt package's node_modules
            $tempTypeSpecFiles = Join-Path $folder.Path "TempTypeSpecFiles"
            $linkPath = Join-Path $tempTypeSpecFiles "node_modules"
            if (Test-Path $linkPath) { Remove-Item $linkPath -Recurse -Force }
            New-Item -ItemType Junction -Path $linkPath -Target (Join-Path $mgmtPkgRoot "node_modules") | Out-Null
            
            try {
                # Run tsp compile using local emitter path
                Push-Location $mgmtPkgRoot
                $tspOutput = npx tsp compile $mainTsp --emit $mgmtPkgRoot --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$($folder.Path)" 2>&1
                $tspExitCode = $LASTEXITCODE
                Pop-Location
                
                if ($tspExitCode -ne 0) {
                    $errorLines = $tspOutput | Where-Object { $_ -match 'error|Error' } | Select-Object -First 5
                    throw "tsp compile failed: $($errorLines -join '; ')"
                }
            }
            finally {
                # Cleanup junction
                Remove-Item $linkPath -Force -ErrorAction SilentlyContinue
                
                # Restore SDK node_modules if we backed it up
                if ($sdkNodeModulesBackup -and (Test-Path $sdkNodeModulesBackup)) {
                    if (Test-Path $sdkNodeModules) { Remove-Item $sdkNodeModules -Recurse -Force }
                    Rename-Item $sdkNodeModulesBackup $sdkNodeModules -Force
                }
            }
            
            # Cleanup temp files
            Remove-Item (Join-Path $folder.Path "TempTypeSpecFiles") -Recurse -Force -ErrorAction SilentlyContinue
            
            $result.Success = $true
            $result.Elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
        }
        catch {
            $result.Error = $_.ToString()
            $result.Elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
        }
        
        # Output progress
        if ($result.Success) {
            Write-Output "  $($result.Library): OK ($($result.Elapsed)s)"
        } else {
            Write-Output "  $($result.Library): FAILED - $($result.Error)"
        }
        
        $result
    }
} else {
    $results = @()
    foreach ($folder in $selectedFolders) {
        Write-Output "`n  $($folder.Library)..."
        
        $result = @{ Library = $folder.Library; Success = $false; Error = ""; Elapsed = 0 }
        $start = Get-Date
        
        try {
            # Sync TypeSpec files
            $syncScript = Join-Path $sdkRepoRoot "eng" "common" "scripts" "TypeSpec-Project-Sync.ps1"
            & $syncScript -ProjectDirectory $folder.Path 2>&1 | Out-Null
            
            # Get spec directory from tsp-location.yaml
            if (-not (Get-Module -ListAvailable -Name powershell-yaml -ErrorAction SilentlyContinue)) {
                Install-Module -Name powershell-yaml -Force -Scope CurrentUser 2>&1 | Out-Null
            }
            Import-Module powershell-yaml -ErrorAction SilentlyContinue
            $tspConfig = Get-Content (Join-Path $folder.Path "tsp-location.yaml") -Raw | ConvertFrom-Yaml
            $specDir = Split-Path $tspConfig["directory"] -Leaf
            
            $workDir = Join-Path $folder.Path "TempTypeSpecFiles" $specDir
            if (-not (Test-Path $workDir)) { throw "TypeSpec files not found: $workDir" }
            
            # Find main tsp file
            $mainTsp = if (Test-Path "$workDir/client.tsp") { "$workDir/client.tsp" } else { "$workDir/main.tsp" }
            
            # Remove any interfering package.json from work dir
            Remove-Item "$workDir/package.json" -Force -ErrorAction SilentlyContinue
            Remove-Item "$workDir/node_modules" -Recurse -Force -ErrorAction SilentlyContinue
            
            # Temporarily rename SDK's node_modules to avoid TypeSpec version conflicts
            $sdkNodeModules = Join-Path $folder.Path "node_modules"
            $sdkNodeModulesBackup = $null
            if (Test-Path $sdkNodeModules) {
                $sdkNodeModulesBackup = "$sdkNodeModules.bak"
                Rename-Item $sdkNodeModules $sdkNodeModulesBackup -Force
            }
            
            # Create junction from TempTypeSpecFiles/node_modules to mgmt package's node_modules
            $tempTypeSpecFiles = Join-Path $folder.Path "TempTypeSpecFiles"
            $linkPath = Join-Path $tempTypeSpecFiles "node_modules"
            if (Test-Path $linkPath) { Remove-Item $linkPath -Recurse -Force }
            New-Item -ItemType Junction -Path $linkPath -Target (Join-Path $mgmtPackageRoot "node_modules") | Out-Null
            
            try {
                # Run tsp compile using local emitter path
                Push-Location $mgmtPackageRoot
                $tspOutput = npx tsp compile $mainTsp --emit $mgmtPackageRoot --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$($folder.Path)" 2>&1
                $tspExitCode = $LASTEXITCODE
                Pop-Location
                
                if ($tspExitCode -ne 0) {
                    $errorLines = $tspOutput | Where-Object { $_ -match 'error|Error' } | Select-Object -First 5
                    throw "tsp compile failed: $($errorLines -join '; ')"
                }
            }
            finally {
                # Cleanup junction
                Remove-Item $linkPath -Force -ErrorAction SilentlyContinue
                
                # Restore SDK node_modules if we backed it up
                if ($sdkNodeModulesBackup -and (Test-Path $sdkNodeModulesBackup)) {
                    if (Test-Path $sdkNodeModules) { Remove-Item $sdkNodeModules -Recurse -Force }
                    Rename-Item $sdkNodeModulesBackup $sdkNodeModules -Force
                }
            }
            
            # Cleanup temp files
            Remove-Item (Join-Path $folder.Path "TempTypeSpecFiles") -Recurse -Force -ErrorAction SilentlyContinue
            
            $result.Success = $true
            $result.Elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
        }
        catch {
            $result.Error = $_.ToString()
            $result.Elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
        }
        
        if ($result.Success) {
            Write-Output "    OK ($($result.Elapsed)s)"
        } else {
            Write-Output "    FAILED: $($result.Error)"
        }
        $results += $result
    }
}

# Summary
$passed = @($results | Where-Object { $_.Success -eq $true }).Count
$failed = @($results | Where-Object { $_.Success -ne $true }).Count
Write-Output "`n=== Summary: $passed passed, $failed failed ==="

if ($failed -gt 0) { exit 1 }
