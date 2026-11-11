#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Trusted publication entry point: validate agent output against current PR totals.
[CmdletBinding()]
param()

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
$graphQLUrl = if ($env:GITHUB_GRAPHQL_URL) { $env:GITHUB_GRAPHQL_URL } else { 'https://api.github.com/graphql' }
$expected = Get-PrReReviewTotals -Repository $env:GITHUB_REPOSITORY -Number $env:PR_NUMBER -AnalyzedHeadSha $env:PR_HEAD_SHA -Since $env:PR_UPDATED_AT -Token $env:GH_TOKEN -GraphQLUrl $graphQLUrl
Write-Host (Assert-PrReReviewOutput -AgentOutput $output -Expected $expected)
