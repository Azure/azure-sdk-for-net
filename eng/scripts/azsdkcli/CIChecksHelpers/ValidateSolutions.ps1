#requires -version 5

<#
.SYNOPSIS
    Validates that all projects referenced in Azure solution files actually exist.

.DESCRIPTION
    This helper script validates solution files in a specified Azure SDK service directory.
    It finds all Azure solution files (Azure.*.sln) and checks that every project reference
    in those solutions points to an existing project file on disk.

.PARAMETER ServiceDirectory
    The name of the service directory under the sdk folder to validate (e.g., "storage", "keyvault").
    This should be a relative path from the sdk directory.

.PARAMETER RepoRoot
    The absolute path to the root directory of the azure-sdk-for-net repository.
    This is used to construct the full path to the service directory.

.OUTPUTS
    System.String[]
    Returns an array of error messages. If no errors are found, returns an empty array.
    Each error message describes a specific validation failure.

.EXAMPLE
    $errors = .\ValidateSolutions.ps1 -ServiceDirectory "storage" -RepoRoot "C:\repos\azure-sdk-for-net"
    if ($errors.Count -gt 0) {
        Write-Error "Validation failed with $($errors.Count) errors"
    }

.NOTES
    This is a helper script designed to be called by other scripts. It performs no output
    formatting or user interaction - it simply returns validation results.
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage="The service directory name under sdk/ to validate")]
    [string] $ServiceDirectory,

    [Parameter(Mandatory=$true, HelpMessage="The absolute path to the repository root")]
    [string] $RepoRoot
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

[string[]] $errors = @()

# Validate solutions for the given service directory
$sdkPath = Join-Path $RepoRoot "sdk" $ServiceDirectory

if (-not (Test-Path $sdkPath)) {
    $errors += "Service directory does not exist: $sdkPath"
    return $errors
}

$solutionFiles = Get-ChildItem $sdkPath -Filter "Azure.*.sln" -Recurse

if ($solutionFiles.Count -eq 0) {
    # No solution files is not an error, just return empty error array
    return $errors
}

foreach ($solutionFile in $solutionFiles) {
    $slnDir = Split-Path -Parent $solutionFile
    
    try {
        $projectList = & dotnet sln $solutionFile list 2>$null
        if ($LASTEXITCODE -ne 0) {
            $errors += "Failed to list projects in solution: $solutionFile"
            continue
        }

        $projectList | Where-Object { 
            $_ -ne 'Project(s)' -and $_ -ne '----------' -and $_.Trim() -ne '' 
        } | ForEach-Object {
            $projectRelativePath = $_.Trim()
            $projectFullPath = Join-Path $slnDir $projectRelativePath
            
            if (-not (Test-Path $projectFullPath)) {
                $errors += "Missing project. Solution references a project which does not exist: $projectFullPath. [$solutionFile]"
            }
        }
    }
    catch {
        $errors += "Error processing solution file ${solutionFile}: $($_.Exception.Message)"
    }
}

return $errors
