#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Any inability to prove the baseline or the full intervening history means review, never skip.
$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewReadmeGate.psm1') -Force

function Get-GitHubJson([string]$Path) {
    $text = & gh api $Path
    if ($LASTEXITCODE -ne 0) { throw "GitHub API request failed: $Path" }
    return ConvertFrom-Json -AsHashtable ($text -join "`n")
}

function Get-CurrentPullRequest {
    $pr = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/pulls/$env:PR_NUMBER"
    if ($pr.state -cne 'open' -or $pr.draft -ne $false -or $pr.head.sha -cne $env:PR_HEAD_SHA -or
        $pr.base.sha -cne $env:PR_BASE_SHA -or $pr.base.ref -cne $env:PR_BASE_REF -or
        $pr.base.repo.full_name -cne $env:GITHUB_REPOSITORY) { throw 'The event is stale or the pull request is not open.' }
    return $pr
}

function Get-Receipt([long]$RunId) {
    $artifacts = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/actions/runs/$RunId/artifacts?per_page=100"
    if ($artifacts.total_count -gt 100 -or @($artifacts.artifacts).Count -ne $artifacts.total_count) { throw 'Incomplete artifact list.' }
    $receipts = @($artifacts.artifacts | Where-Object { $_.name -ceq 'pr-re-review-baseline-v1-attempt-1' -and !$_.expired })
    if ($receipts.Count -ne 1 -or $receipts[0].size_in_bytes -gt 100000 -or [string]$receipts[0].id -cnotmatch '^[1-9][0-9]*$') { throw 'Missing or ambiguous receipt artifact.' }
    $zipPath = Join-Path $env:RUNNER_TEMP ("pr-re-review-receipt-$([guid]::NewGuid()).zip")
    try {
        & gh api "repos/$env:GITHUB_REPOSITORY/actions/artifacts/$($receipts[0].id)/zip" > $zipPath
        if ($LASTEXITCODE -ne 0 -or (Get-Item -LiteralPath $zipPath).Length -gt 100000) { throw 'Unable to download receipt.' }
        $zip = [IO.Compression.ZipFile]::OpenRead($zipPath)
        try {
            if ($zip.Entries.Count -ne 1 -or $zip.Entries[0].FullName -cne 'receipt.json' -or $zip.Entries[0].Length -gt 8192) { throw 'Unexpected receipt archive.' }
            $reader = [IO.StreamReader]::new($zip.Entries[0].Open(), [Text.UTF8Encoding]::new($false, $true))
            try { return ConvertFrom-Json -AsHashtable $reader.ReadToEnd() } finally { $reader.Dispose() }
        } finally { $zip.Dispose() }
    } finally { Remove-Item -LiteralPath $zipPath -Force -ErrorAction SilentlyContinue }
}

function Get-WorkflowBlob([string]$RepositoryPath, [string]$Revision) {
    if ($Revision -cnotmatch '^[0-9a-f]{40}$') { throw 'Invalid revision.' }
    $value = & git -C $RepositoryPath rev-parse "$($Revision):.github/workflows/pr-re-review.lock.yml" 2>$null
    if ($LASTEXITCODE -ne 0 -or $value -cnotmatch '^[0-9a-f]{40}$') { throw 'Workflow revision is unavailable.' }
    return $value
}

