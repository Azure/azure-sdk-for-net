# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $ResultsDirectory
)

$ErrorActionPreference = 'Stop'
$requiredScenarios = @(
    'RoutesTracesAndLogsToTheirOwnResources',
    'ReplaysTracesAndLogsAfterOneEndpointRecovers'
)
$results = @(Get-ChildItem -LiteralPath $ResultsDirectory -Filter '*.trx' -Recurse | ForEach-Object {
    [xml] $document = Get-Content -LiteralPath $_.FullName -Raw
    $requiredIds = @($document.SelectNodes('//*[local-name()="UnitTest"]') | Where-Object {
        $_.TestMethod.className -eq 'Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.MultiTenantExportLiveTests(False)'
    } | ForEach-Object { $_.id })
    $document.SelectNodes('//*[local-name()="UnitTestResult"]') | Where-Object { $_.testId -in $requiredIds }
})
foreach ($scenario in $requiredScenarios) {
    $matches = @($results | Where-Object { $_.testName -match "(^|\.)$scenario(\(|$)" })
    if ($matches.Count -eq 0 -or @($matches | Where-Object { $_.outcome -ne 'Passed' }).Count -gt 0) {
        throw "Required live scenario did not pass or was not executed: $scenario."
    }
}
Write-Host 'Both required multi-tenant live scenarios passed.'