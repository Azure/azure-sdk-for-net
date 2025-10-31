#Requires -Version 7.0

<#
.SYNOPSIS
    Builds local generator packages and regenerates Azure SDK for .NET libraries for validation.

.DESCRIPTION
    This script supports two modes:
    
    Azure SDK Mode (default):
    1. Builds a local npm package of @azure-ypespec/http-client-csharp with a versioned name (1.0.0-alpha.YYYYMMDD.hash)
    2. Builds and packages the NuGet generator framework packages with the same versioning
    3. Updates Packages.Data.props in azure-sdk-for-net with the local NuGet version
    4. Updates the management plane generator (@azure-typespec/http-client-csharp-mgmt) to use local generators
    5. Updates the eng folder package.json artifacts in azure-sdk-for-net
    6. Regenerates libraries based on specified filters (all, by generator type, or interactively selected)
    7. Restores all modified artifacts to original state on success


    Generator Filtering (Azure SDK Mode only):
    - Use -Azure to regenerate only Azure-branded libraries (@azure-typespec/http-client-csharp)
    - Use -Unbranded to regenerate only unbranded libraries (@typespec/http-client-csharp)
    - Use -Mgmt to regenerate only management plane libraries (@azure-typespec/http-client-csharp-mgmt)
    - Omit all filter parameters to regenerate all libraries (default)
        - Use -Select for interactive selection (can be combined with generator filters)

.PARAMETER Select
    Optional. When specified, displays an interactive menu to select specific libraries to regenerate.
    If omitted, regenerates all libraries without prompting.

.PARAMETER Azure
    Optional. Azure SDK Mode only. When specified, only regenerates libraries using the Azure generator (@azure-typespec/http-client-csharp).
    Mutually exclusive with Unbranded and Mgmt parameters.

.PARAMETER Unbranded
    Optional. Azure SDK Mode only. When specified, only regenerates libraries using the unbranded generator (@typespec/http-client-csharp).
    Mutually exclusive with Azure and Mgmt parameters.

.PARAMETER Mgmt
    Optional. Azure SDK Mode only. When specified, only regenerates libraries using the management plane generator (@azure-typespec/http-client-csharp-mgmt).
    Mutually exclusive with Azure and Unbranded parameters.
    If no generator filter is specified, all libraries are regenerated.

.EXAMPLE
    # Azure SDK Mode - Regenerate all libraries
    .\RegenPreview.ps1

.EXAMPLE
    # Azure SDK Mode - Interactively select libraries to regenerate (from all available)
    .\RegenPreview.ps1 -Select

.EXAMPLE
    # Regenerate only Azure-branded libraries (non-interactive)
    .\RegenPreview.ps1 -Azure

.EXAMPLE
    # Interactively select from Azure-branded libraries only
    .\RegenPreview.ps1 -Azure -Select

.EXAMPLE
    # Regenerate only unbranded libraries
    .\RegenPreview.ps1 -Unbranded

.EXAMPLE
    # Regenerate only management plane libraries
    .\RegenPreview.ps1 -Mgmt
#>

