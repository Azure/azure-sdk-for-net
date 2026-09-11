# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param(
    [string] $ResourcesFile,
    [ValidateSet('net8.0', 'net9.0', 'net10.0')]
    [string] $Framework = 'net8.0',
    [string] $ResultsDirectory = (Join-Path ([IO.Path]::GetTempPath()) ('multi-tenant-results-' + [guid]::NewGuid().ToString('N')))
)

$ErrorActionPreference = 'Stop'
$previousMode = $env:AZURE_TEST_MODE
$previousResources = $env:MONITOR_MULTI_TENANT_RESOURCES
$previousLogsEndpoint = $env:MONITOR_LOGS_ENDPOINT
$previousRequired = $env:MONITOR_MULTI_TENANT_REQUIRED

try {
    if ($ResourcesFile) {
        $resources = Get-Content -LiteralPath $ResourcesFile -Raw | ConvertFrom-Json
        $env:MONITOR_MULTI_TENANT_RESOURCES = ConvertTo-Json -InputObject @($resources) -Depth 5 -Compress
    }
    if ([string]::IsNullOrWhiteSpace($env:MONITOR_LOGS_ENDPOINT)) {
        $env:MONITOR_LOGS_ENDPOINT = 'https://api.loganalytics.io'
    }
    $env:AZURE_TEST_MODE = 'Live'
    $env:MONITOR_MULTI_TENANT_REQUIRED = 'true'
    $project = Join-Path $PSScriptRoot 'Azure.Monitor.OpenTelemetry.AspNetCore.MultiTenant.Integration.Tests.csproj'
    if (Test-Path -LiteralPath $ResultsDirectory) {
        throw 'Use a new results directory so stale TRX files cannot satisfy the live-test gate.'
    }
    dotnet test $project --framework $Framework --filter 'FullyQualifiedName~MultiTenantExportLiveTests' --logger trx --results-directory $ResultsDirectory --nologo
    if ($LASTEXITCODE -ne 0) {
        throw "Multi-tenant live tests failed with exit code $LASTEXITCODE."
    }
    & (Join-Path $PSScriptRoot 'Assert-LiveTestResults.ps1') -ResultsDirectory $ResultsDirectory
}
finally {
    $env:AZURE_TEST_MODE = $previousMode
    $env:MONITOR_MULTI_TENANT_RESOURCES = $previousResources
    $env:MONITOR_LOGS_ENDPOINT = $previousLogsEndpoint
    $env:MONITOR_MULTI_TENANT_REQUIRED = $previousRequired
}