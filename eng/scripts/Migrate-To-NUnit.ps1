<#
.SYNOPSIS
    Migrates azure-sdk-for-net test projects from NUnit 3 to NUnit 4.

.DESCRIPTION
    This script automates the migration process from NUnit 3 to NUnit 4 by:
    - Adding NUnit.Analyzers package reference to appropriate test projects
    - Applying NUnit analyzer code fixes to convert classic asserts to constraint model
    
    The script handles two types of packages differently:
    - Data plane (non-Azure.ResourceManager.*): Adds NUnit.Analyzers reference
    - Management plane (Azure.ResourceManager.*): Skips analyzer reference (handled centrally)
    
    NO GIT OPERATIONS are performed - user commits changes manually.

.PARAMETER RepoRoot
    The root directory of the azure-sdk-for-net repository. Defaults to current directory.

.PARAMETER DiagnosticIds
    Array of NUnit diagnostic IDs to apply. Defaults to NUNIT 2001-2007, 2015-2019, 2027-2039, 2048-2050.

.PARAMETER DryRun
    If specified, shows what would be done without making any changes.

.EXAMPLE
    .\Migrate-To-NUnit4.ps1
    Runs the migration from the current directory.

.EXAMPLE
    .\Migrate-To-NUnit4.ps1 -RepoRoot "C:\repos\azure-sdk-for-net"
    Runs the migration from the specified repository root.

.EXAMPLE
    .\Migrate-To-NUnit4.ps1 -DryRun
    Shows what would be done without making changes.

.NOTES
    Based on NUnit 4.0 Migration Guide: https://docs.nunit.org/articles/nunit/release-notes/Nunit4.0-MigrationGuide.html
    
    IMPORTANT: The analyzers only work when code compiles. Apply analyzer fixes BEFORE upgrading NUnit to version 4.0.0.
#>

[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = ".",
    
    [Parameter()]
    [string[]]$DiagnosticIds = @(
        # Classic assert conversions
        #"NUnit2001", "NUnit2002", "NUnit2003", "NUnit2004", "NUnit2005", "NUnit2006", "NUnit2007",
        # String and collection asserts
        #"NUnit2015", "NUnit2016", "NUnit2017", "NUnit2018", "NUnit2019",
        "NUnit2017", "NUnit2018", "NUnit2019",
        # Additional classic assert conversions
        "NUnit2027", "NUnit2028", "NUnit2029", "NUnit2030", "NUnit2031", "NUnit2032", "NUnit2033",
        "NUnit2034", "NUnit2035", "NUnit2036", "NUnit2037", "NUnit2038", "NUnit2039",
        # Constraint-related fixes
        "NUnit2048", "NUnit2049", "NUnit2050"
    ),
    
    [Parameter()]
    [switch]$DryRun,
    
    [Parameter()]
    [switch]$ProcessDiagnosticsIndividually,
    
    [Parameter()]
    [switch]$ShowVerboseOutput
)

$ErrorActionPreference = "Stop"

# Convert to absolute path
$RepoRoot = Resolve-Path $RepoRoot -ErrorAction Stop

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "NUnit 3 to NUnit 4 Migration Script" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Repository: $RepoRoot" -ForegroundColor Yellow
Write-Host "Dry Run: $DryRun" -ForegroundColor Yellow
Write-Host ""

# Validate we're in the azure-sdk-for-net repo
if (-not (Test-Path (Join-Path $RepoRoot "sdk"))) {
    Write-Error "The specified directory does not appear to be the azure-sdk-for-net repository root. 'sdk' folder not found."
    exit 1
}

# Find the SDK directory
$sdkDir = Join-Path $RepoRoot "sdk"
Write-Host "Scanning SDK directory: $sdkDir" -ForegroundColor Cyan

# Step 1: Add NUnit.Analyzers to appropriate test projects
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 1: Adding NUnit.Analyzers References" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