param(    
    [Parameter(Mandatory=$false)]
    [switch]$Select,
    
    [Parameter(Mandatory=$false)]
    [switch]$Azure,
    
    [Parameter(Mandatory=$false)]
    [switch]$Unbranded,
    
    [Parameter(Mandatory=$false)]
    [switch]$Mgmt
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

# In Azure SDK mode, validate filter parameters
$generatorFilters = @($Azure, $Unbranded, $Mgmt)
$activeFilters = @($generatorFilters | Where-Object { $_ }).Count

if ($activeFilters -gt 1) {
    Write-Error "Parameters -Azure, -Unbranded, and -Mgmt are mutually exclusive. Please specify only one."
    exit 1
}

# Import utility functions
Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force
Import-Module "$PSScriptRoot\RegenPreview.psm1" -DisableNameChecking -Force

# Resolve paths
$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
$sdkRepoPath = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..' '..') -ErrorAction Stop

Write-Host "==================== LOCAL VALIDATION SCRIPT ====================" -ForegroundColor Cyan

Write-Host "Repository: Azure SDK for .NET" -ForegroundColor Gray
    
# Display active mode
$modeText = if ($Select) {
    "Interactive library selection"
} elseif ($Azure) {
    "Regenerate Azure SDK libraries only"
} elseif ($Unbranded) {
    "Regenerate Unbranded libraries only"
} elseif ($Mgmt) {
    "Regenerate Management plane libraries only"
} else {
    "Regenerate ALL libraries"
}
Write-Host "Mode: $modeText" -ForegroundColor Yellow
Write-Host ""

# Generate version string with timestamp and hash
# Used for both npm and NuGet packages to ensure consistency
function Get-LocalPackageVersion {
    $timestamp = Get-Date -Format "yyyyMMdd"
    $hash = (git -C $packageRoot rev-parse --short HEAD 2>$null) ?? "local"
    return "1.0.0-alpha.$timestamp.$hash"
}

# Run npm pack and return the package file path
function Invoke-NpmPack {
    param(
        [string]$WorkingDirectory,
        [string]$DebugFolder
    )
    
    Write-Host "Running: npm pack" -ForegroundColor Gray
    Push-Location $WorkingDirectory
    try {
        $output = & npm pack 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "npm pack failed with exit code $LASTEXITCODE"
        }
        
        # Get the first line that ends with .tgz (the actual package filename)
        # It may be in format "filename: package-name.tgz" or just "package-name.tgz"
        $packageLine = ($output | Where-Object { $_ -match '\.tgz$' } | Select-Object -First 1).ToString().Trim()
        if ($packageLine -match 'filename:\s*(.+\.tgz)') {
            $packageFile = $Matches[1].Trim()
        } else {
            $packageFile = $packageLine
        }
        
        $packagePath = Join-Path $WorkingDirectory $packageFile
        if (-not (Test-Path $packagePath)) {
            throw "Package file not created: $packagePath"
        }
        
        # Move package to debug folder
        $debugPackagePath = Join-Path $DebugFolder $packageFile
        Move-Item $packagePath $debugPackagePath -Force
        
        return $debugPackagePath
    }
    finally {
        Pop-Location
    }
}

# Update package.json with new version
function Update-PackageJsonVersion {
    param(
        [string]$PackageJsonPath,
        [string]$NewVersion
    )
    
    Write-Host "Updating package version to $NewVersion in $PackageJsonPath" -ForegroundColor Gray
    $packageJson = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json -AsHashtable
    $packageJson.version = $NewVersion
    $packageJson | ConvertTo-Json -Depth 100 | Set-Content $PackageJsonPath -Encoding utf8 -NoNewline
}

# Parse Library_Inventory.md to get libraries
function Get-LibrariesToRegenerate {
    param([string]$InventoryPath)
    
    $libraries = @()
    $content = Get-Content $InventoryPath -Raw
    
    # Helper function to parse library section
    $parseSection = {
        param($SectionContent, $GeneratorName)
        
        $lines = $SectionContent -split "`n" | Where-Object { 
            $_ -match '^\|.*\|.*\|.*\|' -and 
            $_ -notmatch '^\|\s*Service\s*\|' -and 
            $_ -notmatch '^\|\s*-+\s*\|' -and
            $_.Trim() -ne ''
        }
        
        $result = @()
        foreach ($line in $lines) {
            $parts = $line -split '\|' | ForEach-Object { $_.Trim() } | Where-Object { $_ -and $_ -notmatch '^-+$' }
            if ($parts.Count -eq 3 -and $parts[0] -ne 'Service' -and $parts[0] -notmatch '^-+$') {
                $result += @{
                    Service = $parts[0]
                    Library = $parts[1]
                    Path = $parts[2]
                    Generator = $GeneratorName
                }
            }
        }
        return $result
    }
    
    # Parse @azure-typespec/http-client-csharp libraries
    if ($content -match '## Data Plane Libraries using TypeSpec \(@azure-typespec/http-client-csharp\)[\s\S]*?Total: (\d+)([\s\S]*?)(?=##|\z)') {
        $libraries += & $parseSection $Matches[2] "@azure-typespec/http-client-csharp"
    }
    
    # Parse @typespec/http-client-csharp libraries
    if ($content -match '## Data Plane Libraries using TypeSpec \(@typespec/http-client-csharp\)[\s\S]*?Total: (\d+)([\s\S]*?)(?=##|\z)') {
        $libraries += & $parseSection $Matches[2] "@typespec/http-client-csharp"
    }
    
    # Parse @azure-typespec/http-client-csharp-mgmt libraries (management plane)
    if ($content -match '## Management Plane Libraries using TypeSpec \(@azure-typespec/http-client-csharp-mgmt\)[\s\S]*?Total: (\d+)([\s\S]*?)(?=##|\z)') {
        $libraries += & $parseSection $Matches[2] "@azure-typespec/http-client-csharp-mgmt"
    }
    
    return @($libraries)
}

