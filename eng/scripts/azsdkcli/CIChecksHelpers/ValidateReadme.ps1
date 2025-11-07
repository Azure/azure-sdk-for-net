#requires -version 5

<#
.SYNOPSIS
    Validates installation instructions in README.md files for Azure SDK packages.

.DESCRIPTION
    This helper script validates that README.md files in Azure SDK service directories follow
    the correct installation instruction conventions. It checks for proper dotnet CLI usage,
    version specification rules, and ensures installation instructions match the package's
    release status (GA vs beta) based on the corresponding CHANGELOG.md.

.PARAMETER ServiceDirectory
    The name of the service directory under the sdk folder to validate (e.g., "storage", "keyvault").
    This should be a relative path from the sdk directory.

.PARAMETER RepoRoot
    The absolute path to the root directory of the azure-sdk-for-net repository.
    This is used to construct the full path to the service directory and locate common scripts.

.OUTPUTS
    System.String[]
    Returns an array of error messages. If no errors are found, returns an empty array.
    Each error message describes a specific README validation failure.

.EXAMPLE
    $errors = .\ValidateReadme.ps1 -ServiceDirectory "storage" -RepoRoot "C:\repos\azure-sdk-for-net"
    if ($errors.Count -gt 0) {
        Write-Error "README validation failed with $($errors.Count) errors"
    }

.NOTES
    This is a helper script designed to be called by other scripts. It performs no output
    formatting or user interaction - it simply returns validation results.
    
    Requires access to Get-ChangeLogEntries function from the common scripts.
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

# Import common functions for changelog parsing
$commonScriptPath = Join-Path $RepoRoot "eng\common\scripts\common.ps1"
if (Test-Path $commonScriptPath) {
    . $commonScriptPath
}

[string[]] $errors = @()

# Validate README files for the given service directory
$sdkPath = Join-Path $RepoRoot "sdk" $ServiceDirectory

if (-not (Test-Path $sdkPath)) {
    $errors += "Service directory does not exist: $sdkPath"
    return $errors
}

$readmeFiles = Get-ChildItem $sdkPath -Filter "README.md" -Recurse

if ($readmeFiles.Count -eq 0) {
    # No README files is not an error, just return empty error array
    return $errors
}

foreach ($readmeFile in $readmeFiles) {
    $readmePath = $readmeFile.FullName
    
    try {
        $readmeContent = Get-Content $readmePath
        
        # Check for deprecated Install-Package usage
        if ($readmeContent -Match "Install-Package") {
            $errors += "README files should use dotnet CLI for installation instructions. '$readmePath'"
        }

        # Check for specific version numbers in installation instructions
        if ($readmeContent -Match "dotnet add .*--version") {
            $errors += "Specific versions should not be specified in the installation instructions in '$readmePath'. For beta versions, include the --prerelease flag."
        }

        # Validate prerelease flag usage matches package release status
        if ($readmeContent -Match "dotnet add") {
            $changelogPath = Join-Path (Split-Path -Parent $readmePath) "CHANGELOG.md"
            $hasGa = $false
            $hasRelease = $false
            
            if (Test-Path $changelogPath) {
                try {
                    $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $changelogPath
                    foreach ($key in $changeLogEntries.Keys) {
                        $entry = $changeLogEntries[$key]
                        if ($entry.ReleaseStatus -ne "(Unreleased)") {
                            $hasRelease = $true
                            if ($entry.ReleaseVersion -notmatch "beta" -and $entry.ReleaseVersion -notmatch "preview") {
                                $hasGa = $true
                                break
                            }
                        }
                    }
                }
                catch {
                    $errors += "Error parsing changelog '$changelogPath': $($_.Exception.Message)"
                    continue
                }
            }
            
            # Validate installation instructions match release status
            if ($hasGa) {
                if (-Not ($readmeContent -Match "dotnet add (?!.*--prerelease)")) {
                    $errors += "No GA installation instructions found in '$readmePath' but there was a GA entry in the Changelog '$changelogPath'. Ensure that there are installation instructions that do not contain the --prerelease flag. You may also include instructions for installing a beta that does include the --prerelease flag."
                }
            }
            elseif ($hasRelease) {
                if (-Not ($readmeContent -Match "dotnet add .*--prerelease$")) {
                    $errors += "No beta installation instructions found in '$readmePath' but there was a beta entry in the Changelog '$changelogPath'. Ensure that there are installation instructions that contain the --prerelease flag."
                }
            }
        }
    }
    catch {
        $errors += "Error processing README file ${readmePath}: $($_.Exception.Message)"
    }
}

return $errors
