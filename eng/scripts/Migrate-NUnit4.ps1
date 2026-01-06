<#
.SYNOPSIS
    Automates the migration of NUnit test projects from NUnit 3.x to NUnit 4.x using the constraint model.

.DESCRIPTION
    This script automates the process of adding and configuring the NUnit.Analyzers package to .NET test projects
    in the azure-sdk-for-net repository. It performs the following steps:
    - Adds NUnit.Analyzers references to all .csproj files that reference NUnit.
    - Restores NuGet packages for all .sln files found in the directory.
    - Applies each diagnostic rule sequentially to the projects in parallel:
      - Checks for NUnit.Analyzers reference, and creates or modifies .editorconfig for each .csproj file.
      - Applies the formatting using dotnet format for each diagnostic.
      - Cleans up temporary .editorconfig files.

    Note: NUnit.Analyzers 4.3.0 has already been added to eng/Packages.Data.props.

.EXAMPLE
    .\Migrate-NUnit4.ps1
    Runs the migration script on the repository root.

.NOTES
    Requirements:
    - PowerShell 7.0 or later
    - Git
    - .NET SDK

    This script is specifically designed for the azure-sdk-for-net repository structure
    with centralized package management in eng/Packages.Data.props.
#>

[CmdletBinding()]
param()

$ErrorActionPreference = "Stop"

# Constants
$PackageName = "NUnit.Analyzers"
$PackageVersion = "4.3.0"
$DiagnosticRange = 2001..2050

# Find repository root (look for .git directory)
$RepoRoot = Get-Location
while ($RepoRoot -and -not (Test-Path (Join-Path $RepoRoot ".git"))) {
    $RepoRoot = Split-Path $RepoRoot -Parent
}

if (-not $RepoRoot) {
    Write-Error "Could not find repository root. Please run this script from within the azure-sdk-for-net repository."
    exit 1
}

try {
    # Change to the repository root
    Write-Host "Repository root: $RepoRoot" -ForegroundColor Cyan
    Set-Location $RepoRoot

    # Find all .csproj files that reference NUnit and add NUnit.Analyzers
    Write-Host "Searching for .csproj files that reference NUnit..." -ForegroundColor Cyan
    $CsprojFiles = Get-ChildItem -Path $RepoRoot -Filter "*.csproj" -Recurse -File

    $ProcessedCount = 0
    $SkippedCount = 0

    foreach ($Csproj in $CsprojFiles) {
        $CsprojContent = Get-Content -Path $Csproj.FullName -Raw

        # Check if the project already has NUnit.Analyzers
        if ($CsprojContent -match [regex]::Escape("<PackageReference Include=`"$PackageName`"")) {
            Write-Host "  [SKIP] $($Csproj.Name) - $PackageName already present" -ForegroundColor DarkGray
            $SkippedCount++
            continue
        }

        # Check if the project references NUnit
        if ($CsprojContent -match '<PackageReference (Include|Update)="NUnit"') {
            Write-Host "  [ADD] $($Csproj.Name) - Adding $PackageName" -ForegroundColor Green
            
            # For centralized package management, we only need to include the package without version
            $AnalyzerReference = "    <PackageReference Include=`"$PackageName`" />"
            
            # Insert after the NUnit reference
            $NUnitRefPattern = '(<PackageReference (Include|Update)="NUnit"[^/]*/>\s*)'
            $UpdatedCsprojContent = $CsprojContent -replace $NUnitRefPattern, "`$1`n$AnalyzerReference`n"
            
            Set-Content -Path $Csproj.FullName -Value $UpdatedCsprojContent -NoNewline
            $ProcessedCount++
        }
        else {
            $SkippedCount++
        }
    }

    Write-Host "`nSummary: Processed $ProcessedCount projects, Skipped $SkippedCount projects" -ForegroundColor Cyan

    # Restore NuGet packages for all .sln files
    Write-Host "`nRestoring NuGet packages..." -ForegroundColor Cyan
    $SolutionFiles = Get-ChildItem -Path $RepoRoot -Filter "*.sln" -Recurse -File

    foreach ($Solution in $SolutionFiles) {
        Write-Host "  Restoring $($Solution.Name)..." -ForegroundColor Gray
        dotnet restore $Solution.FullName --verbosity quiet
    }

    # Apply each diagnostic rule sequentially
    $DiagnosticIds = $DiagnosticRange | ForEach-Object { "NUnit$_" }

    foreach ($Diagnostic in $DiagnosticIds) {
        Write-Host "`n=== Applying rule $Diagnostic ===" -ForegroundColor Cyan

        # Process all .csproj files in parallel
        $Jobs = @()

        foreach ($Csproj in $CsprojFiles) {
            $CsprojContent = Get-Content -Path $Csproj.FullName -Raw

            # Check if the project has NUnit.Analyzers reference
            if ($CsprojContent -match [regex]::Escape("<PackageReference Include=`"$PackageName`"") -or 
                $CsprojContent -match '<PackageReference (Include|Update)="NUnit"') {
                
                $Job = Start-Job -ScriptBlock {
                    param($CsprojPath, $DiagnosticId, $PackageName)

                    $CsprojDir = Split-Path -Parent $CsprojPath
                    $EditorConfigPath = Join-Path $CsprojDir ".editorconfig"

                    # Create or update .editorconfig
                    if (-not (Test-Path $EditorConfigPath)) {
                        "[*.cs]" | Out-File -FilePath $EditorConfigPath -Encoding utf8
                    }

                    # Append diagnostic severity
                    "`ndotnet_diagnostic.$DiagnosticId.severity = warning" | Out-File -FilePath $EditorConfigPath -Append -Encoding utf8

                    # Run dotnet format
                    Write-Output "Formatting $CsprojPath with diagnostic $DiagnosticId"
                    dotnet format analyzers $CsprojPath --diagnostics $DiagnosticId --severity info --no-restore --verbosity quiet 2>&1 | Out-Null

                } -ArgumentList $Csproj.FullName, $Diagnostic, $PackageName

                $Jobs += $Job
            }
        }

        # Wait for all jobs to complete
        if ($Jobs.Count -gt 0) {
            Write-Host "  Waiting for $($Jobs.Count) formatting jobs to complete..." -ForegroundColor Gray
            $Jobs | Wait-Job | Receive-Job | Write-Host -ForegroundColor DarkGray
            $Jobs | Remove-Job
        }

        # Clean up .editorconfig files
        Write-Host "  Cleaning up temporary .editorconfig files..." -ForegroundColor Gray
        Get-ChildItem -Path $RepoRoot -Filter ".editorconfig" -Recurse -File | 
            Where-Object { $_.Directory.GetFiles("*.csproj").Count -gt 0 } |
            Remove-Item -Force
    }

    Write-Host "`n=== Migration Complete ===" -ForegroundColor Green
    Write-Host "All NUnit diagnostic rules have been applied." -ForegroundColor Green
    Write-Host "`nNext steps:" -ForegroundColor Cyan
    Write-Host "  1. Review the changes" -ForegroundColor White
    Write-Host "  2. Build the solution and resolve any remaining errors or warnings" -ForegroundColor White
    Write-Host "  3. Run tests to ensure everything works correctly" -ForegroundColor White
    Write-Host "  4. Stage and commit your changes" -ForegroundColor White
}
catch {
    Write-Error "An error occurred: $_"
    Write-Host "Stack trace: $($_.ScriptStackTrace)" -ForegroundColor Red
    exit 1
}