# Interactive library selection
function Select-LibrariesToRegenerate {
    param([array]$Libraries)
    
    # Ensure we have an array
    if (-not $Libraries) {
        return @()
    }
    
    $Libraries = @($Libraries)
    
    Write-Host "`n==================== LIBRARY SELECTION ====================" -ForegroundColor Cyan
    Write-Host "Found $($Libraries.Count) libraries available for regeneration" -ForegroundColor White
    Write-Host ""
    
    # Display libraries grouped by generator
    $azureLibs = @($Libraries | Where-Object { $_.Generator -eq "@azure-typespec/http-client-csharp" })
    $unbrandedLibs = @($Libraries | Where-Object { $_.Generator -eq "@typespec/http-client-csharp" })
    $mgmtLibs = @($Libraries | Where-Object { $_.Generator -eq "@azure-typespec/http-client-csharp-mgmt" })
    
    $currentIndex = 1
    
    if ($azureLibs.Count -gt 0) {
        Write-Host "Azure SDK Libraries:" -ForegroundColor Yellow
        for ($i = 0; $i -lt $azureLibs.Count; $i++) {
            $lib = $azureLibs[$i]
            Write-Host ("  [{0,2}] {1,-50} ({2})" -f $currentIndex, $lib.Library, $lib.Service) -ForegroundColor Gray
            $currentIndex++
        }
        Write-Host ""
    }
    
    if ($unbrandedLibs.Count -gt 0) {
        Write-Host "Unbranded Libraries:" -ForegroundColor Yellow
        for ($i = 0; $i -lt $unbrandedLibs.Count; $i++) {
            $lib = $unbrandedLibs[$i]
            Write-Host ("  [{0,2}] {1,-50} ({2})" -f $currentIndex, $lib.Library, $lib.Service) -ForegroundColor Gray
            $currentIndex++
        }
        Write-Host ""
    }
    
    if ($mgmtLibs.Count -gt 0) {
        Write-Host "Management Plane Libraries:" -ForegroundColor Yellow
        for ($i = 0; $i -lt $mgmtLibs.Count; $i++) {
            $lib = $mgmtLibs[$i]
            Write-Host ("  [{0,2}] {1,-50} ({2})" -f $currentIndex, $lib.Library, $lib.Service) -ForegroundColor Gray
            $currentIndex++
        }
        Write-Host ""
    }
    
    Write-Host "=============================================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Enter library numbers to regenerate (comma-separated), 'all' for all libraries, or 'q' to quit:" -ForegroundColor White
    Write-Host "Example: 1,3,5  or  1-4,7  or  all" -ForegroundColor DarkGray
    Write-Host ""
    
    $selection = Read-Host "Selection"
    
    if ($selection -ieq 'q' -or $selection -ieq 'quit') {
        Write-Host "Operation cancelled by user." -ForegroundColor Yellow
        exit 0
    }
    
    if ($selection -ieq 'all') {
        return $Libraries
    }
    
    # Parse selection
    $selectedIndices = @()
    $parts = $selection -split ',' | ForEach-Object { $_.Trim() }
    
    foreach ($part in $parts) {
        if ($part -match '^(\d+)-(\d+)$') {
            # Range: 1-4
            $start = [int]$Matches[1]
            $end = [int]$Matches[2]
            $selectedIndices += ($start..$end)
        }
        elseif ($part -match '^\d+$') {
            # Single number: 3
            $selectedIndices += [int]$part
        }
        else {
            Write-Host "Invalid selection format: $part" -ForegroundColor Red
            exit 1
        }
    }
    
    # Validate and collect selected libraries
    $selectedLibraries = @()
    foreach ($index in $selectedIndices | Sort-Object -Unique) {
        if ($index -lt 1 -or $index -gt $Libraries.Count) {
            Write-Host "Invalid library number: $index (valid range: 1-$($Libraries.Count))" -ForegroundColor Red
            exit 1
        }
        $selectedLibraries += $Libraries[$index - 1]
    }
    
    if ($selectedLibraries.Count -eq 0) {
        Write-Host "No libraries selected. Exiting." -ForegroundColor Yellow
        exit 0
    }
    
    Write-Host "`nSelected $($selectedLibraries.Count) libraries for regeneration:" -ForegroundColor Green
    foreach ($lib in $selectedLibraries) {
        Write-Host "  - $($lib.Library) ($($lib.Service))" -ForegroundColor Gray
    }
    Write-Host ""
    
    # Ensure we return an array, even for a single element
    return @($selectedLibraries)
}

