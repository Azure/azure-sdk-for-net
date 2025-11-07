#requires -version 5

<#
.SYNOPSIS
    Builds and generates client code for Azure SDK packages.

.DESCRIPTION
    This helper script performs the build and code generation steps for Azure SDK packages.
    It restores Node.js dependencies, initializes the .NET tooling, and regenerates client
    code from specifications using the dotnet msbuild GenerateCode target.

.PARAMETER ServiceDirectory
    The name of the service directory under the sdk folder to build (e.g., "storage", "keyvault").
    This should be a relative path from the sdk directory.

.PARAMETER RepoRoot
    The absolute path to the root directory of the azure-sdk-for-net repository.
    This is used to restore npm packages and locate build files.

.PARAMETER SDKType
    The type of SDK to generate. Valid values are "all", "data", or "mgmt".
    Defaults to "all" if not specified.

.OUTPUTS
    System.String[]
    Returns an array of error messages. If no errors are found, returns an empty array.
    Each error message describes a specific build or generation failure.

.EXAMPLE
    $errors = .\BuildAndGenerateClients.ps1 -ServiceDirectory "storage" -RepoRoot "C:\repos\azure-sdk-for-net"
    if ($errors.Count -gt 0) {
        Write-Error "Build failed with $($errors.Count) errors"
    }

.EXAMPLE
    $errors = .\BuildAndGenerateClients.ps1 -ServiceDirectory "keyvault" -RepoRoot "C:\repos\azure-sdk-for-net" -SDKType "data"

.NOTES
    This is a helper script designed to be called by other scripts. It performs no output
    formatting or user interaction - it simply returns build results.
    
    Requires Node.js and .NET SDK to be installed and available in PATH.
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage="The service directory name under sdk/ to build")]
    [string] $ServiceDirectory,

    [Parameter(Mandatory=$true, HelpMessage="The absolute path to the repository root")]
    [string] $RepoRoot,

    [Parameter(HelpMessage="The type of SDK to generate (all, data, mgmt)")]
    [string] $SDKType = "all"
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

[string[]] $errors = @()

try {
    # Restore Node.js dependencies
    $npmResult = & npm ci --prefix $RepoRoot 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errors += "Failed to restore npm packages: $npmResult"
        return $errors
    }

    # Force .NET Welcome experience to initialize tooling
    $dotnetResult = & dotnet msbuild -version 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errors += "Failed to initialize .NET tooling: $dotnetResult"
        return $errors
    }

    # Setup diagnostic logging if running in CI
    $debugLogging = $env:SYSTEM_DEBUG -eq "true"
    $logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
    $diagnosticArguments = @()
    
    if ($debugLogging -and $logsFolder) {
        $diagnosticArguments += "/binarylogger:$logsFolder/generatecode.binlog"
    }

    # Build the service project file path
    $serviceProjectPath = Join-Path $RepoRoot "eng\service.proj"
    
    if (-not (Test-Path $serviceProjectPath)) {
        $errors += "Service project file not found: $serviceProjectPath"
        return $errors
    }

    # Generate client code
    $msbuildArgs = @(
        $serviceProjectPath,
        "/restore",
        "/t:GenerateCode",
        "/p:SDKType=$SDKType",
        "/p:ServiceDirectory=$ServiceDirectory",
        "/p:ProjectListOverrideFile="
    )
    
    if ($diagnosticArguments) {
        $msbuildArgs += $diagnosticArguments
    }

    $generateResult = & dotnet msbuild @msbuildArgs 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errors += "Failed to generate client code: $generateResult"
        return $errors
    }
}
catch {
    $errors += "Build and generate clients failed: $($_.Exception.Message)"
}

return $errors
