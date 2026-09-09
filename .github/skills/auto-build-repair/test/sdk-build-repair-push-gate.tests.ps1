#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Regression guards for the SDK Build Repair workflow's green-build push gate.

.DESCRIPTION
  Verifies that only a final structured engine result with success=true can request
  push-to-pull-request-branch, while every red-build terminal state reports without
  committing attempted changes.
#>
[CmdletBinding()]
param(
    [string]$WorkflowPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.md'),
    [string]$LockPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.lock.yml'),
    [string]$SkillPath = (Join-Path $PSScriptRoot '..' 'SKILL.md'),
    [string]$EmitterPath = (Join-Path $PSScriptRoot '..' 'emit-repair-report.ps1')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$workflow = Get-Content -Raw (Resolve-Path $WorkflowPath)
$lock = Get-Content -Raw (Resolve-Path $LockPath)
$skill = Get-Content -Raw (Resolve-Path $SkillPath)
$emitter = Get-Content -Raw (Resolve-Path $EmitterPath)

$failures = [System.Collections.Generic.List[string]]::new()
function Assert([bool]$condition, [string]$message) {
    if ($condition) {
        Write-Host "  [PASS] $message"
    }
    else {
        Write-Host "  [FAIL] $message" -ForegroundColor Red
        $script:failures.Add($message)
    }
}

Write-Host 'Source workflow'
Assert ($workflow -match '(?ms)^\s+push-to-pull-request-branch:\r?\n\s+target: "triggering"') `
    'green repairs retain the PR-branch push safe output'
Assert ($workflow -match '(?s)\*\*Gate the push on a green build\.\*\*.*final `result-<n>\.json`.*`success` property is exactly `true`') `
    'push eligibility comes from the final structured engine result'
Assert ($workflow -match '(?s)Do not infer a green build from a successful tool invocation.*exhausted iterations') `
    'tool completion and partial progress cannot be mistaken for a green build'
Assert ($workflow -match '(?s)For every other terminal state.*`maxIterations` reached.*\*\*do not invoke `push-to-pull-request-branch`\*\*') `
    'all red-build stop conditions explicitly suppress the push safe output'
Assert ($workflow -match 'attempted repair changes remain uncommitted in the ephemeral workspace and are discarded') `
    'failed repair edits are explicitly ephemeral'

Write-Host 'Checked-in skill'
Assert ($skill -match 'final structured result has `success: true`') `
    'skill permits commits only for a green final result'
Assert ($skill -match '(?s)`maxIterations` attempts are reached without a green build.*do not commit any attempted changes') `
    'iteration exhaustion cannot commit partial progress'
Assert ($skill -match 'If the build remains red for any reason, commit nothing') `
    'skill applies the no-commit rule to every failure reason'

Write-Host 'Failure report'
Assert ($emitter -match "'failed'\s+\{\s*'- Build remains red - repair changes were not committed'\s*\}") `
    'failed report states that repair changes were not committed'
Assert ($emitter -notmatch 'Partial progress committed') `
    'failed report cannot claim a partial-progress commit'

Write-Host 'Stale contract guard'
$contract = $workflow + "`n" + $skill + "`n" + $emitter
Assert ($contract -notmatch '(?i)commit progress made so far|commit progress and report') `
    'old commit-on-failure instructions are absent'

Write-Host 'Compiled workflow metadata'
$bodyMatch = [regex]::Match($workflow, '(?s)\A---\r?\n.*?\r?\n---\r?\n(?<body>.*)\z')
Assert $bodyMatch.Success 'source workflow body can be isolated'
$normalizedBody = (($bodyMatch.Groups['body'].Value -replace "`r`n", "`n").Trim())
$sha256 = [System.Security.Cryptography.SHA256]::Create()
try {
    $bodyHash = ([System.BitConverter]::ToString(
        $sha256.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($normalizedBody))
    ) -replace '-', '').ToLowerInvariant()
}
finally {
    $sha256.Dispose()
}
$metadataMatch = [regex]::Match($lock, '"body_hash":"(?<hash>[0-9a-f]{64})"')
Assert ($metadataMatch.Success -and $metadataMatch.Groups['hash'].Value -eq $bodyHash) `
    'compiled metadata hash matches the source body containing the push gate'
Assert ($lock -notmatch '(?i)commit progress made so far|commit progress and report|Partial progress committed') `
    'compiled workflow contains no stale commit-on-failure instruction'
Assert ($lock -match 'GH_AW_ACTION_FAILURE_ISSUE_EXPIRES_HOURS: "0"') `
    'disabled failure issues retain the repository-standard zero expiry'

if ($failures.Count -gt 0) {
    Write-Error "$($failures.Count) assertion(s) failed."
}

Write-Host 'All push-gate assertions passed.'
