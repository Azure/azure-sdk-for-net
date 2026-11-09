#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1')

$inputRoot = Join-Path $env:RUNNER_TEMP 'review-input'
$workerRoot = Join-Path $env:RUNNER_TEMP 'review-progress'
$plansJson = & node (Join-Path $PSScriptRoot 'ReviewEvidence.cjs') `
    (Join-Path $inputRoot 'snapshot.json') (Join-Path $workerRoot 'progress.json') `
    (Join-Path $inputRoot 'markers.json') $workerRoot
if ($LASTEXITCODE -ne 0) { throw 'Source-backed worker evidence validation failed.' }
$plans = ConvertFrom-PrReReviewJson ($plansJson -join "`n")
$output = ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($env:AGENT_OUTPUT))
$validationRoot = Join-Path $env:RUNNER_TEMP 'review-evidence-validation'
[void][IO.Directory]::CreateDirectory($validationRoot)
$index = 0
foreach ($plan in $plans) {
    $index++
    $markersPath = Join-Path $validationRoot "$index-markers.json"
    $sessionPath = Join-Path $validationRoot "$index-session.jsonl"
    [IO.File]::WriteAllText($markersPath, (ConvertTo-Json -InputObject @{ files = @($plan.files) } -Depth 100))
    [IO.File]::WriteAllText($sessionPath, $plan.session)
    Write-Host (Assert-PrReReviewReadCoverage -AgentOutput $output -MarkersPath $markersPath -SessionLogPath $sessionPath)
}
Write-Host "Source-backed assessments verified against shared read coverage from $($plans.Count) worker sessions."