$eligible = 'true'
try {
    foreach ($name in 'GITHUB_REPOSITORY', 'GITHUB_SERVER_URL', 'GITHUB_EVENT_NAME', 'GITHUB_RUN_ATTEMPT', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'PR_BASE_REF', 'GH_TOKEN', 'GITHUB_OUTPUT', 'RUNNER_TEMP', 'REVIEW_HEAD_REPOSITORY', 'REVIEW_HELPERS_REPOSITORY') {
        if (![Environment]::GetEnvironmentVariable($name)) { throw "Missing $name." }
    }
    if ($env:GITHUB_RUN_ATTEMPT -cne '1' -or $env:GITHUB_EVENT_NAME -cnotin @('pull_request', 'pull_request_target') -or $env:PR_NUMBER -cnotmatch '^[1-9][0-9]*$' -or
        $env:PR_HEAD_SHA -cnotmatch '^[0-9a-f]{40}$' -or $env:PR_BASE_SHA -cnotmatch '^[0-9a-f]{40}$') { throw 'Unsupported event.' }
    $pr = Get-CurrentPullRequest
    $repo = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY"
    # Only the repository's default branch is trusted as the base for receipts.
    if ($repo.default_branch -cne $env:PR_BASE_REF) { throw 'The PR does not target the default branch.' }
    $expectedEvent = if ($pr.head.repo.id -eq $pr.base.repo.id) { 'pull_request' } else { 'pull_request_target' }
    if ($expectedEvent -cne $env:GITHUB_EVENT_NAME) { throw 'Unexpected event routing.' }
    $head = (& git -C $env:REVIEW_HEAD_REPOSITORY rev-parse HEAD).Trim()
    if ($LASTEXITCODE -ne 0 -or $head -cne $env:PR_HEAD_SHA) { throw 'The fetched PR head is stale.' }
    $trustedCommit = (& git -C $env:REVIEW_HELPERS_REPOSITORY rev-parse HEAD).Trim()
    if ($LASTEXITCODE -ne 0) { throw 'The trusted workflow checkout is unavailable.' }
    $branch = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/commits/$([uri]::EscapeDataString($env:PR_BASE_REF))"
    if ($branch.sha -cne $trustedCommit) { throw 'The base branch moved during gate setup.' }
    $trustedBlob = Get-WorkflowBlob $env:REVIEW_HELPERS_REPOSITORY $trustedCommit
    $expected = @{ repository = $env:GITHUB_REPOSITORY; number = [int]$env:PR_NUMBER; base = $env:PR_BASE_SHA; base_tip = $trustedCommit; base_ref = $env:PR_BASE_REF; event = $expectedEvent }

    $reviews = [Collections.Generic.List[object]]::new()
    $complete = $false
    for ($page = 1; $page -le 10; $page++) {
        $batch = @(Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/pulls/$env:PR_NUMBER/reviews?per_page=100&page=$page")
        foreach ($review in $batch) { $reviews.Add($review) }
        if ($batch.Count -lt 100) { $complete = $true; break }
    }
    if (!$complete) { throw 'Review list exceeds the supported pagination limit.' }
    $prefix = '> Re-reviewed by Pull Request Re-Review: ' + $env:GITHUB_SERVER_URL.TrimEnd('/') + "/$env:GITHUB_REPOSITORY/actions/runs/"
    # Publisher identity is bound to the exact processor-verified review in the receipt.
    $candidates = @($reviews | Where-Object { $_.state -ceq 'COMMENTED' } | Sort-Object -Property id -Descending)
    $checked = 0
    foreach ($review in $candidates) {
        $line = @($review.body -split '\r?\n' | Where-Object { $_.StartsWith($prefix, [StringComparison]::Ordinal) })
        if ($line.Count -ne 1) { continue }
        $runText = $line[0].Substring($prefix.Length)
        if ($runText -cnotmatch '^[1-9][0-9]{0,18}$') { continue }
        if (++$checked -gt 20) { break }
        try {
            $runId = [long]$runText
            $run = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/actions/runs/$runId"
            if ($run.repository.full_name -cne $env:GITHUB_REPOSITORY -or $run.run_attempt -ne 1 -or $run.status -cne 'completed' -or $run.conclusion -cne 'success') { continue }
            $receipt = Get-Receipt $runId
            if ($receipt.head -cnotmatch '^[0-9a-f]{40}$' -or $receipt.head -cne $review.commit_id) { continue }
            # Same-repository pull_request workflows run the merge commit and may be PR-controlled.
            # Fork pull_request_target workflows instead run the trusted base's workflow; their
            # head can legitimately carry an older, unexecuted copy of the lock file.
            if ($expectedEvent -ceq 'pull_request' -and (Get-WorkflowBlob $env:REVIEW_HEAD_REPOSITORY $receipt.head) -cne $trustedBlob) { continue }
            $jobPage = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/actions/runs/$runId/jobs?per_page=100"
            if ($jobPage.total_count -gt 100 -or @($jobPage.jobs).Count -ne $jobPage.total_count) { continue }
            if (!(Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs @($jobPage.jobs) -Review $review -ServerUrl $env:GITHUB_SERVER_URL)) { continue }
            if (!(Test-PrReReviewReadmeOnlyChanges -RepositoryPath $env:REVIEW_HEAD_REPOSITORY -Baseline $receipt.head -Head $env:PR_HEAD_SHA)) { continue }
            $null = Get-CurrentPullRequest
            $branch = Get-GitHubJson "repos/$env:GITHUB_REPOSITORY/commits/$([uri]::EscapeDataString($env:PR_BASE_REF))"
            if ($branch.sha -cne $trustedCommit) { throw 'The base branch moved during the gate.' }
            $eligible = 'false'
            Write-Host "Skipping README-only changes since verified review $($receipt.review_id) at $($receipt.head)."
            break
        } catch { Write-Host "Could not verify candidate baseline $runText; continuing conservatively." }
    }
} catch { Write-Host "Could not prove a README-only re-review skip; running the review. $_" }
[IO.File]::AppendAllText($env:GITHUB_OUTPUT, "eligible=$eligible`n")
# The Actions pwsh wrapper propagates LASTEXITCODE even when the error was handled.
$global:LASTEXITCODE = 0
