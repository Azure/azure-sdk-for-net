#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1')

foreach ($name in 'REVIEW_REPLAY', 'REVIEW_REPLAY_RESULT') {
    if (![Environment]::GetEnvironmentVariable($name)) {
        throw "Missing $name."
    }
}
$replay = ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($env:REVIEW_REPLAY))
$output = if ($env:AGENT_OUTPUT -and [IO.File]::Exists($env:AGENT_OUTPUT)) { ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($env:AGENT_OUTPUT)) } else { $null }
$result = Get-PrReReviewReplayResult -AgentOutput $output -Replay $replay -MarkersPath "$env:REVIEW_INPUT_MARKERS" -SessionLogPath "$env:AGENT_SESSION_LOG"
[void][IO.Directory]::CreateDirectory([IO.Path]::GetDirectoryName([IO.Path]::GetFullPath($env:REVIEW_REPLAY_RESULT)))
[IO.File]::WriteAllText($env:REVIEW_REPLAY_RESULT, (ConvertTo-Json -InputObject $result -Depth 20))

function Format-Cell([string]$Text) { ($Text -replace '\r?\n', ' ' -replace '\|', '\|' -replace '`', "'") }
$counts = @($result.items | Group-Object { $_.type } | ForEach-Object { "$($_.Name) $($_.Count)" }) -join ', '
$summary = @(
    "## Replay of #$($result.pullRequest) at $($result.headSha)"
    ''
    "History cutoff $($result.historyCutoff). Outcome: **$($result.outcome)**. Agent output: $(if ($counts) { $counts } else { 'none' })."
    ''
    '| Check | Passed | Detail |'
    '| --- | --- | --- |'
    "| Coverage line | $($result.coverage.passed) | $(Format-Cell $result.coverage.message) |"
    "| Read coverage | $($result.readCoverage.passed) | $(Format-Cell $result.readCoverage.message) |"
    "| No reads of the current pull request | $(!$result.contaminated) | $($result.contamination.Count) found |"
) + @($result.contamination | Select-Object -First 20 | ForEach-Object { "- $(Format-Cell ($_.Substring(0, [Math]::Min(300, $_.Length))))" })
if ($env:GITHUB_STEP_SUMMARY) {
    Add-Content -LiteralPath $env:GITHUB_STEP_SUMMARY -Value ($summary -join "`n")
}
Write-Host ($summary -join "`n")
throw "A replay never publishes. Outcome: $($result.outcome)$(if ($result.contaminated) { ', contaminated' }). The result is in the pr-re-review-replay artifact."
