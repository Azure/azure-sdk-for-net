<#
.SYNOPSIS
    Targeted migration of specific test projects from NUnit 3 to NUnit 4 assertions.

.DESCRIPTION
    This script focuses on specific service directories that were missed by the initial
    migration. It applies only safe diagnostic fixes to avoid unwanted transformations:
    - Converts Assert.NotNull/Null/AreEqual/etc to Assert.That
    - Does NOT add Assert.Multiple calls
    - Does NOT convert Assert.True(x == y) to Assert.That(x, Is.EqualTo(y))
    
    Optimized version that processes all diagnostics at once per project.

.PARAMETER RepoRoot
    The root directory of the azure-sdk-for-net repository. Defaults to current directory.

.PARAMETER DryRun
    If specified, shows what would be done without making any changes.

.EXAMPLE
    .\Migrate-To-NUnit-Targeted.ps1
    Runs the targeted migration from the current directory.

.EXAMPLE
    .\Migrate-To-NUnit-Targeted.ps1 -DryRun
    Shows what would be done without making changes.

.NOTES
    This is a focused script for fixing specific directories that were missed.
    Uses only safe diagnostic IDs to avoid unwanted transformations.
#>

[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = ".",
    
    [Parameter()]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

# Safe diagnostic IDs - classic assertion conversions including Assert.AreEqual
$DiagnosticIds = @(
    "NUnit2001", "NUnit2002", "NUnit2003", "NUnit2004", "NUnit2005", "NUnit2006", "NUnit2007",
    "NUnit2010",
    "NUnit2015", "NUnit2016", "NUnit2017", "NUnit2018", "NUnit2019",
    "NUnit2021", "NUnit2023", "NUnit2024", "NUnit2025",
    "NUnit2027", "NUnit2028", "NUnit2029", "NUnit2030", "NUnit2031", "NUnit2032", "NUnit2033",
    "NUnit2034", "NUnit2035", "NUnit2036", "NUnit2037", "NUnit2038", "NUnit2039",
    "NUnit2048", "NUnit2049", "NUnit2050"
)

# Create comma-separated list for dotnet format
$diagnosticsList = $DiagnosticIds -join ','

# Targeted directories
$TargetedDirectories = @(
    "sdk/storage/Azure.Storage.Blobs",
    "sdk/storage/Azure.Storage.Queues",
    "sdk/storage/Azure.Storage.Files.DataLake",
    "sdk/storage/Azure.Storage.Files.Shares",
    "sdk/storage/Azure.Storage.Common",
    "sdk/storage/Azure.Storage.DataMovement",
    "sdk/storage/Azure.Storage.DataMovement.Blobs",
    "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs",
    "sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSub"
)

# Convert to absolute path
$RepoRoot = Resolve-Path $RepoRoot -ErrorAction Stop

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "NUnit 3 to NUnit 4 Targeted Migration" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Repository: $RepoRoot" -ForegroundColor Yellow
Write-Host "Dry Run: $DryRun" -ForegroundColor Yellow
Write-Host "Diagnostics: $($DiagnosticIds.Count) IDs" -ForegroundColor Yellow
Write-Host "Target Directories: $($TargetedDirectories.Count)" -ForegroundColor Yellow
Write-Host ""

# Validate we're in the azure-sdk-for-net repo
if (-not (Test-Path (Join-Path $RepoRoot "sdk"))) {
    Write-Error "The specified directory does not appear to be the azure-sdk-for-net repository root. 'sdk' folder not found."
    exit 1
}

if ($DryRun) {
    Write-Host "DRY RUN MODE - No changes will be made" -ForegroundColor Yellow
    Write-Host ""
}

# Step 1: Add NUnit.Analyzers to test projects
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 1: Adding NUnit.Analyzers References" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

$allTestProjects = @()

foreach ($targetDir in $TargetedDirectories) {
    $fullPath = Join-Path $RepoRoot $targetDir
    
    if (-not (Test-Path $fullPath)) {
        Write-Warning "Directory not found: $targetDir"
        continue
    }
    
    Write-Host "Scanning: $targetDir" -ForegroundColor Gray
    
    $testProjects = Get-ChildItem -Path $fullPath -Filter "*.csproj" -Recurse | Where-Object {
        $_.Name -match "\.Tests?\.csproj$" -or $_.Directory.Name -match "^tests?$"
    }
    
    if ($testProjects) {
        Write-Host "  Found $($testProjects.Count) test project(s)" -ForegroundColor Green
        $allTestProjects += $testProjects
    }
    else {
        Write-Host "  No test projects found" -ForegroundColor DarkGray
    }
}

Write-Host ""
Write-Host "Total test projects found: $($allTestProjects.Count)" -ForegroundColor Yellow

if ($allTestProjects.Count -eq 0) {
    Write-Warning "No test projects found in targeted directories"
    exit 0
}

if ($DryRun) {
    Write-Host ""
    Write-Host "DRY RUN: Would process $($allTestProjects.Count) projects" -ForegroundColor Yellow
    Write-Host "DRY RUN: Exiting before making changes" -ForegroundColor Yellow
    exit 0
}

# Add NUnit.Analyzers to projects
$packageName = "NUnit.Analyzers"
$insertSnippet = "    <PackageReference Include=`"$packageName`" />"
$projectsModified = 0
$projectsAlreadyHaveAnalyzer = 0

foreach ($csproj in $allTestProjects) {
    $csprojPath = $csproj.FullName
    $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
    
    $content = Get-Content -Path $csprojPath -Raw
    
    if ($content -match "<PackageReference\s+Include=`"$packageName`"") {
        Write-Host "  [SKIP] Already has $packageName : $relativePath" -ForegroundColor Gray
        $projectsAlreadyHaveAnalyzer++
        continue
    }
    
    Write-Host "  [ADD]  Adding $packageName : $relativePath" -ForegroundColor Green
    
    # Try to find the NUnit PackageReference and add analyzer after it
    # If not found, add to first ItemGroup (NUnit might be centrally managed)
    if ($content -match '(?s)(<PackageReference\s+Include="NUnit"[^>]*/>)') {
        $nunitReference = $Matches[1]
        $newContent = $content -replace [regex]::Escape($nunitReference), "$nunitReference`r`n$insertSnippet"
        Set-Content -Path $csprojPath -Value $newContent -NoNewline
        $projectsModified++
    }
    elseif ($content -match '(?s)(<ItemGroup>)') {
        # NUnit reference not found (likely central), add to first ItemGroup
        $firstItemGroup = $Matches[1]
        $newContent = $content -replace [regex]::Escape($firstItemGroup), "$firstItemGroup`r`n$insertSnippet"
        Set-Content -Path $csprojPath -Value $newContent -NoNewline
        $projectsModified++
    }
    else {
        Write-Warning "Could not find suitable location to add $packageName in $relativePath"
    }
}

