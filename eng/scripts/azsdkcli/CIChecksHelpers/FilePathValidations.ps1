#requires -version 5

<#
.SYNOPSIS
    Validates file paths for length limits and case sensitivity issues.

.DESCRIPTION
    This helper script performs two critical file path validations:
    1. Path Length Validation - Ensures file and directory paths don't exceed Windows limits
    2. Case Sensitivity Validation - Detects files that differ only by case which can cause issues across platforms
    
    The path length validation checks against Windows file system limits:
    - File paths: 260 characters maximum (including base path)
    - Directory paths: 248 characters maximum (including base path)

.PARAMETER SourceDirectory
    The directory to analyze for path length and case sensitivity issues.
    Should be an absolute path to the directory to validate.

.PARAMETER BasePathLength
    The length of the base path that will be prepended to repository paths.
    This accounts for where users might clone the repository. Defaults to 49 characters.

.OUTPUTS
    System.String[]
    Returns an array of error messages. If no errors are found, returns an empty array.
    Each error message describes a specific path validation failure.

.EXAMPLE
    $errors = .\FilePathValidations.ps1 -SourceDirectory "C:\repos\azure-sdk-for-net\sdk\storage"
    if ($errors.Count -gt 0) {
        Write-Error "Path validation failed with $($errors.Count) errors"
    }

.EXAMPLE
    $errors = .\FilePathValidations.ps1 -SourceDirectory "C:\repos\azure-sdk-for-net" -BasePathLength 60

.NOTES
    This is a helper script designed to be called by other scripts. It performs no output
    formatting or user interaction - it simply returns validation results.
    
    The case sensitivity check requires git to be available in PATH.
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage="The directory to validate for path issues")]
    [string] $SourceDirectory,

    [Parameter(HelpMessage="The base path length to account for in path calculations")]
    [int] $BasePathLength = 49
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

[string[]] $errors = @()

# Validate that source directory exists
if (-not (Test-Path $SourceDirectory)) {
    $errors += "Source directory does not exist: $SourceDirectory"
    return $errors
}

try {
    # Path Length Validation
    # File paths must be < 260 characters, directory paths must be < 248 characters
    $longFilePaths = @()
    $longDirPaths = @()
    $checkedDirs = @{}

    Get-ChildItem $SourceDirectory -Recurse -File | ForEach-Object {
        $relativePath = $_.FullName.Substring($SourceDirectory.Length).TrimStart('\', '/')
        $totalFilePathLength = $relativePath.Length + $BasePathLength
        
        if ($totalFilePathLength -gt 260) {
            $longFilePaths += $relativePath
        }
        
        # Check directory path length (only check each unique directory once)
        $dirPath = Split-Path $_.FullName -Parent
        if ($dirPath -ne $SourceDirectory) {
            $relativeDirPath = $dirPath.Substring($SourceDirectory.Length).TrimStart('\', '/')
            if (-not $checkedDirs.ContainsKey($relativeDirPath)) {
                $checkedDirs[$relativeDirPath] = $true
                $totalDirPathLength = $relativeDirPath.Length + $BasePathLength
                
                if ($totalDirPathLength -gt 248) {
                    $longDirPaths += $relativeDirPath
                }
            }
        }
    }

    if ($longFilePaths.Count -gt 0) {
        $plural = if ($longFilePaths.Count -gt 1) { "s" } else { "" }
        $errors += "With a base path length of $BasePathLength the following file path$plural exceed the allowed path length of 260 characters:"
        $longFilePaths | ForEach-Object { $errors += "  $_" }
    }

    if ($longDirPaths.Count -gt 0) {
        $plural = if ($longDirPaths.Count -gt 1) { "s" } else { "" }
        $errors += "With a base path length of $BasePathLength the following directory path$plural exceed the allowed path length of 248 characters:"
        $longDirPaths | ForEach-Object { $errors += "  $_" }
    }

    # Case Sensitivity Validation
    # Use git ls-files to get all tracked files, then group by lowercase name to find duplicates
    Push-Location $SourceDirectory
    try {
        $gitResult = & git ls-files 2>$null
        if ($LASTEXITCODE -eq 0 -and $gitResult) {
            $duplicateGroups = $gitResult | Group-Object { $_.ToLower() } | Where-Object { $_.Count -gt 1 }
            
            if ($duplicateGroups) {
                $errors += "Files that differ only by case detected (this causes issues on case-insensitive file systems):"
                foreach ($group in $duplicateGroups) {
                    $files = $group.Group -join ", "
                    $errors += "  Duplicated files: [$files]"
                }
            }
        }
        else {
            # If git ls-files fails, fall back to file system enumeration
            $allFiles = Get-ChildItem $SourceDirectory -Recurse -File | ForEach-Object {
                $_.FullName.Substring($SourceDirectory.Length).TrimStart('\', '/')
            }
            
            $duplicateGroups = $allFiles | Group-Object { $_.ToLower() } | Where-Object { $_.Count -gt 1 }
            
            if ($duplicateGroups) {
                $errors += "Files that differ only by case detected (this causes issues on case-insensitive file systems):"
                foreach ($group in $duplicateGroups) {
                    $files = $group.Group -join ", "
                    $errors += "  Duplicated files: [$files]"
                }
            }
        }
    }
    finally {
        Pop-Location
    }
}
catch {
    $errors += "File path validation failed: $($_.Exception.Message)"
}

return $errors
