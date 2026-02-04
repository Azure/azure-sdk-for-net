#Requires -Version 7.0

<#
.SYNOPSIS
    Regenerates management SDK folders using local generator build.

.DESCRIPTION
    Builds the mgmt generator locally and regenerates SDK folders using TypeSpec.
    Does NOT modify package.json files or create versioned packages.
    By default, regenerates ALL mgmt SDKs. Use -Services to limit scope.

.PARAMETER Services
    One or more service name patterns to regenerate (e.g., "KeyVault", "Compute").
    Supports wildcards. Case-insensitive.

.PARAMETER Parallel
    Number of parallel jobs (default: 4). Set to 1 for sequential execution.

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "KeyVault"

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "KeyVault","Compute","Network"

.EXAMPLE
    .\RegenSdkLocal.ps1 -Services "Key*" -Parallel 8
#>

param(
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

Write-Host "=== Local Mgmt SDK Regeneration ==="
Write-Host "Mgmt Generator: $mgmtPackageRoot"
Write-Host "SDK Root: $sdkRepoRoot"

# Step 1: Build generator
Write-Host "`n[1/3] Building Mgmt generator..."
Push-Location $mgmtPackageRoot
try {
    if (-not (Test-Path "node_modules")) {
        Write-Host "  npm install..."
        npm install 2>&1 | Out-Null
    }
    Write-Host "  npm run build:emitter..."
    npm run build:emitter 2>&1 | Out-Null
    Write-Host "  dotnet build..."
    dotnet build ./generator/Azure.Generator.Management/src -c Debug --verbosity quiet 2>&1 | Out-Null
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

# Helper function: Sync TypeSpec files with proper forward-slash paths for git sparse-checkout
function Sync-TypeSpecFiles {
    param(
        [string]$ProjectDirectory,
        [string]$SdkRepoRoot
    )
    
    # Load tsp-location.yaml
    $tspLocationPath = Join-Path $ProjectDirectory "tsp-location.yaml"
    $tspConfig = Get-Content $tspLocationPath -Raw | ConvertFrom-Yaml
    
    $repo = $tspConfig["repo"]
    $commit = $tspConfig["commit"]
    $directory = $tspConfig["directory"]
    $additionalDirs = $tspConfig["additionalDirectories"]
    $projectName = Split-Path $ProjectDirectory -Leaf
    
    # Convert backslashes to forward slashes for git
    $directoryForGit = $directory -replace '\\', '/'
    $directoryForGit = $directoryForGit.TrimEnd('/')
    
    # Setup sparse-spec clone directory
    $sparseSpecRoot = Join-Path (Split-Path $SdkRepoRoot -Parent) "sparse-spec"
    $sparseSpecDir = Join-Path $sparseSpecRoot $projectName
    
    # Clean up and recreate
    if (Test-Path $sparseSpecDir) {
        Remove-Item $sparseSpecDir -Recurse -Force
    }
    New-Item $sparseSpecDir -ItemType Directory -Force | Out-Null
    
    Push-Location $sparseSpecDir
    try {
        # Initialize sparse clone
        $gitRemote = "https://github.com/$repo.git"
        git clone --filter=blob:none --no-checkout --depth 1 --sparse $gitRemote . 2>&1 | Out-Null
        git sparse-checkout init --cone 2>&1 | Out-Null
        git sparse-checkout set $directoryForGit 2>&1 | Out-Null
        
        # Add additional directories if any
        if ($additionalDirs) {
            foreach ($addDir in $additionalDirs) {
                $addDirForGit = ($addDir -replace '\\', '/').TrimEnd('/')
                git sparse-checkout add $addDirForGit 2>&1 | Out-Null
            }
        }
        
        # Checkout the specific commit
        git fetch --depth 1 origin $commit 2>&1 | Out-Null
        git checkout $commit 2>&1 | Out-Null
        
        # Verify directory exists
        if (-not (Test-Path $directory)) {
            throw "Cannot find path '$sparseSpecDir\$directory' because it does not exist."
        }
    }
    finally {
        Pop-Location
    }
    
    # Copy spec files to TempTypeSpecFiles
    $tempTypeSpecDir = Join-Path $ProjectDirectory "TempTypeSpecFiles"
    if (Test-Path $tempTypeSpecDir) {
        Remove-Item $tempTypeSpecDir -Recurse -Force
    }
    New-Item $tempTypeSpecDir -ItemType Directory -Force | Out-Null
    
    $source = Join-Path $sparseSpecDir $directory
    Copy-Item -Path $source -Destination $tempTypeSpecDir -Recurse -Force
    
    # Copy additional directories if any
    if ($additionalDirs) {
        foreach ($addDir in $additionalDirs) {
            $addSource = Join-Path $sparseSpecDir $addDir
            Copy-Item -Path $addSource -Destination $tempTypeSpecDir -Recurse -Force
        }
    }
}

# Step 3: Regenerate
Write-Host "`n[3/3] Regenerating ($Parallel parallel jobs)..."
$totalStart = Get-Date

# Run regeneration (parallel or sequential)
if ($Parallel -gt 1 -and $selectedFolders.Count -gt 1) {
    $results = $selectedFolders | ForEach-Object -ThrottleLimit $Parallel -Parallel {
        $folder = $_
        $mgmtPkgRoot = $using:mgmtPackageRoot
        $sdkRepo = $using:sdkRepoRoot
        
        $result = @{ Library = $folder.Library; Success = $false; Error = ""; Elapsed = 0 }
        $start = Get-Date
        
        try {
            # Load tsp-location.yaml
            if (-not (Get-Module -ListAvailable -Name powershell-yaml -ErrorAction SilentlyContinue)) {
                Install-Module -Name powershell-yaml -Force -Scope CurrentUser 2>&1 | Out-Null
            }
            Import-Module powershell-yaml -ErrorAction SilentlyContinue
            $tspConfig = Get-Content (Join-Path $folder.Path "tsp-location.yaml") -Raw | ConvertFrom-Yaml
            
            $repo = $tspConfig["repo"]
            $commit = $tspConfig["commit"]
            $directory = $tspConfig["directory"]
            $additionalDirs = $tspConfig["additionalDirectories"]
            $specDir = Split-Path $directory -Leaf
            
            # Convert backslashes to forward slashes for git
            $directoryForGit = ($directory -replace '\\', '/').TrimEnd('/')
            
            # Setup sparse-spec clone directory
            $sparseSpecRoot = Join-Path (Split-Path $sdkRepo -Parent) "sparse-spec"
            $sparseSpecDir = Join-Path $sparseSpecRoot $folder.Library
            
            # Clean up and recreate
            if (Test-Path $sparseSpecDir) {
                Remove-Item $sparseSpecDir -Recurse -Force
            }
            New-Item $sparseSpecDir -ItemType Directory -Force | Out-Null
            
            Push-Location $sparseSpecDir
            try {
                # Initialize sparse clone with forward slashes
                $gitRemote = "https://github.com/$repo.git"
                git clone --filter=blob:none --no-checkout --depth 1 --sparse $gitRemote . 2>&1 | Out-Null
                git sparse-checkout init --cone 2>&1 | Out-Null
                git sparse-checkout set $directoryForGit 2>&1 | Out-Null
                
                # Add additional directories if any
                if ($additionalDirs) {
                    foreach ($addDir in $additionalDirs) {
                        $addDirForGit = ($addDir -replace '\\', '/').TrimEnd('/')
                        git sparse-checkout add $addDirForGit 2>&1 | Out-Null
                    }
                }
                
                # Checkout the specific commit
                git fetch --depth 1 origin $commit 2>&1 | Out-Null
                git checkout $commit 2>&1 | Out-Null
            }
            finally {
                Pop-Location
            }
            
            # Copy spec files to TempTypeSpecFiles
            $tempTypeSpecDir = Join-Path $folder.Path "TempTypeSpecFiles"
            if (Test-Path $tempTypeSpecDir) {
                Remove-Item $tempTypeSpecDir -Recurse -Force
            }
            New-Item $tempTypeSpecDir -ItemType Directory -Force | Out-Null
            
            $source = Join-Path $sparseSpecDir $directory
            Copy-Item -Path $source -Destination $tempTypeSpecDir -Recurse -Force
            
            # Copy additional directories if any
            if ($additionalDirs) {
                foreach ($addDir in $additionalDirs) {
                    $addSource = Join-Path $sparseSpecDir $addDir
                    Copy-Item -Path $addSource -Destination $tempTypeSpecDir -Recurse -Force
                }
            }
            
            $workDir = Join-Path $tempTypeSpecDir $specDir
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
            # Sync TypeSpec files using the helper function with forward-slash paths
            Sync-TypeSpecFiles -ProjectDirectory $folder.Path -SdkRepoRoot $sdkRepoRoot
            
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
