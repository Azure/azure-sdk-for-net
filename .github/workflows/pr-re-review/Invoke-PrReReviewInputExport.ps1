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

$pullRequest = Get-PrReReviewPullRequestInput -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA
Export-PrReReviewInput -Files $pullRequest.Files -Repository $env:GITHUB_REPOSITORY -HeadSha $pullRequest.HeadSha -MergeBaseSha "$($pullRequest.MergeBaseSha)" -InputDirectory $env:REVIEW_INPUT_DIR -MarkersPath $env:REVIEW_INPUT_MARKERS
Write-Host "Exported $($pullRequest.Files.Count) changed files at $($pullRequest.HeadSha) to $env:REVIEW_INPUT_DIR."
