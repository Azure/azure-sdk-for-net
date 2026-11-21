# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $ManifestPath,
    [Parameter(Mandatory)] [string] $ResultsRoot
)

$ErrorActionPreference = 'Stop'
$manifest = Get-Content -LiteralPath $ManifestPath -Raw | ConvertFrom-Json
$expected = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
foreach ($test in $manifest.selectedTests) {
    if ([string]::IsNullOrWhiteSpace($test.fullName) -or -not $expected.Add($test.fullName)) {
        throw 'Assignment manifest must contain unique nonempty test IDs.'
    }
}
if ($expected.Count -eq 0) { throw 'Assignment manifest is empty.' }
$seen = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
$files = @(Get-ChildItem -LiteralPath $ResultsRoot -Recurse -Filter '*.trx' -File)
if ($files.Count -eq 0) { throw 'No TRX results were produced for the assigned samples.' }
foreach ($file in $files) {
    [xml] $document = Get-Content -LiteralPath $file.FullName -Raw
    $definitions = @{}
    foreach ($definition in $document.TestRun.TestDefinitions.UnitTest) {
        if ($null -ne $definition) {
            $definitions[[string] $definition.id] = "$($definition.TestMethod.className).$($definition.name)"
        }
    }
    foreach ($result in $document.TestRun.Results.UnitTestResult) {
        if ($null -eq $result) { continue }
        $name = $definitions[[string] $result.testId]
        if ([string]::IsNullOrWhiteSpace($name) -or -not $expected.Contains($name)) {
            throw "TRX contains an unassigned sample: $name"
        }
        if (-not $seen.Add($name)) { throw "Assigned sample ran more than once: $name" }
        if ($result.outcome -cne 'Passed') { throw "Assigned sample did not pass: $name ($($result.outcome))" }
    }
}
if (-not $seen.SetEquals($expected)) {
    $missing = @($expected | Where-Object { -not $seen.Contains($_) })
    throw "Assigned samples did not execute: $($missing -join ', ')"
}
Write-Host "Verified all $($expected.Count) assigned samples passed exactly once."
