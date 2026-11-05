#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1')

if (!$env:AGENT_OUTPUT) {
    throw 'Missing AGENT_OUTPUT.'
}
$output = ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($env:AGENT_OUTPUT))
Write-Host (Assert-PrReReviewOutput -AgentOutput $output)
Write-Host (Assert-PrReReviewReadCoverage -AgentOutput $output -MarkersPath "$env:REVIEW_INPUT_MARKERS" -SessionLogPath "$env:AGENT_SESSION_LOG")

# Thread actions may be present even when the agent reports incomplete work.
$publicationTypes = @('create_pull_request_review_comment', 'reply_to_pull_request_review_comment', 'resolve_pull_request_review_thread', 'unresolve_review_thread', 'submit_pull_request_review')
if (@($output.items | Where-Object { $publicationTypes -ccontains $_.type }).Count -gt 0) {
    foreach ($name in 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'GH_TOKEN') {
        if (![Environment]::GetEnvironmentVariable($name)) { throw "Missing $name for publication state verification." }
    }
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1')
    Write-Host (Assert-PrReReviewCurrentState -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA)
}
