#Requires -Version 7.0

<#
.SYNOPSIS
    Worker script to regenerate a single SDK using local mgmt generator.

.DESCRIPTION
    This script is called by RegenSdkLocal.ps1 for each SDK to regenerate.
    It handles TypeSpec sync, compilation, and cleanup.

.PARAMETER ProjectPath
    Full path to the SDK project folder.

.PARAMETER MgmtPackageRoot
    Full path to the mgmt package root (http-client-csharp-mgmt).

.PARAMETER SdkRepoRoot
    Full path to the azure-sdk-for-net repository root.
#>

param(
    [Parameter(Mandatory)]
    [string]$ProjectPath,
    
    [Parameter(Mandatory)]
    [string]$MgmtPackageRoot,
    
    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [switch]$SaveInputs,
    
    [switch]$DebugGenerator
)

$ErrorActionPreference = 'Stop'

$result = @{
    Success = $false
    Error = ""
}

try {
    # Load tsp-location.yaml
    if (-not (Get-Module -ListAvailable -Name powershell-yaml -ErrorAction SilentlyContinue)) {
        Install-Module -Name powershell-yaml -Force -Scope CurrentUser 2>&1 | Out-Null
    }
    Import-Module powershell-yaml -ErrorAction SilentlyContinue
    $tspConfig = Get-Content (Join-Path $ProjectPath "tsp-location.yaml") -Raw | ConvertFrom-Yaml
    
    $repo = $tspConfig["repo"]
    $commit = $tspConfig["commit"]
    $directory = $tspConfig["directory"]
    $additionalDirs = $tspConfig["additionalDirectories"]
    $specDir = Split-Path $directory -Leaf
    $projectName = Split-Path $ProjectPath -Leaf
    
    # Convert backslashes to forward slashes for git
    $directoryForGit = ($directory -replace '\\', '/').TrimEnd('/')
    
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
        # Initialize sparse clone with forward slashes
        $gitRemote = "https://github.com/$repo.git"
        $gitOutput = git clone --filter=blob:none --no-checkout --depth 1 --sparse $gitRemote . 2>&1
        if ($LASTEXITCODE -ne 0) { throw "git clone failed: $gitOutput" }
        
        $gitOutput = git sparse-checkout init --cone 2>&1
        if ($LASTEXITCODE -ne 0) { throw "git sparse-checkout init failed: $gitOutput" }
        
        $gitOutput = git sparse-checkout set $directoryForGit 2>&1
        if ($LASTEXITCODE -ne 0) { throw "git sparse-checkout set failed: $gitOutput" }
        
        # Add additional directories if any
        if ($additionalDirs) {
            foreach ($addDir in $additionalDirs) {
                $addDirForGit = ($addDir -replace '\\', '/').TrimEnd('/')
                $gitOutput = git sparse-checkout add $addDirForGit 2>&1
                if ($LASTEXITCODE -ne 0) { throw "git sparse-checkout add failed: $gitOutput" }
            }
        }
        
        # Checkout the specific commit
        $gitOutput = git fetch --depth 1 origin $commit 2>&1
        if ($LASTEXITCODE -ne 0) { throw "git fetch failed: $gitOutput" }
        
        $gitOutput = git checkout $commit 2>&1
        if ($LASTEXITCODE -ne 0) { throw "git checkout failed: $gitOutput" }
    }
    finally {
        Pop-Location
    }
    
    # Copy spec files to TempTypeSpecFiles
    $tempTypeSpecDir = Join-Path $ProjectPath "TempTypeSpecFiles"
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
    $sdkNodeModules = Join-Path $ProjectPath "node_modules"
    $sdkNodeModulesBackup = $null
    if (Test-Path $sdkNodeModules) {
        $sdkNodeModulesBackup = "$sdkNodeModules.bak"
        Rename-Item $sdkNodeModules $sdkNodeModulesBackup -Force
    }
    
    # Create junction from TempTypeSpecFiles/node_modules to mgmt package's node_modules
    $linkPath = Join-Path $tempTypeSpecDir "node_modules"
    if (Test-Path $linkPath) { Remove-Item $linkPath -Recurse -Force }
    New-Item -ItemType Junction -Path $linkPath -Target (Join-Path $MgmtPackageRoot "node_modules") | Out-Null
    
    try {
        # Run tsp compile using local emitter path
        Push-Location $MgmtPackageRoot
        $tspOptions = "--emit $MgmtPackageRoot --option `"@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$ProjectPath`""
        if ($SaveInputs) {
            $tspOptions += " --option `"@azure-typespec/http-client-csharp-mgmt.save-inputs=true`""
        }
        if ($DebugGenerator) {
            $tspOptions += " --option `"@azure-typespec/http-client-csharp-mgmt.debug=true`""
        }
        $tspOutput = Invoke-Expression "npx tsp compile $mainTsp $tspOptions 2>&1"
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
    Remove-Item $tempTypeSpecDir -Recurse -Force -ErrorAction SilentlyContinue
    
    $result.Success = $true
}
catch {
    $result.Error = $_.ToString()
}

# Output result as JSON for parsing
$result | ConvertTo-Json -Compress
