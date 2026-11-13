#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1')

foreach ($name in 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS') {
    if (![Environment]::GetEnvironmentVariable($name)) {
        throw "Missing $name."
    }
}

$pullRequest = Get-PrReReviewPullRequestInput -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA -ApiOnly
Export-PrReReviewInput -Files $pullRequest.Files -Repository $env:GITHUB_REPOSITORY -HeadSha $pullRequest.HeadSha -MergeBaseSha "$($pullRequest.MergeBaseSha)" -InputDirectory $env:REVIEW_INPUT_DIR -MarkersPath $env:REVIEW_INPUT_MARKERS -ApiOnly -PrChangedFiles $pullRequest.PrChangedFiles -InlineTargets $pullRequest.InlineTargets
Write-Host (Assert-PrReReviewCurrentState -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA)
Write-Host "Exported $($pullRequest.Files.Count) API files at $($pullRequest.HeadSha) to $env:REVIEW_INPUT_DIR (full PR: $($pullRequest.PrChangedFiles) changed files)."

# Only publish the gate after capture, export, and the final freshness check succeeded.
if ($env:GITHUB_OUTPUT) {
    $hasApiChanges = if ($pullRequest.Files.Count -gt 0) { 'true' } else { 'false' }
    [IO.File]::AppendAllText($env:GITHUB_OUTPUT, "has_api_changes=$hasApiChanges`napi_files=$($pullRequest.Files.Count)`n")
}
if ($env:GITHUB_STEP_SUMMARY -and $pullRequest.Files.Count -eq 0) {
    [IO.File]::AppendAllText($env:GITHUB_STEP_SUMMARY, "No changed API listings; API-only review skipped. Other PR files and review threads were not reviewed by this workflow.`n")
}