# Generate final report
function Write-RegenerationReport {
    param(
        [array]$Results,
        [TimeSpan]$ElapsedTime,
        [string]$DebugFolder
    )
    
    $passed = @($Results | Where-Object { $_.Success -eq $true })
    $failed = @($Results | Where-Object { $_.Success -eq $false })
    
    Write-Host "`n==================== REGENERATION REPORT ====================" -ForegroundColor Cyan
    Write-Host "Total Libraries: $($Results.Count)" -ForegroundColor White
    Write-Host "Passed: $($passed.Count)" -ForegroundColor Green
    Write-Host "Failed: $($failed.Count)" -ForegroundColor Red
    
    if ($ElapsedTime) {
        $elapsedFormatted = "{0:hh\:mm\:ss}" -f $ElapsedTime
        Write-Host "Execution Time: $elapsedFormatted" -ForegroundColor Cyan
    }
    Write-Host ""
    
    if ($passed.Count -gt 0) {
        Write-Host "PASSED LIBRARIES:" -ForegroundColor Green
        foreach ($result in $passed) {
            Write-Host "  ✓ $($result.Library) ($($result.Service))" -ForegroundColor Green
        }
        Write-Host ""
    }
    
    if ($failed.Count -gt 0) {
        Write-Host "FAILED LIBRARIES:" -ForegroundColor Red
        foreach ($result in $failed) {
            Write-Host "  ✗ $($result.Library) ($($result.Service))" -ForegroundColor Red
            Write-Host "    Error: $($result.Error)" -ForegroundColor Gray
            if ($result.Output) {
                Write-Host "    Details: $($result.Output.Substring(0, [Math]::Min(200, $result.Output.Length)))..." -ForegroundColor DarkGray
            }
        }
        Write-Host ""
    }
    
    Write-Host "=============================================================" -ForegroundColor Cyan
    
    # Save detailed report to debug folder
    $reportPath = if ($DebugFolder) { 
        Join-Path $DebugFolder "regen-report.json" 
    } else { 
        Join-Path $packageRoot "regen-report.json" 
    }
    $Results | ConvertTo-Json -Depth 10 | Set-Content $reportPath -Encoding utf8
    Write-Host "Detailed report saved to: $reportPath" -ForegroundColor Gray
}

# ============================================================================
# Main Script Execution
# ============================================================================

# Start timer
$scriptStartTime = Get-Date

