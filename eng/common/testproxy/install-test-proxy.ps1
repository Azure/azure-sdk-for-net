<#
.SYNOPSIS
Installs a standalone version of the test-proxy for use in tests. This function is intended to be used in CI/CD pipelines, and leaves behind
the pipeline variable PROXY_EXE which contains the path to the test-proxy executable.

.PARAMETER Version
The version of the proxy to install. Requires a full version to be provided. EG "1.0.0-dev.20240617.1"

.PARAMETER Directory
The directory within which the test-proxy exe will exist after this function invokes. Defaults to CWD.
#>
param(
    [Parameter(Mandatory = $true)]
    $Version,
    [Parameter(Mandatory = $true)]
    $InstallDirectory
)

. (Join-Path $PSScriptRoot test-proxy.ps1)

Write-Host "Attempting to download and install version `"$Version`" into `"$InstallDirectory`""

Install-Standalone-TestProxy -Version $Version -Directory $InstallDirectory

$PROXY_EXE = ""

if ($IsWindows) {
    $PROXY_EXE = Join-Path $InstallDirectory "Azure.Sdk.Tools.TestProxy.exe"
} else {
    $PROXY_EXE = Join-Path $InstallDirectory "Azure.Sdk.Tools.TestProxy"
}
Write-Host "Downloaded test-proxy available at $PROXY_EXE."
Write-Host "##vso[task.setvariable variable=PROXY_EXE]$PROXY_EXE"
