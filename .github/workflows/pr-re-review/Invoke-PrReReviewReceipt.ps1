#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewReadmeGate.psm1') -Force

foreach ($name in 'GITHUB_REPOSITORY', 'GITHUB_SERVER_URL', 'GITHUB_RUN_ID', 'GITHUB_RUN_ATTEMPT', 'GITHUB_EVENT_NAME', 'WORKFLOW_SHA', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'PR_BASE_REF', 'GH_TOKEN', 'REVIEW_ITEMS', 'RECEIPT_PATH') {
    if (![Environment]::GetEnvironmentVariable($name)) { throw "Missing $name." }
}
$context = @{
    Repository = $env:GITHUB_REPOSITORY; Number = [int]$env:PR_NUMBER; Head = $env:PR_HEAD_SHA
    Base = $env:PR_BASE_SHA; BaseRef = $env:PR_BASE_REF; BaseTip = ''; WorkflowSha = $env:WORKFLOW_SHA; RunId = [long]$env:GITHUB_RUN_ID
    Attempt = [int]$env:GITHUB_RUN_ATTEMPT; Event = $env:GITHUB_EVENT_NAME
}
$items = @([IO.File]::ReadAllLines($env:REVIEW_ITEMS) | Where-Object { $_.Trim() } | ForEach-Object { ConvertFrom-Json -AsHashtable $_ })
$processed = @($items | Where-Object { $_.type -ceq 'submit_pull_request_review' })
if ($processed.Count -ne 1 -or [string]$processed[0].id -cnotmatch '^[1-9][0-9]*$') { throw 'No unique processed review.' }

function Get-GitHubJson([string]$Path) {
    $text = & gh api $Path
    if ($LASTEXITCODE -ne 0) { throw "GitHub API request failed: $Path" }
    return ConvertFrom-Json -AsHashtable ($text -join "`n")
}

$context.BaseTip = (& git rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or $context.BaseTip -cnotmatch '^[0-9a-f]{40}$') { throw 'Trusted base tip is unavailable.' }
$branch = Get-GitHubJson "repos/$($context.Repository)/commits/$([uri]::EscapeDataString($context.BaseRef))"
if ($branch.sha -cne $context.BaseTip) { throw 'The base branch moved during publication.' }
$prefix = "repos/$($context.Repository)/pulls/$($context.Number)"
$pr = Get-GitHubJson $prefix
if ($pr.state -cne 'open' -or $pr.draft -ne $false -or $pr.head.sha -cne $context.Head -or
    $pr.base.sha -cne $context.Base -or $pr.base.ref -cne $context.BaseRef -or
    $pr.base.repo.full_name -cne $context.Repository) { throw 'The PR no longer matches the reviewed state.' }
$review = Get-GitHubJson "$prefix/reviews/$($processed[0].id)"
$receipt = New-PrReReviewReceipt -Context $context -Items $items -Review $review -ServerUrl $env:GITHUB_SERVER_URL
$branch = Get-GitHubJson "repos/$($context.Repository)/commits/$([uri]::EscapeDataString($context.BaseRef))"
if ($branch.sha -cne $context.BaseTip) { throw 'The base branch moved before recording the receipt.' }
[IO.File]::WriteAllText($env:RECEIPT_PATH, (ConvertTo-Json -Compress $receipt), [Text.UTF8Encoding]::new($false))