try {
    # Step 1: Load and select libraries (Azure SDK Mode only, if using -Select flag)
    if ($Select) {
        Write-Host "`n[1/6] Loading libraries from Library_Inventory.md..." -ForegroundColor Cyan
        
        $inventoryPath = Join-Path $sdkRepoPath "doc" "GeneratorMigration" "Library_Inventory.md"
        if (-not (Test-Path $inventoryPath)) {
            throw "Library_Inventory.md not found at: $inventoryPath"
        }
        
        $allLibraries = Get-LibrariesToRegenerate -InventoryPath $inventoryPath
        
        # Apply generator filter before interactive selection
        $filteredLibraries = @(Filter-LibrariesByGenerator `
            -Libraries $allLibraries `
            -Azure:$Azure `
            -Unbranded:$Unbranded `
            -Mgmt:$Mgmt)
        
        if (-not $filteredLibraries -or $filteredLibraries.Count -eq 0) {
            Write-Host "No libraries found matching the specified generator filter" -ForegroundColor Yellow
            exit 0
        }
        
        $libraries = @(Select-LibrariesToRegenerate -Libraries $filteredLibraries)
        
        # Check if user cancelled selection
        if (-not $libraries -or $libraries.Count -eq 0) {
            Write-Host "No libraries selected. Exiting..." -ForegroundColor Yellow
            exit 0
        }
    }
    
    # Create debug folder for packaged artifacts with timestamped subfolder
    $timestamp = Get-Date -Format "yyyyMMdd"
    $debugFolder = Join-Path $packageRoot "debug" $timestamp
    if (-not (Test-Path $debugFolder)) {
        New-Item -ItemType Directory -Path $debugFolder -Force | Out-Null
    }
    
    Write-Host "Debug folder: $debugFolder" -ForegroundColor Gray
    Write-Host ""

    # Step 1: Build the azure generator
    Write-Host "`n[2/6] Building azure generator..." -ForegroundColor Cyan

    Push-Location $packageRoot
    try {
        Write-Host "Installing dependencies..." -ForegroundColor Gray
        Invoke "npm ci"
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to install dependencies for azure generator"
        }
        
        Write-Host "Cleaning build artifacts..." -ForegroundColor Gray
        Invoke "npm run clean"
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to clean azure generator"
        }
        
        Write-Host "Building generator..." -ForegroundColor Gray
        Invoke "npm run build"
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to build azure generator"
        }
        
        Write-Host "  Build completed" -ForegroundColor Green
    }
    finally {
        Pop-Location
    }
    
    # Step 2: Package the generators with local version
    Write-Host "`n[3/6] Packaging generators..." -ForegroundColor Cyan
    
    $localVersion = Get-LocalPackageVersion
    Write-Host "Local package version: $localVersion" -ForegroundColor Yellow
    
    $azurePackageJson = Join-Path $packageRoot "package.json"
    $originalPackageJson = Get-Content $azurePackageJson -Raw

    try {
        Update-PackageJsonVersion -PackageJsonPath $azurePackageJson -NewVersion $localVersion
        $azurePackagePath = Invoke-NpmPack -WorkingDirectory $packageRoot -DebugFolder $debugFolder
        Write-Host "Created npm package: $azurePackagePath" -ForegroundColor Green
    }
    finally {
        # Restore original package.json
        Set-Content $azurePackageJson $originalPackageJson -Encoding utf8 -NoNewline
    }
    
    # Update Packages.Data.props with local NuGet version
    $packagesDataPropsPath = Join-Path $sdkRepoPath "eng" "Packages.Data.props"
    if (-not (Test-Path $packagesDataPropsPath)) {
        throw "Packages.Data.props not found at: $packagesDataPropsPath"
    }

    Update-AzureGeneratorVersion -PackagesDataPropsPath $packagesDataPropsPath -NewVersion $localVersion

    # Add debug folder as a NuGet package source
    $nugetConfigPath = Join-Path $sdkRepoPath "NuGet.Config"
    Add-LocalNuGetSource -NuGetConfigPath $nugetConfigPath -SourcePath $debugFolder
    
    # Step 3: Build required generators and update artifacts
    Write-Host "`n[4/5] Building additional required generators and updating artifacts..." -ForegroundColor Cyan
    
    # Determine which generators are needed based on libraries to be regenerated
    if ($Select) {
        # Libraries were already selected at the beginning
        $librariesToAnalyze = $libraries
    } else {
        # Load all libraries and apply filters to determine what would be regenerated
        $inventoryPath = Join-Path $sdkRepoPath "doc" "GeneratorMigration" "Library_Inventory.md"
        if (-not (Test-Path $inventoryPath)) {
            throw "Library_Inventory.md not found at: $inventoryPath"
        }
        
        $allLibraries = Get-LibrariesToRegenerate -InventoryPath $inventoryPath
        $librariesToAnalyze = Filter-LibrariesByGenerator `
            -Libraries $allLibraries `
            -Azure:$Azure `
            -Unbranded:$Unbranded `
            -Mgmt:$Mgmt
    }
    
    # Determine which generators are actually needed
    $needsUnbranded = $false
    $needsAzure = $false
    $needsMgmt = $false
    
    if ($librariesToAnalyze -and $librariesToAnalyze.Count -gt 0) {
        foreach ($lib in $librariesToAnalyze) {
            switch ($lib.Generator) {
                "@typespec/http-client-csharp" { $needsUnbranded = $true }
                "@azure-typespec/http-client-csharp" { $needsAzure = $true; $needsUnbranded = $true }
                "@azure-typespec/http-client-csharp-mgmt" { $needsMgmt = $true; $needsAzure = $true; $needsUnbranded = $true }
            }
        }
    }
    
    $generatorSummary = @()
    if ($needsUnbranded) { $generatorSummary += "Unbranded" }
    if ($needsAzure) { $generatorSummary += "Azure" }
    if ($needsMgmt) { $generatorSummary += "Management" }
    
    if ($generatorSummary.Count -gt 0) {
        Write-Host "Required generators: $($generatorSummary -join ', ')" -ForegroundColor Yellow
    } else {
        Write-Host "No additional generators required" -ForegroundColor Yellow
    }
    
    # Update eng folder artifacts if needed
    if ($needsAzure -or $needsUnbranded) {
        Write-Host "Updating eng folder artifacts..." -ForegroundColor Gray
        
        $engFolder = Join-Path $sdkRepoPath "eng"
        $tempDir = Join-Path $engFolder "temp-package-update"
        New-Item -ItemType Directory -Path $tempDir -Force | Out-Null
        
        # Helper function to update emitter package files
        $updateEmitterPackage = {
            param($PackagePath, $EmitterJsonName, $LockJsonName)
            
            $emitterJson = Join-Path $engFolder $EmitterJsonName
            $tempPackageJson = Join-Path $tempDir "package.json"
            
            Copy-Item $emitterJson $tempPackageJson -Force
            
            Push-Location $tempDir
            try {
                Invoke "npm install `"`"file:$PackagePath`"`" --package-lock-only" $tempDir
                if ($LASTEXITCODE -ne 0) {
                    throw "Failed to install local package for emitter update."
                }
                
                Copy-Item $tempPackageJson $emitterJson -Force
                $lockFile = Join-Path $tempDir "package-lock.json"
                if (Test-Path $lockFile) {
                    Copy-Item $lockFile (Join-Path $engFolder $LockJsonName) -Force
                }
                
                # Cleanup temp files
                Remove-Item $tempPackageJson, $lockFile -Force -ErrorAction SilentlyContinue
            }
            finally {
                Pop-Location
            }
        }
        
        try {
            if ($needsAzure -and $azurePackagePath) {
                & $updateEmitterPackage $azurePackagePath "azure-typespec-http-client-csharp-emitter-package.json" "azure-typespec-http-client-csharp-emitter-package-lock.json"
            }
            
            Write-Host "  Artifacts updated" -ForegroundColor Green
        }
        finally {
            Remove-Item $tempDir -Recurse -Force -ErrorAction SilentlyContinue
        }
    }
    
    # Update management plane generator if needed
    if ($needsMgmt) {
        Write-Host "Building management plane generator..." -ForegroundColor Gray
        
        $engFolder = Join-Path $sdkRepoPath "eng"
        $mgmtGeneratorPath = Join-Path $engFolder "packages" "http-client-csharp-mgmt"
        
        if (Test-Path $mgmtGeneratorPath) {
            Update-MgmtGenerator `
                -EngFolder $engFolder `
                -DebugFolder $debugFolder `
                -LocalVersion $localVersion
            
            Write-Host "  Management plane generator completed" -ForegroundColor Green
        } else {
            Write-Host "  Management plane generator not found, skipping..." -ForegroundColor Yellow
        }
    }
    
    # Step 4: Regenerate libraries
    Write-Host "`n[5/6] Regenerating libraries..." -ForegroundColor Cyan
    
    if (-not $Select) {
        # Load all libraries if not using -Select flag
        $inventoryPath = Join-Path $sdkRepoPath "doc" "GeneratorMigration" "Library_Inventory.md"
        if (-not (Test-Path $inventoryPath)) {
            throw "Library_Inventory.md not found at: $inventoryPath"
        }
        
        $allLibraries = Get-LibrariesToRegenerate -InventoryPath $inventoryPath
        
        # Apply generator filter
        $libraries = Filter-LibrariesByGenerator `
            -Libraries $allLibraries `
            -Azure:$Azure `
            -Unbranded:$Unbranded `
            -Mgmt:$Mgmt
        
        if ($libraries.Count -eq 0) {
            Write-Host "No libraries found matching the specified generator filter" -ForegroundColor Yellow
            Write-Host "Skipping regeneration step..." -ForegroundColor Gray
        } else {
            $filterText = if ($Azure) {
                " (Azure generator only)"
            } elseif ($Unbranded) {
                " (Unbranded generator only)"
            } elseif ($Mgmt) {
                " (Management plane generator only)"
            } else {
                ""
            }
            Write-Host "Regenerating $($libraries.Count) libraries$filterText" -ForegroundColor Yellow
        }
    } else {
        # Libraries were already selected at the beginning
        if ($libraries -and $libraries.Count -gt 0) {
            Write-Host "Using $($libraries.Count) previously selected libraries" -ForegroundColor Yellow
        } else {
            Write-Host "No libraries were selected" -ForegroundColor Yellow
        }
    }
    
    if (-not $libraries -or $libraries.Count -eq 0) {
        Write-Host "No libraries selected for regeneration" -ForegroundColor Yellow
        $failedCount = 0
    } else {
        
        # Determine parallel execution throttle limit: (CPU cores - 2), min 1, max 8
        $cpuCores = if ($IsWindows -or $PSVersionTable.PSVersion.Major -lt 6) {
            (Get-CimInstance -ClassName Win32_Processor | Measure-Object -Property NumberOfLogicalProcessors -Sum).Sum
        } elseif ($IsMacOS) {
            [int](sysctl -n hw.ncpu)
        } else {
            [int](nproc)
        }
        
        $throttleLimit = [Math]::Max(1, [Math]::Min(8, $cpuCores - 2))
        
        Write-Host "Using $throttleLimit concurrent jobs (detected $cpuCores logical processors)" -ForegroundColor Gray
        Write-Host ""
        
        # Pre-install tsp-client to avoid concurrent npm operations
    Write-Host "Pre-installing tsp-client..." -ForegroundColor Gray
    $tspClientDir = Join-Path $sdkRepoPath "eng" "common" "tsp-client"
    Invoke "npm ci --prefix $tspClientDir" $tspClientDir
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to install tsp-client"
    }
    Write-Host "  tsp-client ready" -ForegroundColor Green
    Write-Host ""
    
    # Thread-safe collections for progress tracking
    $completed = [System.Collections.Concurrent.ConcurrentBag[int]]::new()
    $totalCount = $libraries.Count
    
    # Run regeneration in parallel
    $results = $libraries | ForEach-Object -ThrottleLimit $throttleLimit -Parallel {
        $library = $_
        $azureSdkPath = $using:sdkRepoPath
        $completedBag = $using:completed
        $total = $using:totalCount
        
        # Determine build path (check for src subdirectory)
        $libraryPath = Join-Path $azureSdkPath $library.Path
        $srcPath = Join-Path $libraryPath "src"
        $buildPath = if ((Test-Path $srcPath) -and (Get-ChildItem -Path $srcPath -Filter "*.csproj" -ErrorAction SilentlyContinue)) {
            $srcPath
        } else {
            $libraryPath
        }
        
        # Regenerate library
        $result = try {
            if (-not (Test-Path $libraryPath)) {
                @{ Success = $false; Error = "Library path not found"; Output = "" }
            } else {
                Push-Location $buildPath
                try {
                    $output = & dotnet build /t:GenerateCode /p:SkipTspClientInstall=true 2>&1
                    $exitCode = $LASTEXITCODE
                    
                    if ($exitCode -ne 0) {
                        @{ Success = $false; Error = "Generation failed with exit code $exitCode"; Output = ($output -join "`n") }
                    } else {
                        @{ Success = $true; Output = ($output -join "`n") }
                    }
                }
                finally {
                    Pop-Location
                }
            }
        }
        catch {
            @{ Success = $false; Error = $_.Exception.Message; Output = $_.Exception.ToString() }
        }
        
        # Update progress counter
        $completedBag.Add(1)
        $currentCount = $completedBag.Count
        
        # Thread-safe console output with progress
        $status = if ($result.Success) { "✓" } else { "✗" }
        $color = if ($result.Success) { "Green" } else { "White" }
        
        $progressMsg = "[$currentCount/$total] $status $($library.Library)"
        Write-Host $progressMsg -ForegroundColor $color
        
        # Return result with library metadata
        return @{
            Service = $library.Service
            Library = $library.Library
            Path = $library.Path
            Generator = $library.Generator
            Success = if ($result.ContainsKey('Success')) { $result.Success } else { $false }
            Error = if ($result.ContainsKey('Error')) { $result.Error } else { "" }
            Output = if ($result.ContainsKey('Output')) { $result.Output } else { "" }
        }
    }
    
    # Generate final report
    $scriptEndTime = Get-Date
    $elapsedTime = $scriptEndTime - $scriptStartTime
    
    Write-RegenerationReport -Results $results -ElapsedTime $elapsedTime -DebugFolder $debugFolder
    
    # Check if any libraries failed
    $failedLibraries = @($results | Where-Object { -not $_.Success })
    $failedCount = $failedLibraries.Count
    }
    
    if ($failedCount -gt 0) {
        Write-Host "`nValidation completed with warnings: $failedCount libraries failed to regenerate" -ForegroundColor Yellow
        Write-Host "Check the detailed report above for error information" -ForegroundColor Yellow
    } else {
        Write-Host "`nValidation completed successfully! All libraries regenerated without errors." -ForegroundColor Green
        
        # Step 5: Restore artifacts to original state
        Write-Host "`n[6/6] Restoring artifacts to original state..." -ForegroundColor Cyan
        
        Push-Location $sdkRepoPath
        try {
            Write-Host "Restoring modified files..." -ForegroundColor Gray
            $filesToRestore = @(
                "eng/azure-typespec-http-client-csharp-emitter-package.json"
                "eng/azure-typespec-http-client-csharp-emitter-package-lock.json"
                "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json"
                "eng/azure-typespec-http-client-csharp-mgmt-emitter-package-lock.json"
                "eng/packages/http-client-csharp/package-lock.json"
                "eng/packages/http-client-csharp-mgmt/package.json"
                "eng/packages/http-client-csharp-mgmt/package-lock.json"
                "eng/Packages.Data.props"
                "NuGet.Config"
            )
            $restoreCmd = "git restore $($filesToRestore -join ' ')"
            Invoke $restoreCmd $sdkRepoPath
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to restore modified files"
            }
            Write-Host "  All artifacts restored" -ForegroundColor Green
        }
        finally {
            Pop-Location
        }
    }
}
catch {
    Write-Host "`nScript encountered an error during setup or configuration." -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    Write-Host $_.ScriptStackTrace -ForegroundColor DarkGray
    
    # Attempt to restore NuGet.Config even on failure
    Write-Host "`nAttempting to restore NuGet.Config..." -ForegroundColor Yellow
    Push-Location $sdkRepoPath -ErrorAction SilentlyContinue
    try {
        #& git restore NuGet.Config 2>&1 | Out-Null
        Invoke "git restore NuGet.Config" $sdkRepoPath
        Write-Host "  NuGet.Config restored" -ForegroundColor Green
    }
    catch {
        Write-Host "  Failed to restore NuGet.Config" -ForegroundColor Red
    }
    finally {
        Pop-Location -ErrorAction SilentlyContinue
    }
    
    exit 1
}

Write-Host "`nScript completed." -ForegroundColor Cyan
