#requires -version 5

<#
.SYNOPSIS
    Runs tests for Azure SDK packages using the same logic as CI pipelines.

.DESCRIPTION
    This helper script executes unit tests for Azure SDK packages using the same command
    structure and parameters as the CI pipelines. It supports both data plane and management
    plane SDKs, with appropriate filtering and configuration for each type.
    
    The script runs tests with the same filters, loggers, and properties used in CI:
    - Excludes manually run and live tests by default
    - Uses TRX and console loggers for output
    - Configures crash and hang dumps for debugging
    - Supports code coverage collection

.PARAMETER ServiceDirectory
    The name of the service directory under the sdk folder to test (e.g., "storage", "keyvault").
    This should be a relative path from the sdk directory.

.PARAMETER RepoRoot
    The absolute path to the root directory of the azure-sdk-for-net repository.
    This is used to locate the service.proj file and set working directory.

.PARAMETER SDKType
    The type of SDK to test. Valid values are "all", "data", "mgmt", or "client".
    - "all": Tests all SDK types (default)
    - "data": Tests only data plane SDKs
    - "mgmt": Tests only management plane SDKs  
    - "client": Tests client SDKs
    Defaults to "all" if not specified.

.PARAMETER TestTargetFramework
    The target framework to use for testing (e.g., "net8.0", "net6.0").
    If not specified, uses the default framework for the projects.

.PARAMETER CollectCoverage
    Whether to collect code coverage during test execution. Defaults to false.

.PARAMETER TestTimeoutInMinutes
    Timeout in minutes for hang detection. Defaults to 60 minutes.

.PARAMETER AdditionalTestFilters
    Additional test filters to apply beyond the default exclusions.
    These are combined with the default filters using AND logic.

.OUTPUTS
    System.String[]
    Returns an array of error messages. If no errors are found, returns an empty array.
    Each error message describes a specific test execution failure.

.EXAMPLE
    $errors = .\RunTests.ps1 -ServiceDirectory "storage" -RepoRoot "C:\repos\azure-sdk-for-net"
    if ($errors.Count -gt 0) {
        Write-Error "Tests failed with $($errors.Count) errors"
    }

.EXAMPLE
    $errors = .\RunTests.ps1 -ServiceDirectory "keyvault" -RepoRoot "C:\repos\azure-sdk-for-net" -SDKType "data" -CollectCoverage $true

.NOTES
    This is a helper script designed to be called by other scripts. It performs no output
    formatting or user interaction - it simply returns test execution results.
    
    Requires .NET SDK to be installed and available in PATH.
    Test results are written to TRX files in the standard location.
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage="The service directory name under sdk/ to test")]
    [string] $ServiceDirectory,

    [Parameter(Mandatory=$true, HelpMessage="The absolute path to the repository root")]
    [string] $RepoRoot,

    [Parameter(HelpMessage="The type of SDK to test (all, data, mgmt, client)")]
    [ValidateSet("all", "data", "mgmt", "client")]
    [string] $SDKType = "all",

    [Parameter(HelpMessage="The target framework for testing")]
    [string] $TestTargetFramework,

    [Parameter(HelpMessage="Whether to collect code coverage")]
    [bool] $CollectCoverage = $false,

    [Parameter(HelpMessage="Test timeout in minutes for hang detection")]
    [int] $TestTimeoutInMinutes = 60,

    [Parameter(HelpMessage="Additional test filters beyond default exclusions")]
    [string] $AdditionalTestFilters = "TestCategory!=Disabled"
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

[string[]] $errors = @()

try {
    # Build the service project file path
    $serviceProjectPath = Join-Path $RepoRoot "eng\service.proj"
    
    if (-not (Test-Path $serviceProjectPath)) {
        $errors += "Service project file not found: $serviceProjectPath"
        return $errors
    }

    # Setup diagnostic logging if running in CI
    $debugLogging = $env:SYSTEM_DEBUG -eq "true"
    $logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
    $diagnosticArguments = @()
    
    if ($debugLogging -and $logsFolder) {
        $diagnosticArguments += "/binarylogger:$logsFolder/test.binlog"
    }

    # Build the test command arguments
    $testArgs = @(
        "test",
        $serviceProjectPath
    )

    # Test filters - exclude manual and live tests by default
    $testFilter = "`"(TestCategory!=Manually) & (TestCategory!=Live)"
    if ($AdditionalTestFilters) {
        $testFilter += " & ($AdditionalTestFilters)"
    }
    $testFilter += "`""
    
    $testArgs += @(
        "--filter", $testFilter
    )

    # Add target framework if specified
    if ($TestTargetFramework) {
        $testArgs += @("--framework", $TestTargetFramework)
        $logFileName = "$TestTargetFramework.trx"
    } else {
        $logFileName = "test-results.trx"
    }

    # Configure loggers
    $testArgs += @(
        "--logger", "`"trx;LogFileName=$logFileName`"",
        "--logger", "`"console;verbosity=normal`""
    )

    # Add crash and hang dump configuration
    $testArgs += @(
        "--blame-crash-dump-type", "full",
        "--blame-hang-dump-type", "full", 
        "--blame-hang-timeout", "${TestTimeoutInMinutes}minutes"
    )

    # MSBuild properties
    $msBuildProperties = @(
        "/p:SDKType=$SDKType",
        "/p:ServiceDirectory=$ServiceDirectory",
        "/p:IncludeSrc=false",
        "/p:IncludeSamples=false", 
        "/p:IncludePerf=false",
        "/p:IncludeStress=false",
        "/p:IncludeIntegrationTests=false",
        "/p:RunApiCompat=false",
        "/p:InheritDocEnabled=false",
        "/p:Configuration=Release",
        "/p:CollectCoverage=$($CollectCoverage.ToString().ToLower())",
        "/p:EnableSourceLink=false",
        "/p:EnableOverrideExclusions=true"
    )

    $testArgs += $msBuildProperties

    # Add diagnostic arguments if available
    if ($diagnosticArguments) {
        $testArgs += $diagnosticArguments
    }

    # Set working directory to repo root
    Push-Location $RepoRoot
    try {
        # Execute the test command
        $testResult = & dotnet @testArgs 2>&1
        if ($LASTEXITCODE -ne 0) {
            $errors += "Test execution failed with exit code $LASTEXITCODE"
            if ($testResult) {
                $errors += "Test output: $testResult"
            }
        }
    }
    finally {
        Pop-Location
    }
}
catch {
    $errors += "Test execution failed: $($_.Exception.Message)"
}

return $errors
