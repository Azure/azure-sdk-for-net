<#
.SYNOPSIS
    Reverts all modified .csproj files to their state in origin/main.

.DESCRIPTION
    This script identifies all modified .csproj files and reverts them using git checkout origin/main.
    Useful for reverting formatting changes made by the NUnit migration script.

.PARAMETER RepoRoot
    The root directory of the repository. Defaults to current directory.

.PARAMETER DryRun
    If specified, shows what would be reverted without making changes.

.EXAMPLE
    .\Revert-CsprojFiles.ps1
    Reverts all modified .csproj files.

.EXAMPLE
    .\Revert-CsprojFiles.ps1 -DryRun
    Shows which files would be reverted without making changes.
#>

[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = ".",
    
    [Parameter()]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

# Convert to absolute path
$RepoRoot = Resolve-Path $RepoRoot -ErrorAction Stop

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Revert .csproj Files Script" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Repository: $RepoRoot" -ForegroundColor Yellow
Write-Host "Dry Run: $DryRun" -ForegroundColor Yellow
Write-Host ""

# Change to repo root
Push-Location $RepoRoot

try {
    # Hardcoded list of .csproj files to revert
    $csprojFiles = @(
        "sdk/storage/Azure.Storage.Blobs/samples/Azure.Storage.Blobs.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.Blobs/tests/Azure.Storage.Blobs.Tests.csproj",
        "sdk/storage/Azure.Storage.Common/samples/Azure.Storage.Common.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.Common/tests/AesGcmTests/Azure.Storage.Common.AesGcm.Tests.csproj",
        "sdk/storage/Azure.Storage.Common/tests/Azure.Storage.Common.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Blobs/samples/Azure.Storage.DataMovement.Blobs.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Blobs/tests/Azure.Storage.DataMovement.Blobs.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement/samples/Azure.Storage.DataMovement.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement/tests/Azure.Storage.DataMovement.Tests.csproj",
        "sdk/storage/Azure.Storage.Files.DataLake/samples/Azure.Storage.Files.DataLake.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.Files.DataLake/tests/Azure.Storage.Files.DataLake.Tests.csproj",
        "sdk/storage/Azure.Storage.Files.Shares/samples/Azure.Storage.Files.Shares.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.Files.Shares/tests/Azure.Storage.Files.Shares.Tests.csproj",
        "sdk/storage/Azure.Storage.Queues/samples/Azure.Storage.Queues.Samples.Tests.csproj",
        "sdk/storage/Azure.Storage.Queues/tests/Azure.Storage.Queues.Tests.csproj",
        "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/samples/readmes/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Samples.Tests.csproj",
        "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.csproj",
        "sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSub/tests/Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests.csproj"
    )
    
    Write-Host "Found $($csprojFiles.Count) .csproj files to revert" -ForegroundColor Yellow
    Write-Host ""
    
    $revertedCount = 0
    $failedCount = 0
    
    foreach ($file in $csprojFiles) {
        if ($DryRun) {
            Write-Host "  [DRY RUN] Would revert: $file" -ForegroundColor Gray
            $revertedCount++
        }
        else {
            Write-Host "  Reverting: $file" -ForegroundColor Green
            
            try {
                git checkout origin/main -- $file
                
                if ($LASTEXITCODE -eq 0) {
                    $revertedCount++
                }
                else {
                    Write-Warning "  Failed to revert: $file (Exit code: $LASTEXITCODE)"
                    $failedCount++
                }
            }
            catch {
                Write-Warning "  Error reverting $file : $_"
                $failedCount++
            }
        }
    }
    
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host "Summary:" -ForegroundColor Cyan
    Write-Host "  Files reverted: $revertedCount" -ForegroundColor Green
    
    if ($failedCount -gt 0) {
        Write-Host "  Files failed: $failedCount" -ForegroundColor Red
    }
    
    if ($DryRun) {
        Write-Host ""
        Write-Host "DRY RUN: No files were modified" -ForegroundColor Yellow
    }
    else {
        Write-Host ""
        Write-Host "Note: Don't forget to stage the reverted files if needed." -ForegroundColor Yellow
    }
}
finally {
    Pop-Location
}
