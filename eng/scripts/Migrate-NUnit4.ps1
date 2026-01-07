<#
.SYNOPSIS
    Automates the migration of Azure.ResourceManager.* NUnit test projects from NUnit 3.x to NUnit 4.x using the constraint model.

.DESCRIPTION
    This script applies NUnit 4.x diagnostic rules to Azure.ResourceManager.* test projects in the azure-sdk-for-net repository.
    It performs the following steps:
    - Finds all Azure.ResourceManager.*.Tests.csproj files
    - Applies each NUnit diagnostic rule sequentially to the projects in parallel:
      - Creates or modifies .editorconfig for each .csproj file.
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
$DiagnosticRange = 2019..2050

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

    # Find all Azure.ResourceManager.*.Tests.csproj files
    Write-Host "Searching for Azure.ResourceManager test projects..." -ForegroundColor Cyan
    $CsprojFiles = Get-ChildItem -Path (Join-Path $RepoRoot "sdk") -Filter "*.csproj" -Recurse -File | 
        Where-Object { $_.Name -match "^Azure\.ResourceManager\..*\.Tests\.csproj$" }

    if ($CsprojFiles.Count -eq 0) {
        Write-Warning "No Azure.ResourceManager test projects found."
        exit 0
    }

    Write-Host "Found $($CsprojFiles.Count) Azure.ResourceManager test projects" -ForegroundColor Cyan
    foreach ($Csproj in $CsprojFiles) {
        Write-Host "  - $($Csproj.Name)" -ForegroundColor Gray
    }

    # Restore packages first to ensure all dependencies are available
    Write-Host "`nRestoring NuGet packages..." -ForegroundColor Cyan
    foreach ($Csproj in $CsprojFiles) {
        Write-Host "  Restoring $($Csproj.Name)..." -ForegroundColor DarkGray
        dotnet restore $Csproj.FullName --verbosity quiet
        if ($LASTEXITCODE -ne 0) {
            Write-Warning "Failed to restore $($Csproj.Name), but continuing..."
        }
    }

    # Apply each diagnostic rule sequentially
    $DiagnosticIds = $DiagnosticRange | ForEach-Object { "NUnit$_" }

    foreach ($Diagnostic in $DiagnosticIds) {
        Write-Host "`n=== Applying rule $Diagnostic ===" -ForegroundColor Cyan

        # Process all projects in parallel
        $Jobs = @()

        foreach ($Csproj in $CsprojFiles) {
            $Job = Start-Job -ScriptBlock {
                param($CsprojPath, $DiagnosticId)

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
                $result = dotnet format analyzers $CsprojPath --diagnostics $DiagnosticId --severity info --no-restore --verbosity diagnostic 2>&1
                Write-Output $result

            } -ArgumentList $Csproj.FullName, $Diagnostic

            $Jobs += $Job
        }

        # Wait for all jobs to complete
        if ($Jobs.Count -gt 0) {
            Write-Host "  Waiting for $($Jobs.Count) formatting jobs to complete..." -ForegroundColor Gray
            $Jobs | Wait-Job | Receive-Job | Write-Host -ForegroundColor Gray
            $Jobs | Remove-Job
        }

        # Clean up .editorconfig files
        Write-Host "  Cleaning up temporary .editorconfig files..." -ForegroundColor Gray
        foreach ($Csproj in $CsprojFiles) {
            $CsprojDir = Split-Path -Parent $Csproj.FullName
            $EditorConfigPath = Join-Path $CsprojDir ".editorconfig"
            if (Test-Path $EditorConfigPath) {
                Remove-Item -Path $EditorConfigPath -Force
            }
        }
    }

    Write-Host "`n=== Migration Complete ===" -ForegroundColor Green
    Write-Host "All NUnit diagnostic rules have been applied to $($CsprojFiles.Count) Azure.ResourceManager test projects." -ForegroundColor Green
    Write-Host "`nNext steps:" -ForegroundColor Cyan
    Write-Host "  1. Review the changes" -ForegroundColor White
    Write-Host "  2. Build the projects and resolve any remaining errors or warnings" -ForegroundColor White
    Write-Host "  3. Run tests to ensure everything works correctly" -ForegroundColor White
    Write-Host "  4. Stage and commit your changes" -ForegroundColor White
}
catch {
    Write-Error "An error occurred: $_"
    Write-Host "Stack trace: $($_.ScriptStackTrace)" -ForegroundColor Red
    exit 1
}