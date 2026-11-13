#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param([switch]$ApiOnly)

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1')

if (!$env:AGENT_OUTPUT) {
    throw 'Missing AGENT_OUTPUT.'
}
foreach ($name in 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_UPDATED_AT', 'GH_TOKEN') {
    if (![Environment]::GetEnvironmentVariable($name)) {
        throw "Missing $name."
    }
}
$output = ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($env:AGENT_OUTPUT))
if ($ApiOnly) {
    if (!$env:PR_BASE_SHA) { throw 'Missing PR_BASE_SHA.' }
    foreach ($sha in @($env:PR_HEAD_SHA, $env:PR_BASE_SHA)) {
        if ($sha -notmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$') { throw 'Malformed PR head or base SHA.' }
    }
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1')
    $scopeInput = Get-PrReReviewPullRequestInput -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA -ApiOnly
    if ($null -eq $scopeInput -or $scopeInput.Files -isnot [array] -or $scopeInput.InlineTargets -isnot [array]) {
        throw 'Missing or malformed independently captured API scope.'
    }
    $expected = @{
        Scope = 'api'; Repository = $env:GITHUB_REPOSITORY; Number = [int]$env:PR_NUMBER
        AnalyzedHeadSha = $env:PR_HEAD_SHA; HeadSha = $scopeInput.HeadSha
        ChangedFiles = $scopeInput.PrChangedFiles; ChangedApiFiles = $scopeInput.Files.Count
        ApiFilePaths = @($scopeInput.Files | ForEach-Object { $_.filename })
        InlineTargets = $scopeInput.InlineTargets
    }
    Write-Host (Assert-PrReReviewOutput -AgentOutput $output -Expected $expected)
    Write-Host (Assert-PrReReviewReadCoverage -AgentOutput $output -MarkersPath "$env:REVIEW_INPUT_MARKERS" -SessionLogPath "$env:AGENT_SESSION_LOG" -Expected $expected)
    # The final comparison includes the base tip as well as the head: either can
    # change after the scoped inputs were captured and before publication.
    Write-Host (Assert-PrReReviewCurrentState -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA)
} else {
    $graphQLUrl = if ($env:GITHUB_GRAPHQL_URL) { $env:GITHUB_GRAPHQL_URL } else { 'https://api.github.com/graphql' }
    $expected = Get-PrReReviewTotals -Repository $env:GITHUB_REPOSITORY -Number $env:PR_NUMBER -AnalyzedHeadSha $env:PR_HEAD_SHA -Since $env:PR_UPDATED_AT -Token $env:GH_TOKEN -GraphQLUrl $graphQLUrl
    Write-Host (Assert-PrReReviewOutput -AgentOutput $output -Expected $expected)
}