Write-Host ""
Write-Host "Added NUnit.Analyzers to $projectsModified project(s)" -ForegroundColor Green
Write-Host "Skipped $projectsAlreadyHaveAnalyzer project(s) that already had it" -ForegroundColor Gray

# Step 2: Restore NuGet packages for targeted projects
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 2: Restoring NuGet Packages" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

$uniqueSolutions = @{}
foreach ($proj in $allTestProjects) {
    # Find the nearest .sln file
    $dir = $proj.Directory
    while ($dir.FullName.StartsWith($RepoRoot)) {
        $slnFiles = Get-ChildItem -Path $dir.FullName -Filter "*.sln" -ErrorAction SilentlyContinue
        if ($slnFiles) {
            foreach ($sln in $slnFiles) {
                $uniqueSolutions[$sln.FullName] = $true
            }
            break
        }
        $dir = $dir.Parent
        if ($null -eq $dir) { break }
    }
}

Write-Host "Found $($uniqueSolutions.Count) solution(s) to restore" -ForegroundColor Yellow

foreach ($slnPath in $uniqueSolutions.Keys) {
    $relativePath = $slnPath.Substring($RepoRoot.Length + 1)
    Write-Host "  Restoring: $relativePath" -ForegroundColor Gray
    
    try {
        & dotnet restore "$slnPath" --verbosity quiet 2>&1 | Out-Null
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
Write-Host "Processing $($DiagnosticIds.Count) diagnostics across $($allTestProjects.Count) projects" -ForegroundColor Yellow
Write-Host "Using parallel processing for each diagnostic" -ForegroundColor Gray
Write-Host ""

$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
$diagnosticCounter = 0

# Process each diagnostic separately, but parallelize projects within each diagnostic
foreach ($diagnostic in $DiagnosticIds) {
    $diagnosticCounter++
    Write-Host "[$diagnosticCounter/$($DiagnosticIds.Count)] Processing diagnostic: $diagnostic" -ForegroundColor Cyan
    
    $formattingJobs = @()
    
    # Launch formatting jobs in parallel for all projects
    foreach ($csproj in $allTestProjects) {
        $job = Start-Job -ScriptBlock {
            param($csprojPath, $diagnostic, $RepoRoot)
            
            $csprojDir = Split-Path -Parent $csprojPath
            $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
            
            # Create temporary .editorconfig
            $editorConfigPath = Join-Path $csprojDir ".editorconfig"
            $editorConfigExisted = Test-Path $editorConfigPath
            $originalEditorConfig = $null
            
            $success = $false
            $formatted = 0
            
            try {
                # Backup existing .editorconfig if present
                if ($editorConfigExisted) {
                    $originalEditorConfig = Get-Content -Path $editorConfigPath -Raw
                }
                
                # Create .editorconfig with diagnostic severity
                $editorConfigContent = "[*.cs]`ndotnet_diagnostic.$diagnostic.severity = warning`n"
                Set-Content -Path $editorConfigPath -Value $editorConfigContent -NoNewline
                
                # Run dotnet format
                $output = & dotnet format analyzers $csprojPath --diagnostics $diagnostic --severity info --no-restore --verbosity quiet 2>&1 | Out-String
                
                if ($LASTEXITCODE -eq 0) {
                    $success = $true
                    # Check if any files were formatted
                    if ($output -match "Formatted (\d+) of") {
                        $formatted = [int]$Matches[1]
                    }
                }
            }
            catch {
                # Silently handle errors in background job
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
            
            return @{
                Success = $success
                Formatted = $formatted
                Project = $relativePath
            }
        } -ArgumentList $csproj.FullName, $diagnostic, $RepoRoot
        
        $formattingJobs += $job
    }
    
    # Wait for all jobs to complete
    Write-Host "  Waiting for $($formattingJobs.Count) formatting jobs to complete..." -ForegroundColor Gray
    $results = $formattingJobs | Wait-Job | Receive-Job
    $formattingJobs | Remove-Job
    
    # Summarize results
    $successCount = ($results | Where-Object { $_.Success }).Count
    $formattedCount = ($results | Where-Object { $_.Formatted -gt 0 }).Count
    Write-Host "  ✓ Completed: $successCount projects, $formattedCount with changes" -ForegroundColor Green
}

$stopwatch.Stop()

# Count total projects with changes across all diagnostics
$projectsWithChanges = ($allTestProjects | ForEach-Object {
    $csproj = $_
    # Check if any cs files in the project directory were modified
    $csprojDir = $csproj.Directory.FullName
    $modifiedFiles = git status --porcelain "$csprojDir/*.cs" 2>$null
    if ($modifiedFiles) { $csproj }
}).Count

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Processing Summary" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Projects processed: $($allTestProjects.Count)" -ForegroundColor White
Write-Host "  Diagnostics applied: $($DiagnosticIds.Count)" -ForegroundColor White
Write-Host "  Projects with changes: $projectsWithChanges" -ForegroundColor Green
Write-Host "  Time elapsed: $($stopwatch.Elapsed.ToString('hh\:mm\:ss'))" -ForegroundColor Yellow

# Step 4: Remove NUnit.Analyzers references
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Step 4: Removing NUnit.Analyzers References" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

$projectsAnalyzerRemoved = 0

foreach ($csproj in $allTestProjects) {
    $csprojPath = $csproj.FullName
    $relativePath = $csprojPath.Substring($RepoRoot.Length + 1)
    
    $content = Get-Content -Path $csprojPath -Raw
    
    if ($content -match '<PackageReference\s+Include="NUnit\.Analyzers"\s*/>\r?\n?') {
        $lineToRemove = $Matches[0]
        
        # Also check if there's whitespace before it
        if ($content -match '\s*<PackageReference\s+Include="NUnit\.Analyzers"\s*/>\r?\n') {
            $lineToRemove = $Matches[0]
        }
        
        Write-Host "  [REMOVE] $relativePath" -ForegroundColor Yellow
        
        $newContent = $content -replace [regex]::Escape($lineToRemove), ''
        Set-Content -Path $csprojPath -Value $newContent -NoNewline
        $projectsAnalyzerRemoved++
    }
}

Write-Host ""
Write-Host "Removed NUnit.Analyzers from $projectsAnalyzerRemoved project(s)" -ForegroundColor Green

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Migration Complete!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "1. Review the changes made to test files" -ForegroundColor White
Write-Host "2. Build the affected projects to verify no errors" -ForegroundColor White
Write-Host "3. Run tests to ensure everything still works" -ForegroundColor White
Write-Host "4. Commit the changes when ready" -ForegroundColor White
Write-Host ""
Write-Host "Diagnostics used:" -ForegroundColor Cyan
foreach ($id in $DiagnosticIds) {
    Write-Host "  - $id" -ForegroundColor Gray
}