$packageName = "NUnit.Analyzers"
$insertSnippet = "    <PackageReference Include=`"$packageName`" />"

# Find all test .csproj files
$testProjects = Get-ChildItem -Path $sdkDir -Filter "*.csproj" -Recurse | Where-Object {
    $_.Name -match "\.Tests?\.csproj$" -or $_.Directory.Name -match "^tests?$"
}

Write-Host "Found $($testProjects.Count) potential test projects" -ForegroundColor Yellow

$projectsModified = 0
$projectsSkipped = 0
$projectsAlreadyHaveAnalyzer = 0

foreach ($csproj in $testProjects) {
    $csprojPath = $csproj.FullName
    $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
    
    # Read the project file
    $content = Get-Content -Path $csprojPath -Raw
    
    # Check if already has NUnit.Analyzers
    if ($content -match "<PackageReference\s+Include=`"$packageName`"") {
        Write-Host "  [SKIP] Already has $packageName : $relativePath" -ForegroundColor Gray
        $projectsAlreadyHaveAnalyzer++
        continue
    }
    
    # Determine if this is a management plane package
    $isManagementPlane = $relativePath -match "\\Azure\.ResourceManager\."
    
    if ($isManagementPlane) {
        Write-Host "  [SKIP] Management plane (handled centrally): $relativePath" -ForegroundColor DarkYellow
        $projectsSkipped++
        continue
    }
    
    # This is a data plane package - add the analyzer
    Write-Host "  [ADD]  Adding $packageName : $relativePath" -ForegroundColor Green
    
    if (-not $DryRun) {
        # Find the NUnit PackageReference and add analyzer after it
        if ($content -match '(?s)(<PackageReference\s+Include="NUnit"[^>]*/>)') {
            $nunitReference = $Matches[1]
            $newContent = $content -replace [regex]::Escape($nunitReference), "$nunitReference`r`n$insertSnippet"
            
            Set-Content -Path $csprojPath -Value $newContent -NoNewline
            $projectsModified++
        }
        else {
            Write-Warning "Could not find NUnit reference pattern in $relativePath"
        }
    }
    else {
        $projectsModified++
    }
}

Write-Host ""
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  Projects modified: $projectsModified" -ForegroundColor Green
Write-Host "  Projects skipped (mgmt plane): $projectsSkipped" -ForegroundColor Yellow
Write-Host "  Projects already had analyzer: $projectsAlreadyHaveAnalyzer" -ForegroundColor Yellow

if ($DryRun) {
    Write-Host ""
    Write-Host "DRY RUN: No files were modified" -ForegroundColor Yellow
    exit 0
}

# Step 2: Restore NuGet packages
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 2: Restoring NuGet Packages" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

# Find all solution files
$solutions = Get-ChildItem -Path $sdkDir -Filter "*.sln" -Recurse

Write-Host "Found $($solutions.Count) solution files. Restoring packages..." -ForegroundColor Yellow

foreach ($sln in $solutions) {
    $slnPath = $sln.FullName
    $relativePath = $slnPath.Substring($RepoRoot.Length + 1)
    
    Write-Host "  Restoring: $relativePath" -ForegroundColor Gray
    
    try {
        & dotnet restore "$slnPath" --verbosity quiet
        if ($LASTEXITCODE -ne 0) {
            Write-Warning "Failed to restore $relativePath"
        }
    }
    catch {
        Write-Warning "Error restoring $relativePath : $_"
    }
}

Write-Host "Package restoration complete" -ForegroundColor Green

# Step 3: Apply analyzer fixes
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 3: Applying Analyzer Code Fixes" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

# Get all test projects (both data plane and management plane)
$projectsToFormat = Get-ChildItem -Path $sdkDir -Filter "*.csproj" -Recurse | Where-Object {
    $_.Name -match "\.Tests?\.csproj$" -or $_.Directory.Name -match "^tests?$"
}

Write-Host "Found $($projectsToFormat.Count) test projects to format" -ForegroundColor Yellow
Write-Host "Applying $($DiagnosticIds.Count) diagnostic fixes..." -ForegroundColor Yellow

if ($ProcessDiagnosticsIndividually) {
    Write-Host "Mode: Processing each diagnostic individually (slower but more reliable)" -ForegroundColor Yellow
}
else {
    Write-Host "Mode: Processing all diagnostics together (faster)" -ForegroundColor Yellow
    Write-Host "  (Use -ProcessDiagnosticsIndividually if fixes are not applied)" -ForegroundColor Gray
}
Write-Host ""

$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
$totalProjects = $projectsToFormat.Count
$projectCounter = 0
$counterLock = [System.Threading.Mutex]::new($false, "ProgressCounter")

