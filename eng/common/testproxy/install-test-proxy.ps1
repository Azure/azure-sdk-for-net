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

. (Join-Path $PSScriptRoot '..' 'scripts' 'Helpers' 'AzSdkTool-Helpers.ps1')

Write-Host "Attempting to download and install version `"$Version`" into `"$InstallDirectory`""

$exe = Install-Standalone-Tool `
        -Version $Version `
        -FileName "test-proxy" `
        -Package "Azure.Sdk.Tools.TestProxy" `
        -Directory $InstallDirectory

Write-Host "Downloaded test-proxy available at $exe."
Write-Host "##vso[task.setvariable variable=PROXY_EXE]$exe"
