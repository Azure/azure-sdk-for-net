#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1')

# workflow_dispatch only replays an earlier re-review; see README.md.
$replay = $env:GITHUB_EVENT_NAME -ceq 'workflow_dispatch'
$required = if ($replay) {
    'GITHUB_REPOSITORY', 'REPLAY_PULL_REQUEST', 'REPLAY_HEAD_SHA', 'REPLAY_BASE_SHA', 'REPLAY_HISTORY_CUTOFF', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS'
} else {
    'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS'
}
foreach ($name in $required) {
    if (![Environment]::GetEnvironmentVariable($name)) {
        throw "Missing $name."
    }
}

if ($replay) {
    if ($env:REPLAY_PULL_REQUEST -cnotmatch '^[1-9][0-9]{0,9}$') {
        throw "REPLAY_PULL_REQUEST '$env:REPLAY_PULL_REQUEST' is not a pull request number."
    }
    foreach ($name in 'REPLAY_HEAD_SHA', 'REPLAY_BASE_SHA') {
        if ([Environment]::GetEnvironmentVariable($name) -cnotmatch '^[0-9a-f]{40}$') {
            throw "$name must be a full 40-character commit SHA."
        }
    }
    $cutoff = ConvertTo-PrReReviewReplayCutoff $env:REPLAY_HISTORY_CUTOFF
    $pullRequest = Get-PrReReviewReplayInput -Repository $env:GITHUB_REPOSITORY -HeadSha $env:REPLAY_HEAD_SHA -BaseSha $env:REPLAY_BASE_SHA
} else {
    $pullRequest = Get-PrReReviewPullRequestInput -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:PR_NUMBER) -ExpectedHeadSha $env:PR_HEAD_SHA -ExpectedBaseSha $env:PR_BASE_SHA
}
Export-PrReReviewInput -Files $pullRequest.Files -Repository $env:GITHUB_REPOSITORY -HeadSha $pullRequest.HeadSha -MergeBaseSha "$($pullRequest.MergeBaseSha)" -InputDirectory $env:REVIEW_INPUT_DIR -MarkersPath $env:REVIEW_INPUT_MARKERS
Write-Host "Exported $($pullRequest.Files.Count) changed files at $($pullRequest.HeadSha) to $env:REVIEW_INPUT_DIR."

if ($replay) {
    $threads = Export-PrReReviewHistory -Repository $env:GITHUB_REPOSITORY -Number ([int]$env:REPLAY_PULL_REQUEST) -HeadSha $env:REPLAY_HEAD_SHA -BaseSha $env:REPLAY_BASE_SHA -Files $pullRequest.Files -Cutoff $cutoff -InputDirectory $env:REVIEW_INPUT_DIR
    # Stored beside the markers, outside the agent's view, for the replay guard.
    $summary = [ordered]@{
        pullRequest = [int]$env:REPLAY_PULL_REQUEST
        headSha = $env:REPLAY_HEAD_SHA
        baseSha = $env:REPLAY_BASE_SHA
        mergeBaseSha = $pullRequest.MergeBaseSha
        historyCutoff = $env:REPLAY_HISTORY_CUTOFF
        changedFiles = $pullRequest.Files.Count
        threads = $threads
    }
    [IO.File]::WriteAllText((Join-Path ([IO.Path]::GetDirectoryName([IO.Path]::GetFullPath($env:REVIEW_INPUT_MARKERS))) 'replay.json'), (ConvertTo-Json -InputObject $summary))
    Write-Host "Exported the review history of #$env:REPLAY_PULL_REQUEST as of $env:REPLAY_HISTORY_CUTOFF ($threads review threads) for a replay."
}