if ($ProcessDiagnosticsIndividually) {
    # Process each diagnostic separately
    $diagnosticCounter = 0
    foreach ($diagnostic in $DiagnosticIds) {
        $diagnosticCounter++
        Write-Host "[$diagnosticCounter/$($DiagnosticIds.Count)] Processing diagnostic: $diagnostic" -ForegroundColor Cyan
        
        $results = $projectsToFormat | ForEach-Object -ThrottleLimit 8 -Parallel {
            $csproj = $_
            $csprojPath = $csproj.FullName
            $csprojDir = $csproj.Directory.FullName
            $diagnostic = $using:diagnostic
            $RepoRoot = $using:RepoRoot
            $verboseMode = $using:ShowVerboseOutput
            $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
            
            # Create temporary .editorconfig
            $editorConfigPath = Join-Path $csprojDir ".editorconfig"
            $editorConfigExisted = Test-Path $editorConfigPath
            $originalEditorConfig = $null
            
            $success = $false
            $changesApplied = $false
            try {
                if ($editorConfigExisted) {
                    $originalEditorConfig = Get-Content -Path $editorConfigPath -Raw
                }
                else {
                    "[*.cs]" | Set-Content -Path $editorConfigPath
                }
                
                # Add diagnostic severity
                "`ndotnet_diagnostic.$diagnostic.severity = warning" | Add-Content -Path $editorConfigPath
                
                # Run dotnet format
                $verbosityLevel = if ($verboseMode) { "normal" } else { "quiet" }
                $output = & dotnet format analyzers "$csprojPath" --diagnostics $diagnostic --severity info --no-restore --verbosity $verbosityLevel 2>&1 | Out-String
                
                if ($LASTEXITCODE -eq 0) {
                    $success = $true
                    # Check if any files were formatted
                    $changesApplied = $output -match "Formatted \d+ of \d+ files" -and $output -notmatch "Formatted 0 of"
                    
                    if ($verboseMode -or $changesApplied) {
                        Write-Host "    [OK] $relativePath" -ForegroundColor Green
                        if ($verboseMode) {
                            Write-Host "    Output: $output" -ForegroundColor DarkGray
                        }
                    }
                }
                else {
                    Write-Warning "    [FAIL] $relativePath (Exit code: $LASTEXITCODE)"
                    if ($verboseMode) {
                        Write-Host "    Output: $output" -ForegroundColor DarkGray
                    }
                }
            }
            catch {
                Write-Warning "    [ERROR] $relativePath : $_"
            }
            finally {
                # Restore or remove .editorconfig
                if ($editorConfigExisted -and $originalEditorConfig) {
                    Set-Content -Path $editorConfigPath -Value $originalEditorConfig -NoNewline
                }
                elseif (-not $editorConfigExisted -and (Test-Path $editorConfigPath)) {
                    Remove-Item -Path $editorConfigPath -Force -ErrorAction SilentlyContinue
                }
            }
            
            return @{ Success = $success; ChangesApplied = $changesApplied }
        }
        
        $successCount = ($results | Where-Object { $_.Success -eq $true }).Count
        $changesCount = ($results | Where-Object { $_.ChangesApplied -eq $true }).Count
        Write-Host "  Processed: $successCount projects, Changes applied: $changesCount" -ForegroundColor Green
    }
}
else {
    # Process all diagnostics together (optimized)
    $results = $projectsToFormat | ForEach-Object -ThrottleLimit 8 -Parallel {
        $csproj = $_
        $csprojPath = $csproj.FullName
        $csprojDir = $csproj.Directory.FullName
        $diagnostics = $using:DiagnosticIds
        $RepoRoot = $using:RepoRoot
        $verboseMode = $using:ShowVerboseOutput
        $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
        $totalProjects = $using:totalProjects
        $counterLock = $using:counterLock
        $counter = $using:projectCounter
        
        # Thread-safe progress tracking
        $null = $counterLock.WaitOne()
        try {
            $script:projectCounter++
            $current = $script:projectCounter
        }
        finally {
            $counterLock.ReleaseMutex()
        }
        
        $percent = [math]::Round(($current / $totalProjects) * 100)
        Write-Host "  [$percent% - $current/$totalProjects] $relativePath" -ForegroundColor Gray
        
        # Create temporary .editorconfig
        $editorConfigPath = Join-Path $csprojDir ".editorconfig"
        $editorConfigExisted = Test-Path $editorConfigPath
        $originalEditorConfig = $null
        
        $success = $false
        $changesApplied = $false
        try {
            if ($editorConfigExisted) {
                $originalEditorConfig = Get-Content -Path $editorConfigPath -Raw
            }
            else {
                "[*.cs]" | Set-Content -Path $editorConfigPath
            }
            
            # Add ALL diagnostic severities
            foreach ($diagnostic in $diagnostics) {
                "`ndotnet_diagnostic.$diagnostic.severity = warning" | Add-Content -Path $editorConfigPath
            }
            
            # Run dotnet format with comma-separated diagnostics
            $diagnosticsList = $diagnostics -join ','
            $verbosityLevel = if ($verboseMode) { "normal" } else { "quiet" }
            $output = & dotnet format analyzers "$csprojPath" --diagnostics $diagnosticsList --severity info --no-restore --verbosity $verbosityLevel 2>&1 | Out-String
            
            if ($LASTEXITCODE -eq 0) {
                $success = $true
                # Check if any files were formatted
                $changesApplied = $output -match "Formatted \d+ of \d+ files" -and $output -notmatch "Formatted 0 of"
                
                if ($changesApplied) {
                    Write-Host "    [CHANGES APPLIED] $relativePath" -ForegroundColor Green
                }
                elseif ($verboseMode) {
                    Write-Host "    [NO CHANGES] $relativePath" -ForegroundColor DarkGray
                }
                
                if ($verboseMode) {
                    Write-Host "    Output: $output" -ForegroundColor DarkGray
                }
            }
            else {
                Write-Warning "    [FAIL] $relativePath (Exit code: $LASTEXITCODE)"
                if ($verboseMode) {
                    Write-Host "    Output: $output" -ForegroundColor DarkGray
                }
            }
        }
        catch {
            Write-Warning "    [ERROR] $relativePath : $_"
        }
        finally {
            # Restore or remove .editorconfig
            if ($editorConfigExisted -and $originalEditorConfig) {
                Set-Content -Path $editorConfigPath -Value $originalEditorConfig -NoNewline
            }
            elseif (-not $editorConfigExisted -and (Test-Path $editorConfigPath)) {
                Remove-Item -Path $editorConfigPath -Force -ErrorAction SilentlyContinue
            }
        }
        
        return @{ Success = $success; ChangesApplied = $changesApplied }
    }
}

$stopwatch.Stop()
$projectsProcessed = ($results | Where-Object { $_.Success -eq $true }).Count
$projectsFailed = ($results | Where-Object { $_.Success -ne $true }).Count
$projectsWithChanges = ($results | Where-Object { $_.ChangesApplied -eq $true }).Count

Write-Host ""
Write-Host "Processing Summary:" -ForegroundColor Cyan
Write-Host "  Successful: $projectsProcessed projects" -ForegroundColor Green
Write-Host "  Changes applied: $projectsWithChanges projects" -ForegroundColor Green
if ($projectsFailed -gt 0) {
    Write-Host "  Failed: $projectsFailed projects" -ForegroundColor Red
}
Write-Host "  Time elapsed: $($stopwatch.Elapsed.ToString('hh\:mm\:ss'))" -ForegroundColor Yellow

if ($projectsWithChanges -eq 0 -and -not $ProcessDiagnosticsIndividually) {
    Write-Host ""
    Write-Host "WARNING: No changes were applied!" -ForegroundColor Yellow
    Write-Host "Try running with -ProcessDiagnosticsIndividually flag" -ForegroundColor Yellow
}

# Step 4: Remove NUnit.Analyzers references
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 4: Removing NUnit.Analyzers References" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

$projectsWithAnalyzer = Get-ChildItem -Path $sdkDir -Filter "*.csproj" -Recurse | Where-Object {
    $_.Name -match "\.Tests?\.csproj$" -or $_.Directory.Name -match "^tests?$"
}

$projectsAnalyzerRemoved = 0
$projectsAnalyzerNotFound = 0

foreach ($csproj in $projectsWithAnalyzer) {
    $csprojPath = $csproj.FullName
    $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
    
    # Read the project file
    $content = Get-Content -Path $csprojPath -Raw
    
    # Check if has NUnit.Analyzers
    if ($content -match '<PackageReference\s+Include="NUnit\.Analyzers"\s*/>\r?\n?') {
        $lineToRemove = $Matches[0]
        
        # Also check if there's whitespace before it to remove the whole line cleanly
        if ($content -match '\s*<PackageReference\s+Include="NUnit\.Analyzers"\s*/>\r?\n') {
            $lineToRemove = $Matches[0]
        }
        
        Write-Host "  [REMOVE] Removing NUnit.Analyzers from: $relativePath" -ForegroundColor Yellow
        
        $newContent = $content -replace [regex]::Escape($lineToRemove), ''
        Set-Content -Path $csprojPath -Value $newContent -NoNewline
        $projectsAnalyzerRemoved++
    }
    else {
        $projectsAnalyzerNotFound++
    }
}

Write-Host ""
Write-Host "Analyzer Removal Summary:" -ForegroundColor Cyan
Write-Host "  Analyzers removed: $projectsAnalyzerRemoved projects" -ForegroundColor Green
Write-Host "  No analyzer found: $projectsAnalyzerNotFound projects" -ForegroundColor Gray

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Migration Complete!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "1. Review the changes made to test files" -ForegroundColor White
Write-Host "2. Build the solution to verify no errors" -ForegroundColor White
Write-Host "3. Run tests to ensure everything still works" -ForegroundColor White
Write-Host "4. Commit the changes when ready" -ForegroundColor White
Write-Host ""
Write-Host "Note: You can now upgrade NUnit to version 4.0.0" -ForegroundColor Cyan